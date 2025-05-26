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
    public partial class UserProfile : Form
    {
        string connectionString = @"Data Source=ESTORBA-PC\SQLEXPRESS02;Initial Catalog=MANAGEMENT_SYSTEM;Integrated Security=True;Encrypt=False;";

        private Image originalImage;
        public event Action? ProfileUpdated;
        private readonly Action? onLogout;
        private string OrigPassword;

        public int user_id;
        public UserProfile(int user_id, Action onProfileUpdated, Action? onLogout = null)
        {
            InitializeComponent();
            this.user_id = user_id;
            this.ProfileUpdated = onProfileUpdated;
            this.onLogout = onLogout;
            fetchUserDetail(user_id);
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
                        {
                            panelLogout.Visible = true;
                        }

                        // View Panels
                        lblFullname2.Text = $"{lastname}, {firstname} {middlename}";
                        lblDob.Text = dobFormatted;
                        lblGender.Text = genderFull;
                        lblAddress.Text = address;
                        lblPhone.Text = phone;
                        lblEmail.Text = email;
                        lblUsername.Text = username;
                        lblPassword.Text = new string('*', password.Length);
                        OrigPassword = password;

                        // Edit Panels
                        txtLastname.Text = lastname;
                        txtFirstname.Text = firstname;
                        txtMiddlename.Text = middlename;
                        txtAddress.Text = address;
                        pickerDob.Value = dobValue;
                        comboBoxGender.Text = genderFull;
                        txtPhone.Text = phone;
                        txtEmail.Text = email;
                        txtUsername.Text = username;
                    }
                    else
                    {
                        MessageBox.Show("User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnUpdateImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select an Image";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Image newImage = Image.FromFile(ofd.FileName);

                    // Update image
                    profileImage.Image = newImage;
                    profileImage.SizeMode = PictureBoxSizeMode.StretchImage;

                    // Show cancel button only if different from original
                    updateImageButtons.Visible = !ImagesAreEqual(newImage, originalImage);
                    btnUpdateImage.Text = "CHANGE IMAGE";
                }
            }
        }

        private bool ImagesAreEqual(Image img1, Image img2)
        {
            using (var ms1 = new System.IO.MemoryStream())
            using (var ms2 = new System.IO.MemoryStream())
            {
                img1.Save(ms1, System.Drawing.Imaging.ImageFormat.Png);
                img2.Save(ms2, System.Drawing.Imaging.ImageFormat.Png);

                byte[] imgBytes1 = ms1.ToArray();
                byte[] imgBytes2 = ms2.ToArray();

                return imgBytes1.SequenceEqual(imgBytes2);
            }
        }

        private void cancelUpdatingImage_Click(object sender, EventArgs e)
        {
            profileImage.Image = originalImage;
            profileImage.SizeMode = PictureBoxSizeMode.StretchImage;
            updateImageButtons.Visible = false;
            btnUpdateImage.Text = "UPDATE IMAGE";
        }

        private void saveNewImage_Click(object sender, EventArgs e)
        {
            if (profileImage.Image == null)
            {
                MessageBox.Show("No image selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                byte[] imageBytes;
                using (var ms = new System.IO.MemoryStream())
                {
                    profileImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    imageBytes = ms.ToArray();
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string updateQuery = "UPDATE Users SET userImage = @image WHERE userID = @id";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.Add("@image", SqlDbType.VarBinary).Value = imageBytes;
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = user_id;

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            using (var info = new Information("SUCCESS", "Profile image updated successfully!"))
                            {
                                info.ShowDialog();
                            }
                            originalImage = profileImage.Image;
                            updateImageButtons.Visible = false;
                            btnUpdateImage.Text = "UPDATE IMAGE";
                            ProfileUpdated?.Invoke();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditAbout_Click(object sender, EventArgs e)
        {
            viewAboutPanel.Visible = false;
            editAboutPanel.Visible = true;
        }

        private void btnAboutCancel_Click(object sender, EventArgs e)
        {
            viewAboutPanel.Visible = true;
            editAboutPanel.Visible = false;
        }

        private void btnEditContact_Click(object sender, EventArgs e)
        {
            viewContactPanel.Visible = false;
            editContactPanel.Visible = true;
        }

        private void btnContactCancel_Click(object sender, EventArgs e)
        {
            viewContactPanel.Visible = true;
            editContactPanel.Visible = false;
        }

        private void btnEditCred_Click(object sender, EventArgs e)
        {
            viewCredPanel.Visible = false;
            editCredPanel.Visible = true;
        }

        private void btnCredCancel_Click(object sender, EventArgs e)
        {
            viewCredPanel.Visible = true;
            editCredPanel.Visible = false;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            onLogout?.Invoke();
        }

        private void btnAboutSave_Click(object sender, EventArgs e)
        {
            // Hide all error labels
            errorLastname.Visible = false;
            errorFirstname.Visible = false;
            errorDob.Visible = false;
            errorGender.Visible = false;
            errorAddress.Visible = false;

            bool hasError = false;

            if (string.IsNullOrWhiteSpace(txtLastname.Text))
            {
                errorLastname.Visible = true;
                hasError = true;
            }
            if (string.IsNullOrWhiteSpace(txtFirstname.Text))
            {
                errorFirstname.Visible = true;
                hasError = true;
            }
            if (string.IsNullOrWhiteSpace(pickerDob.Text))
            {
                errorDob.Visible = true;
                hasError = true;
            }
            if (comboBoxGender.SelectedItem == null)
            {
                errorGender.Visible = true;
                hasError = true;
            }
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                errorAddress.Visible = true;
                hasError = true;
            }

            if (hasError)
                return;

            // Map ComboBox value to 'M' or 'F'
            string genderValue = comboBoxGender.SelectedItem.ToString() == "Male" ? "M" : "F";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string updateQuery = @"
                    UPDATE Users
                    SET 
                        userLname = @lastname,
                        userFname = @firstname,
                        userMname = @middlename,
                        userDob = @dob,
                        userGender = @gender,
                        userAddress = @address
                    WHERE userID = @id";

                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@lastname", txtLastname.Text.Trim());
                    cmd.Parameters.AddWithValue("@firstname", txtFirstname.Text.Trim());
                    cmd.Parameters.AddWithValue("@middlename", txtMiddlename.Text.Trim());
                    cmd.Parameters.AddWithValue("@dob", pickerDob.Value.Date);
                    cmd.Parameters.AddWithValue("@gender", genderValue);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", user_id);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        using (var info = new Information("SUCCESS", "Profile updated successfully!"))
                        {
                            info.ShowDialog();
                        }

                        viewAboutPanel.Visible = true;
                        editAboutPanel.Visible = false;
                        fetchUserDetail(user_id);

                        ProfileUpdated?.Invoke();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update profile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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

        private void comboBoxGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBoxGender.Text))
            {
                errorGender.Visible = true;
            }
            else
            {
                errorGender.Visible = false;
            }
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                errorAddress.Visible = true;
            }
            else
            {
                errorAddress.Visible = false;
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block the input
            }
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                errorPhone.Visible = true;
            }
            else
            {
                if (!IsValidMobileNumber(txtPhone.Text.Trim()))
                {
                    errorPhone.Visible = true;
                }
                else
                {
                    errorPhone.Visible = false;
                }
            }
        }
        private bool IsValidMobileNumber(string mobile)
        {
            string pattern = @"^09\d{9}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(mobile);
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

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

        private void btnContactSave_Click(object sender, EventArgs e)
        {
            errorEmail.Visible = false;
            errorPhone.Visible = false;

            bool hasError = false;

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
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                errorPhone.Visible = true;
                hasError = true;
            }
            else
            {

                if (!IsValidMobileNumber(txtPhone.Text.Trim()))
                {
                    errorPhone.Visible = true;
                    hasError = true;
                }
            }
            if (hasError)
            {
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string updateQuery = @"
                    UPDATE Users
                    SET 
                        userMobile = @mobile,
                        userEmail = @email
                    WHERE userID = @id";

                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@mobile", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@id", user_id);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        using (var info = new Information("SUCCESS", "Profile updated successfully!"))
                        {
                            info.ShowDialog();
                        }

                        viewContactPanel.Visible = true;
                        editContactPanel.Visible = false;
                        fetchUserDetail(user_id);

                        ProfileUpdated?.Invoke();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update profile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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

        private void txtCurrentPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassword.Text))
            {
                errorCurrentPassword.Visible = true;
            }
            else
            {
                errorCurrentPassword.Visible = false;
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
                errorConfirmPassword.Visible = true;
            }
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                errorConfirmPassword.Visible = true;
            }
            else
            {
                errorConfirmPassword.Visible = false;
            }
        }

        private void btnCredSave_Click(object sender, EventArgs e)
        {
            errorUsername.Visible = false;
            errorCurrentPassword.Visible = false;
            errorPassword.Visible = false;
            errorConfirmPassword.Visible = false;

            bool hasError = false;

            if (string.IsNullOrEmpty(txtCurrentPassword.Text))
            {
                errorCurrentPassword.Visible = true;
                hasError = true;
            }
            else if (txtCurrentPassword.Text != OrigPassword)
            {
                MessageBox.Show("The current password you entered is incorrect.", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string updateQuery = @"
                    UPDATE Users
                    SET 
                        userName = @username,
                        userPassword = @password
                    WHERE userID = @id";

                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@id", user_id);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        using (var info = new Information("SUCCESS", "Profile updated successfully!"))
                        {
                            info.ShowDialog();
                        }

                        viewCredPanel.Visible = true;
                        editCredPanel.Visible = false;
                        fetchUserDetail(user_id);

                        ProfileUpdated?.Invoke();
                        txtPassword.Clear();
                        txtConfirmPassword.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update profile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
