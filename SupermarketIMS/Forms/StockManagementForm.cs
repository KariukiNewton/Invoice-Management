using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SupermarketIMS.Database;
using SupermarketIMS.Models;

namespace SupermarketIMS.Forms
{
    public partial class StockManagementForm : Form
    {
        private StockRepository stockRepo;

        public StockManagementForm()
        {
            InitializeComponent();
            stockRepo = new StockRepository();
            LoadProducts();
        }

        private void LoadProducts()
        {
            List<Product> products = stockRepo.GetProducts();
            dataGridViewProducts.DataSource = products; // Load products into DataGridView
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            string name = txtProductName.Text;

            // Validate Quantity
            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity < 0)
            {
                MessageBox.Show("Invalid quantity! Please enter a valid positive number.");
                return;
            }

            // Validate Price
            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Invalid price! Please enter a valid positive number.");
                return;
            }

            // Add product to database
            stockRepo.AddProduct(name, quantity, price);
            MessageBox.Show("Product Added!");

            // Refresh DataGridView
            LoadProducts();
        }


        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count > 0)
            {
                int productId = Convert.ToInt32(dataGridViewProducts.SelectedRows[0].Cells["ProductID"].Value);
                stockRepo.DeleteProduct(productId);
                MessageBox.Show("Product Deleted!");
                LoadProducts();
            }
        }
    }
}
