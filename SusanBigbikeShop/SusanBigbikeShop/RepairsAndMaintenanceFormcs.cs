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
    public partial class RepairsAndMaintenanceFormcs : Form
    {
        public RepairsAndMaintenanceFormcs()
        {
            InitializeComponent();
            LoadStatusFilter();
            LoadJobOrders();
            panelJobDetails.Visible = false;
        }
        private void LoadStatusFilter()
        {
            cboxRepairsStatus.Items.Clear();
            cboxRepairsStatus.Items.Add("All Status");
            cboxRepairsStatus.Items.Add("Pending");
            cboxRepairsStatus.Items.Add("Confirmed");
            cboxRepairsStatus.Items.Add("In Progress");
            cboxRepairsStatus.Items.Add("Completed");
            cboxRepairsStatus.SelectedIndex = 0;
        }
        public void LoadJobOrders(string search = "", string status = "All Status")
        {
            dataGridOrderList.Rows.Clear();

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT job_order_id, customer_name, contact_number,
                               motorcycle_model, plate_number, type, status
                        FROM JobOrder
                        WHERE (@status = 'All Status' OR status = @status)
                          AND (customer_name LIKE @search
                               OR plate_number LIKE @search
                               OR motorcycle_model LIKE @search)
                        ORDER BY date_received DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataGridOrderList.Rows.Add(
                                    reader["job_order_id"].ToString(),
                                    reader["customer_name"].ToString(),
                                    reader["contact_number"].ToString(),
                                    reader["motorcycle_model"].ToString(),
                                    reader["plate_number"].ToString(),
                                    reader["type"].ToString(),
                                    reader["status"].ToString(),
                                    "Update",
                                    "Done"
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading job orders: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnRepairsNewJobOrder_Click(object sender, EventArgs e)
        {
            NewJobOrderForm newJobOrder = new NewJobOrderForm();
            if (newJobOrder.ShowDialog() == DialogResult.OK)
            {
                LoadJobOrders(txtSearch.Text, cboxRepairsStatus.SelectedItem.ToString());
            }
        }

        private void dataGridOrderList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridOrderList.Rows[e.RowIndex];
            int jobOrderId = int.Parse(row.Cells["JobOrderID"].Value.ToString());

            if (e.ColumnIndex == dataGridOrderList.Columns["Update"].Index)
            {
                string currentStatus = row.Cells["Status"].Value.ToString();
                if (currentStatus == "Completed")
                {
                    MessageBox.Show("This job order is already completed.",
                        "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string newStatus = currentStatus == "Pending" ? "In Progress" : "In Progress";

                using (var form = new UpdateJobOrderForm(jobOrderId))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                        LoadJobOrders(txtSearch.Text, cboxRepairsStatus.SelectedItem.ToString());
                }
                return;
            }

            if (e.ColumnIndex == dataGridOrderList.Columns["Done"].Index)
            {
                string currentStatus = row.Cells["Status"].Value.ToString();
                if (currentStatus == "Completed")
                {
                    MessageBox.Show("This job order is already completed.",
                        "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult confirm = MessageBox.Show(
                    "Mark this job order as Completed?",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    MarkAsDone(jobOrderId);
                }
                return;
            }

            ShowJobOrderDetails(jobOrderId);
        }
        private void ShowJobOrderDetails(int jobOrderId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT job_order_id, date_received, type, customer_name,
                               contact_number, motorcycle_model, plate_number,
                               issue_description, parts_used, labor_cost, status
                        FROM JobOrder
                        WHERE job_order_id = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", jobOrderId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblJO.Text = "JO-" + reader["job_order_id"].ToString().PadLeft(4, '0');
                                lblDate.Text = Convert.ToDateTime(reader["date_received"]).ToString("MM/dd/yyyy");
                                lblType.Text = reader["type"].ToString();
                                lblName.Text = reader["customer_name"].ToString();
                                lblContact.Text = reader["contact_number"].ToString();
                                lblModel.Text = reader["motorcycle_model"].ToString();
                                lblPlateNum.Text = reader["plate_number"].ToString();
                                lblIssue.Text = reader["issue_description"].ToString();
                                lblParts.Text = reader["parts_used"].ToString();
                                lblCost.Text = "PHP " + Convert.ToDouble(reader["labor_cost"]).ToString("N2");
                                lblStatus.Text = reader["status"].ToString();
                            }
                        }
                    }
                }

                panelJobDetails.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading details: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MarkAsDone(int jobOrderId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE JobOrder SET status = 'Completed' WHERE job_order_id = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", jobOrderId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Job order marked as Completed.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                panelJobDetails.Visible = false;
                LoadJobOrders(txtSearch.Text, cboxRepairsStatus.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating status: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadJobOrders(txtSearch.Text, cboxRepairsStatus.SelectedItem.ToString());
        }

        private void cboxRepairsStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadJobOrders(txtSearch.Text, cboxRepairsStatus.SelectedItem.ToString());
        }
    }
}
