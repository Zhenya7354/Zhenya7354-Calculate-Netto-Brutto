using System.Globalization;

namespace Lab_1._IO.Models
{
    public class Product
    {
        public string Title { get; set; }
        public int Quantity { get; set; }

        public decimal UnitNettoPrice { get; set; }
        public decimal VAT { get; set;}
        public decimal IndividualDiscount { get; set;}
        public decimal QuantityDiscount { get; set;}
        public bool IsRetailCustomer { get; set;}
    }
}
