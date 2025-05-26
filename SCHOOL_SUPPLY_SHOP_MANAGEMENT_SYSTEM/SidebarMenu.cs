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

namespace SCHOOL_SUPPLY_SHOP_MANAGEMENT_SYSTEM
{
    public partial class SidebarMenu : Form
    {
        UserProfile profile;
        Dashboard adminDashboard;
        Customers adminCustomers;
        Inventory adminInventory;
        Products adminProducts;
        ChooseReport adminReports;
        Users adminUsers;

        public int user_id;

        public SidebarMenu(int user_id)
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

        private void SidebarMenu_Load(object sender, EventArgs e)
        {
            ShowChildForm(ref adminDashboard, () => new Dashboard(), AdminDashboard_FormClosed, "Dashboard", btnDashboard, Properties.Resources.icons8_dashboard_24);
        }

        // Button click

        private bool isLoggingOut = false;

        private void btnLogout_Click(object sender, EventArgs e)
        {
            clickStyleBtn(btnLogout, Properties.Resources.icons8_power_off_30__1_);
            using (var confirmLogout = new Logout("LOGOUT", "Are you sure you want to logout?"))
            {
                var result = confirmLogout.ShowDialog();

                if (result == DialogResult.OK)
                {
                    isLoggingOut = true;
                    Login login = new Login();
                    login.Show();
                    this.Hide();
                }
                else
                {
                    originalStyleBtn(btnLogout, Properties.Resources.icons8_power_off_30);
                }
            }
        }

        private void SidebarMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isLoggingOut)
            {
                originalStyleBtn(btnLogout, Properties.Resources.icons8_power_off_30);
                return;
            }

            using (var confirmLogout = new Logout("LOGOUT", "Are you sure you want to logout?"))
            {
                clickStyleBtn(btnLogout, Properties.Resources.icons8_power_off_30__1_);
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
                    originalStyleBtn(btnLogout, Properties.Resources.icons8_power_off_30);
                    e.Cancel = true;
                }
            }
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            resetAllButtons();
            ShowChildForm(ref profile, () => new UserProfile(user_id, () => fetchUserDetail(user_id)), Profile_FormClosed, "Profile");
            profileBtnStyle(Color.FromArgb(230, 95, 43));
        }

        private void label3_Click(object sender, EventArgs e)
        {
            resetAllButtons();
            ShowChildForm(ref profile, () => new UserProfile(user_id, () => fetchUserDetail(user_id)), Profile_FormClosed, "Profile");
            profileBtnStyle(Color.FromArgb(230, 95, 43));
        }

        private void label1_Click(object sender, EventArgs e)
        {
            resetAllButtons();
            ShowChildForm(ref profile, () => new UserProfile(user_id, () => fetchUserDetail(user_id)), Profile_FormClosed, "Profile");
            profileBtnStyle(Color.FromArgb(230, 95, 43));
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            resetAllButtons();
            ShowChildForm(ref profile, () => new UserProfile(user_id, () => fetchUserDetail(user_id)), Profile_FormClosed, "Profile");
            profileBtnStyle(Color.FromArgb(230, 95, 43));
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            resetAllButtons();
            ShowChildForm(ref adminDashboard, () => new Dashboard(), AdminDashboard_FormClosed, "Dashboard", btnDashboard, Properties.Resources.icons8_dashboard_24);
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            resetAllButtons();
            ShowChildForm(ref adminProducts, () => new Products(), AdminProducts_FormClosed, "Products", btnProducts, Properties.Resources.icons8_products_30__1_);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            resetAllButtons();
            ShowChildForm(ref adminUsers, () => new Users(), adminUsers_FormClosed, "Users", btnUsers, Properties.Resources.icons8_users_30__1_);
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            resetAllButtons();
            ShowChildForm(ref adminCustomers, () => new Customers(), adminCustomers_FormClosed, "Customers", btnCustomers, Properties.Resources.icons8_customers_24__1_);
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            resetAllButtons();
            ShowChildForm(ref adminInventory, () => new Inventory(user_id), adminInventory_FormClosed, "Inventory", btnInventory, Properties.Resources.icons8_inventory_30__1_);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            resetAllButtons();
            ShowChildForm(ref adminReports, () => new ChooseReport(), adminReports_FormClosed, "Reports", btnReports, Properties.Resources.icons8_reports_30__1_);
        }

        // Show forms

        private void ShowChildForm<T>(
            ref T? childForm,
            Func<T> createForm,
            FormClosedEventHandler formClosed,
            string title,
            Button? activeButton = null,
            Image? activeIcon = null)
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

            // Update title
            lblTitle.Text = title;

            // Update button styles
            if (activeButton != null && activeIcon != null)
            {
                resetAllButtons();
                clickStyleBtn(activeButton, activeIcon);
            }
        }

        // FormClosed

        private void adminReports_FormClosed(object? sender, FormClosedEventArgs e)
        {
            adminReports = null;
        }

        private void adminInventory_FormClosed(object? sender, FormClosedEventArgs e)
        {
            adminInventory = null;
        }

        private void adminCustomers_FormClosed(object? sender, FormClosedEventArgs e)
        {
            adminCustomers = null;
        }

        private void adminUsers_FormClosed(object? sender, FormClosedEventArgs e)
        {
            adminUsers = null;
        }

        private void AdminProducts_FormClosed(object? sender, FormClosedEventArgs e)
        {
            adminProducts = null;
        }

        private void AdminDashboard_FormClosed(object? sender, FormClosedEventArgs e)
        {
            adminDashboard = null;
        }

        private void Profile_FormClosed(object? sender, FormClosedEventArgs e)
        {
            profile = null;
        }

        // Button styles

        private void resetAllButtons()
        {
            originalStyleBtn(btnDashboard, Properties.Resources.icons8_dashboard_24__1_);
            originalStyleBtn(btnProducts, Properties.Resources.icons8_products_30);
            originalStyleBtn(btnUsers, Properties.Resources.icons8_users_30);
            originalStyleBtn(btnCustomers, Properties.Resources.icons8_customers_24);
            originalStyleBtn(btnInventory, Properties.Resources.icons8_inventory_30);
            originalStyleBtn(btnReports, Properties.Resources.icons8_reports_30);
            originalStyleBtn(btnLogout, Properties.Resources.icons8_power_off_30);

            profileBtnStyle(Color.Black);
        }

        private void profileBtnStyle(Color color)
        {
            label3.ForeColor = color;
            label1.ForeColor = color;
        }

        private void originalStyleBtn(Button button, Image icon)
        {
            button.ForeColor = Color.White;
            button.BackColor = Color.Black;
            button.Image = icon;
        }

        private void clickStyleBtn(Button button, Image icon)
        {
            button.ForeColor = Color.FromArgb(230, 95, 43);
            button.BackColor = Color.White;
            button.Image = icon;
        }
    }
}
