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
    -- Part 1: Get all Parts Sold
    SELECT 
        s.sale_id               AS [Sale ID], 
        CAST(s.sale_date AS DATE) AS [Date], 
        i.item_name             AS [Item], 
        i.category              AS [Category],
        si.quantity             AS [Qty],
        si.unit_price           AS [Unit Price],
        si.subtotal             AS [Subtotal],
        s.payment_method        AS [Payment]
    FROM Sales s
    INNER JOIN SalesItem si ON s.sale_id = si.sale_id
    INNER JOIN Inventory i  ON si.item_id = i.item_id
    WHERE CAST(s.sale_date AS DATE) >= CAST(@DateFrom AS DATE) 
      AND CAST(s.sale_date AS DATE) <= CAST(@DateTo AS DATE)

    UNION ALL

    -- Part 2: Get the Labor Cost as a separate row
    SELECT 
        s.sale_id, 
        CAST(s.sale_date AS DATE), 
        'Labor Service', 
        'Labor',
        1,
        (s.total_amount - (SELECT ISNULL(SUM(subtotal), 0) FROM SalesItem WHERE sale_id = s.sale_id)),
        (s.total_amount - (SELECT ISNULL(SUM(subtotal), 0) FROM SalesItem WHERE sale_id = s.sale_id)),
        s.payment_method
    FROM Sales s
    WHERE (s.total_amount - (SELECT ISNULL(SUM(subtotal), 0) FROM SalesItem WHERE sale_id = s.sale_id)) > 0
      AND CAST(s.sale_date AS DATE) >= CAST(@DateFrom AS DATE) 
      AND CAST(s.sale_date AS DATE) <= CAST(@DateTo AS DATE)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DateFrom", dateTimePickerSalesReportsDateFrom.Value.Date);
                        cmd.Parameters.AddWithValue("@DateTo", dateTimePickerSalesReportsDateTo.Value.Date);



                        cmd.CommandText = query;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dataGridView3.DataSource = dt;

                        // Keeps the grid looking clean
                        if (dataGridView3.Columns.Count > 0)
                        {
                            dataGridView3.Columns[dataGridView3.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating report: " + ex.Message, "System Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dateTimePickerSalesReportsDateFrom.Value = DateTime.Now;
            dateTimePickerSalesReportsDateTo.Value = DateTime.Now;

            if (dataGridView3.DataSource != null)
            {
                ((DataTable)dataGridView3.DataSource).Clear();
            }
        }

        private void label25_Click(object sender, EventArgs e) { }
        private void dateTimePickerSalesReportsDateFrom_ValueChanged(object sender, EventArgs e) { }
        private void dateTimePickerSalesReportsDateTo_ValueChanged(object sender, EventArgs e) { }
        private void cboxSalesReportsService_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cboxSalesReportStatus_SelectedIndexChanged(object sender, EventArgs e) { }

        private void pnlitemsales_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}