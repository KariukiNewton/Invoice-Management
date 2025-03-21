using System;
using System.Windows.Forms;
using SupermarketIMS.Database;

namespace SupermarketIMS
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ✅ Test the database connection before running the app
            if (DatabaseHelper.TestConnection())
            {
                Application.Run(new MainForm());  // Open MainForm if connection is OK
            }
            else
            {
                MessageBox.Show("Database connection failed. Please check the connection settings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
