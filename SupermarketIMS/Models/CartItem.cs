namespace SupermarketIMS.Models
{
    public class CartItem
    {
        public required Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
