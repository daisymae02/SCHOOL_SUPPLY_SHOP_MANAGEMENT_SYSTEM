using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class Customers : Form
    {
        string connectionString = @"Data Source=ESTORBA-PC\SQLEXPRESS02;Initial Catalog=MANAGEMENT_SYSTEM;Integrated Security=True;Encrypt=False;";

        public Customers()
        {
            InitializeComponent();
            LoadCustomers();
            dataGridViewCustomers.AllowUserToAddRows = false;
            dataGridViewCustomers.ReadOnly = true;
            dataGridViewCustomers.ClearSelection();
            dataGridViewCustomers.DataSource = GetCustomers();
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            dataGridViewCustomers.AllowUserToAddRows = false;
            dataGridViewCustomers.ReadOnly = true;
            dataGridViewCustomers.ClearSelection();
            dataGridViewCustomers.DataSource = GetCustomers();
        }

        private void LoadCustomers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT * FROM Customer WHERE custStatus = 'Active'";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridViewCustomers.DataSource = table;
                }
                dataGridViewCustomers.AllowUserToAddRows = false;
                dataGridViewCustomers.ReadOnly = true;
                dataGridViewCustomers.DataSource = GetCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message);
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            DataTable results = GetCustomers(searchTerm);

            if (results.Rows.Count > 0)
            {
                dataGridViewCustomers.DataSource = results;
                dataGridViewCustomers.Visible = true;
            }
            else
            {
                dataGridViewCustomers.Visible = false;
            }

            clearSearch.Visible = !string.IsNullOrEmpty(searchTerm);
            dataGridViewCustomers.AllowUserToAddRows = false;
            dataGridViewCustomers.ReadOnly = true;
        }

        private void clearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            dataGridViewCustomers.DataSource = GetCustomers();
            clearSearch.Visible = false;
            dataGridViewCustomers.Visible = true;
            dataGridViewCustomers.AllowUserToAddRows = false;
            dataGridViewCustomers.ReadOnly = true;
        }
        private DataTable GetCustomers(string searchTerm = "")
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT custId, custLname, custFname, custMname, custMobile, custAddress
                FROM Customer
                WHERE 
                    (custLname LIKE @search OR
                     custFname LIKE @search OR
                     custMname LIKE @search OR
                     custMobile LIKE @search OR
                     custAddress LIKE @search)
                AND custStatus = 'Active'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        private void dataGridViewCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridViewCustomers.Columns[e.ColumnIndex].Name == "delete")
                {
                    int custId = Convert.ToInt32(dataGridViewCustomers.Rows[e.RowIndex].Cells["custId"].Value);
                    using (var confirm = new Logout("CONFIRMATION", "Are you sure you want to delete this customer?"))
                    {
                        if (confirm.ShowDialog() != DialogResult.OK)
                        {
                            return;
                        }
                    }

                    DeleteCustomer(custId);

                    using (var info = new Information("SUCCESS", "User deleted successfully!"))
                    {
                        info.ShowDialog();
                    }
                    LoadCustomers();
                    dataGridViewCustomers.DataSource = GetCustomers();
                }
                if (dataGridViewCustomers.Columns[e.ColumnIndex].Name == "view")
                {
                    int custId = Convert.ToInt32(dataGridViewCustomers.Rows[e.RowIndex].Cells["custId"].Value);
                    viewCustomers viewCustomers = new viewCustomers(custId);
                    viewCustomers.ShowDialog();
                }
            }
        }

        private void DeleteCustomer(int custId)
        {
            string query = "UPDATE Customer SET custStatus = 'Deleted' WHERE custId = @custId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@custID", custId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
