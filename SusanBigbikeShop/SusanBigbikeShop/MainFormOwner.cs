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
    public partial class MainFormOwner : Form
    {
        private MainForm _main;
        public MainFormOwner(MainForm main)
        {
            InitializeComponent();
            _main = main;
            _main.LoadContent(new DasboardForm());
        }

        private void btnDashboardOwner_Click(object sender, EventArgs e)
        {
            _main.LoadContent(new DasboardForm());
        }

        private void btnSalesOwner_Click(object sender, EventArgs e)
        {
            _main.LoadContent(new SalesForm());
        }

        private void btnRepairsAndMaintenanceOwner_Click(object sender, EventArgs e)
        {
            _main.LoadContent(new RepairsAndMaintenanceFormcs());
        }

        private void btnInventoryManagementOwner_Click(object sender, EventArgs e)
        {
            _main.LoadContent(new InventoryForm());
        }

        private void btnProductManagementOwner_Click(object sender, EventArgs e)
        {
            _main.LoadContent(new ProductManagementForm());
        }

        private void btnBookingOwner_Click(object sender, EventArgs e)
        {
            _main.LoadContent(new BookingForm());
        }

        private void btnReportsOwner_Click(object sender, EventArgs e)
        {
            _main.LoadContent(new ReportsForm());
        }

        private void btnLogOutOwner_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
