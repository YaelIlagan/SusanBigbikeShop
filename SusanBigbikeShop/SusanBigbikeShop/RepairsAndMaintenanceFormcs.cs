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
        private int selectedJobOrderId = -1;

        public RepairsAndMaintenanceFormcs()
        {
            InitializeComponent();
            LoadStatusFilter();
            LoadJobOrders();
            panelJobDetails.Visible = false;
            txtSearch.Text = "Enter keyword...";
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
            if (search == "Enter keyword...")
                search = "";

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
                                    reader["status"].ToString()
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedJobOrderId == -1)
            {
                MessageBox.Show("Please select a job order to update.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string currentStatus = GetSelectedStatus();

            if (currentStatus == "Completed")
            {
                MessageBox.Show("This job order is already completed.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var form = new UpdateJobOrderForm(selectedJobOrderId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadJobOrders(txtSearch.Text, cboxRepairsStatus.SelectedItem.ToString());
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (selectedJobOrderId == -1)
            {
                MessageBox.Show("Please select a job order to mark as done.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string currentStatus = GetSelectedStatus();

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
                MarkAsDone(selectedJobOrderId);
        }

        private string GetSelectedStatus()
        {
            foreach (DataGridViewRow row in dataGridOrderList.Rows)
            {
                if (row.Cells["JobOrderID"].Value?.ToString() == selectedJobOrderId.ToString())
                    return row.Cells["Status"].Value?.ToString() ?? "";
            }
            return "";
        }

        private void dataGridOrderList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridOrderList.Rows[e.RowIndex];
            selectedJobOrderId = int.Parse(row.Cells["JobOrderID"].Value.ToString());

            ShowJobOrderDetails(selectedJobOrderId);
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

                    string joQuery = @"SELECT customer_name, parts_used, labor_cost, mechanic_id, motorcycle_id 
                               FROM JobOrder WHERE job_order_id = @id";

                    string partsUsed = "";
                    double laborCost = 0;
                    string customerName = "";
                    int mechanicId = 0;
                    int motorcycleId = 0;

                    using (SqlCommand cmd = new SqlCommand(joQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", jobOrderId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                customerName = reader["customer_name"].ToString();
                                partsUsed = reader["parts_used"].ToString();
                                laborCost = Convert.ToDouble(reader["labor_cost"]);
                                mechanicId = reader["mechanic_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["mechanic_id"]);
                                motorcycleId = reader["motorcycle_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["motorcycle_id"]);
                            }
                        }
                    }

                    int customerId = 0;
                    string custQuery = "SELECT TOP 1 customer_id FROM Customer WHERE full_name = @name";
                    using (SqlCommand cmd = new SqlCommand(custQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", customerName);
                        object res = cmd.ExecuteScalar();
                        if (res != null) customerId = Convert.ToInt32(res);
                    }

                    double totalPartsCost = 0;
                    List<Tuple<int, double>> partsToInsert = new List<Tuple<int, double>>();

                    if (!string.IsNullOrWhiteSpace(partsUsed) && partsUsed != "None yet" && partsUsed != "N/A")
                    {
                        string[] partsList = partsUsed.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string part in partsList)
                        {
                            string partQuery = "SELECT item_id, unit_price FROM Inventory WHERE item_name = @itemName";
                            using (SqlCommand cmd = new SqlCommand(partQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@itemName", part);
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        int itemId = Convert.ToInt32(reader["item_id"]);
                                        double unitPrice = Convert.ToDouble(reader["unit_price"]);
                                        totalPartsCost += unitPrice;
                                        partsToInsert.Add(new Tuple<int, double>(itemId, unitPrice));
                                    }
                                }
                            }
                        }
                    }

                    double grandTotal = laborCost + totalPartsCost;

                    int saleId = 0;
                    string insertSale = @"INSERT INTO Sales (customer_id, sale_date, total_amount, payment_method, mechanic_id)
                                  OUTPUT INSERTED.sale_id
                                  VALUES (@custId, @date, @total, 'CASH', @mechId)";
                    using (SqlCommand cmd = new SqlCommand(insertSale, conn))
                    {
                        cmd.Parameters.AddWithValue("@custId", customerId > 0 ? (object)customerId : DBNull.Value);
                        cmd.Parameters.AddWithValue("@date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@total", grandTotal);
                        cmd.Parameters.AddWithValue("@mechId", mechanicId > 0 ? (object)mechanicId : DBNull.Value);
                        saleId = (int)cmd.ExecuteScalar();
                    }

                    foreach (var part in partsToInsert)
                    {
                        string insertItemQuery = @"INSERT INTO SalesItem (sale_id, item_id, quantity, unit_price, subtotal)
                                           VALUES (@saleId, @itemId, 1, @price, @price)";
                        using (SqlCommand cmdInsert = new SqlCommand(insertItemQuery, conn))
                        {
                            cmdInsert.Parameters.AddWithValue("@saleId", saleId);
                            cmdInsert.Parameters.AddWithValue("@itemId", part.Item1);
                            cmdInsert.Parameters.AddWithValue("@price", part.Item2);
                            cmdInsert.ExecuteNonQuery();
                        }

                        string deductInvQuery = "UPDATE Inventory SET quantity_in_stock = quantity_in_stock - 1 WHERE item_id = @itemId";
                        using (SqlCommand cmdDeduct = new SqlCommand(deductInvQuery, conn))
                        {
                            cmdDeduct.Parameters.AddWithValue("@itemId", part.Item1);
                            cmdDeduct.ExecuteNonQuery();
                        }
                    }

                    string updateJo = "UPDATE JobOrder SET status = 'Completed' WHERE job_order_id = @id";
                    using (SqlCommand cmd = new SqlCommand(updateJo, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", jobOrderId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Job order completed! Sales record generated.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                selectedJobOrderId = -1;
                panelJobDetails.Visible = false;
                LoadJobOrders(txtSearch.Text, cboxRepairsStatus.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error completing job: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Enter keyword...") return;

            LoadJobOrders(
                txtSearch.Text,
                cboxRepairsStatus.SelectedItem.ToString()
            );
        }

        private void cboxRepairsStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadJobOrders(txtSearch.Text, cboxRepairsStatus.SelectedItem.ToString());
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Enter keyword...")
                txtSearch.Text = "";

            LoadJobOrders("", cboxRepairsStatus.SelectedItem.ToString());
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
                txtSearch.Text = "Enter keyword...";

            LoadJobOrders("", cboxRepairsStatus.SelectedItem.ToString());
        }

    }
}