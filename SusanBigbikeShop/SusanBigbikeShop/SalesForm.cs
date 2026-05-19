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
    public partial class SalesForm : Form
    {
        private string selectedPayment = "";

        private double cartTotal = 0;
        public SalesForm()
        {
            InitializeComponent();
        }

        private void btnSalesSearchItem_Click(object sender, EventArgs e)
        {
            string searchText = txtSalesSearchItem.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Please enter a search term.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // lalagay pa database mga itlog
            MessageBox.Show("Searching for: " + searchText, "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        }
        // di pa naayos datagrid for filtering
        private void btnSalesCategory_Click(object sender, EventArgs e)
        {
            btnSalesCategory.BackColor = Color.DarkRed;
            btnSalesCategory1.BackColor = Color.FromArgb(58, 22, 30);
        }

        private void btnSalesCategory1_Click(object sender, EventArgs e)
        {
            btnSalesCategory1.BackColor = Color.DarkRed;
            btnSalesCategory.BackColor = Color.FromArgb(58, 22, 30);
        }

        private void btnSalesClearCart_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to clear the cart?",
                "Clear Cart",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                dataGridView2.Rows.Clear();
                cartTotal = 0;
                UpdateTotal();
            }
        }


        private void UpdateTotal()
        {
            label6.Text = cartTotal.ToString("N2");
        }

        private void btnSalesCashPayment_Click(object sender, EventArgs e)
        {
            selectedPayment = "CASH";
            btnSalesCashPayment.BackColor = Color.DarkRed;
            btnSalesOnlinePayment.BackColor = Color.FromArgb(58, 22, 30);

        }

        private void btnSalesOnlinePayment_Click(object sender, EventArgs e)
        {
            selectedPayment = "ONLINE";
            btnSalesOnlinePayment.BackColor = Color.DarkRed;
            btnSalesCashPayment.BackColor = Color.FromArgb(58, 22, 30);
        }

        private void btnSalesProceedPayment_Click(object sender, EventArgs e)
        {
            //if (dataGridView2.Rows.Count == 0)
            //{
            //    MessageBox.Show(
            //        "Cart is empty. Please add items before proceeding.",
            //        "Empty Cart",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Warning
            //    );
            //    return;
            //}

            DialogResult result = MessageBox.Show(
                "Proceed payment of PHP " + cartTotal.ToString("N2") + " via " + selectedPayment + "?",
                "Confirm Payment",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // sample lang toh wala pa design ng resibo e
            if (result == DialogResult.Yes)
            {
                MessageBox.Show(
                    "Payment succesful! \nTotal: " + cartTotal.ToString("N2") + "\nPayment: " + selectedPayment,
                    "Payment Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }

            cartTotal = 0;
            UpdateTotal();
        }
    }
}
