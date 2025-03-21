namespace SupermarketIMS.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
