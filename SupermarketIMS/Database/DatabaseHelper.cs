using System;
using Microsoft.Data.SqlClient;


namespace SupermarketIMS.Database
{
    public class DatabaseHelper
    {
        //Connect to the sql server
        private static string connectionString = @"Server=KARIS\SQLEXPRESS;Database=supermarketDB;Integrated Security=True;Encrypt=False;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString); //Return a sql connection
        }

        public static bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    Console.WriteLine("✅ Connection Successful!");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Connection Failed: " + ex.Message);
                return false;
            }
        }
    }
}






