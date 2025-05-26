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
    public partial class Reports : Form
    {
        string connectionString = @"Data Source=ESTORBA-PC\SQLEXPRESS02;Initial Catalog=MANAGEMENT_SYSTEM;Integrated Security=True;Encrypt=False;";
        private bool isFromSet = false;
        private bool isToSet = false;

        public Reports()
        {
            InitializeComponent();
            LoadReports();
            dataGridViewReports.AllowUserToAddRows = false;
            dataGridViewReports.ReadOnly = true;
            dataGridViewReports.ClearSelection();
            dataGridViewReports.DataSource = GetProducts();
            dateTimePickerFrom.Value = new DateTime(1753, 1, 1);
            dateTimePickerTo.Value = DateTime.Today;

            clearFromTo.Visible = false;
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            LoadReports();
            dataGridViewReports.AllowUserToAddRows = false;
            dataGridViewReports.ReadOnly = true;
            dataGridViewReports.ClearSelection();
            dataGridViewReports.DataSource = GetProducts();
            dateTimePickerFrom.Value = new DateTime(1753, 1, 1);
            dateTimePickerTo.Value = DateTime.Today;

            clearFromTo.Visible = false;
        }

        private void LoadReports()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT 
                            t.transactionItemId, 
                            t.transactionItemQuantity, 
                            t.transactionItemPrice, 
                            t.transactionItemSubTotal, 
                            FORMAT(tr.createdAt, 'MMMM d, yyyy') AS createdAt, 
                            p.prodName 
                        FROM 
                            Transactions tr 
                        JOIN 
                            TransactionItems t ON tr.transactionId = t.transactionId 
                        JOIN 
                            Product p ON t.prodId = p.prodId 
                        ORDER BY 
                            t.transactionItemId DESC;";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridViewReports.DataSource = table;
                }

                dataGridViewReports.AllowUserToAddRows = false;
                dataGridViewReports.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading stocks: " + ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            DataTable results = GetProducts(searchTerm);

            if (results.Rows.Count > 0)
            {
                dataGridViewReports.DataSource = results;
                dataGridViewReports.Visible = true;
            }
            else
            {
                dataGridViewReports.Visible = false;
            }

            clearSearch.Visible = !string.IsNullOrEmpty(searchTerm);
            dataGridViewReports.AllowUserToAddRows = false;
            dataGridViewReports.ReadOnly = true;
        }

        private void clearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            dataGridViewReports.DataSource = GetProducts();
            clearSearch.Visible = false;
            dataGridViewReports.Visible = true;
            dataGridViewReports.AllowUserToAddRows = false;
            dataGridViewReports.ReadOnly = true;
        }

        private DataTable GetProducts(string searchTerm = "", DateTime? dateFrom = null, DateTime? dateTo = null)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        t.transactionItemId, 
                        t.transactionItemQuantity, 
                        t.transactionItemPrice, 
                        t.transactionItemSubTotal, 
                        FORMAT(tr.createdAt, 'MMMM d, yyyy') AS createdAt, 
                        p.prodName 
                    FROM 
                        Transactions tr 
                    JOIN 
                        TransactionItems t ON tr.transactionId = t.transactionId 
                    JOIN 
                        Product p ON t.prodId = p.prodId
                    WHERE 
                        p.prodName LIKE @search AND
                        tr.createdAt >= @dateFrom AND tr.createdAt <= @dateTo
                    ORDER BY 
                        t.transactionItemId DESC;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");
                    DateTime safeMinDate = new DateTime(1753, 1, 1);
                    DateTime safeMaxDate = new DateTime(9999, 12, 31);

                    cmd.Parameters.AddWithValue("@dateFrom", dateFrom ?? safeMinDate);
                    cmd.Parameters.AddWithValue("@dateTo", dateTo?.Date.AddDays(1).AddSeconds(-1) ?? safeMaxDate);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        private void clearFromTo_Click(object sender, EventArgs e)
        {
            isFromSet = false;
            isToSet = false;

            // Reset DatePickers to today or desired default
            dateTimePickerFrom.Value = new DateTime(1753, 1, 1);
            dateTimePickerTo.Value = DateTime.Today;

            // Refresh with only search term
            string searchTerm = txtSearch.Text.Trim();
            dataGridViewReports.DataSource = GetProducts(searchTerm);

            clearFromTo.Visible = false;
        }

        private void ApplyDateFilter()
        {
            string searchTerm = txtSearch.Text.Trim();
            DateTime from = dateTimePickerFrom.Value.Date;
            DateTime to = dateTimePickerTo.Value.Date;

            dataGridViewReports.DataSource = GetProducts(searchTerm, from, to);
        }

        private void UpdateClearFromToVisibility()
        {
            clearFromTo.Visible = isFromSet || isToSet;
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            isFromSet = true;
            ApplyDateFilter();
            UpdateClearFromToVisibility();
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            isToSet = true;
            ApplyDateFilter();
            UpdateClearFromToVisibility();
        }
    }
}
