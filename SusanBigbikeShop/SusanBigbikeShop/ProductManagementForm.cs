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
    public partial class ProductManagementForm : Form
    {
        public ProductManagementForm()
        {
            InitializeComponent();
            LoadCategories();
            LoadProducts();
            txtProductID.ReadOnly = true;
        }

        private void LoadCategories()
        {
            cboBoxCategory.Items.Clear();
            cboBoxCategory.Items.Add("Parts");
            cboBoxCategory.Items.Add("Oils");
            cboBoxCategory.Items.Add("Accessories");
            cboBoxCategory.SelectedIndex = 0;

            cboBoxCategorySearch.Items.Clear();
            cboBoxCategorySearch.Items.Add("All");
            cboBoxCategorySearch.Items.Add("Parts");
            cboBoxCategorySearch.Items.Add("Oils");
            cboBoxCategorySearch.Items.Add("Accessories");
            cboBoxCategorySearch.SelectedIndex = 0;
        }

        private void LoadProducts(string category = "All", string search = "")
        {
            dataGridProductList.Rows.Clear();

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();

                    string query = @"SELECT item_id, item_name, category,
                                    unit_price, quantity_in_stock, description
                                    FROM Inventory
                                    WHERE (@category = 'All' OR category = @category)
                                    AND item_name LIKE @search
                                    ORDER BY item_name";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@category", category);
                        cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataGridProductList.Rows.Add(
                                    reader["item_id"].ToString(),
                                    reader["item_name"].ToString(),
                                    reader["category"].ToString(),
                                    Convert.ToDouble(reader["unit_price"]).ToString("N2"),
                                    reader["quantity_in_stock"].ToString(),
                                    reader["description"].ToString()
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading products: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                string.IsNullOrWhiteSpace(txtQty.Text) ||
                cboBoxCategory.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please fill in all required fields.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }

            if (!double.TryParse(txtPrice.Text, out double price) || price <= 0)
            {
                MessageBox.Show(
                    "Unit Price must be a valid number.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtPrice.Focus();
                return false;
            }

            if (!int.TryParse(txtQty.Text, out int qty) || qty < 0)
            {
                MessageBox.Show(
                    "Stock Quantity must be a valid number.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtQty.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            txtProductID.Clear();
            txtProductName.Clear();
            txtPrice.Clear();
            txtQty.Clear();
            txtDescription.Clear();
            cboBoxCategory.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();

                    string query = @"INSERT INTO Inventory
                                    (item_name, category, description,
                                    quantity_in_stock, unit_price)
                                    VALUES
                                    (@itemName, @category, @description,
                                    @qty, @price)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@itemName",
                            txtProductName.Text.Trim());
                        cmd.Parameters.AddWithValue("@category",
                            cboBoxCategory.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@description",
                            txtDescription.Text.Trim());
                        cmd.Parameters.AddWithValue("@qty",
                            int.Parse(txtQty.Text));
                        cmd.Parameters.AddWithValue("@price",
                            double.Parse(txtPrice.Text));

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Product added successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                ClearForm();
                LoadProducts(
                    cboBoxCategorySearch.SelectedItem.ToString(),
                    txtSearchProduct.Text == "Enter keyword..." ? "" : txtSearchProduct.Text
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error adding product: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductID.Text))
            {
                MessageBox.Show(
                    "Please select a product to update.",
                    "No Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (!ValidateForm())
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();

                    string query = @"UPDATE Inventory SET
                                    item_name = @itemName,
                                    category = @category,
                                    description = @description,
                                    quantity_in_stock = @qty,
                                    unit_price = @price
                                    WHERE item_id = @itemId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@itemName",
                            txtProductName.Text.Trim());
                        cmd.Parameters.AddWithValue("@category",
                            cboBoxCategory.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@description",
                            txtDescription.Text.Trim());
                        cmd.Parameters.AddWithValue("@qty",
                            int.Parse(txtQty.Text));
                        cmd.Parameters.AddWithValue("@price",
                            double.Parse(txtPrice.Text));
                        cmd.Parameters.AddWithValue("@itemId",
                            int.Parse(txtProductID.Text));

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Product updated successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                ClearForm();
                LoadProducts(cboBoxCategorySearch.SelectedItem.ToString(),txtSearchProduct.Text == "Enter keyword..." ? "" : txtSearchProduct.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error updating product: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductID.Text))
            {
                MessageBox.Show(
                    "Please select a product to delete.",
                    "No Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this product?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn =
                        new SqlConnection(DBConnection.ConnectionString))
                    {
                        conn.Open();

                        string query = "DELETE FROM Inventory WHERE item_id = @itemId";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@itemId",
                                int.Parse(txtProductID.Text));
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show(
                        "Product deleted successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    ClearForm();
                    LoadProducts(cboBoxCategorySearch.SelectedItem.ToString(),txtSearchProduct.Text == "Enter keyword..." ? "" : txtSearchProduct.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error deleting product: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearchProduct.Text = "Enter keyword...";
            cboBoxCategorySearch.SelectedIndex = 0;
            LoadProducts();
        }

        private void dataGridProductList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridProductList.Rows[e.RowIndex];
                txtProductID.Text = row.Cells["ProductID"].Value.ToString();
                txtProductName.Text = row.Cells["ProductName"].Value.ToString();
                txtPrice.Text = row.Cells["UnitPrice"].Value.ToString().Replace(",", "");
                txtQty.Text = row.Cells["Stock"].Value.ToString();
                txtDescription.Text = row.Cells["Description"].Value.ToString();
                cboBoxCategory.SelectedItem = row.Cells["Category"].Value.ToString();
            }
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchProduct.Text == "Enter keyword...")
                return;

            LoadProducts(cboBoxCategorySearch.SelectedItem.ToString(),txtSearchProduct.Text);
        }

        private void cboBoxCategorySearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProducts(cboBoxCategorySearch.SelectedItem.ToString(),txtSearchProduct.Text == "Enter keyword..." ? "" : txtSearchProduct.Text);
        }

        private void txtSearchProduct_Enter(object sender, EventArgs e)
        {
            if (txtSearchProduct.Text == "Enter keyword...")
            {
                txtSearchProduct.Text = "";
            }
        }

        private void txtSearchProduct_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchProduct.Text))
            {
                txtSearchProduct.Text = "Enter keyword...";
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' &&
                e.KeyChar != (char)Keys.Back)
                e.Handled = true;

            if (e.KeyChar == '.' && txtPrice.Text.Contains('.'))
                e.Handled = true;
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
    }
}
