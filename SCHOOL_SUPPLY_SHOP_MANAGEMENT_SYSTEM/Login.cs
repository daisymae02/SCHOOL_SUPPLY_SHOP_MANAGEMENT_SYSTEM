using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace SCHOOL_SUPPLY_SHOP_MANAGEMENT_SYSTEM
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnSignup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();
            //this.Hide();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=ESTORBA-PC\SQLEXPRESS02;Initial Catalog=MANAGEMENT_SYSTEM;Integrated Security=True;Encrypt=False;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT userID FROM Users WHERE userName=@username AND userPassword=@password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = txtUsername.Text;
                cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = txtPassword.Text;

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    int userId = Convert.ToInt32(result);

                    string query1 = "SELECT * FROM Users WHERE userID = @id";
                    SqlCommand cmd1 = new SqlCommand(query1, conn);
                    cmd1.Parameters.Add("@id", SqlDbType.Int).Value = userId;

                    using (SqlDataReader reader = cmd1.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int user_id = Convert.ToInt32(reader["userId"]);
                            string role = reader["userRole"].ToString();

                            SidebarMenu menu = new SidebarMenu(user_id);
                            staffHomepage staffHomepage = new staffHomepage(user_id);
                            this.Hide();

                            if (role == "Admin")
                            {
                                menu.Show();
                            }
                            else if (role == "Staff")
                            {
                                staffHomepage.Show();
                            }

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void hideShow_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar)
            {
                txtPassword.UseSystemPasswordChar = false;
                hideShow.Image = Properties.Resources.show__1_;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                hideShow.Image = Properties.Resources.hide__2_;
            }
        }
    }
}
