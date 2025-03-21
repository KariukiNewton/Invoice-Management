using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing; // ✅ Import for PrintDocument
using System.Windows.Forms;
using SupermarketIMS.Database;

namespace SupermarketIMS
{
    public partial class ReportsForm : Form
    {
        private InvoiceRepository invoiceRepo;
        private DataTable invoicesTable = new DataTable();


        public ReportsForm()
        {
            InitializeComponent(); // ✅ Ensure this is generated in Designer.cs
            invoiceRepo = new InvoiceRepository();
            LoadInvoices();
        }

        private void LoadInvoices()
        {
            invoicesTable = invoiceRepo.GetAllInvoices();
            dataGridViewInvoices.DataSource = invoicesTable; // ✅ Ensure this control exists
        }

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            if (dataGridViewInvoices.SelectedRows.Count > 0)
            {
                // ✅ Retrieve selected InvoiceID
                int invoiceId = Convert.ToInt32(dataGridViewInvoices.SelectedRows[0].Cells["InvoiceID"].Value);
                PrintInvoice(invoiceId);
            }
            else
            {
                MessageBox.Show("Please select an invoice to print.", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PrintInvoice(int invoiceId)
        {
            PrintDialog printDialog = new PrintDialog();
            PrintDocument printDoc = new PrintDocument(); // ✅ Ensure System.Drawing.Printing is imported
            printDialog.Document = printDoc;
            printDoc.PrintPage += (s, e) =>
            {
                if (e.Graphics == null) return;
                e.Graphics.DrawString($"Invoice ID: {invoiceId}", new Font("Arial", 12), Brushes.Black, 100, 100);
                e.Graphics.DrawString("Invoice Details:", new Font("Arial", 10), Brushes.Black, 100, 130);

                int yPos = 160;
                foreach (DataRow row in invoicesTable.Rows)
                {
                    if (Convert.ToInt32(row["InvoiceID"]) == invoiceId)
                    {
                        string line = $"ProductID: {row["ProductID"]}, Quantity: {row["Quantity"]}, SubTotal: {row["SubTotal"]}";
                        e.Graphics.DrawString(line, new Font("Arial", 10), Brushes.Black, 100, yPos);
                        yPos += 20;
                    }
                }
            };

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDoc.Print();
            }
        }
    }
}
