using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TestFile
{
    public class OrderCSVReader
        : ICSVReader<Order>
    {
        public List<Order> ReadFromFile(string path)
        {
            var orders = new List<Order>();
            //Load the file
            var allLines = File
                            .ReadAllLines(path)
                            .ToList();

            //headers
            // to fixing a colum 

            var headers = allLines[0]
                                .Split('|')
                                .Skip(1)
                                .SkipLast(1)
                                .Where(l => !string.IsNullOrWhiteSpace(l))
                                .ToList();

            var lines = allLines.Skip(1).ToList();
            //Parse each Line

            foreach (var line in lines)
            {
                var cols = line
                                .Split('|')
                                .Skip(1)
                                .SkipLast(1)
                                .ToList();

                var order = new Order();

                var properties = order.GetType().GetRuntimeProperties().ToList();

                for (var i = 0; i < properties.Count; i++)
                {
                    var p = properties[i];
                    if (p.Name.Equals(headers[i])
                     && cols != null
                     && cols.Count >= i
                    )
                    {
                        var value = cols[i];
                        if (value == null
                         || string.IsNullOrWhiteSpace(value)
                        )
                            p.SetValue(order, null);
                        else
                        {                            
                            if (int.TryParse(value, out var valInt))
                                p.SetValue(
                                    order,
                                    valInt
                                );
                            else if (double.TryParse(value, out var valDouble))
                                p.SetValue(
                                    order,
                                    valDouble
                                );
                            else if (decimal.TryParse(value, out var valDecimal))
                                p.SetValue(
                                    order,
                                    valDecimal
                                ); 
                            else if (value is string valStr)
                                p.SetValue(
                                    order,
                                    valStr
                                );
                        }
                    }
                }

                orders.Add(order);
            }
            return orders;
        }
    }
}