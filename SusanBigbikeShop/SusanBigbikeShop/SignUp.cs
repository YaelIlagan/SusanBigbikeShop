using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SusanBigbikeShop
{
    public partial class SignUp : Form
    {
        private readonly UserAuth _parent;

        public SignUp(UserAuth parent)
        {
            InitializeComponent();
            _parent = parent;

            txtPassword.PasswordChar = '●';
            txtConfirmPass.PasswordChar = '●';
            this.FormClosed += (s, e) => Application.Exit();

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPass = txtConfirmPass.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPass))
            {
                MessageBox.Show("All fields are required.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (username.Length < 4)
            {
                MessageBox.Show("Username must be at least 4 characters long.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9_]+$"))
            {
                MessageBox.Show("Username can only contain letters, numbers, and underscores.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (password != confirmPass)
            {
                MessageBox.Show("Passwords do not match. Please re-enter.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPass.Clear();
                txtConfirmPass.Focus();
                return;
            }

            try
            {
                DBConnection db = new DBConnection();
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE username = @username";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@username", username);
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Username already exists. Please choose a different one.",
                                "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtUsername.Focus();
                            return;
                        }
                    }

                    string insertUserQuery = @"
                        INSERT INTO Users (username, password, role, full_name)
                        OUTPUT INSERTED.user_id
                        VALUES (@username, @password, 'Customer', @fullName)";

                    int newUserId;
                    using (SqlCommand insertCmd = new SqlCommand(insertUserQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@username", username);
                        insertCmd.Parameters.AddWithValue("@password", password);
                        insertCmd.Parameters.AddWithValue("@fullName", username);

                        newUserId = (int)insertCmd.ExecuteScalar();
                    }

                    string insertCustomerQuery = @"
                        INSERT INTO Customer (user_id, full_name)
                        VALUES (@userId, @fullName)";

                    using (SqlCommand custCmd = new SqlCommand(insertCustomerQuery, conn))
                    {
                        custCmd.Parameters.AddWithValue("@userId", newUserId);
                        custCmd.Parameters.AddWithValue("@fullName", username);
                        custCmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Account created successfully!\n\nYou can now log in with your new credentials.",
                    "Registration Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                _parent.ShowLogin();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message,
                    "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linklblLogIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _parent.ShowLogin();
        }

        private void checkBoxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtConfirmPass.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '●';
                txtConfirmPass.PasswordChar = '●';
            }
        }
    }
}
