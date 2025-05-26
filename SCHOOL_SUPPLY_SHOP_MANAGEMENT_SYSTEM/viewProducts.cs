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
using System.Globalization;

namespace SCHOOL_SUPPLY_SHOP_MANAGEMENT_SYSTEM
{
    public partial class viewProducts : Form
    {
        private int _prodId;
        string connectionString = @"Data Source=ESTORBA-PC\SQLEXPRESS02;Initial Catalog=MANAGEMENT_SYSTEM;Integrated Security=True;Encrypt=False;";
        public viewProducts(int prodId)
        {
            InitializeComponent();
            _prodId = prodId;
            LoadProducts();
        }

        private void viewProducts_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }
        private void LoadProducts()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT p.prodId, p.prodName, p.prodDesc, p.prodImage, p.prodCat, 
                               p.prodColor, p.prodPrice, b.brandName, prodUnit, prodQuantityInStock
                        FROM Product p 
                        INNER JOIN Brand b ON p.brandId = b.brandId
                        WHERE p.prodStatus = 'Active' AND p.prodId = @Id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", _prodId);
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Assuming you have labels or textboxes on your form to display details
                                label1.Text = reader["prodName"].ToString();
                                label3.Text = reader["prodDesc"].ToString();
                                label7.Text = reader["prodCat"].ToString();
                                label5.Text = reader["prodColor"].ToString();
                                label13.Text = Convert.ToDecimal(reader["prodPrice"]).ToString("C", new CultureInfo("en-PH"));
                                label9.Text = reader["brandName"].ToString();
                                label11.Text = reader["prodUnit"].ToString();
                                label15.Text = reader["prodQuantityInStock"].ToString();

                                // Load image
                                if (reader["prodImage"] != DBNull.Value)
                                {
                                    byte[] imageBytes = (byte[])reader["prodImage"];
                                    using (MemoryStream ms = new MemoryStream(imageBytes))
                                    {
                                        pictureBox1.Image = Image.FromStream(ms);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Product not found.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message);
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
