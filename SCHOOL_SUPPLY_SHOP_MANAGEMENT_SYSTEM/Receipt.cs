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
using System.Xml.Linq;

namespace SCHOOL_SUPPLY_SHOP_MANAGEMENT_SYSTEM
{
    public partial class Receipt : Form
    {
        string connectionString = "Data Source=ESTORBA-PC\\SQLEXPRESS02;Initial Catalog=MANAGEMENT_SYSTEM;Integrated Security=True;Encrypt=False;";
        string transID;
        string ReceiptTotalAmount;
        string ReceiptCashAmount;
        string ReceiptChangeAmount;
        string ReceiptDiscountAmount;
        string ReceiptVatAmount;
        string ReceiptTotalItems;
        string ReceiptSubTotal;

        string CustomerName;
        string CustomerAddress;
        string CustomerMobile;

        string ReceiptPaymentMethod;
        string ReceiptReferenceNo;

        public Receipt(string id = "")
        {
            InitializeComponent();
            this.transID = id;
            LoadTransactionDetails();
            LoadTransactionItems();
            AddSubtotalPanel();
            AddTotalPanel();
            AddCashPanel();
            AddChangePanel();
            AddLabel();
            AddDiscountPanel();
            AddVatPanel();
            AddEmptyPanel();
            AddCustomerLbl();
            LoadCustomerDetails();
            AddCustomerName();
            AddCustomerMobile();
            AddCustomerAddress();
            AddLabel();
            AddPaymentMethod();
            if (!string.IsNullOrWhiteSpace(ReceiptReferenceNo))
            {
                AddPaymentReference();
            }
            AddEmptyPanel();
            AddClosingRemark();
            AddEmptyPanel();
        }

        private void LoadTransactionDetails()
        {
            string query = @"
                SELECT 
                    t.transactionId, 
                    COUNT(ti.transactionId) AS numItems, 
                    t.subTotalAmount, 
                    t.totalAmount, 
                    t.amountPaid, 
                    t.changeDue, 
                    t.discountAmount, 
                    t.vatAmount, 
                    t.paymentMethod, 
                    t.paymentReference, 
                    t.createdAt, 
                    u.userLname, 
                    u.userFname, 
                    u.userMname 
                FROM Transactions t 
                JOIN TransactionItems ti ON t.transactionId = ti.transactionId 
                JOIN Users u ON t.userId = u.userId 
                WHERE t.transactionId = @id 
                GROUP BY 
                    t.transactionId, 
                    t.subTotalAmount, 
                    t.totalAmount, 
                    t.amountPaid, 
                    t.changeDue, 
                    t.discountAmount, 
                    t.vatAmount, 
                    t.paymentMethod, 
                    t.paymentReference, 
                    t.createdAt, 
                    u.userLname, 
                    u.userFname, 
                    u.userMname;";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", transID);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string transactionId = reader["transactionId"].ToString();
                        string totalAmount = $"{Convert.ToDecimal(reader["totalAmount"]):N2}";
                        string amountPaid = $"{Convert.ToDecimal(reader["amountPaid"]):N2}";
                        string changeDue = $"{Convert.ToDecimal(reader["changeDue"]):N2}";
                        string discountAmount = $"{Convert.ToDecimal(reader["discountAmount"]):N2}";
                        string vatAmount = $"{Convert.ToDecimal(reader["vatAmount"]):N2}";
                        string createdAt = Convert.ToDateTime(reader["createdAt"]).ToString("MMMM dd, yyyy");
                        string createdAtTime = Convert.ToDateTime(reader["createdAt"]).ToString("hh: mm tt");
                        string paymentMethod = reader["paymentMethod"].ToString();
                        string paymentReference = reader["paymentReference"].ToString();
                        string numItems = $"{reader["numItems"]} Item(s)";
                        string subTotalAmount = $"{Convert.ToDecimal(reader["subTotalAmount"]):N2}";
                        string lname = reader["userLname"].ToString();
                        string fname = reader["userFname"].ToString();
                        string mname = reader["userMname"]?.ToString();
                        string middleInitial = string.IsNullOrWhiteSpace(mname) ? "" : $"{mname[0]}.";

                        string fullName = $"{lname}, {fname} {middleInitial}".Trim();

                        lblTransactionID.Text = transactionId;
                        lblTransactionDate.Text = createdAt;
                        lblTransactionTime.Text = createdAtTime;
                        lblStaffname.Text = fullName;
                        ReceiptTotalAmount = totalAmount;
                        ReceiptCashAmount = amountPaid;
                        ReceiptChangeAmount = changeDue;
                        ReceiptDiscountAmount = discountAmount;
                        ReceiptVatAmount = vatAmount;
                        ReceiptPaymentMethod = paymentMethod;
                        ReceiptReferenceNo = paymentReference;
                        ReceiptTotalItems = numItems;
                        ReceiptSubTotal = subTotalAmount;
                    }
                }
            }
        }
        private void LoadTransactionItems()
        {
            string query = "SELECT p.prodName, item.transactionItemQuantity, item.transactionItemPrice, item.transactionItemSubTotal " +
                           "FROM TransactionItems item JOIN Product p ON item.prodId = p.prodId WHERE item.transactionId = @id;";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", transID);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string prodName = reader["prodName"].ToString();
                        string quantity = "x" + reader["transactionItemQuantity"].ToString();
                        string price = $"₱ {Convert.ToDecimal(reader["transactionItemPrice"]):N2}";
                        string subtotal = $"{Convert.ToDecimal(reader["transactionItemSubTotal"]):N2}";

                        receiptItems itemControl = new receiptItems
                        {
                            ReceiptItemName = prodName,
                            ReceiptItemQuantity = quantity,
                            ReceiptItemPrice = price,
                            ReceiptItemSubtotal = subtotal
                        };

                        flowLayoutReceipt.Controls.Add(itemControl);
                    }
                }
            }
        }

        private void LoadCustomerDetails()
        {
            string query = "SELECT custLname, c.custFname, c.custMname, c.custAddress, c.custMobile " +
                "FROM Transactions t JOIN Customer c ON t.custId = c.custId WHERE t.transactionId = @id;";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", transID);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string address = reader["custAddress"].ToString();
                        string mobile = reader["custMobile"].ToString();
                        string lname = reader["custLname"].ToString();
                        string fname = reader["custFname"].ToString();
                        string mname = reader["custMname"]?.ToString();
                        string middleInitial = string.IsNullOrWhiteSpace(mname) ? "" : $"{mname[0]}.";

                        string fullName = $"{lname}, {fname} {middleInitial}".Trim();

                        CustomerName = fullName;
                        CustomerAddress = address;
                        CustomerMobile = mobile;
                    }
                }
            }
        }

        private void AddTotalPanel()
        {
            // Initialize if not already done
            Panel panel8 = new Panel();
            Label lblTotalAmount = new Label();
            Label label11 = new Label();

            label11.Dock = DockStyle.Left;
            label11.Font = new Font("Mongolian Baiti", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Size = new Size(200, 30);
            label11.Text = "Total Amount Due";
            label11.Padding = new Padding(10, 0, 0, 0);
            label11.TextAlign = ContentAlignment.BottomLeft;

            lblTotalAmount.Dock = DockStyle.Right;
            lblTotalAmount.Font = new Font("Mongolian Baiti", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalAmount.Size = new Size(155, 30);
            lblTotalAmount.Padding = new Padding(0, 0, 10, 0);
            lblTotalAmount.TextAlign = ContentAlignment.BottomRight;

            lblTotalAmount.Text = ReceiptTotalAmount;

            panel8.Controls.Add(lblTotalAmount);
            panel8.Controls.Add(label11);
            panel8.Size = new Size(338, 30);
            panel8.Margin = new Padding(3);
            flowLayoutReceipt.Controls.Add(panel8);
        }

        private void AddCashPanel()
        {
            // Initialize if not already done
            Panel panel9 = new Panel();
            Label lblCashAmount = new Label();
            Label label10 = new Label();

            label10.Dock = DockStyle.Left;
            label10.Font = new Font("Mongolian Baiti", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Size = new Size(200, 30);
            label10.Text = "Cash";
            label10.Padding = new Padding(10, 0, 0, 0);
            label10.TextAlign = ContentAlignment.BottomLeft;

            lblCashAmount.Dock = DockStyle.Right;
            lblCashAmount.Font = new Font("Mongolian Baiti", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCashAmount.Size = new Size(155, 30);
            lblCashAmount.Padding = new Padding(0, 0, 10, 0);
            lblCashAmount.TextAlign = ContentAlignment.BottomRight;

            lblCashAmount.Text = ReceiptCashAmount;

            panel9.Controls.Add(lblCashAmount);
            panel9.Controls.Add(label10);
            panel9.Size = new Size(338, 18);
            panel9.Margin = new Padding(3);
            flowLayoutReceipt.Controls.Add(panel9);
        }

        private void AddChangePanel()
        {
            // Initialize if not already done
            Panel panel10 = new Panel();
            Label lblChangeAmount = new Label();
            Label label11 = new Label();

            label11.Dock = DockStyle.Left;
            label11.Font = new Font("Mongolian Baiti", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Size = new Size(200, 30);
            label11.Text = "Change";
            label11.Padding = new Padding(10, 0, 0, 0);
            label11.TextAlign = ContentAlignment.BottomLeft;

            lblChangeAmount.Dock = DockStyle.Right;
            lblChangeAmount.Font = new Font("Mongolian Baiti", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblChangeAmount.Size = new Size(155, 30);
            lblChangeAmount.Padding = new Padding(0, 0, 10, 0);
            lblChangeAmount.TextAlign = ContentAlignment.BottomRight;

            lblChangeAmount.Text = ReceiptChangeAmount;

            panel10.Controls.Add(lblChangeAmount);
            panel10.Controls.Add(label11);
            panel10.Size = new Size(338, 18);
            panel10.Margin = new Padding(3);
            flowLayoutReceipt.Controls.Add(panel10);
        }

        private void AddLabel()
        {
            Label label4 = new Label();

            label4.Size = new Size(338, 18);
            label4.Margin = new Padding(3);
            label4.Text = "--------------------------------------------------------";
            label4.TextAlign = ContentAlignment.MiddleCenter;

            flowLayoutReceipt.Controls.Add(label4);
        }

        private void AddDiscountPanel()
        {
            // Initialize if not already done
            Panel panel11 = new Panel();
            Label lblDiscountAmount = new Label();
            Label label12 = new Label();

            label12.Dock = DockStyle.Left;
            label12.Font = new Font("Mongolian Baiti", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Size = new Size(200, 30);
            label12.Text = "Discount";
            label12.Padding = new Padding(10, 0, 0, 0);
            label12.TextAlign = ContentAlignment.BottomLeft;

            lblDiscountAmount.Dock = DockStyle.Right;
            lblDiscountAmount.Font = new Font("Mongolian Baiti", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDiscountAmount.Size = new Size(155, 30);
            lblDiscountAmount.Padding = new Padding(0, 0, 10, 0);
            lblDiscountAmount.TextAlign = ContentAlignment.BottomRight;

            lblDiscountAmount.Text = ReceiptDiscountAmount;

            panel11.Controls.Add(lblDiscountAmount);
            panel11.Controls.Add(label12);
            panel11.Size = new Size(338, 18);
            panel11.Margin = new Padding(3);
            flowLayoutReceipt.Controls.Add(panel11);
        }

        private void AddVatPanel()
        {
            // Initialize if not already done
            Panel panel12 = new Panel();
            Label lblVatAmount = new Label();
            Label label13 = new Label();

            label13.Dock = DockStyle.Left;
            label13.Font = new Font("Mongolian Baiti", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Size = new Size(200, 30);
            label13.Text = "VAT";
            label13.Padding = new Padding(10, 0, 0, 0);
            label13.TextAlign = ContentAlignment.BottomLeft;

            lblVatAmount.Dock = DockStyle.Right;
            lblVatAmount.Font = new Font("Mongolian Baiti", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVatAmount.Size = new Size(155, 30);
            lblVatAmount.Padding = new Padding(0, 0, 10, 0);
            lblVatAmount.TextAlign = ContentAlignment.BottomRight;

            lblVatAmount.Text = ReceiptVatAmount;

            panel12.Controls.Add(lblVatAmount);
            panel12.Controls.Add(label13);
            panel12.Size = new Size(338, 18);
            panel12.Margin = new Padding(3);
            flowLayoutReceipt.Controls.Add(panel12);
        }

        private void AddEmptyPanel()
        {
            Panel panel13 = new Panel();
            panel13.Size = new Size(338, 10);
            panel13.Margin = new Padding(3);
            flowLayoutReceipt.Controls.Add(panel13);
        }

        private void AddCustomerLbl()
        {
            Panel panel14 = new Panel();
            Label label14 = new Label();

            label14.Dock = DockStyle.Fill;
            label14.Font = new Font("Mongolian Baiti", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Size = new Size(70, 20);
            label14.Padding = new Padding(10, 0, 0, 0);
            label14.Text = "Customer Details:";
            label14.TextAlign = ContentAlignment.MiddleLeft;

            panel14.Size = new Size(338, 18);
            panel14.Margin = new Padding(3);
            panel14.Controls.Add(label14);
            flowLayoutReceipt.Controls.Add(panel14);
        }

        private void AddCustomerName()
        {
            Panel panel15 = new Panel();
            Label label15 = new Label();
            Label lblCusname = new Label();

            label15.Dock = DockStyle.Left;
            label15.Font = new Font("Mongolian Baiti", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.Size = new Size(70, 20);
            label15.Text = "Name:";
            label15.Padding = new Padding(10, 0, 0, 0);
            label15.TextAlign = ContentAlignment.MiddleLeft;

            lblCusname.Dock = DockStyle.Fill;
            lblCusname.Font = new Font("Mongolian Baiti", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCusname.Size = new Size(260, 20);
            lblCusname.Padding = new Padding(0, 0, 10, 0);
            lblCusname.TextAlign = ContentAlignment.MiddleLeft;
            lblCusname.AutoEllipsis = true;

            lblCusname.Text = CustomerName + " ......................................................................";

            panel15.Size = new Size(338, 20);
            panel15.Margin = new Padding(3);
            panel15.Controls.Add(lblCusname);
            panel15.Controls.Add(label15);
            flowLayoutReceipt.Controls.Add(panel15);
        }

        private void AddCustomerMobile()
        {
            Panel panel16 = new Panel();
            Label label16 = new Label();
            Label lblCusmobile = new Label();

            label16.Dock = DockStyle.Left;
            label16.Font = new Font("Mongolian Baiti", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label16.Size = new Size(108, 20);
            label16.Text = "Mobile no.:";
            label16.Padding = new Padding(10, 0, 0, 0);
            label16.TextAlign = ContentAlignment.MiddleLeft;

            lblCusmobile.Dock = DockStyle.Fill;
            lblCusmobile.Font = new Font("Mongolian Baiti", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCusmobile.Size = new Size(260, 20);
            lblCusmobile.Padding = new Padding(0, 0, 10, 0);
            lblCusmobile.TextAlign = ContentAlignment.MiddleLeft;
            lblCusmobile.AutoEllipsis = true;

            lblCusmobile.Text = CustomerMobile + " ......................................................................";

            panel16.Size = new Size(338, 20);
            panel16.Margin = new Padding(3);
            panel16.Controls.Add(lblCusmobile);
            panel16.Controls.Add(label16);
            flowLayoutReceipt.Controls.Add(panel16);
        }

        private void AddCustomerAddress()
        {
            Panel panel17 = new Panel();
            Label label17 = new Label();
            Label lblCusaddress = new Label();

            label17.Dock = DockStyle.Left;
            label17.Font = new Font("Mongolian Baiti", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label17.Size = new Size(84, 20);
            label17.Text = "Address:";
            label17.Padding = new Padding(10, 0, 0, 0);
            label17.TextAlign = ContentAlignment.MiddleLeft;

            lblCusaddress.Dock = DockStyle.Fill;
            lblCusaddress.Font = new Font("Mongolian Baiti", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCusaddress.Size = new Size(260, 20);
            lblCusaddress.Padding = new Padding(0, 0, 10, 0);
            lblCusaddress.TextAlign = ContentAlignment.MiddleLeft;
            lblCusaddress.AutoEllipsis = true;

            lblCusaddress.Text = CustomerAddress + " ......................................................................";

            panel17.Size = new Size(338, 20);
            panel17.Margin = new Padding(3);
            panel17.Controls.Add(lblCusaddress);
            panel17.Controls.Add(label17);
            flowLayoutReceipt.Controls.Add(panel17);
        }

        private void AddPaymentMethod()
        {
            Panel panel18 = new Panel();
            Label label18 = new Label();
            Label lblPaymentMethod = new Label();

            label18.Dock = DockStyle.Left;
            label18.Font = new Font("Mongolian Baiti", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label18.Size = new Size(145, 20);
            label18.Text = "Payment Method:";
            label18.Padding = new Padding(10, 0, 0, 0);
            label18.TextAlign = ContentAlignment.MiddleLeft;

            lblPaymentMethod.Dock = DockStyle.Fill;
            lblPaymentMethod.Font = new Font("Mongolian Baiti", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPaymentMethod.Size = new Size(260, 20);
            lblPaymentMethod.Padding = new Padding(0, 0, 10, 0);
            lblPaymentMethod.TextAlign = ContentAlignment.MiddleLeft;
            lblPaymentMethod.AutoEllipsis = true;

            lblPaymentMethod.Text = ReceiptPaymentMethod + " ......................................................................";

            panel18.Size = new Size(338, 20);
            panel18.Margin = new Padding(3);
            panel18.Controls.Add(lblPaymentMethod);
            panel18.Controls.Add(label18);
            flowLayoutReceipt.Controls.Add(panel18);
        }

        private void AddPaymentReference()
        {
            Panel panel19 = new Panel();
            Label label19 = new Label();
            Label lblPaymentReference = new Label();

            label19.Dock = DockStyle.Left;
            label19.Font = new Font("Mongolian Baiti", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label19.Size = new Size(160, 20);
            label19.Text = "Payment Reference:";
            label19.Padding = new Padding(10, 0, 0, 0);
            label19.TextAlign = ContentAlignment.MiddleLeft;

            lblPaymentReference.Dock = DockStyle.Fill;
            lblPaymentReference.Font = new Font("Mongolian Baiti", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPaymentReference.Size = new Size(260, 20);
            lblPaymentReference.Padding = new Padding(0, 0, 10, 0);
            lblPaymentReference.TextAlign = ContentAlignment.MiddleLeft;
            lblPaymentReference.AutoEllipsis = true;

            lblPaymentReference.Text = ReceiptReferenceNo + " ......................................................................";

            panel19.Size = new Size(338, 20);
            panel19.Margin = new Padding(3);
            panel19.Controls.Add(lblPaymentReference);
            panel19.Controls.Add(label19);
            flowLayoutReceipt.Controls.Add(panel19);
        }

        private void AddClosingRemark()
        {
            Panel panelClosing = new Panel();
            Label labelClosing = new Label();

            labelClosing.Font = new Font("Mongolian Baiti", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelClosing.Text = "THANK YOU FOR\r\nYOUR PURCHASE";
            labelClosing.Size = new Size(338, 47);
            labelClosing.TextAlign = ContentAlignment.MiddleCenter;
            labelClosing.Dock = DockStyle.Fill;

            panelClosing.Size = new Size(338, 47);
            panelClosing.Margin = new Padding(3);
            panelClosing.Controls.Add(labelClosing);
            flowLayoutReceipt.Controls.Add(panelClosing);
        }

        private void AddSubtotalPanel()
        {
            // Initialize if not already done
            Panel panel8 = new Panel();
            Label lblSubtotalAmount = new Label();
            Label label11 = new Label();

            label11.Dock = DockStyle.Left;
            label11.Font = new Font("Mongolian Baiti", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Size = new Size(200, 30);
            label11.Text = ReceiptTotalItems;
            label11.Padding = new Padding(10, 0, 0, 0);
            label11.TextAlign = ContentAlignment.BottomLeft;

            lblSubtotalAmount.Dock = DockStyle.Right;
            lblSubtotalAmount.Font = new Font("Mongolian Baiti", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtotalAmount.Size = new Size(155, 30);
            lblSubtotalAmount.Padding = new Padding(0, 0, 10, 0);
            lblSubtotalAmount.TextAlign = ContentAlignment.BottomRight;

            lblSubtotalAmount.Text = ReceiptSubTotal;

            panel8.Controls.Add(lblSubtotalAmount);
            panel8.Controls.Add(label11);
            panel8.Size = new Size(338, 30);
            panel8.Margin = new Padding(3);
            flowLayoutReceipt.Controls.Add(panel8);
        }
    }
}
