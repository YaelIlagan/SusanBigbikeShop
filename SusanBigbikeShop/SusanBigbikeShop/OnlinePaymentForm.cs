using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SusanBigbikeShop
{
    public partial class OnlinePaymentForm : Form
    {
        public string TransactionNumber { get; private set; }

        private readonly double _total;

        public OnlinePaymentForm(double total)
        {
            InitializeComponent();
            _total = total;
            lblTotal.Text = "₱" + total.ToString("N2");
            txtCash.Text = "";
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCash.Text))
            {
                MessageBox.Show("Please enter the transaction number.",
                    "Missing Transaction Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCash.Focus();
                return;
            }

            TransactionNumber = txtCash.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
