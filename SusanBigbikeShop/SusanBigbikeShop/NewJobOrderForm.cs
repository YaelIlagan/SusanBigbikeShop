using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            LoadPartsFromInventory();
        }

        private void LoadTypeOptions()
        {
            cboxType.Items.Clear();
            cboxType.Items.Add("Walk-In");
            cboxType.Items.Add("Booking");
            cboxType.SelectedIndex = 0;
        }

        private void LoadPartsFromInventory()
        {
            chkListParts.Items.Clear();

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();

                    string query = "SELECT item_id, item_name FROM Inventory ORDER BY item_name";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            chkListParts.Items.Add(new PartItem
                            {
                                ItemId = reader.GetInt32(0),
                                ItemName = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading parts: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetSelectedParts()
        {
            var selected = new List<string>();
            foreach (PartItem item in chkListParts.CheckedItems)
                selected.Add(item.ItemName);
            return string.Join(", ", selected);
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text) ||
                string.IsNullOrWhiteSpace(txtMotorcycleModel.Text) ||
                string.IsNullOrWhiteSpace(txtPlateNumber.Text) ||
                string.IsNullOrWhiteSpace(txtLaborCost.Text) ||
                string.IsNullOrWhiteSpace(txtIssueCocernsNote.Text) ||
                cboxType.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all required fields.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (chkListParts.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one part.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtContactNumber.Text, @"^\d{11}$"))
            {
                MessageBox.Show("Contact Number must be exactly 11 digits.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContactNumber.Focus();
                return false;
            }

            if (!double.TryParse(txtLaborCost.Text, out double laborCost) || laborCost <= 0)
            {
                MessageBox.Show("Labor Cost must be a valid positive number.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            txtLaborCost.Clear();
            txtIssueCocernsNote.Clear();
            cboxType.SelectedIndex = 0;

            for (int i = 0; i < chkListParts.Items.Count; i++)
                chkListParts.SetItemChecked(i, false);
        }

        private void btnSaveOrderJob_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();

                    string query = @"
                        INSERT INTO JobOrder
                            (customer_name, contact_number, motorcycle_model,
                             plate_number, parts_used, labor_cost,
                             type, issue_description, status, date_received)
                        VALUES
                            (@customerName, @contact, @model,
                             @plate, @parts, @laborCost,
                             @type, @issue, 'Pending', GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@customerName", txtCustomerName.Text.Trim());
                        cmd.Parameters.AddWithValue("@contact", string.IsNullOrWhiteSpace(txtContactNumber.Text) ? "N/A" : txtContactNumber.Text.Trim());
                        cmd.Parameters.AddWithValue("@model", txtMotorcycleModel.Text.Trim());
                        cmd.Parameters.AddWithValue("@plate", txtPlateNumber.Text.Trim());
                        cmd.Parameters.AddWithValue("@parts", GetSelectedParts());
                        cmd.Parameters.AddWithValue("@laborCost", double.Parse(txtLaborCost.Text));
                        cmd.Parameters.AddWithValue("@type", cboxType.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@issue", txtIssueCocernsNote.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Job Order saved successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving job order: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to cancel?",
                "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                ClearForm();
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }

    public class PartItem
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public override string ToString() => ItemName;
    }
}
