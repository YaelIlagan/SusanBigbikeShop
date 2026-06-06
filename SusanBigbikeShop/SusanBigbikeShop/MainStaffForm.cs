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
    public partial class MainStaffForm : Form
    {
        private MainForm _main;
        public MainStaffForm(MainForm main)
        {
            InitializeComponent();
            _main = main;
            _main.LoadContent(new DasboardForm());
        }

        private void btnDashboardStaff_Click(object sender, EventArgs e)
        {
            _main.LoadContent(new DasboardForm());
        }

        private void btnSalesStaff_Click(object sender, EventArgs e)
        {
            _main.LoadContent(new SalesForm());
        }

        private void btnRepairsAndManagementStaff_Click(object sender, EventArgs e)
        {
            _main.LoadContent(new RepairsAndMaintenanceFormcs());
        }

        private void btnInventoryManagementStaff_Click(object sender, EventArgs e)
        {
            _main.LoadContent(new InventoryForm());
        }

        private void btnProductManagementStaff_Click(object sender, EventArgs e)
        {
            _main.LoadContent(new ProductManagementForm());
        }

        private void btnBookingStaff_Click(object sender, EventArgs e)
        {
            _main.LoadContent(new BookingForm());
        }
    }
}
