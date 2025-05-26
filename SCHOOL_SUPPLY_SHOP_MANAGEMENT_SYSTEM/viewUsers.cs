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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SCHOOL_SUPPLY_SHOP_MANAGEMENT_SYSTEM
{
    public partial class viewUsers : Form
    {
        public int _userId;
        string connectionString = @"Data Source=ESTORBA-PC\SQLEXPRESS02;Initial Catalog=MANAGEMENT_SYSTEM;Integrated Security=True;Encrypt=False;";
        private Image originalImage;
        public viewUsers(int userId)
        {
            InitializeComponent();
            _userId = userId;
            fetchUserDetail(userId);
            profileImage.Image = originalImage;
            profileImage.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void fetchUserDetail(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Users WHERE userID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string lastname = reader["userLname"].ToString();
                        string firstname = reader["userFname"].ToString();
                        string middlename = reader["userMname"].ToString();
                        string role = reader["userRole"].ToString();

                        // Parse and format DOB
                        string dobRaw = reader["userDob"].ToString();
                        DateTime dobValue;
                        string dobFormatted = "";
                        if (DateTime.TryParse(dobRaw, out dobValue))
                        {
                            dobFormatted = dobValue.ToString("MMMM dd, yyyy");
                        }

                        // Map gender code to full text
                        string genderCode = reader["userGender"].ToString();
                        string genderFull = genderCode == "M" ? "Male" : genderCode == "F" ? "Female" : "Other";

                        string address = reader["userAddress"].ToString();
                        string phone = reader["userMobile"].ToString();
                        string email = reader["userEmail"].ToString();
                        string username = reader["userName"].ToString();
                        string password = reader["userPassword"].ToString();

                        // Get image
                        byte[] imageBytes = reader["userImage"] as byte[];
                        Image userImage = null;
                        if (imageBytes != null && imageBytes.Length > 0)
                        {
                            using (var ms = new System.IO.MemoryStream(imageBytes))
                            {
                                userImage = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            // Assign default image from resources
                            userImage = Properties.Resources.user;
                        }

                        string middleInitial = !string.IsNullOrEmpty(middlename) ? middlename[0].ToString() + "." : "";

                        lblFullname.Text = $"{lastname}, {firstname} {middleInitial}";
                        originalImage = userImage;
                        lblRole.Text = role;
                        if (role == "Staff")

                        // View Panels
                        lblFullname2.Text = $"{lastname}, {firstname} {middlename}";
                        lblDob.Text = dobFormatted;
                        lblGender.Text = genderFull;
                        lblAddress.Text = address;
                        lblPhone.Text = phone;
                        lblEmail.Text = email;
                        lblUsername.Text = username;
                        lblPassword.Text = new string('*', password.Length);
                    }
                    else
                    {
                        MessageBox.Show("User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
