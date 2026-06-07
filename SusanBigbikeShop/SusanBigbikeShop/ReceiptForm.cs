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
    public partial class ReceiptForm : Form
    {
        public ReceiptForm(
            int saleId,
            DateTime date,
            string cashierName,
            List<string> items,
            List<string> amounts,
            double total,
            string paymentMethod,
            double cashGiven,
            double change,
            string transactionRef)
        {
            InitializeComponent();

            lblDate.Text = date.ToString("yyyy/MM/dd hh:mm tt");
            lblName.Text = cashierName;
            lblTotal.Text = "₱" + total.ToString("N2");
            lblItem.Text = string.Join(Environment.NewLine, items);
            lblAmount.Text = string.Join(Environment.NewLine, amounts);

            if (paymentMethod == "CASH")
            {
                lblChange.Text = "₱" + change.ToString("N2");
            }
            else
            {
                lblChange.Text = "Ref#: " + transactionRef;
            }
        }
    }
}
