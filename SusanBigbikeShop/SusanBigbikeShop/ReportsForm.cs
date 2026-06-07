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
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.ReportsForm_Load);
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
        }

        private void LoadComboBoxes()
        {
            cboxSalesReportsService.Items.Clear();
            cboxSalesReportsService.Items.AddRange(new string[] {
            "Parts",
            "Oils",
            "Accessories"
        });

            cboxSalesReportStatus.Items.Clear();
            cboxSalesReportStatus.Items.AddRange(new string[] {
            "CASH",
            "ONLINE"
            });

            try
            {
                DBConnection db = new DBConnection();
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    // Changed: loads all users, not just Mechanics
                    string query = "SELECT user_id, full_name FROM Users";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cboxSalesReportMechanic.DataSource = dt;
                        cboxSalesReportMechanic.DisplayMember = "full_name";
                        cboxSalesReportMechanic.ValueMember = "user_id";
                        cboxSalesReportMechanic.SelectedIndex = -1;
                        cboxSalesReportMechanic.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading staff: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalesReportsGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                DBConnection db = new DBConnection();
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"
                SELECT 
                    s.sale_id AS [Sale ID], 
                    CAST(s.sale_date AS DATE) AS [Date], 
                    i.item_name AS [Item], 
                    i.category AS [Category],
                    si.quantity AS [Qty],
                    si.unit_price AS [Unit Price],
                    si.subtotal AS [Subtotal],
                    s.payment_method AS [Payment],
                    ISNULL(u.full_name, 'None') AS [Staff]
                FROM Sales s
                INNER JOIN SalesItem si ON s.sale_id = si.sale_id
                INNER JOIN Inventory i ON si.item_id = i.item_id
                LEFT JOIN Users u ON s.staff_id = u.user_id
                WHERE CAST(s.sale_date AS DATE) >= CAST(@DateFrom AS DATE) 
                  AND CAST(s.sale_date AS DATE) <= CAST(@DateTo AS DATE)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DateFrom", dateTimePickerSalesReportsDateFrom.Value.Date);
                        cmd.Parameters.AddWithValue("@DateTo", dateTimePickerSalesReportsDateTo.Value.Date);

                        if (cboxSalesReportsService.SelectedIndex != -1)
                        {
                            query += " AND i.category = @Category";
                            cmd.Parameters.AddWithValue("@Category", cboxSalesReportsService.Text);
                        }

                        if (cboxSalesReportMechanic.SelectedIndex != -1)
                        {
                            query += " AND s.staff_id = @StaffID"; 
                            cmd.Parameters.AddWithValue("@StaffID", cboxSalesReportMechanic.SelectedValue);
                        }

                        if (cboxSalesReportStatus.SelectedIndex != -1)
                        {
                            query += " AND s.payment_method = @Payment";
                            cmd.Parameters.AddWithValue("@Payment", cboxSalesReportStatus.Text);
                        }

                        cmd.CommandText = query;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dataGridView3.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating report: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dateTimePickerSalesReportsDateFrom.Value = DateTime.Now;
            dateTimePickerSalesReportsDateTo.Value = DateTime.Now;

            cboxSalesReportsService.SelectedIndex = -1;
            cboxSalesReportMechanic.SelectedIndex = -1;
            cboxSalesReportStatus.SelectedIndex = -1;

            if (dataGridView3.DataSource != null)
            {
                ((DataTable)dataGridView3.DataSource).Clear();
            }
        }

        private void label25_Click(object sender, EventArgs e) { }
        private void dateTimePickerSalesReportsDateFrom_ValueChanged(object sender, EventArgs e) { }
        private void dateTimePickerSalesReportsDateTo_ValueChanged(object sender, EventArgs e) { }
        private void cboxSalesReportsService_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cboxSalesReportMechanic_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cboxSalesReportStatus_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}