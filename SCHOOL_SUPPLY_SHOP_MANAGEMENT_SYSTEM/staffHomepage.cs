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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SCHOOL_SUPPLY_SHOP_MANAGEMENT_SYSTEM
{
    public partial class staffHomepage : Form
    {
        staffHome staffHome;
        Purchase staffProducts;
        Customers staffCustomers;
        UserProfile staffProfile;

        public int user_id;

        public staffHomepage(int user_id)
        {
            InitializeComponent();
            this.user_id = user_id;
            fetchUserDetail(user_id);
        }

        private void fetchUserDetail(int id)
        {
            string connectionString = @"Data Source=ESTORBA-PC\SQLEXPRESS02;Initial Catalog=MANAGEMENT_SYSTEM;Integrated Security=True;Encrypt=False;";

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

                        string firstInitial = !string.IsNullOrEmpty(firstname) ? firstname[0].ToString() : "";
                        string middleInitial = !string.IsNullOrEmpty(middlename) ? middlename[0].ToString() : "";

                        label3.Text = $"{lastname}, {firstInitial}{middleInitial}";
                        profileImage.Image = userImage;
                    }
                    else
                    {
                        MessageBox.Show("User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ShowChildForm<T>(
            ref T? childForm,
            Func<T> createForm,
            FormClosedEventHandler formClosed,
            Button? activeButton = null)
            where T : Form
        {
            // Close all other child forms if needed
            foreach (Form form in this.MdiChildren)
            {
                if (form != childForm)
                {
                    form.Close();
                }
            }

            // Show or activate the desired form
            if (childForm == null || childForm.IsDisposed)
            {
                childForm = createForm();
                childForm.MdiParent = this;
                childForm.Dock = DockStyle.Fill;
                childForm.FormClosed += formClosed;
                childForm.Show();
            }
            else
            {
                childForm.Activate();
            }

            // Update button styles
            if (activeButton != null)
            {
                resetAllButtons();
                clickStyleBtn(activeButton);
            }
        }

        private void resetAllButtons()
        {
            originalStyleBtn(btnCustomers);
            originalStyleBtn(btnProducts);
            originalStyleBtn(btnHome);
        }

        private void profileBtnStyle(Color color)
        {
            label3.ForeColor = color;
            label1.ForeColor = color;
        }

        private void originalStyleBtn(Button button)
        {
            button.ForeColor = Color.Black;
            button.BackColor = Color.FromArgb(235, 229, 215);
            profileBtnStyle(Color.Black);
        }

        private void clickStyleBtn(Button button)
        {
            button.ForeColor = Color.White;
            button.BackColor = Color.FromArgb(230, 95, 43);
        }

        private void staffHome_FormClosed(object? sender, FormClosedEventArgs e)
        {
            staffHome = null;
        }

        private void staffProducts_FormClosed(object? sender, FormClosedEventArgs e)
        {
            staffProducts = null;
        }

        private void staffCustomers_FormClosed(object? sender, FormClosedEventArgs e)
        {
            staffCustomers = null;
        }

        private void staffProfile_FormClosed(object? sender, FormClosedEventArgs e)
        {
            staffProfile = null;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            resetAllButtons();
            ShowChildForm<staffHome>(ref staffHome, () =>
            {
                var home = new staffHome();

                home.NavigateToProducts += () =>
                {
                    ShowChildForm<Purchase>(ref staffProducts, () => new Purchase(user_id), staffProducts_FormClosed, btnProducts);
                };

                return home;
            }, staffHome_FormClosed, btnHome);
        }

        private void staffHomepage_Load(object sender, EventArgs e)
        {
            resetAllButtons();
            btnHome_Click(sender, e);
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            resetAllButtons();
            ShowChildForm(ref staffProducts, () => new Purchase(user_id), staffProducts_FormClosed, btnProducts);
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            resetAllButtons();
            ShowChildForm(ref staffCustomers, () => new Customers(), staffCustomers_FormClosed, btnCustomers);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            resetAllButtons();
            ShowChildForm(ref staffProfile,
                () => new UserProfile(user_id, () => fetchUserDetail(user_id), () =>
                {
                    isLogoutRequested = true;
                    Close(); // triggers FormClosing
                }),
                staffProfile_FormClosed);
            profileBtnStyle(Color.FromArgb(230, 95, 43));
        }

        private void label3_Click(object sender, EventArgs e)
        {
            resetAllButtons();
            ShowChildForm(ref staffProfile,
                () => new UserProfile(user_id, () => fetchUserDetail(user_id), () =>
                {
                    isLogoutRequested = true;
                    Close(); // triggers FormClosing
                }),
                staffProfile_FormClosed);
            profileBtnStyle(Color.FromArgb(230, 95, 43));
        }

        private void label1_Click(object sender, EventArgs e)
        {
            resetAllButtons();
            ShowChildForm(ref staffProfile,
                () => new UserProfile(user_id, () => fetchUserDetail(user_id), () =>
                {
                    isLogoutRequested = true;
                    Close(); // triggers FormClosing
                }),
                staffProfile_FormClosed);
            profileBtnStyle(Color.FromArgb(230, 95, 43));
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            resetAllButtons();
            ShowChildForm(ref staffProfile,
                () => new UserProfile(user_id, () => fetchUserDetail(user_id), () =>
                {
                    isLogoutRequested = true;
                    Close(); // triggers FormClosing
                }),
                staffProfile_FormClosed);
            profileBtnStyle(Color.FromArgb(230, 95, 43));
        }

        private bool isLogoutRequested = false;

        //private bool PerformLogout(FormClosingEventArgs? e = null)
        //{
        //    using (var confirmLogout = new Logout("LOGOUT", "Are you sure you want to logout?"))
        //    {
        //        var result = confirmLogout.ShowDialog();

        //        if (result == DialogResult.OK)
        //        {
        //            isLogoutRequested = false; // reset the flag
        //            Login login = new Login();
        //            login.Show();
        //            this.Hide();

        //            if (e != null)
        //                e.Cancel = false;

        //            return true;
        //        }
        //        else
        //        {
        //            if (e != null)
        //                e.Cancel = true;

        //            return false;
        //        }
        //    }
        //}

        private void staffHomepage_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (isLogoutRequested)
            //{
            //    PerformLogout(e);
            //}
            //else
            //{
            //    // Allow form to close without confirmation if logout wasn't requested
            //    e.Cancel = false;
            //}
            using (var confirmLogout = new Logout("LOGOUT", "Are you sure you want to logout?"))
            {
                var result = confirmLogout.ShowDialog();

                if (result == DialogResult.OK)
                {
                    Login login = new Login();
                    login.Show();
                    this.Hide();

                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }

            }
        }

        public void SwitchToStaffHome()
        {
            // Close Purchase child if open
            if (staffProducts != null && !staffProducts.IsDisposed)
            {
                staffProducts.Close();
                staffProducts = null;
            }

            // Open staffHome child and activate the Home button style
            btnHome_Click(null, EventArgs.Empty);
        }

    }
}
