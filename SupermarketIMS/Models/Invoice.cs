using System;

namespace SupermarketIMS.Models
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime InvoiceDate { get; set; }
    }
}
