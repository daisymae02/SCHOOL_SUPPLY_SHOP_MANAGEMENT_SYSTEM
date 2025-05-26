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

namespace SCHOOL_SUPPLY_SHOP_MANAGEMENT_SYSTEM
{
    public partial class Checkout : Form
    {
        string connectionString = "Data Source=ESTORBA-PC\\SQLEXPRESS02;Initial Catalog=MANAGEMENT_SYSTEM;Integrated Security=True;Encrypt=False;";
        Dictionary<string, int> customerMap = new Dictionary<string, int>();
        // Declare event
        public event Action? CheckoutCompleted;
        int userID;
        public Checkout(int id)
        {
            InitializeComponent();
            this.userID = id;
            LoadCustomers();
            txtCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCustomer.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void Checkout_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            txtCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCustomer.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void LoadCustomers()
        {
            txtCustomer.Items.Clear();
            customerMap.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT custId, custLname, custFname FROM Customer ORDER BY custLname";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string fullName = $"{reader["custLname"]}, {reader["custFname"]}";
                            int custId = Convert.ToInt32(reader["custId"]);

                            txtCustomer.Items.Add(fullName);
                            customerMap[fullName] = custId;
                        }
                    }
                }
            }

            txtCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCustomer.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public void LoadCartItems(List<CartList> cartItems)
        {
            flowLayoutCheckoutItems.Controls.Clear();

            decimal subtotal = 0;

            foreach (var cart in cartItems)
            {
                Image productImage = GetProductImageById(cart.productCartID);

                checkoutItems item = new checkoutItems
                {
                    checkoutImage = productImage,
                    checkoutName = cart.productCartName,
                    checkoutQuantity = $"x{cart.Quantity}",
                    checkoutPrice = $"₱ {cart.GetTotalPrice():N2}",
                    NumericQuantity = cart.Quantity,
                    NumericPrice = cart.GetTotalPrice()
                };

                flowLayoutCheckoutItems.Controls.Add(item);

                subtotal += cart.GetTotalPrice();
            }

            // Apply discount and VAT
            decimal discountRate = 0.10m;
            decimal vatRate = 0.12m;

            decimal discountAmount = subtotal * discountRate;
            decimal discountedSubtotal = subtotal - discountAmount;
            decimal vatAmount = discountedSubtotal * vatRate;
            decimal total = discountedSubtotal + vatAmount;

            // Display in labels
            lblSubtotal.Text = $"₱ {subtotal:N2}";
            lblDiscount.Text = $"- ₱ {discountAmount:N2}";
            lblVat.Text = $"+ ₱ {vatAmount:N2}";
            lblTotal.Text = $"₱ {total:N2}";
        }

        public Image GetProductImageById(int productId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT prodImage FROM Product WHERE prodId = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", productId);
                    byte[] imageBytes = cmd.ExecuteScalar() as byte[];

                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            return Image.FromStream(ms);
                        }
                    }
                }
            }

            return null; // or a default image if needed
        }

        private void txtCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedName = txtCustomer.Text.Trim();

            if (customerMap.ContainsKey(selectedName))
            {
                int custId = customerMap[selectedName];

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT custLname, custFname, custMname, custMobile, custAddress FROM Customer WHERE custId = @custId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@custId", custId);
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtLastname.Text = reader["custLname"].ToString();
                                txtFirstname.Text = reader["custFname"].ToString();
                                txtMiddlename.Text = reader["custMname"].ToString();
                                txtMobileNumber.Text = reader["custMobile"].ToString();
                                txtAddress.Text = reader["custAddress"].ToString();
                            }
                        }
                    }
                }
            }
        }

        private void txtMobileNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block the input
            }
        }

        private void txtxAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Allow control keys (e.g., backspace), digits, and one dot (.)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            // Only allow one decimal point
            if (e.KeyChar == '.' && txt.Text.Contains("."))
            {
                e.Handled = true;
                return;
            }

            // Limit to two decimal places
            if (txt.Text.Contains("."))
            {
                int decimalIndex = txt.Text.IndexOf('.');
                string afterDecimal = txt.Text.Substring(decimalIndex + 1);

                if (txt.SelectionStart > decimalIndex && afterDecimal.Length >= 2 && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void txtxAmount_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtxAmount.Text, out decimal amountPaid) &&
                decimal.TryParse(lblTotal.Text.Replace("₱", "").Trim(), out decimal totalAmount))
            {
                decimal change = amountPaid - totalAmount;
                txtChange.Text = change >= 0 ? $"₱ {change:N2}" : "₱ 0.00";
                errorAmount.Visible = false; // Hide error icon
            }
            else
            {
                txtChange.Text = "₱ 0.00";
                errorAmount.Visible = true; // Show error icon
            }
        }

        private void cbPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPaymentMethod.SelectedItem?.ToString() == "Pay Cash")
            {
                referencePanel.Visible = false;
                errorPaymentMethod.Visible = false; // No error if a valid selection is made
            }
            else if (!string.IsNullOrEmpty(cbPaymentMethod.SelectedItem?.ToString()))
            {
                referencePanel.Visible = true;
                errorPaymentMethod.Visible = false; // Still valid
            }
            else
            {
                referencePanel.Visible = false;
                errorPaymentMethod.Visible = true; // Show error if invalid or null
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

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                errorAddress.Visible = true;
            }
            else
            {
                errorAddress.Visible = false;
            }
        }
        private bool IsValidMobileNumber(string mobile)
        {
            string pattern = @"^09\d{9}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(mobile);
        }

        private void txtMobileNumber_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMobileNumber.Text))
            {
                errorMobileNumber.Visible = true;
            }
            else
            {
                if (!IsValidMobileNumber(txtMobileNumber.Text.Trim()))
                {
                    errorMobileNumber.Visible = true;
                }
                else
                {
                    errorMobileNumber.Visible = false;
                }
            }
        }

        private void txtReferenceNo_TextChanged(object sender, EventArgs e)
        {
            if (referencePanel.Visible)
            {
                if (!string.IsNullOrWhiteSpace(txtReferenceNo.Text))
                {
                    errorReferencePayment.Visible = false; // Valid input
                }
                else
                {
                    errorReferencePayment.Visible = true; // Show error only if panel is visible and input is empty
                }
            }
            else
            {
                errorReferencePayment.Visible = false; // Hide error if panel is hidden
            }
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            ClearErrorIndicators();

            if (!ValidateInputs(out decimal amountPaid, out decimal totalAmount))
                return;

            using (var confirm = new Logout("CONFIRMATION", "Would you like to confirm this order?"))
            {
                if (confirm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }

            string lastName = txtLastname.Text.Trim();
            string firstName = txtFirstname.Text.Trim();
            string middleName = txtMiddlename.Text.Trim();
            string mobileNumber = txtMobileNumber.Text.Trim();
            string address = txtAddress.Text.Trim();
            string paymentMethod = cbPaymentMethod.SelectedItem?.ToString() ?? "Pay Cash";
            string paymentReference = txtReferenceNo.Text.Trim();

            try
            {
                using SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                using SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    int customerId = GetOrCreateCustomer(conn, transaction, lastName, firstName, middleName, mobileNumber, address);

                    string transactionId = GenerateTransactionId(conn, transaction);

                    ProcessTransaction(conn, transaction, customerId, paymentMethod, paymentReference, amountPaid, transactionId);

                    InsertTransactionItems(conn, transaction, transactionId);

                    UpdateProductQuantities(conn, transaction);

                    transaction.Commit();
                    
                    using (var info = new Information("SUCCESS", "Purchase completed successfully!"))
                    {
                        info.ShowDialog();
                    }

                    using (var confirm = new Logout("VIEW RECEIPT", "Do you want to view the receipt?"))
                    {
                        if (confirm.ShowDialog() == DialogResult.OK)
                        {
                            Receipt receipt = new Receipt(transactionId);
                            receipt.ShowDialog();
                        }
                    }

                    // Notify parent about successful checkout
                    CheckoutCompleted?.Invoke();

                    this.Close();

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearErrorIndicators()
        {
            errorLastname.Visible = false;
            errorFirstname.Visible = false;
            errorAddress.Visible = false;
            errorMobileNumber.Visible = false;
            errorAmount.Visible = false;
            errorPaymentMethod.Visible = false;
            errorReferencePayment.Visible = false;
        }

        private bool ValidateInputs(out decimal amountPaid, out decimal totalAmount)
        {
            bool isValid = true;
            amountPaid = 0m;
            totalAmount = 0m;

            if (string.IsNullOrEmpty(txtLastname.Text.Trim()))
            {
                errorLastname.Visible = true;
                isValid = false;
            }
            if (string.IsNullOrEmpty(txtFirstname.Text.Trim()))
            {
                errorFirstname.Visible = true;
                isValid = false;
            }
            if (string.IsNullOrEmpty(txtAddress.Text.Trim()))
            {
                errorAddress.Visible = true;
                isValid = false;
            }
            if (string.IsNullOrEmpty(txtMobileNumber.Text.Trim()) || !IsValidMobileNumber(txtMobileNumber.Text.Trim()))
            {
                errorMobileNumber.Visible = true;
                isValid = false;
            }

            if (!decimal.TryParse(txtxAmount.Text.Trim(), out amountPaid))
            {
                errorAmount.Visible = true;
                isValid = false;
            }
            else if (!decimal.TryParse(lblTotal.Text.Replace("₱", "").Trim(), out totalAmount) || amountPaid < totalAmount)
            {
                errorAmount.Visible = true;
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(cbPaymentMethod.SelectedItem?.ToString()))
            {
                errorPaymentMethod.Visible = true;
                isValid = false;
            }

            if (referencePanel.Visible && string.IsNullOrWhiteSpace(txtReferenceNo.Text))
            {
                errorReferencePayment.Visible = true;
                isValid = false;
            }

            return isValid;
        }

        private int GetOrCreateCustomer(SqlConnection conn, SqlTransaction transaction, string lastName, string firstName, string middleName, string mobile, string address)
        {
            const string selectQuery = @"
                SELECT custId, custAddress, custMobile FROM Customer 
                WHERE custLname = @lname AND custFname = @fname AND custMname = @mname";    

            using SqlCommand cmd = new SqlCommand(selectQuery, conn, transaction);
            cmd.Parameters.AddWithValue("@lname", lastName);
            cmd.Parameters.AddWithValue("@fname", firstName);
            cmd.Parameters.AddWithValue("@mname", middleName);

            using SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                int customerId = Convert.ToInt32(reader["custId"]);
                string existingAddress = reader["custAddress"].ToString();
                string existingMobile = reader["custMobile"].ToString();
                reader.Close();

                if (!string.Equals(existingAddress, address, StringComparison.OrdinalIgnoreCase))
                {
                    UpdateCustomerAddress(conn, transaction, customerId, address, mobile);
                }

                return customerId;
            }
            reader.Close();

            return InsertCustomer(conn, transaction, lastName, firstName, middleName, mobile, address);
        }

        private void UpdateCustomerAddress(SqlConnection conn, SqlTransaction transaction, int customerId, string newAddress, string newMobile)
        {
            const string updateQuery = "UPDATE Customer SET custAddress = @address, custMobile = @mobile WHERE custId = @custId";

            using SqlCommand cmd = new SqlCommand(updateQuery, conn, transaction);
            cmd.Parameters.AddWithValue("@address", newAddress);
            cmd.Parameters.AddWithValue("@mobile", newMobile);
            cmd.Parameters.AddWithValue("@custId", customerId);
            cmd.ExecuteNonQuery();
        }

        private int InsertCustomer(SqlConnection conn, SqlTransaction transaction, string lastName, string firstName, string middleName, string mobile, string address)
        {
            const string insertQuery = @"
                INSERT INTO Customer (custLname, custFname, custMname, custMobile, custAddress, custStatus)
                VALUES (@lname, @fname, @mname, @mobile, @address, 'Active');
                SELECT CAST(SCOPE_IDENTITY() AS int);";

            using SqlCommand cmd = new SqlCommand(insertQuery, conn, transaction);
            cmd.Parameters.AddWithValue("@lname", lastName);
            cmd.Parameters.AddWithValue("@fname", firstName);
            cmd.Parameters.AddWithValue("@mname", middleName);
            cmd.Parameters.AddWithValue("@mobile", mobile);
            cmd.Parameters.AddWithValue("@address", address);

            return (int)cmd.ExecuteScalar();
        }

        private void ProcessTransaction(SqlConnection conn, SqlTransaction transaction, int customerId, string paymentMethod, string paymentReference, decimal amountPaid, string transactionId)
        {
            decimal subTotal = ParseCurrency(lblSubtotal.Text);
            decimal discount = ParseCurrency(lblDiscount.Text);
            decimal vat = ParseCurrency(lblVat.Text);
            decimal total = ParseCurrency(lblTotal.Text);
            decimal change = amountPaid - total;

            const string insertTransactionQuery = @"
                INSERT INTO Transactions 
                (transactionId, subTotalAmount, discountAmount, vatAmount, totalAmount, amountPaid, changeDue, 
                 paymentMethod, paymentReference, createdAt, userId, custId)
                VALUES 
                (@transactionId, @subTotal, @discount, @vat, @total, @paid, @change, 
                 @method, @reference, GETDATE(), @userId, @custId)";

            using (SqlCommand cmd = new SqlCommand(insertTransactionQuery, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@transactionId", transactionId);
                cmd.Parameters.AddWithValue("@subTotal", subTotal);
                cmd.Parameters.AddWithValue("@discount", discount);
                cmd.Parameters.AddWithValue("@vat", vat);
                cmd.Parameters.AddWithValue("@total", total);
                cmd.Parameters.AddWithValue("@paid", amountPaid);
                cmd.Parameters.AddWithValue("@change", change);
                cmd.Parameters.AddWithValue("@method", paymentMethod);
                cmd.Parameters.AddWithValue("@reference", string.IsNullOrEmpty(paymentReference) ? DBNull.Value : (object)paymentReference);
                cmd.Parameters.AddWithValue("@userId", userID); // Make sure userID is defined elsewhere in the class
                cmd.Parameters.AddWithValue("@custId", customerId);
                cmd.ExecuteNonQuery();
            }
        }

        private void InsertTransactionItems(SqlConnection conn, SqlTransaction transaction, string transactionId)
        {
            foreach (checkoutItems item in flowLayoutCheckoutItems.Controls.OfType<checkoutItems>())
            {
                int prodId = GetProductIdByName(item.checkoutName, conn, transaction);
                int quantity = item.NumericQuantity;
                decimal price = item.NumericPrice;
                decimal subtotal = quantity * price;

                const string insertItemQuery = @"
                    INSERT INTO TransactionItems 
                    (transactionItemQuantity, transactionItemPrice, transactionItemSubTotal, transactionId, prodId)
                    VALUES (@qty, @price, @subtotal, @transId, @prodId)";

                using SqlCommand cmd = new SqlCommand(insertItemQuery, conn, transaction);
                cmd.Parameters.AddWithValue("@qty", quantity);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@subtotal", subtotal);
                cmd.Parameters.AddWithValue("@transId", transactionId);
                cmd.Parameters.AddWithValue("@prodId", prodId);
                cmd.ExecuteNonQuery();
            }
        }

        // Update product quantity after sale
        private void UpdateProductQuantities(SqlConnection conn, SqlTransaction transaction)
        {
            foreach (checkoutItems item in flowLayoutCheckoutItems.Controls.OfType<checkoutItems>())
            {
                int prodId = GetProductIdByName(item.checkoutName, conn, transaction);
                int quantitySold = item.NumericQuantity;

                const string updateProductQuantityQuery = @"
                    UPDATE Product
                    SET prodQuantityInStock = prodQuantityInStock - @quantitySold
                    WHERE prodId = @prodId";    

                using SqlCommand cmd = new SqlCommand(updateProductQuantityQuery, conn, transaction);
                cmd.Parameters.AddWithValue("@quantitySold", quantitySold);
                cmd.Parameters.AddWithValue("@prodId", prodId);
                cmd.ExecuteNonQuery();
            }
        }

        private int GetProductIdByName(string productName, SqlConnection conn, SqlTransaction transaction)
        {
            const string query = "SELECT prodId FROM Product WHERE prodName = @name";

            using SqlCommand cmd = new SqlCommand(query, conn, transaction);
            cmd.Parameters.AddWithValue("@name", productName);

            var result = cmd.ExecuteScalar();
            return result != null ? Convert.ToInt32(result) : 0;
        }

        private decimal ParseCurrency(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0m;

            string cleanText = text.Replace("₱", "").Trim().Replace("-", "").Replace("+", "");
            return decimal.TryParse(cleanText, out var result) ? result : 0m;
        }

        private string GenerateTransactionId(SqlConnection conn, SqlTransaction transaction)
        {
            string prefix = "INV" + DateTime.Now.ToString("yyyyMM"); // e.g., INV202505
            string query = @"
                SELECT TOP 1 transactionId 
                FROM Transactions 
                WHERE transactionId LIKE @prefix + '%' 
                ORDER BY transactionId DESC";

            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@prefix", prefix);
                var lastId = cmd.ExecuteScalar()?.ToString();

                int newSeq = 1;
                if (!string.IsNullOrEmpty(lastId) && lastId.Length >= prefix.Length + 4)
                {
                    // Get the last 4 digits after the prefix
                    string lastSeq = lastId.Substring(prefix.Length, 4);
                    if (int.TryParse(lastSeq, out int lastNumber))
                    {
                        newSeq = lastNumber + 1;
                    }
                }

                return prefix + newSeq.ToString("D4"); // e.g., INV2025050002
            }
        }


        private int GetProductIdByName(string productName, SqlConnection conn)
        {
            string query = "SELECT prodId FROM Product WHERE prodName = @name";
            using SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@name", productName);
            object result = cmd.ExecuteScalar();

            if (result != null && int.TryParse(result.ToString(), out int prodId))
            {
                return prodId;
            }
            else
            {
                throw new Exception($"Product '{productName}' not found in the database.");
            }
        }
    }
}
