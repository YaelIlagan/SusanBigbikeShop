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
    public partial class RepairsAndMaintenanceFormcs : Form
    {
        public RepairsAndMaintenanceFormcs()
        {
            InitializeComponent();
        }

        private void btnRepairsNewJobOrder_Click(object sender, EventArgs e)
        {
            NewJobOrderForm newJobOrder = new NewJobOrderForm();
            newJobOrder.ShowDialog();
        }

        private void txtRepairsSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
