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
    public partial class NewJobOrderForm : Form
    {
        
        public NewJobOrderForm()
        {
            InitializeComponent();
            LoadTypeOptions();
        }

        private void LoadTypeOptions()
        {
            cboxType.Items.Clear();
            cboxType.Items.Add("Walk-in");
            cboxType.Items.Add("Booking");
            cboxType.SelectedIndex = 0;
        }

        private void btnSaveOrderJob_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            // add to sa database
            MessageBox.Show(
                "Job Order saved successfully!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            ClearForm();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Are you sure you want to cancel?",
            "Cancel",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                ClearForm();
                this.Close();
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text) ||
                string.IsNullOrWhiteSpace(txtMotorcycleModel.Text) ||
                string.IsNullOrWhiteSpace(txtPlateNumber.Text) ||
                string.IsNullOrWhiteSpace(txtPartsUsed.Text) ||
                string.IsNullOrWhiteSpace(txtLaborCost.Text) ||
                string.IsNullOrWhiteSpace(txtIssueCocernsNote.Text) ||
                cboxType == null)
            {
                MessageBox.Show(
                    "Please fill in all required fields.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }

            if (txtContactNumber.Text.Length != 11 || !txtContactNumber.Text.All(char.IsDigit))
            {
                MessageBox.Show(
                    "Contact Number must be exactly 11 digits.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtContactNumber.Focus();
                return false;
            }

            if (!double.TryParse(txtLaborCost.Text, out double laborCost) || laborCost <= 0)
            {
                MessageBox.Show(
                    "Labor Cost must be a valid number.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtLaborCost.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            txtCustomerName.Clear();
            txtContactNumber.Clear();
            txtMotorcycleModel.Clear();
            txtPlateNumber.Clear();
            txtPartsUsed.Clear();
            txtLaborCost.Clear();
            txtIssueCocernsNote.Clear();
            cboxType.SelectedIndex = 0;
        }
    }
}
