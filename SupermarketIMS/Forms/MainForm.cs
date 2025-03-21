using System;
using System.Windows.Forms;
using SupermarketIMS.Forms;

namespace SupermarketIMS
{
    public partial class MainForm : Form  // ✅ "partial" keyword required
    {
        public MainForm()
        {
            InitializeComponent();  // ✅ Call Designer file
        }

        public void BtnStockManagement_Click(object sender, EventArgs e)
        {
            StockManagementForm stockForm = new StockManagementForm();
            stockForm.Show();
        }

        public void BtnCheckout_Click(object sender, EventArgs e)
        {
            CheckoutForm checkoutForm = new CheckoutForm();
            checkoutForm.Show();
        }

        public void BtnViewInvoices_Click(object sender, EventArgs e)
        {
            ReportsForm reportsForm = new ReportsForm();
            reportsForm.Show();
        }
    }
}
