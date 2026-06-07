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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SusanBigbikeShop
{
    public partial class ManageUsersForm : Form
    {
        public ManageUsersForm()
        {
            InitializeComponent();
            LoadComboBoxes();
            LoadUsers();
            txtProductID.ReadOnly = true;
        }

        private void LoadComboBoxes()
        {
            cboBoxRole.Items.Clear();
            cboBoxRole.Items.Add("Customer");
            cboBoxRole.Items.Add("Staff");
            cboBoxRole.SelectedIndex = 0;

            cboBoxStatus.Items.Clear();
            cboBoxStatus.Items.Add("Active");
            cboBoxStatus.Items.Add("Inactive");
            cboBoxStatus.SelectedIndex = 0;

            cboBoxUsers.Items.Clear();
            cboBoxUsers.Items.Add("All Roles");
            cboBoxUsers.Items.Add("Customer");
            cboBoxUsers.Items.Add("Staff");
            cboBoxUsers.SelectedIndex = 0;

            cboBoxSearchStatus.Items.Clear();
            cboBoxSearchStatus.Items.Add("All Status");
            cboBoxSearchStatus.Items.Add("Active");
            cboBoxSearchStatus.Items.Add("Inactive");
            cboBoxSearchStatus.SelectedIndex = 0;
        }

        private void LoadUsers(string search = "", string role = "All Roles", string status = "All Status")
        {
            dataGridUserList.Rows.Clear();

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT u.user_id, u.username, u.full_name, u.role, u.password, ISNULL(u.status, 'Active') AS status
                        FROM Users u WHERE u.role <> 'Owner'
                        AND (@role = 'All Roles' OR u.role = @role)
                        AND (@status = 'All Status' OR ISNULL(u.status, 'Active') = @status)
                        AND (u.username LIKE @search OR u.full_name LIKE @search)
                        ORDER BY u.full_name";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@role", role);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataGridUserList.Rows.Add(
                                    reader["user_id"].ToString(),   
                                    reader["username"].ToString(),  
                                    reader["full_name"].ToString(), 
                                    reader["role"].ToString(),      
                                    reader["password"].ToString(),  
                                    reader["status"].ToString()     
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridUserList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridUserList.Rows[e.RowIndex];
            txtProductID.Text = row.Cells["UserID"].Value.ToString();
            txtProductName.Text = row.Cells["Username"].Value.ToString();
            txtQty.Text = row.Cells["FullName"].Value.ToString();
            txtPrice.Text = row.Cells["Password"].Value.ToString();
            cboBoxRole.SelectedItem = row.Cells["Role"].Value.ToString();
            cboBoxStatus.SelectedItem = row.Cells["Status"].Value.ToString();
        }
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text) || string.IsNullOrWhiteSpace(txtQty.Text) || string.IsNullOrWhiteSpace(txtPrice.Text) || cboBoxRole.SelectedIndex == -1 || cboBoxStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all required fields.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            if (txtProductName.Text.Trim().Length < 4)
            {
                MessageBox.Show("Username must be at least 4 characters.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtPrice.Text.Trim().Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            txtProductID.Clear();
            txtProductName.Clear();
            txtQty.Clear();
            txtPrice.Clear();
            cboBoxRole.SelectedIndex = 0;
            cboBoxStatus.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            string username = txtProductName.Text.Trim();
            string fullName = txtQty.Text.Trim();
            string password = txtPrice.Text.Trim();
            string role = cboBoxRole.SelectedItem.ToString();
            string status = cboBoxStatus.SelectedItem.ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE username = @username";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@username", username);
                        if ((int)checkCmd.ExecuteScalar() > 0)
                        {
                            MessageBox.Show("Username already exists.",
                                "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string query = @"
                        INSERT INTO Users (username, password, role, full_name, status)
                        OUTPUT INSERTED.user_id
                        VALUES (@username, @password, @role, @fullName, @status)";

                    int newUserId;
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@role", role);
                        cmd.Parameters.AddWithValue("@fullName", fullName);
                        cmd.Parameters.AddWithValue("@status", status);
                        newUserId = (int)cmd.ExecuteScalar();
                    }

                    if (role == "Customer")
                    {
                        string custQuery = "INSERT INTO Customer (user_id, full_name) VALUES (@userId, @fullName)";
                        using (SqlCommand custCmd = new SqlCommand(custQuery, conn))
                        {
                            custCmd.Parameters.AddWithValue("@userId", newUserId);
                            custCmd.Parameters.AddWithValue("@fullName", fullName);
                            custCmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("User added successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding user: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductID.Text))
            {
                MessageBox.Show("Please select a user to update.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (!ValidateForm()) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();

                    string query = @"
                        UPDATE Users SET
                            username  = @username,
                            full_name = @fullName,
                            password  = @password,
                            role      = @role,
                            status    = @status
                        WHERE user_id = @userId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", txtProductName.Text.Trim());
                        cmd.Parameters.AddWithValue("@fullName", txtQty.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", txtPrice.Text.Trim());
                        cmd.Parameters.AddWithValue("@role", cboBoxRole.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@status", cboBoxStatus.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@userId", int.Parse(txtProductID.Text));
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("User updated successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating user: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductID.Text))
            {
                MessageBox.Show("Please select a user to delete.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to delete this user?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM Users WHERE user_id = @userId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", int.Parse(txtProductID.Text));
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("User deleted successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting user: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void txtSearchUser_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearchUser.Text == "Enter keyword..." ? "" : txtSearchUser.Text;
            LoadUsers(keyword, cboBoxSearchStatus.SelectedItem.ToString(), cboBoxUsers.SelectedItem.ToString());
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearchUser.Text = "Enter keyword...";
            cboBoxUsers.SelectedIndex = 0;
            cboBoxSearchStatus.SelectedIndex = 0;
            LoadUsers();
        }

        private void txtSearchUser_Enter(object sender, EventArgs e)
        {
            if (txtSearchUser.Text == "Enter keyword...")
                txtSearchUser.Text = "";
        }

        private void txtSearchUser_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchUser.Text))
                txtSearchUser.Text = "Enter keyword...";
        }

    }
}
