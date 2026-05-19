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
    }
}
