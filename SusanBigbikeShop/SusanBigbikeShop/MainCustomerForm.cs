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
    public partial class MainCustomerForm : Form
    {
        private MainForm _main;
        public MainCustomerForm(MainForm main)
        {
            InitializeComponent();
            _main = main;
            _main.LoadContent(new DasboardForm());
        }

        private void btnBookingCustomer_Click(object sender, EventArgs e)
        {
            _main.LoadContent(new BookingForm());
        }

        private void btnLogOutOwner_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to log out?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                UserAuth loginForm = new UserAuth();
                loginForm.Show();
                _main.Close();
            }
        }
    }
}
