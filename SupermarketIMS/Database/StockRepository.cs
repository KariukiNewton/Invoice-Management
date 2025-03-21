using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using SupermarketIMS.Models;

namespace SupermarketIMS.Database
{
    public class StockRepository
    {
        // Get all products
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        ProductID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Quantity = reader.GetInt32(2),
                        Price = reader.GetDecimal(3)
                    });
                }
            }
            return products;
        }

        // Add a product to the database
        public void AddProduct(string name, int quantity, decimal price)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Products (Name, Quantity, Price) VALUES (@Name, @Quantity, @Price)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.ExecuteNonQuery();
            }
        }

        // Delete a product by ProductID
        public void DeleteProduct(int productId)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Products WHERE ProductID = @ProductID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProductID", productId);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateStock(List<CartItem> cartItems)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                foreach (var item in cartItems)
                {
                    string query = "UPDATE Products SET Quantity = Quantity - @Quantity WHERE ProductID = @ProductID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                    cmd.Parameters.AddWithValue("@ProductID", item.Product.ProductID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
