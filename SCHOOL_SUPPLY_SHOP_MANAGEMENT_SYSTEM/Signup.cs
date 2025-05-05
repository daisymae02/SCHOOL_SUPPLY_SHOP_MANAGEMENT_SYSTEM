using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCHOOL_SUPPLY_SHOP_MANAGEMENT_SYSTEM
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

        private void btnSignup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void Signup_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void hideShow2_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar)
            {
                txtPassword.UseSystemPasswordChar = false;
                hideShow2.Image = Properties.Resources.show__1_;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                hideShow2.Image = Properties.Resources.hide__2_;
            }
        }

        private void hideShow1_Click(object sender, EventArgs e)
        {
            if (txtConfirmPassword.UseSystemPasswordChar)
            {
                txtConfirmPassword.UseSystemPasswordChar = false;
                hideShow1.Image = Properties.Resources.show__1_;
            }
            else
            {
                txtConfirmPassword.UseSystemPasswordChar = true;
                hideShow1.Image = Properties.Resources.hide__2_;
            }
        }

        private void txtLastname_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLastname.Text))
            {
                errorLastname.Visible = true;
            }
            else
            {
                errorLastname.Visible = false;
            }
        }

        private void txtFirstname_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstname.Text))
            {
                errorFirstname.Visible = true;
            }
            else
            {
                errorFirstname.Visible = false;
            }
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                errorAddress.Visible = true;
            }
            else
            {
                errorAddress.Visible = false;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorEmail.Visible = true;
            }
            else
            {
                if (!IsValidEmail(txtEmail.Text))
                {
                    errorEmail.Visible = true;
                }
                else
                {
                    errorEmail.Visible = false;
                }
            }
        }

        private void txtMobileNumber_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMobileNumber.Text))
            {
                errorMobileNumber.Visible = true;
            }
            else
            {
                errorMobileNumber.Visible = false;
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                errorUsername.Visible = true;
            }
            else
            {
                errorUsername.Visible = false;
            }
        }

        private void pickerDob_ValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pickerDob.Text))
            {
                errorDob.Visible = true;
            }
            else
            {
                errorDob.Visible = false;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errorPassword.Visible = true;
            }
            else
            {
                errorPassword.Visible = false;
            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                errorConfirmPassword.Text = "*Confirm your password";
                errorConfirmPassword.Visible = true;
            }
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                errorConfirmPassword.Text = "*Password doesn't match";
                errorConfirmPassword.Visible = true;
            }
            else
            {
                errorConfirmPassword.Visible = false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            errorLastname.Visible = false;
            errorFirstname.Visible = false;
            errorDob.Visible = false;
            errorGender.Visible = false;
            errorAddress.Visible = false;
            errorEmail.Visible = false;
            errorMobileNumber.Visible = false;
            errorUsername.Visible = false;
            errorPassword.Visible = false;
            errorConfirmPassword.Visible = false;

            bool hasError = false;

            if (string.IsNullOrEmpty(txtLastname.Text))
            {
                errorLastname.Visible = true;
                hasError = true;
            }
            if (string.IsNullOrEmpty(txtFirstname.Text))
            {
                errorFirstname.Visible = true;
                hasError = true;
            }
            if (string.IsNullOrEmpty(pickerDob.Text))
            {
                errorDob.Visible = true;
                hasError = true;
            }
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                errorAddress.Visible = true;
                hasError = true;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorEmail.Visible = true;
                hasError = true;
            }
            else
            {
                if (!IsValidEmail(txtEmail.Text))
                {
                    errorEmail.Visible = true;
                }
            }
            if (string.IsNullOrEmpty(txtMobileNumber.Text))
            {
                errorMobileNumber.Visible = true;
                hasError = true;
            }
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                errorUsername.Visible = true;
                hasError = true;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errorPassword.Visible = true;
                hasError = true;
            }
            if (!string.IsNullOrEmpty(txtPassword.Text) && string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                errorConfirmPassword.Text = "*Confirm your password";
                errorConfirmPassword.Visible = true;
                hasError = true;
            }
            else if (txtPassword.Text != txtConfirmPassword.Text)
            {
                errorConfirmPassword.Text = "*Password doesn't match";
                errorConfirmPassword.Visible = true;
                hasError = true;
            }
            if (hasError)
            {
                return;
            }

            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}