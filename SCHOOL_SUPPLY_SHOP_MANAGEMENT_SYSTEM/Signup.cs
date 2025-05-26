using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCHOOL_SUPPLY_SHOP_MANAGEMENT_SYSTEM
{
    public partial class Signup : Form
    {
        private bool isSignup;
        public Signup(bool is_signup = false)
        {
            InitializeComponent();
            LoadRoleDropdown();
            pickerDob.MaxDate = DateTime.Today.AddYears(-18);
            pickerDob.MinDate = DateTime.Today.AddYears(-100);
            pickerDob.Value = DateTime.Today.AddYears(-18);
            this.isSignup = is_signup;
            if (isSignup == true)
            {
                btnSignup.Text = "Create New Account";
                btnBackLogin.Visible = false;
                label13.Visible = false;
            }
        }

        private void LoadRoleDropdown()
        {
            cmbRole.Items.Add(" ");
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("Staff");

            cmbRole.SelectedIndex = 0;
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }
        private bool IsValidMobileNumber(string mobile)
        {
            string pattern = @"^09\d{9}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(mobile);
        }

        private void btnBackLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void Signup_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Login login = new Login();
            //login.Show();
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
                if (!IsValidMobileNumber(txtMobileNumber.Text.Trim()))
                {
                    errorMobileNumber.Visible = true;
                }
                else
                {
                    errorMobileNumber.Visible = false;
                }
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
            DateTime dob = pickerDob.Value;
            int age = DateTime.Today.Year - dob.Year;
            if (dob > DateTime.Today.AddYears(-age)) age--;

            if (age < 18)
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

        private void btnSignup_Click(object sender, EventArgs e)
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
            if (!rbuttonMale.Checked && !rbuttonFemale.Checked)
            {
                errorGender.Visible = true;
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
            else
            {

                if (!IsValidMobileNumber(txtMobileNumber.Text.Trim()))
                {
                    errorMobileNumber.Visible = true;
                    hasError = true;
                }
            }

            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                errorUsername.Visible = true;
                hasError = true;
            }
            if (string.IsNullOrWhiteSpace(cmbRole.Text))
            {
                errorRole.Visible = true;
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

            string connectionString = "Data Source=ESTORBA-PC\\SQLEXPRESS02;Initial Catalog=MANAGEMENT_SYSTEM;Integrated Security=True;Encrypt=False;";
            string query = "INSERT INTO Users (userLname, userFname, userMname, userDob, userGender, userAddress, userMobile, userEmail, userRole, userName, userPassword, userStatus)" +
                           "VALUES (@lastname, @firstname, @middlename, @dob, @gender, @address, @mobile, @email, @role, @username, @password, 'Active')";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    string gender = rbuttonMale.Checked ? "M" : (rbuttonFemale.Checked ? "F" : "");

                    command.Parameters.AddWithValue("@lastname", txtLastname.Text);
                    command.Parameters.AddWithValue("@firstname", txtFirstname.Text);
                    command.Parameters.AddWithValue("@middlename", txtMiddlename.Text);
                    command.Parameters.AddWithValue("@dob", pickerDob.Value);
                    command.Parameters.AddWithValue("@gender", gender);
                    command.Parameters.AddWithValue("@address", txtAddress.Text);
                    command.Parameters.AddWithValue("@mobile", txtMobileNumber.Text);
                    command.Parameters.AddWithValue("@email", txtEmail.Text);
                    command.Parameters.AddWithValue("@role", cmbRole.Text);
                    command.Parameters.AddWithValue("@username", txtUsername.Text);
                    command.Parameters.AddWithValue("@password", txtPassword.Text);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        using (var info = new Information("SUCCESS", "User added successfully!"))
                        {
                            info.ShowDialog();
                        }
                        Login login = Application.OpenForms.OfType<Login>().FirstOrDefault();
                        if (login != null)
                        {
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void txtMobileNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block the input
            }
        }

        private void rbuttonFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbuttonMale.Checked || rbuttonFemale.Checked)
            {
                errorGender.Visible = false;
            }
        }

        private void rbuttonMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbuttonMale.Checked || rbuttonFemale.Checked)
            {
                errorGender.Visible = false;
            }
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cmbRole.Text))
            {
                errorRole.Visible = false;
            }
        }
    }
}