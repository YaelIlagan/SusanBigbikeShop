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
    public partial class SalesForm : Form
    {
        private string selectedPayment = "";

        private double cartTotal = 0;
        public SalesForm()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts(string category = "All", string search = "")
        {
            dataGridItems.Rows.Clear();

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();

                    string query = @"SELECT item_id, item_name, category,
                                    unit_price, quantity_in_stock
                                    FROM Inventory
                                    WHERE (@category = 'All' OR category = @category)
                                    AND item_name LIKE @search
                                    AND quantity_in_stock > 0";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@category", category);
                        cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataGridItems.Rows.Add(
                                    reader["item_id"].ToString(),
                                    reader["item_name"].ToString(),
                                    reader["category"].ToString(),
                                    Convert.ToDouble(reader["unit_price"]).ToString("N2"),
                                    reader["quantity_in_stock"].ToString()
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

        private void AddToCart()
        {
            if (dataGridItems.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a product to add.",
                    "No Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DataGridViewRow selected = dataGridItems.SelectedRows[0];
            string itemId = selected.Cells["ItemID"].Value.ToString();
            string itemName = selected.Cells["ItemName"].Value.ToString();
            double unitPrice = double.Parse(
                selected.Cells["UnitPrice"].Value.ToString().Replace(",", ""));
            int stock = int.Parse(selected.Cells["Stock"].Value.ToString());

            foreach (DataGridViewRow row in dataGridCart.Rows)
            {
                if (row.Cells["CartItemID"].Value.ToString() == itemId)
                {
                    int currentQty = int.Parse(row.Cells["Quantity"].Value.ToString());
                    if (currentQty >= stock)
                    {
                        MessageBox.Show(
                            "Not enough stock available.",
                            "Stock Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }
                    currentQty++;
                    row.Cells["Quantity"].Value = currentQty;
                    row.Cells["Subtotal"].Value = (unitPrice * currentQty).ToString("N2");
                    UpdateTotal();
                    return;
                }
            }

            dataGridCart.Rows.Add(
                itemId,
                itemName,
                unitPrice.ToString("N2"),
                1,
                unitPrice.ToString("N2")
            );

            UpdateTotal();
        }

        private void UpdateTotal()
        {
            cartTotal = 0;
            foreach (DataGridViewRow row in dataGridCart.Rows)
            {
                cartTotal += double.Parse(
                    row.Cells["Subtotal"].Value.ToString().Replace(",", ""));
            }
            lblTotal.Text = cartTotal.ToString("N2");
        }

        private void btnSalesSearchItem_Click(object sender, EventArgs e)
        {
            LoadProducts("All", txtSalesSearchItem.Text);
        }

        private void btnSalesClearCart_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSalesCashPayment_Click(object sender, EventArgs e)
        {
            selectedPayment = "CASH";
            btnSalesCashPayment.BackColor = Color.DarkRed;
            btnSalesOnlinePayment.BackColor = Color.FromArgb(58, 22, 30);

        }

        private void btnSalesOnlinePayment_Click(object sender, EventArgs e)
        {
            selectedPayment = "ONLINE";
            btnSalesOnlinePayment.BackColor = Color.DarkRed;
            btnSalesCashPayment.BackColor = Color.FromArgb(58, 22, 30);
        }

        private void btnSalesProceedPayment_Click(object sender, EventArgs e)
        {
            if (dataGridCart.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Cart is empty. Please add items before proceeding.",
                    "Empty Cart",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DialogResult result = MessageBox.Show(
                "Proceed payment of ₱" + cartTotal.ToString("N2") +
                " via " + selectedPayment + "?",
                "Confirm Payment",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
                    {
                        conn.Open();
                        SqlTransaction transaction = conn.BeginTransaction();

                        try
                        {
                            string salesQuery = @"INSERT INTO Sales
                                                (total_amount, payment_method)
                                                VALUES (@totalAmount, @paymentMethod);
                                                SELECT SCOPE_IDENTITY();";

                            int saleId;
                            using (SqlCommand cmd = new SqlCommand(salesQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@totalAmount", cartTotal);
                                cmd.Parameters.AddWithValue("@paymentMethod", selectedPayment);
                                saleId = Convert.ToInt32(cmd.ExecuteScalar());
                            }

                            foreach (DataGridViewRow row in dataGridCart.Rows)
                            {
                                int itemId = int.Parse(row.Cells["CartItemID"].Value.ToString());
                                double unitPrice = double.Parse(row.Cells["UnitPrice"].Value.ToString().Replace(",", ""));
                                int qty = int.Parse(row.Cells["Quantity"].Value.ToString());
                                double subtotal = double.Parse(row.Cells["Subtotal"].Value.ToString().Replace(",", ""));

                                string itemQuery = @"INSERT INTO SalesItem
                                                    (sale_id, item_id, quantity,
                                                    unit_price, subtotal)
                                                    VALUES
                                                    (@saleId, @itemId, @qty,
                                                    @unitPrice, @subtotal)";

                                using (SqlCommand cmd = new SqlCommand(
                                    itemQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@saleId", saleId);
                                    cmd.Parameters.AddWithValue("@itemId", itemId);
                                    cmd.Parameters.AddWithValue("@qty", qty);
                                    cmd.Parameters.AddWithValue("@unitPrice", unitPrice);
                                    cmd.Parameters.AddWithValue("@subtotal", subtotal);
                                    cmd.ExecuteNonQuery();
                                }

                                string stockQuery = @"UPDATE Inventory
                                                    SET quantity_in_stock =
                                                    quantity_in_stock - @qty
                                                    WHERE item_id = @itemId";

                                using (SqlCommand cmd = new SqlCommand(
                                    stockQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@qty", qty);
                                    cmd.Parameters.AddWithValue("@itemId", itemId);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();

                            MessageBox.Show(
                                "Payment successful!\nTotal: ₱" +
                                cartTotal.ToString("N2") +
                                "\nPayment: " + selectedPayment,
                                "Payment Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );

                            dataGridCart.Rows.Clear();
                            cartTotal = 0;
                            lblTotal.Text = "0.00";
                            LoadProducts();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show(
                                "Error processing payment: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Database connection error: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void btnPartsCategory_Click(object sender, EventArgs e)
        {
            btnPartsCategory.BackColor = System.Drawing.Color.DarkRed;
            btnOilsCategory.BackColor = System.Drawing.Color.FromArgb(58, 22, 30);
            btnAccessories.BackColor = System.Drawing.Color.FromArgb(58, 22, 30);
            LoadProducts("Parts", txtSalesSearchItem.Text);
        }

        private void btnOilsCategory_Click(object sender, EventArgs e)
        {
            btnOilsCategory.BackColor = System.Drawing.Color.DarkRed;
            btnPartsCategory.BackColor = System.Drawing.Color.FromArgb(58, 22, 30);
            btnAccessories.BackColor = System.Drawing.Color.FromArgb(58, 22, 30);
            LoadProducts("Oils", txtSalesSearchItem.Text);
        }

        private void btnAccessories_Click(object sender, EventArgs e)
        {
            btnAccessories.BackColor = System.Drawing.Color.DarkRed;
            btnPartsCategory.BackColor = System.Drawing.Color.FromArgb(58, 22, 30);
            btnOilsCategory.BackColor = System.Drawing.Color.FromArgb(58, 22, 30);
            LoadProducts("Accessories", txtSalesSearchItem.Text);
        }
    }
}
