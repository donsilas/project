using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms; 
namespace p.o.s
{
    public partial class Form1 : Form
    {
        List<string[]> sales = new List<string[]>();
        public Inventory Invt;
        public decimal total;
        public Form1()
        {
            InitializeComponent();
            Invt = new Inventory();
            foreach (ProductLine line in Invt.ProductLines)
            { cboItems.Items.Add(line.item.Name); }

        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            Boolean exists = false;
            ProductLine line = Invt.ProductLines.ElementAt(cboItems.SelectedIndex);
            
            int Qty;
            Int32.TryParse(txtQty.Text.Trim(),out Qty);

            decimal ExitPrice = line.item.Price * Qty;
            total = total + ExitPrice;
            txtDue.Text = total.ToString(); 
            foreach (string[] row in sales)
            {
                if (row[0] == line.item.Name)
                {
                    Qty += 10;
                }
            }

            string[] str = { line.item.Name, line.item.Price.ToString(), Qty.ToString(), ExitPrice.ToString() };

            
            dvgSales.Rows.Add(str);
        }

        private void txtFinish_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            decimal paid;
            decimal change;

            decimal.TryParse(txtPaid.Text.Trim(),out paid    );
            change = paid - total;
            txtChange.Text = change.ToString(); 
        }
    }
}
    