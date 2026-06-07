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
    public partial class DasboardForm : Form
    {
        public DasboardForm()
        {
            InitializeComponent();
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            try
            {
                DBConnection db = new DBConnection();
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    LoadTodaySales(conn);
                    LoadOngoingRepairs(conn);
                    LoadLowStock(conn);
                    LoadBookingsToday(conn);
                    LoadRecentJobOrders(conn);
                    LoadInventoryAlerts(conn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTodaySales(SqlConnection conn)
        {
            string query = @"
                SELECT 
                    ISNULL(SUM(total_amount), 0) AS TotalSales,
                    COUNT(sale_id)               AS TotalTransactions
                FROM Sales
                WHERE CAST(sale_date AS DATE) = CAST(GETDATE() AS DATE)";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    decimal total = Convert.ToDecimal(reader["TotalSales"]);
                    int count = Convert.ToInt32(reader["TotalTransactions"]);

                    lblTodaySales.Text = $"₱ {total:N2}";
                    lblTotalTransaction.Text = $"{count} transaction{(count != 1 ? "s" : "")}";
                }
            }
        }

        private void LoadOngoingRepairs(SqlConnection conn)
        {
            string query = @"
                SELECT COUNT(job_order_id) AS OngoingCount
                FROM JobOrder
                WHERE status = 'In Progress'";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                label2.Text = count.ToString();
            }
        }

        private void LoadLowStock(SqlConnection conn)
        {
            string query = @"
                SELECT COUNT(item_id) AS LowStockCount
                FROM Inventory
                WHERE quantity_in_stock <= low_stock_threshold";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                lblLowStock.Text = count.ToString();
            }
        }

        private void LoadBookingsToday(SqlConnection conn)
        {
            string query = @"
                SELECT COUNT(booking_id) AS BookingCount
                FROM Booking
                WHERE requested_date = CAST(GETDATE() AS DATE)";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                lblBookings.Text = count.ToString();
            }
        }

        private void LoadRecentJobOrders(SqlConnection conn)
        {

            string query = @"
                SELECT TOP 10
                    jo.customer_name        AS [Customer Name],
                    jo.motorcycle_model     AS [Motorcycle],
                    jo.status               AS [Status],
                    jo.labor_cost           AS [Labor]
                FROM JobOrder jo
                ORDER BY jo.date_received DESC";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridRecentJobOrders.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    dataGridRecentJobOrders.Rows.Add(
                        row["Customer Name"].ToString(),
                        row["Motorcycle"].ToString(),
                        row["Status"].ToString(),
                        $"₱ {Convert.ToDecimal(row["Labor"]):N2}"
                    );
                }
            }
        }

        private void LoadInventoryAlerts(SqlConnection conn)
        {
            string query = @"
                SELECT item_name, quantity_in_stock
                FROM Inventory
                WHERE quantity_in_stock <= low_stock_threshold
                ORDER BY quantity_in_stock ASC";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    lblItemList.Text = "No alerts";
                    lblStockList.Text = "";
                    return;
                }

                string items = "";
                string stocks = "";

                foreach (DataRow row in dt.Rows)
                {
                    items += row["item_name"].ToString() + "\n";
                    stocks += row["quantity_in_stock"].ToString() + " left\n";
                }

                lblItemList.Text = items.TrimEnd();
                lblStockList.Text = stocks.TrimEnd();
            }
        }

        public void RefreshDashboard()
        {
            LoadDashboard();
        }

        private void DasboardForm_Shown(object sender, EventArgs e)
        {

        }
    }
}
