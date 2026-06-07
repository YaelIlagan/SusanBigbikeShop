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
            LoadCategories();
            LoadProducts();
        }

        private void LoadCategories()
        {
            cboBoxCategory.Items.Clear();
            cboBoxCategory.Items.Add("All");
            cboBoxCategory.Items.Add("Parts");
            cboBoxCategory.Items.Add("Oils");
            cboBoxCategory.Items.Add("Accessories");
            cboBoxCategory.SelectedIndex = 0;
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
                                int rowIndex = dataGridItems.Rows.Add(
                                    reader["item_id"].ToString(),
                                    reader["item_name"].ToString(),
                                    reader["category"].ToString(),
                                    Convert.ToDouble(reader["unit_price"]).ToString("N2"),
                                    reader["quantity_in_stock"].ToString()
                                );

                                dataGridItems.Rows[rowIndex]
                                    .Cells["ProductToCart"].Value = "Add to Cart";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToCart(int rowIndex)
        {
            try
            {
                DataGridViewRow selected = dataGridItems.Rows[rowIndex];
                string itemId = selected.Cells["ItemID"].Value.ToString();
                string itemName = selected.Cells["ItemName"].Value.ToString();
                double unitPrice = double.Parse(
                    selected.Cells["UnitPrice"].Value.ToString().Replace(",", ""));
                int stock = int.Parse(selected.Cells["Stock"].Value.ToString());

                foreach (DataGridViewRow row in dataGridCart.Rows)
                {
                    if (row.Cells["CartItemID"].Value != null &&
                        row.Cells["CartItemID"].Value.ToString() == itemId)
                    {
                        int currentQty = int.Parse(row.Cells["Quantity"].Value.ToString());

                        if (currentQty >= stock)
                        {
                            MessageBox.Show("Not enough stock available.",
                                "Stock Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        currentQty++;
                        row.Cells["Quantity"].Value = currentQty;
                        row.Cells["Subtotal"].Value = (unitPrice * currentQty).ToString("N2");
                        UpdateTotal();
                        return;
                    }
                }

                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dataGridCart);
                newRow.Cells[dataGridCart.Columns["CartItemID"].Index].Value = itemId;
                newRow.Cells[dataGridCart.Columns["CartItemName"].Index].Value = itemName;
                newRow.Cells[dataGridCart.Columns["CartUnitPrice"].Index].Value = unitPrice.ToString("N2");
                newRow.Cells[dataGridCart.Columns["Quantity"].Index].Value = 1;
                newRow.Cells[dataGridCart.Columns["Subtotal"].Index].Value = unitPrice.ToString("N2");

                dataGridCart.Rows.Add(newRow);
                UpdateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding to cart: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTotal()
        {
            cartTotal = 0;
            foreach (DataGridViewRow row in dataGridCart.Rows)
            {
                if (row.Cells["Subtotal"].Value != null)
                    cartTotal += double.Parse(
                        row.Cells["Subtotal"].Value.ToString().Replace(",", ""));
            }
            lblTotal.Text = cartTotal.ToString("N2");
        }

        private void txtSalesSearchItem_TextChanged(object sender, EventArgs e)
        {
            if (txtSalesSearchItem.Text == "Enter keyword...") return;
            LoadProducts(cboBoxCategory.SelectedItem.ToString(), txtSalesSearchItem.Text);
        }

        private void cboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProducts(cboBoxCategory.SelectedItem.ToString(), txtSalesSearchItem.Text == "Enter keyword..." ? "" : txtSalesSearchItem.Text);
        }

        private void dataGridItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 &&
                dataGridItems.Columns[e.ColumnIndex].Name == "ProductToCart")
            {
                AddToCart(e.RowIndex);
            }
        }

        private void btnSalesClearCart_Click(object sender, EventArgs e)
        {
            if (dataGridCart.Rows.Count == 0) return;

            DialogResult result = MessageBox.Show(
                "Are you sure you want to clear the cart?",
                "Clear Cart", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                dataGridCart.Rows.Clear();
                cartTotal = 0;
                lblTotal.Text = "0.00";
            }
        }

        private void btnSalesCashPayment_Click(object sender, EventArgs e)
        {
            selectedPayment = "CASH";
            btnSalesCashPayment.BackColor = Color.FromArgb(180, 140, 20);
            btnSalesOnlinePayment.BackColor = Color.FromArgb(70, 130, 180);
        }

        private void btnSalesOnlinePayment_Click(object sender, EventArgs e)
        {
            selectedPayment = "ONLINE";
            btnSalesOnlinePayment.BackColor = Color.FromArgb(40, 90, 140);
            btnSalesCashPayment.BackColor = Color.FromArgb(212, 175, 55);
        }

        private void btnSalesProceedPayment_Click(object sender, EventArgs e)
        {
            if (dataGridCart.Rows.Count == 0)
            {
                MessageBox.Show("Cart is empty. Please add items before proceeding.",
                    "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(selectedPayment))
            {
                MessageBox.Show("Please select a payment method.",
                    "No Payment Method", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double cashGiven = 0;
            double change = 0;
            string transactionRef = "";

            if (selectedPayment == "CASH")
            {
                CashPaymentForm cashForm = new CashPaymentForm(cartTotal);
                if (cashForm.ShowDialog() != DialogResult.OK) return;

                cashGiven = cashForm.CashGiven;
                change = cashForm.Change;
            }
            else if (selectedPayment == "ONLINE")
            {
                OnlinePaymentForm onlineForm = new OnlinePaymentForm(cartTotal);
                if (onlineForm.ShowDialog() != DialogResult.OK) return;

                transactionRef = onlineForm.TransactionNumber;
            }

            DialogResult confirm = MessageBox.Show(
                "Proceed payment of ₱" + cartTotal.ToString("N2") +
                " via " + selectedPayment + "?",
                "Confirm Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            double finalTotal = cartTotal;
            double finalCash = cashGiven;
            double finalChange = change;
            string finalPayment = selectedPayment;
            string finalRef = transactionRef;

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        string paymentNote = finalPayment == "ONLINE"
                            ? "ONLINE (Ref: " + finalRef + ")"
                            : "CASH";

                        string salesQuery = @"INSERT INTO Sales (total_amount, payment_method)
                                             VALUES (@totalAmount, @paymentMethod);
                                             SELECT SCOPE_IDENTITY();";

                        int saleId;
                        using (SqlCommand cmd = new SqlCommand(salesQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@totalAmount", finalTotal);
                            cmd.Parameters.AddWithValue("@paymentMethod", paymentNote);
                            saleId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        var itemLines = new List<string>();
                        var amountLines = new List<string>();

                        foreach (DataGridViewRow row in dataGridCart.Rows)
                        {
                            int itemId = int.Parse(row.Cells["CartItemID"].Value.ToString());
                            string itemName = row.Cells["CartItemName"].Value.ToString();
                            double unitPrice = double.Parse(
                                row.Cells["CartUnitPrice"].Value.ToString().Replace(",", ""));
                            int qty = int.Parse(row.Cells["Quantity"].Value.ToString());
                            double subtotal = double.Parse(
                                row.Cells["Subtotal"].Value.ToString().Replace(",", ""));

                            string itemQuery = @"INSERT INTO SalesItem
                                                (sale_id, item_id, quantity, unit_price, subtotal)
                                                VALUES (@saleId, @itemId, @qty, @unitPrice, @subtotal)";

                            using (SqlCommand cmd = new SqlCommand(itemQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@saleId", saleId);
                                cmd.Parameters.AddWithValue("@itemId", itemId);
                                cmd.Parameters.AddWithValue("@qty", qty);
                                cmd.Parameters.AddWithValue("@unitPrice", unitPrice);
                                cmd.Parameters.AddWithValue("@subtotal", subtotal);
                                cmd.ExecuteNonQuery();
                            }

                            string stockQuery = @"UPDATE Inventory
                                                 SET quantity_in_stock = quantity_in_stock - @qty
                                                 WHERE item_id = @itemId";

                            using (SqlCommand cmd = new SqlCommand(stockQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@qty", qty);
                                cmd.Parameters.AddWithValue("@itemId", itemId);
                                cmd.ExecuteNonQuery();
                            }

                            itemLines.Add(itemName + " x" + qty);
                            amountLines.Add(subtotal.ToString("N2"));
                        }

                        transaction.Commit();

                        dataGridCart.Rows.Clear();
                        cartTotal = 0;
                        lblTotal.Text = "0.00";
                        selectedPayment = "";
                        btnSalesCashPayment.BackColor = Color.FromArgb(58, 22, 30);
                        btnSalesOnlinePayment.BackColor = Color.FromArgb(58, 22, 30);
                        LoadProducts();

                        ReceiptForm receipt = new ReceiptForm(
                            saleId,
                            DateTime.Now,
                            "Staff",
                            itemLines,
                            amountLines,
                            finalTotal,
                            finalPayment,
                            finalCash,
                            finalChange,
                            finalRef);

                        receipt.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error processing payment: " + ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSalesSearchItem_Enter(object sender, EventArgs e)
        {
            if (txtSalesSearchItem.Text == "Enter keyword...")
                txtSalesSearchItem.Text = "";
        }

        private void txtSalesSearchItem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSalesSearchItem.Text))
                txtSalesSearchItem.Text = "Enter keyword...";
        }
    }
}
