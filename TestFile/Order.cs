using System;

namespace TestFile
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public string OrderLineNumber { get; set; }
        public int ProductNumber { get; set; }
        public double Quantity { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string ProductGroup { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public int CustomerNumber { get; set; }
    }
}
