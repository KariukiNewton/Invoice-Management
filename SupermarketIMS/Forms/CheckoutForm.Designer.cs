namespace SupermarketIMS.Forms
{
    partial class CheckoutForm
    {
        private System.Windows.Forms.ComboBox comboProducts;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.DataGridView dataGridViewCart;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.ComboBox comboPaymentMethod;

        private void InitializeComponent()
        {
            this.comboProducts = new System.Windows.Forms.ComboBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.dataGridViewCart = new System.Windows.Forms.DataGridView();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.comboPaymentMethod = new System.Windows.Forms.ComboBox();

            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Name = "Checkout Form";
            this.Text = "Checkout Form";

            // Combo Box for Products
            this.comboProducts.Location = new System.Drawing.Point(20, 20);
            this.comboProducts.Size = new System.Drawing.Size(200, 25);

            // Quantity Input
            this.txtQuantity.Location = new System.Drawing.Point(230, 20);
            this.txtQuantity.Size = new System.Drawing.Size(100, 25);

            // Cart DataGridView
            this.dataGridViewCart.Location = new System.Drawing.Point(20, 60);
            this.dataGridViewCart.Size = new System.Drawing.Size(400, 200);

            // Buttons
            this.btnAddToCart.Text = "Add to Cart";
            this.btnAddToCart.Location = new System.Drawing.Point(350, 20);
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);

            this.btnCheckout.Text = "Checkout";
            this.btnCheckout.Location = new System.Drawing.Point(300, 280);
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);

            // Total Amount Label
            this.lblTotalAmount.Text = "Total: $0.00";
            this.lblTotalAmount.Location = new System.Drawing.Point(20, 280);
            this.lblTotalAmount.Size = new System.Drawing.Size(200, 25);

            // Payment Method Dropdown
            this.comboPaymentMethod.Items.AddRange(new string[] { "Cash", "Card" });
            this.comboPaymentMethod.Location = new System.Drawing.Point(20, 310);
            this.comboPaymentMethod.Size = new System.Drawing.Size(200, 25);

            // Add controls
            this.Controls.Add(this.comboProducts);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.dataGridViewCart);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.btnCheckout);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.comboPaymentMethod);
        }
    }
}
