using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCHOOL_SUPPLY_SHOP_MANAGEMENT_SYSTEM
{
    public partial class viewCustomers : Form
    {
        public int _customerId;
        string connectionString = @"Data Source=ESTORBA-PC\SQLEXPRESS02;Initial Catalog=MANAGEMENT_SYSTEM;Integrated Security=True;Encrypt=False;";
        public viewCustomers(int custId)
        {
            InitializeComponent();
            _customerId = custId;
            fetchCustomerDetail(custId);
            LoadCustomerTransactionDetails();
            dataGridViewReceipt.AllowUserToAddRows = false;
            dataGridViewReceipt.ReadOnly = true;
            dataGridViewReceipt.ClearSelection();
        }
        private void LoadCustomerTransactionDetails()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT t.transactionId, COUNT(ti.transactionId) as numItems, FORMAT(t.totalAmount, 'C', 'en-PH') AS totalAmount, t.paymentMethod, t.createdAt, CONCAT(u.userFname, ' ', u.userLname) AS fullName 
                        FROM Transactions t JOIN TransactionItems ti ON t.transactionId = ti.transactionId JOIN Users u ON t.userId = u.userId WHERE t.custId = @custId
                        GROUP BY t.transactionId, t.totalAmount, t.paymentMethod, t.createdAt, u.userLname, u.userFname ORDER BY t.transactionId DESC";


                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.Add("@custId", SqlDbType.Int).Value = _customerId;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridViewReceipt.DataSource = table;
                }
                dataGridViewReceipt.AllowUserToAddRows = false;
                dataGridViewReceipt.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading purchase history: " + ex.Message);
            }
        }
        private void fetchCustomerDetail(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Customer WHERE custId = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string lastname = reader["custLname"].ToString();
                        string firstname = reader["custFname"].ToString();
                        string middlename = reader["custMname"].ToString();
                        string address = reader["custAddress"].ToString();
                        string phone = reader["custMobile"].ToString();

                        // View Panels
                        lblLastname.Text = lastname;
                        lblFirstName.Text = firstname;
                        lblMiddlename.Text = middlename;
                        lblAddress.Text = address;
                        lblMnumber.Text = phone;
                    }
                    else
                    {
                        MessageBox.Show("Customer not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dataGridViewReceipt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridViewReceipt.Columns[e.ColumnIndex].Name == "viewReceipt")
                {
                    string transactionId = dataGridViewReceipt.Rows[e.RowIndex].Cells["invNum"].Value.ToString();
                    Receipt receipt = new Receipt(transactionId);
                    receipt.ShowDialog();
                }
            }
        }
    }
}
