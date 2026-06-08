using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SusanBigbikeShop
{
    public partial class UserAuth : Form
    {
        public UserAuth()
        {
            InitializeComponent();
            ShowLogin();
            this.FormClosed += (s, e) => Application.Exit();

        }

        public void ShowLogin()
        {
            panelUserAuth.Controls.Clear();

            LogIn loginForm = new LogIn(this);
            loginForm.FormBorderStyle = FormBorderStyle.None;
            loginForm.TopLevel = false;
            loginForm.Dock = DockStyle.Fill;
            panelUserAuth.Controls.Add(loginForm);
            loginForm.Show();
        }

        public void ShowSignUp()
        {
            panelUserAuth.Controls.Clear();

            SignUp signUpForm = new SignUp(this);
            signUpForm.FormBorderStyle = FormBorderStyle.None;
            signUpForm.TopLevel = false;
            signUpForm.Dock = DockStyle.Fill;
            panelUserAuth.Controls.Add(signUpForm);
            signUpForm.Show();
        }
    }
}
