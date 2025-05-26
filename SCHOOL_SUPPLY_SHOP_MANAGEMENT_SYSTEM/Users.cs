using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SCHOOL_SUPPLY_SHOP_MANAGEMENT_SYSTEM
{
    public partial class Users : Form
    {
        string connectionString = @"Data Source=ESTORBA-PC\SQLEXPRESS02;Initial Catalog=MANAGEMENT_SYSTEM;Integrated Security=True;Encrypt=False;";
        public Users()
        {
            InitializeComponent();
            LoadUsers();
            dataGridViewUsers.AllowUserToAddRows = false;
            dataGridViewUsers.ReadOnly = true;
            dataGridViewUsers.ClearSelection();
            dataGridViewUsers.DataSource = GetUsers();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            LoadUsers();
            dataGridViewUsers.AllowUserToAddRows = false;
            dataGridViewUsers.ReadOnly = true;
            dataGridViewUsers.ClearSelection();
            dataGridViewUsers.DataSource = GetUsers();
        }

        private void LoadUsers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT userId, userLname, userFname, userMname, userName, userRole, userGender, userAddress, userMobile FROM Users WHERE userStatus = 'Active'";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridViewUsers.DataSource = table;
                }
                dataGridViewUsers.AllowUserToAddRows = false;
                dataGridViewUsers.ReadOnly = true;
                dataGridViewUsers.DataSource = GetUsers();
                dataGridViewUsers.AutoGenerateColumns = false;
                dataGridViewUsers.Columns["viewUser"].DisplayIndex = dataGridViewUsers.Columns.Count - 2;
                dataGridViewUsers.Columns["delete"].DisplayIndex = dataGridViewUsers.Columns.Count - 1;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Signup signup = new Signup(true);
            signup.Show();
            LoadUsers();
            dataGridViewUsers.DataSource = GetUsers();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            DataTable results = GetUsers(searchTerm);

            if (results.Rows.Count > 0)
            {
                dataGridViewUsers.DataSource = results;
                dataGridViewUsers.Visible = true;
            }
            else
            {
                dataGridViewUsers.Visible = false;
            }

            clearSearch.Visible = !string.IsNullOrEmpty(searchTerm);
            dataGridViewUsers.AllowUserToAddRows = false;
            dataGridViewUsers.ReadOnly = true;
        }

        private void clearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            dataGridViewUsers.DataSource = GetUsers();
            clearSearch.Visible = false;
            dataGridViewUsers.Visible = true;
            dataGridViewUsers.AllowUserToAddRows = false;
            dataGridViewUsers.ReadOnly = true;
        }

        private DataTable GetUsers(string searchTerm = "")
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT userId, userLname, userFname, userMname, userName, userRole, userGender, userAddress, userMobile 
                FROM Users 
                WHERE 
                    (userLname LIKE @search OR 
                     userFname LIKE @search OR 
                     userMname LIKE @search OR 
                     userGender LIKE @search OR 
                     userRole LIKE @search OR 
                     userName LIKE @search) 
                    AND userStatus = 'Active'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }

            return dt;
        }
        private void dataGridViewUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridViewUsers.Columns[e.ColumnIndex].Name == "delete")
                {
                    int userId = Convert.ToInt32(dataGridViewUsers.Rows[e.RowIndex].Cells["userId"].Value);
                    using (var confirm = new Logout("CONFIRMATION", "Are you sure you want to delete this user?"))
                    {
                        if (confirm.ShowDialog() != DialogResult.OK)
                        {
                            return;
                        }
                    }

                    DeleteUser(userId);

                    using (var info = new Information("SUCCESS", "User deleted successfully!"))
                    {
                        info.ShowDialog();
                    }
                    LoadUsers();
                    dataGridViewUsers.DataSource = GetUsers();
                }
                if (dataGridViewUsers.Columns[e.ColumnIndex].Name == "viewUser")
                {
                    int userId = Convert.ToInt32(dataGridViewUsers.Rows[e.RowIndex].Cells["userId"].Value);
                    viewUsers viewUsers = new viewUsers(userId);
                    viewUsers.ShowDialog();
                }
            }
        }
        private void DeleteUser(int userId)
        {
            string query = "UPDATE Users SET userStatus = 'Deleted' WHERE userId = @userID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userID", userId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
