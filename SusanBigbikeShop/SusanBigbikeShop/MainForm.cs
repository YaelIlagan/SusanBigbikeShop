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
    public partial class MainForm : Form
    {
        private string role;
        public MainForm()
        {
            InitializeComponent();
            LoadNavPanel(role);
        }

        public void LoadNavPanel(string role)
        {
            this.role = role;
            PnlNavBar.Controls.Clear();

            Form navForm = null;

            if (role == "Owner")
            {
                navForm = new MainFormOwner(this);
            }

            else if (role == "Staff")
            {
                navForm = new MainStaffForm(this);
            }

            else if (role == "Customer")
            {
                navForm = new MainCustomerForm(this);
            }

            if (navForm != null)
            {
                navForm.FormBorderStyle = FormBorderStyle.None;
                navForm.TopLevel = false;
                navForm.Dock = DockStyle.Fill;
                PnlNavBar.Controls.Add(navForm);
                navForm.Show();
            }
        }

        public void LoadContent(Form contentForm)
        {
            PnlRightPanel.Controls.Clear();

            contentForm.TopLevel = false;
            contentForm.FormBorderStyle = FormBorderStyle.None;
            contentForm.Dock = DockStyle.Fill;
            contentForm.TopMost = false;

            PnlRightPanel.Controls.Add(contentForm);

            contentForm.Show();
        }
    }
}
