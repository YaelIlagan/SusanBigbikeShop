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
    public partial class InventoryForm : Form
    {
        public InventoryForm()
        {
            InitializeComponent();
            LoadCategoryFilter();
            LoadStatusFilter();
            LoadMetrics();
            LoadInventory("All", "All", "");
        }
        private void LoadCategoryFilter()
        {
            cboBoxCategorySearch.Items.Clear();
            cboBoxCategorySearch.Items.Add("All");
            cboBoxCategorySearch.Items.Add("Parts");
            cboBoxCategorySearch.Items.Add("Oils");
            cboBoxCategorySearch.Items.Add("Accessories");
            cboBoxCategorySearch.SelectedIndex = 0;
        }

        private void LoadStatusFilter()
        {
            cboBoxStatus.Items.Clear();
            cboBoxStatus.Items.Add("All");
            cboBoxStatus.Items.Add("Low Stock");
            cboBoxStatus.Items.Add("OK");
            cboBoxStatus.Items.Add("Out of Stock");
            cboBoxStatus.SelectedIndex = 0;
        }

        private void LoadMetrics()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();

                    string query = @"SELECT
                        COUNT(*) as total,
                        SUM(CASE WHEN quantity_in_stock <= low_stock_threshold
                            AND quantity_in_stock > 0 THEN 1 ELSE 0 END) as low,
                        SUM(CASE WHEN quantity_in_stock > low_stock_threshold
                            THEN 1 ELSE 0 END) as ok,
                        SUM(CASE WHEN quantity_in_stock = 0 THEN 1 ELSE 0 END) as out
                        FROM Inventory";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblTotalItemQty.Text = reader["total"].ToString();
                            lblLowStockQty.Text = reader["low"].ToString();
                            label6.Text = reader["ok"].ToString();
                            lblOutStockQty.Text = reader["out"].ToString();

                            // Update label colors
                            lblTotalItemQty.ForeColor = Color.White;
                            lblTotalItem.ForeColor = Color.White;
                            lblLowStockQty.ForeColor = Color.Orange;
                            lblLowStock.ForeColor = Color.White;
                            label6.ForeColor = Color.LightGreen;
                            lblOkStock.ForeColor = Color.White;
                            lblOutStockQty.ForeColor = Color.Red;
                            lblOutStock.ForeColor = Color.White;
                        }
                    }

                    // Load alert details for low stock items
                    string alertQuery = @"SELECT item_name, quantity_in_stock,
                                        low_stock_threshold
                                        FROM Inventory
                                        WHERE quantity_in_stock <= low_stock_threshold
                                        ORDER BY quantity_in_stock ASC";

                    string alertText = "";
                    using (SqlCommand cmd = new SqlCommand(alertQuery, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int stock = Convert.ToInt32(reader["quantity_in_stock"]);
                            string status = stock == 0 ? "OUT OF STOCK" : "LOW STOCK";
                            alertText += $"⚠ {reader["item_name"]} — {stock} left ({status})     ";
                        }
                    }

                    lblAlertDetails.ForeColor = Color.White;
                    lblAlertDetails.Text = string.IsNullOrEmpty(alertText)
                        ? "✓ All items are sufficiently stocked."
                        : alertText;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading metrics: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void LoadInventory(string category = "All",
            string status = "All", string search = "")
        {
            dataGridInventoryList.Rows.Clear();

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();

                    string query = @"SELECT item_id, item_name, category,
                                    quantity_in_stock, unit_price, low_stock_threshold
                                    FROM Inventory
                                    WHERE (@category = 'All' OR category = @category)
                                    AND item_name LIKE @search
                                    AND (
                                        @status = 'All'
                                        OR (@status = 'Low Stock'
                                            AND quantity_in_stock <= low_stock_threshold
                                            AND quantity_in_stock > 0)
                                        OR (@status = 'OK'
                                            AND quantity_in_stock > low_stock_threshold)
                                        OR (@status = 'Out of Stock'
                                            AND quantity_in_stock = 0)
                                    )
                                    ORDER BY item_name";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@category", category);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int stock = Convert.ToInt32(reader["quantity_in_stock"]);
                                int threshold = Convert.ToInt32(reader["low_stock_threshold"]);

                                string stockStatus;
                                if (stock == 0)
                                    stockStatus = "Out of Stock";
                                else if (stock <= threshold)
                                    stockStatus = "Low Stock";
                                else
                                    stockStatus = "OK";

                                int rowIndex = dataGridInventoryList.Rows.Add(
                                    reader["item_id"].ToString(),
                                    reader["item_name"].ToString(),
                                    reader["category"].ToString(),
                                    stock.ToString(),
                                    Convert.ToDouble(reader["unit_price"]).ToString("N2"),
                                    threshold.ToString(),
                                    stockStatus
                                );

                                // Color the status cell
                                if (stockStatus == "Out of Stock")
                                    dataGridInventoryList.Rows[rowIndex].Cells["Status"]
                                        .Style.ForeColor = Color.Red;
                                else if (stockStatus == "Low Stock")
                                    dataGridInventoryList.Rows[rowIndex].Cells["Status"]
                                        .Style.ForeColor = Color.Orange;
                                else
                                    dataGridInventoryList.Rows[rowIndex].Cells["Status"]
                                        .Style.ForeColor = Color.Green;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading inventory: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnInventoryRestockItem_Click(object sender, EventArgs e)
        {
            if (dataGridInventoryList.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select an item to restock.",
                    "No Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string itemId = dataGridInventoryList.SelectedRows[0]
                .Cells["ItemID"].Value.ToString();
            string itemName = dataGridInventoryList.SelectedRows[0]
                .Cells["ItemName"].Value.ToString();
            string category = dataGridInventoryList.SelectedRows[0]
                .Cells["Category"].Value.ToString();
            int currentStock = int.Parse(dataGridInventoryList.SelectedRows[0]
                .Cells["Stock"].Value.ToString());
            int minThreshold = int.Parse(dataGridInventoryList.SelectedRows[0]
                .Cells["LowStockThreshold"].Value.ToString());

            RestockItemForm restockForm = new RestockItemForm(
                itemId, itemName, category, currentStock, minThreshold);
            restockForm.ShowDialog();

            if (restockForm.IsSaved)
            {
                LoadMetrics();
                LoadInventory(
                    cboBoxCategorySearch.SelectedItem.ToString(),
                    cboBoxStatus.SelectedItem.ToString(),
                    txtInventorySearch.Text
                );
            }
        }

        private void cboBoxCategorySearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBoxCategorySearch.SelectedItem == null || cboBoxStatus.SelectedItem == null)
            {  return; 
            }
            LoadInventory(cboBoxCategorySearch.SelectedItem.ToString(), cboBoxStatus.SelectedItem.ToString(), txtInventorySearch.Text);
        }

        private void cboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBoxCategorySearch.SelectedItem == null || cboBoxStatus.SelectedItem == null)
            {
                return;
            }
            LoadInventory(cboBoxCategorySearch.SelectedItem.ToString(), cboBoxStatus.SelectedItem.ToString(), txtInventorySearch.Text);
        }

        private void txtInventorySearch_TextChanged(object sender, EventArgs e)
        {
            if (cboBoxCategorySearch.SelectedItem == null || cboBoxStatus.SelectedItem == null)
            {
                return;
            }
            LoadInventory(cboBoxCategorySearch.SelectedItem.ToString(), cboBoxStatus.SelectedItem.ToString(), txtInventorySearch.Text);
        }

        private void lblLowStock_Click(object sender, EventArgs e)
        {

        }

        private void lblLowStockQty_Click(object sender, EventArgs e)
        {

        }
    }
}
