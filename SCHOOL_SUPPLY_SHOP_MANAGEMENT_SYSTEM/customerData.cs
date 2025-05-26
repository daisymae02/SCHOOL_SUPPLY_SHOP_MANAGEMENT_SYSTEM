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
    public partial class customerData : Form
    {
        string connectionString = @"Data Source=ESTORBA-PC\SQLEXPRESS02;Initial Catalog=MANAGEMENT_SYSTEM;Integrated Security=True;Encrypt=False;";
        public customerData()
        {
            InitializeComponent();
            LoadCustomerData();
            dataGridViewCustomerData.AllowUserToAddRows = false;
            dataGridViewCustomerData.ReadOnly = true;
            dataGridViewCustomerData.ClearSelection();
            dataGridViewCustomerData.DataSource = GetCustomerData();
        }
        private void LoadCustomerData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT 
                            c.custId, 
                            CONCAT(c.custLname, ', ', c.custFname, ' ', c.custMname) AS fullName, 
                            c.custAddress, 
                            c.custMobile, 
                            SUM(t.totalAmount) AS totalAmount
                        FROM 
                            Customer c 
                        JOIN 
                            Transactions t ON t.custId = c.custId
                        GROUP BY 
                            c.custId, c.custLname, c.custFname, c.custMname, c.custAddress, c.custMobile ORDER BY custId DESC";


                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridViewCustomerData.DataSource = table;
                }
                dataGridViewCustomerData.AllowUserToAddRows = false;
                dataGridViewCustomerData.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customer data: " + ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            DataTable results = GetCustomerData(searchTerm);

            if (results.Rows.Count > 0)
            {
                dataGridViewCustomerData.DataSource = results;
                dataGridViewCustomerData.Visible = true;
            }
            else
            {
                dataGridViewCustomerData.Visible = false;
            }

            clearSearch.Visible = !string.IsNullOrEmpty(searchTerm);
            dataGridViewCustomerData.AllowUserToAddRows = false;
            dataGridViewCustomerData.ReadOnly = true;
        }

        private void clearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            dataGridViewCustomerData.DataSource = GetCustomerData();
            clearSearch.Visible = false;
            dataGridViewCustomerData.Visible = true;
            dataGridViewCustomerData.AllowUserToAddRows = false;
            dataGridViewCustomerData.ReadOnly = true;
        }

        private DataTable GetCustomerData(string searchTerm = "")
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                         c.custId, 
                         CONCAT(c.custLname, ', ', c.custFname, ' ', c.custMname) AS fullName, 
                         c.custAddress, 
                         c.custMobile, 
                         SUM(t.totalAmount) AS totalAmount
                    FROM 
                         Customer c 
                    JOIN 
                         Transactions t ON t.custId = c.custId
                    WHERE
                        (c.custLname LIKE @search OR
                         c.custFname LIKE @search OR
                         c.custMname LIKE @search)
                    GROUP BY 
                         c.custId, c.custLname, c.custFname, c.custMname, c.custAddress, c.custMobile ORDER BY custId DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
    }
}
