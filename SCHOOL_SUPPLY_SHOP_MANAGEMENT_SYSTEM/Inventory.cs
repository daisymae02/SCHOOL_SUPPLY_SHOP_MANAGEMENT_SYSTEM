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
    public partial class Inventory : Form
    {
        string connectionString = @"Data Source=ESTORBA-PC\SQLEXPRESS02;Initial Catalog=MANAGEMENT_SYSTEM;Integrated Security=True;Encrypt=False;";
        int userID;
        public Inventory(int id)
        {
            InitializeComponent();
            this.userID = id;
            LoadProducts();
            LoadStocks();
            dataGridViewStocks.AllowUserToAddRows = false;
            dataGridViewStocks.ReadOnly = true;
            dataGridViewStocks.ClearSelection();
            dataGridViewStocks.DataSource = GetProducts();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadStocks();
            dataGridViewStocks.AllowUserToAddRows = false;
            dataGridViewStocks.ReadOnly = true;
            dataGridViewStocks.ClearSelection();
            dataGridViewStocks.DataSource = GetProducts();
        }

        private void LoadProducts()
        {
            txtProduct.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT prodName FROM Product ORDER BY prodName";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            txtProduct.Items.Add(reader["prodName"].ToString());
                        }
                    }
                }
            }
        }

        private void txtProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtProduct.SelectedItem == null)
            {
                errorProduct.Visible = true;
            }
            else
            {
                errorProduct.Visible = false;
            }
        }

        private void txtStockQuantity_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStockQuantity.Text))
            {
                errorStockQuantity.Visible = true;
            }
            else
            {
                errorStockQuantity.Visible = false;
            }
        }

        private void txtStockQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // block non-numeric input
            }
        }

        private void btnAddStock_Click(object sender, EventArgs e)
        {
            bool isValid = true;

            // Product validation
            if (string.IsNullOrWhiteSpace(txtProduct.Text))
            {
                errorProduct.Visible = true;
                isValid = false;
            }
            else
            {
                errorProduct.Visible = false;
            }

            // Stock Quantity validation
            if (string.IsNullOrWhiteSpace(txtStockQuantity.Text))
            {
                errorStockQuantity.Visible = true;
                isValid = false;
            }
            else
            {
                errorStockQuantity.Visible = false;
            }

            // Stop if invalid
            if (!isValid)
            {
                return;
            }

            using (var confirm = new Logout("CONFIRMATION", "Are you sure you want to add a new stock?"))
            {
                if (confirm.ShowDialog() != DialogResult.OK)
                {
                    return; // User cancelled
                }
            }
            AddStock();
            txtProduct.SelectedIndex = -1;
            txtStockQuantity.Clear();
            errorProduct.Visible = false;
            errorStockQuantity.Visible = false;
            LoadStocks();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtProduct.SelectedIndex = -1;
            txtStockQuantity.Clear();
            errorProduct.Visible = false;
            errorStockQuantity.Visible = false;
            LoadStocks();
        }

        private void AddStock()
        {
            string prodName = txtProduct.Text.Trim();
            string quantity = txtStockQuantity.Text.Trim();

            if (!decimal.TryParse(quantity, out decimal stockQuantity))
            {
                MessageBox.Show("Please enter a valid quantity.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Step 1: Get prodId
                    int prodId;
                    using (SqlCommand getProdIdCmd = new SqlCommand("SELECT prodId FROM Product WHERE prodName = @prodName", conn, transaction))
                    {
                        getProdIdCmd.Parameters.AddWithValue("@prodName", prodName);
                        var result = getProdIdCmd.ExecuteScalar();
                        if (result == null)
                        {
                            MessageBox.Show("Product not found.");
                            transaction.Rollback();
                            return;
                        }
                        prodId = Convert.ToInt32(result);
                    }

                    // Step 2: Generate custom stockId
                    string stockId = GenerateStockId(conn, transaction);

                    // Step 3: Insert into Stock table
                    using (SqlCommand insertCmd = new SqlCommand(@"
                        INSERT INTO Stock 
                        (stockId, stockQuantityChanged, createdAt, prodId, userId) 
                        VALUES (@stockId, @quantity, @createdAt, @prodId, @userId)", conn, transaction))
                    {
                        insertCmd.Parameters.AddWithValue("@stockId", stockId);
                        insertCmd.Parameters.AddWithValue("@quantity", stockQuantity);
                        insertCmd.Parameters.AddWithValue("@createdAt", DateTime.Now);
                        insertCmd.Parameters.AddWithValue("@prodId", prodId);
                        insertCmd.Parameters.AddWithValue("@userId", userID);

                        insertCmd.ExecuteNonQuery();
                    }

                    // Step 4: Update Product quantity
                    using (SqlCommand updateCmd = new SqlCommand(@"
                        UPDATE Product 
                        SET prodQuantityInStock = prodQuantityInStock + @quantity 
                        WHERE prodId = @prodId", conn, transaction))
                    {
                        updateCmd.Parameters.AddWithValue("@quantity", stockQuantity);
                        updateCmd.Parameters.AddWithValue("@prodId", prodId);

                        updateCmd.ExecuteNonQuery();
                    }

                    transaction.Commit();

                    using (var confirm = new Information("SUCCESS", "Product added and stock updated successfully!"))
                    {
                        confirm.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private string GenerateStockId(SqlConnection conn, SqlTransaction transaction)
        {
            string prefix = DateTime.Now.ToString("yyyyMM"); // e.g., 202505
            string query = @"
                SELECT TOP 1 stockId 
                FROM Stock 
                WHERE stockId LIKE @prefix + '%' 
                ORDER BY stockId DESC";

            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@prefix", prefix);
                var lastId = cmd.ExecuteScalar()?.ToString();

                int newSeq = 1;
                if (!string.IsNullOrEmpty(lastId))
                {
                    string lastSeq = lastId.Substring(6); // Get last 4 digits
                    newSeq = int.Parse(lastSeq) + 1;
                }

                return prefix + newSeq.ToString("D4"); // e.g., 2025050002
            }
        }

        private void LoadStocks()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT 
                            S.stockId,
                            P.prodName,
                            S.stockQuantityChanged,
                            FORMAT(S.createdAt, 'MMMM dd, yyyy hh:mm tt') AS formattedDate,
                            U.userLname + ', ' + U.userFname AS fullName
                        FROM Stock S
                        JOIN Product P ON S.prodId = P.prodId
                        JOIN Users U ON S.userId = U.userId
                        ORDER BY S.createdAt DESC";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridViewStocks.DataSource = table;
                }

                dataGridViewStocks.AllowUserToAddRows = false;
                dataGridViewStocks.ReadOnly = true;
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
                dataGridViewStocks.DataSource = results;
                dataGridViewStocks.Visible = true;
            }
            else
            {
                dataGridViewStocks.Visible = false;
            }

            clearSearch.Visible = !string.IsNullOrEmpty(searchTerm);
            dataGridViewStocks.AllowUserToAddRows = false;
            dataGridViewStocks.ReadOnly = true;
        }

        private void clearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            dataGridViewStocks.DataSource = GetProducts();
            clearSearch.Visible = false;
            dataGridViewStocks.Visible = true;
            dataGridViewStocks.AllowUserToAddRows = false;
            dataGridViewStocks.ReadOnly = true;
        }

        private DataTable GetProducts(string searchTerm = "")
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        S.stockId,
                        P.prodName,
                        S.stockQuantityChanged,
                        FORMAT(S.createdAt, 'MMMM dd, yyyy hh:mm tt') AS formattedDate,
                        U.userLname + ', ' + U.userFname AS fullName
                    FROM Stock S
                    JOIN Product P ON S.prodId = P.prodId
                    JOIN Users U ON S.userId = U.userId
                    WHERE 
                        P.prodName LIKE @search
                    ORDER BY S.createdAt DESC";

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
