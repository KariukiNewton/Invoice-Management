using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SupermarketIMS.Database;
using SupermarketIMS.Models;

namespace SupermarketIMS.Forms
{
    public partial class CheckoutForm : Form
    {
        private StockRepository stockRepo;
        private InvoiceRepository invoiceRepo;
        private List<CartItem> cartItems;

        public CheckoutForm()
        {
            InitializeComponent();
            stockRepo = new StockRepository();
            invoiceRepo = new InvoiceRepository();
            cartItems = new List<CartItem>();
            LoadProducts();
        }

        private void LoadProducts()
        {
            List<Product> products = stockRepo.GetProducts();
            comboProducts.DataSource = products;
            comboProducts.DisplayMember = "Name";
            comboProducts.ValueMember = "ProductID";
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (comboProducts.SelectedItem != null && int.TryParse(txtQuantity.Text, out int quantity))
            {
                Product selectedProduct = (Product)comboProducts.SelectedItem;
                decimal totalPrice = selectedProduct.Price * quantity;

                cartItems.Add(new CartItem { Product = selectedProduct, Quantity = quantity, TotalPrice = totalPrice });

                UpdateCart();
            }
        }

        private void UpdateCart()
        {
            dataGridViewCart.DataSource = null;
            dataGridViewCart.DataSource = cartItems;
            lblTotalAmount.Text = "Total: Ksh" + CalculateTotal().ToString("0.00");
        }

        private decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (var item in cartItems)
            {
                total += item.TotalPrice;
            }
            return total;
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (cartItems.Count > 0)
            {
                decimal totalAmount = CalculateTotal();

                // Ensure payment method is selected before proceeding
                if (comboPaymentMethod.SelectedItem == null)
                {
                    MessageBox.Show("Please select a payment method.");
                    return; // Stop execution if no payment method is selected
                }

                string paymentMethod = comboPaymentMethod.SelectedItem?.ToString() ?? string.Empty;

                // Check again if paymentMethod is empty (should not happen but for safety)
                if (string.IsNullOrEmpty(paymentMethod))
                {
                    MessageBox.Show("Invalid payment method.");
                    return;
                }

                invoiceRepo.CreateInvoice(cartItems, totalAmount, paymentMethod);
                MessageBox.Show("Invoice Generated!");

                stockRepo.UpdateStock(cartItems); // Deduct stock
                cartItems.Clear();
                UpdateCart();
            }
        }

    }
}
