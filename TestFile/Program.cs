using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestFile
{

    class Program
    {
        public static List<Order> orders = new List<Order>();
        //|OrderNumber|OrderLineNumber|ProductNumber|Quantity|Name|Description|Price|ProductGroup|OrderDate|CustomerName|CustomerNumber|
        public static int orderNumber = 0;
        public static int orderLineNumber = 0;
        public static int productNumber = 0;
        public static int quanitity = 0;
        public static int name = 0;
        public static int descrption = 0;
        public static int price = 0;
        public static int productGroup = 0;
        public static int orderDate = 0;
        public static int customerName = 0;
        public static int customerNumber = 0;

        static void Main(string[] args)
        {
            var orderReader = new OrderCSVReader();
            var filePath = Path.Combine(
                                    Environment.CurrentDirectory,
                                    "order.csv"
                           );
            var orders = orderReader.ReadFromFile(filePath);
            foreach (var item in orders)
            {
                Console.WriteLine($"{item.OrderNumber} {item.OrderLineNumber}");
            }
        }
    }
}