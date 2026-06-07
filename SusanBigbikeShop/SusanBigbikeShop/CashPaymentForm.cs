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
    public partial class CashPaymentForm : Form
    {
        public double CashGiven { get; private set; }
        public double Change { get; private set; }

        private readonly double _total;

        public CashPaymentForm(double total)
        {
            InitializeComponent();
            _total = total;
            lblTotal.Text = "₱" + total.ToString("N2");
            txtCash.Text = "";
        }


        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtCash.Text, out double cash) || cash <= 0)
            {
                MessageBox.Show("Please enter a valid cash amount.",
                    "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCash.Focus();
                return;
            }

            if (cash < _total)
            {
                MessageBox.Show("Insufficient cash. Total is ₱" + _total.ToString("N2"),
                    "Insufficient Cash", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCash.Focus();
                return;
            }

            CashGiven = cash;
            Change = cash - _total;
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
