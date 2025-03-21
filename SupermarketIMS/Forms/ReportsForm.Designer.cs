namespace SupermarketIMS
{
    partial class ReportsForm
    {
        private System.Windows.Forms.DataGridView dataGridViewInvoices;
        private System.Windows.Forms.Button btnPrintInvoice;

        private void InitializeComponent()
        {
            this.dataGridViewInvoices = new System.Windows.Forms.DataGridView();
            this.btnPrintInvoice = new System.Windows.Forms.Button();

            // 
            // dataGridViewInvoices
            // 
            this.dataGridViewInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInvoices.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewInvoices.Name = "dataGridViewInvoices";
            this.dataGridViewInvoices.Size = new System.Drawing.Size(600, 300);
            this.dataGridViewInvoices.TabIndex = 0;

            // 
            // btnPrintInvoice
            // 
            this.btnPrintInvoice.Location = new System.Drawing.Point(12, 320);
            this.btnPrintInvoice.Name = "btnPrintInvoice";
            this.btnPrintInvoice.Size = new System.Drawing.Size(150, 30);
            this.btnPrintInvoice.TabIndex = 1;
            this.btnPrintInvoice.Text = "Print Invoice";
            this.btnPrintInvoice.UseVisualStyleBackColor = true;
            this.btnPrintInvoice.Click += new System.EventHandler(this.btnPrintInvoice_Click);

            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(640, 380);
            this.Controls.Add(this.dataGridViewInvoices);
            this.Controls.Add(this.btnPrintInvoice);
            this.Name = "ReportsForm";
            this.Text = "View Invoices";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInvoices)).EndInit();
        }
    }
}
