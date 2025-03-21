using System;
using System.Windows.Forms;

namespace SupermarketIMS.Forms
{
    partial class StockManagementForm
    {
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblPrice;



        private void InitializeComponent()
        {
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Name = "Manage Inventory";
            this.Text = "Manage Inventory";


            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();

            // DataGridView
            this.dataGridViewProducts.Location = new System.Drawing.Point(20, 150);
            this.dataGridViewProducts.Size = new System.Drawing.Size(400, 200);

            // Labels
            this.lblName.Text = "Name:";
            this.lblName.Location = new System.Drawing.Point(20, 20);
            this.lblQuantity.Text = "Quantity:";
            this.lblQuantity.Location = new System.Drawing.Point(20, 50);
            this.lblPrice.Text = "Price:";
            this.lblPrice.Location = new System.Drawing.Point(20, 80);

            // TextBoxes
            this.txtProductName.Location = new System.Drawing.Point(150, 20);
            this.txtQuantity.Location = new System.Drawing.Point(150, 50);
            this.txtPrice.Location = new System.Drawing.Point(150, 80);

            // Buttons
            this.btnAddProduct.Text = "Add Product";
            this.btnAddProduct.Location = new System.Drawing.Point(250, 20);
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);

            this.btnDeleteProduct.Text = "Delete Selected";
            this.btnDeleteProduct.Location = new System.Drawing.Point(250, 50);
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);


            // Add controls
            this.Controls.Add(this.dataGridViewProducts);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.btnDeleteProduct);


        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
