using System;
using System.Windows.Forms;


namespace SupermarketIMS
{
    partial class MainForm
    {
        private Button btnStockManagement;
        private Button btnCheckout;
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "Supermarket Inventory Management System";

            // Label
            Label lblTitle = new Label();
            lblTitle.Text = "Welcome!";
            lblTitle.Location = new System.Drawing.Point(20, 50);
            this.Controls.Add(lblTitle);

            //Button to open StockManagement Form
            btnStockManagement = new Button();
            btnStockManagement.Text = "Manage Stock";
            btnStockManagement.Location = new System.Drawing.Point(20, 100);
            btnStockManagement.Click += new EventHandler(this.BtnStockManagement_Click);
            this.Controls.Add(btnStockManagement);

            //Checkout Button
            btnCheckout = new Button();
            btnCheckout.Text = "CheckOut";
            btnCheckout.Location = new System.Drawing.Point(20, 150);
            btnCheckout.Click += new EventHandler(this.BtnCheckout_Click);
            this.Controls.Add(btnCheckout);


            this.ResumeLayout(false);
        }

    }
}
