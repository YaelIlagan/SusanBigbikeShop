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
    public partial class UpdateJobOrderForm : Form
    {
        private readonly int _jobOrderId;

        public UpdateJobOrderForm(int jobOrderId)
        {
            InitializeComponent();
            _jobOrderId = jobOrderId;
            LoadTypeOptions();
            LoadStatusOptions();
            LoadPartsFromInventory();
            LoadJobOrderData();
            LoadMotorcycleAutoComplete();
        }

        private void LoadMotorcycleAutoComplete()
        {
            cboxModel.Items.Clear();

            string[] baseModels = new string[] {
                "BMW R 1300 GS", "BMW S 1000 RR", "BMW M 1000 RR",
                "Yamaha YZF-R1", "Yamaha YZF-R6", "Yamaha MT-10 SP", "Yamaha MT-09",
                "Honda CBR1000RR-R Fireblade SP", "Honda CBR600RR", "Honda Africa Twin",
                "Kawasaki Ninja H2", "Kawasaki Ninja ZX-10R", "Kawasaki Ninja ZX-6R",
                "Ducati Panigale V4", "Ducati Streetfighter V4", "Ducati Multistrada V4",
                "Suzuki Hayabusa", "Suzuki GSX-R1000R",
                "KTM 1390 Super Duke R", "KTM 1290 Super Adventure",
                "Triumph Rocket 3 R", "Triumph Speed Triple 1200 RS",
                "Harley-Davidson Pan America 1250", "Harley-Davidson Street Glide"
            };

            int currentYear = DateTime.Now.Year;
            for (int year = 2010; year <= currentYear + 1; year++)
                foreach (string model in baseModels)
                    cboxModel.Items.Add($"{year} {model}");

            cboxModel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboxModel.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void LoadTypeOptions()
        {
            cboxType.Items.Clear();
            cboxType.Items.Add("Walk-In");
            cboxType.Items.Add("Booking");
            cboxType.SelectedIndex = 0;
        }

        private void LoadStatusOptions()
        {
            cboBoxStatus.Items.Clear();
            cboBoxStatus.Items.Add("Pending");
            cboBoxStatus.Items.Add("In Progress");
            cboBoxStatus.Items.Add("Completed");
            cboBoxStatus.SelectedIndex = 0;
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

        private void LoadJobOrderData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT customer_name, contact_number, motorcycle_model,
                               plate_number, parts_used, labor_cost,
                               type, issue_description, status
                        FROM JobOrder
                        WHERE job_order_id = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _jobOrderId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtCustomerName.Text = reader["customer_name"].ToString();
                                txtContactNumber.Text = reader["contact_number"].ToString();
                                cboxModel.Text = reader["motorcycle_model"].ToString();
                                txtPlateNumber.Text = reader["plate_number"].ToString();
                                txtLaborCost.Text = reader["labor_cost"].ToString();
                                txtIssueCocernsNote.Text = reader["issue_description"].ToString();
                                cboxType.SelectedItem = reader["type"].ToString();
                                cboBoxStatus.SelectedItem = reader["status"].ToString();

                                string savedParts = reader["parts_used"].ToString();
                                List<string> savedList = new List<string>(
                                    savedParts.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries));

                                for (int i = 0; i < chkListParts.Items.Count; i++)
                                {
                                    PartItem item = (PartItem)chkListParts.Items[i];
                                    if (savedList.Contains(item.ItemName))
                                        chkListParts.SetItemChecked(i, true);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading job order: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text) ||
                string.IsNullOrWhiteSpace(cboxModel.Text) ||
                string.IsNullOrWhiteSpace(txtPlateNumber.Text) ||
                string.IsNullOrWhiteSpace(txtLaborCost.Text) ||
                cboxType.SelectedIndex == -1 ||
                cboBoxStatus.SelectedIndex == -1)
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

            if (!string.IsNullOrWhiteSpace(txtContactNumber.Text) &&
                !System.Text.RegularExpressions.Regex.IsMatch(txtContactNumber.Text, @"^\d{11}$"))
            {
                MessageBox.Show("Contact Number must be exactly 11 digits if provided.",
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

        private void btnSaveOrderJob_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();

                    string query = @"
                        UPDATE JobOrder SET
                            customer_name     = @customerName,
                            contact_number    = @contact,
                            motorcycle_model  = @model,
                            plate_number      = @plate,
                            parts_used        = @parts,
                            labor_cost        = @laborCost,
                            type              = @type,
                            issue_description = @issue,
                            status            = @status
                        WHERE job_order_id = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@customerName", txtCustomerName.Text.Trim());
                        cmd.Parameters.AddWithValue("@contact", string.IsNullOrWhiteSpace(txtContactNumber.Text) ? "N/A" : txtContactNumber.Text.Trim());
                        cmd.Parameters.AddWithValue("@model", cboxModel.Text.Trim());
                        cmd.Parameters.AddWithValue("@plate", txtPlateNumber.Text.Trim());
                        cmd.Parameters.AddWithValue("@parts", GetSelectedParts());
                        cmd.Parameters.AddWithValue("@laborCost", double.Parse(txtLaborCost.Text));
                        cmd.Parameters.AddWithValue("@type", cboxType.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@issue", txtIssueCocernsNote.Text.Trim());
                        cmd.Parameters.AddWithValue("@status", cboBoxStatus.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@id", _jobOrderId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Job Order updated successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating job order: " + ex.Message,
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
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
