using System;
using System.Data;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using SupermarketIMS.Models;

namespace SupermarketIMS.Database
{
    public class InvoiceRepository
    {
        public void CreateInvoice(List<CartItem> cartItems, decimal totalAmount, string paymentMethod)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Invoices (TotalAmount, Date) VALUES (@total, @date); SELECT SCOPE_IDENTITY();", conn);
                cmd.Parameters.AddWithValue("@total", totalAmount);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);

                int invoiceId = Convert.ToInt32(cmd.ExecuteScalar());

                foreach (var item in cartItems)
                {
                    SqlCommand cmdItem = new SqlCommand("INSERT INTO InvoiceDetails (InvoiceID, ProductID, Quantity, Subtotal) VALUES (@invoice, @product, @quantity, @subtotal)", conn);
                    cmdItem.Parameters.AddWithValue("@invoice", invoiceId);
                    cmdItem.Parameters.AddWithValue("@product", item.Product.ProductID);
                    cmdItem.Parameters.AddWithValue("@quantity", item.Quantity);
                    cmdItem.Parameters.AddWithValue("@subtotal", item.TotalPrice); // Renamed to match database column
                    cmdItem.ExecuteNonQuery();

                }
            }
        }

        // ✅ View All Invoices (New Function)
        public DataTable GetAllInvoices()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT 
                        d.InvoiceID, 
                        d.ProductID, 
                        d.Quantity, 
                        d.SubTotal 
                    FROM InvoiceDetails d
                    ORDER BY d.InvoiceID DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
    }
}
