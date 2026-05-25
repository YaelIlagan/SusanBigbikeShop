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
    public partial class RestockItemForm : Form
    {
        public bool IsSaved { get; private set; } = false;

        private string _itemId;

        public RestockItemForm(string itemId, string itemName, string category, int currentStock, int minThreshold)
        {
            InitializeComponent();
            LoadCategories();
            this.FormBorderStyle = FormBorderStyle.None;

            _itemId = itemId;
            txtProductName.Text = itemName;
            txtProductName.ReadOnly = true;
            cboxCategory.SelectedItem = category;
            txtCurrentStock.Text = currentStock.ToString();
            txtCurrentStock.ReadOnly = true;
            txtMinimunStockThreshold.Text = minThreshold.ToString();
            txtAddQuantity.Text = "0";
        }

        private void LoadCategories()
        {
            cboxCategory.Items.Clear();
            cboxCategory.Items.Add("Parts");
            cboxCategory.Items.Add("Oils");
            cboxCategory.Items.Add("Accessories");
            cboxCategory.SelectedIndex = 0;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                e.Cancel = true;
            base.OnFormClosing(e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                int addQty = int.Parse(txtAddQuantity.Text);
                int minThreshold = int.Parse(txtMinimunStockThreshold.Text);

                using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();

                    string query = @"UPDATE Inventory SET
                                    quantity_in_stock = quantity_in_stock + @addQty,
                                    low_stock_threshold = @minThreshold,
                                    category = @category
                                    WHERE item_id = @itemId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@addQty", addQty);
                        cmd.Parameters.AddWithValue("@minThreshold", minThreshold);
                        cmd.Parameters.AddWithValue("@category",
                            cboxCategory.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@itemId", _itemId);
                        cmd.ExecuteNonQuery();
                    }
                }

                IsSaved = true;

                MessageBox.Show(
                    "Item restocked successfully!\nAdded " + addQty + " units.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.FormClosing -= null;
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error restocking item: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
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
                IsSaved = false;
                this.FormClosing -= null;
                this.Dispose();
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtAddQuantity.Text) ||
                string.IsNullOrWhiteSpace(txtMinimunStockThreshold.Text) ||
                cboxCategory.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please fill in all required fields.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }

            if (!int.TryParse(txtAddQuantity.Text, out int addQty) || addQty <= 0)
            {
                MessageBox.Show(
                    "Add Quantity must be a valid number greater than 0.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtAddQuantity.Focus();
                return false;
            }

            if (!int.TryParse(txtMinimunStockThreshold.Text, out int minThreshold)
                || minThreshold < 0)
            {
                MessageBox.Show(
                    "Minimum Stock Threshold must be a valid number.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtMinimunStockThreshold.Focus();
                return false;
            }

            return true;
        }

        private void txtAddQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void txtMinimunStockThreshold_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
    }
}
