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
    public partial class Products : Form
    {
        private int ID;
        string connectionString = @"Data Source=ESTORBA-PC\SQLEXPRESS02;Initial Catalog=MANAGEMENT_SYSTEM;Integrated Security=True;Encrypt=False;";
        public Products()
        {
            InitializeComponent();
            LoadBrands();
            LoadProducts();
            dataGridViewProducts.AllowUserToAddRows = false;
            dataGridViewProducts.ReadOnly = true;
            dataGridViewProducts.ClearSelection();
            dataGridViewProducts.DataSource = GetProducts();
        }

        private void Products_Load(object sender, EventArgs e)
        {
            LoadBrands();
            LoadProducts();
            dataGridViewProducts.AllowUserToAddRows = false;
            dataGridViewProducts.ReadOnly = true;
            dataGridViewProducts.ClearSelection();
            dataGridViewProducts.DataSource = GetProducts();
        }

        private void txtProductBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = txtProductBrand.SelectedItem;

            if (txtProductBrand.SelectedItem == null || txtProductBrand.SelectedItem.ToString() == "Add new brand...")
            {
                errorProductBrand.Visible = true;
            }
            else
            {
                errorProductBrand.Visible = false;
            }

            // Check if the selected item is "Add new brand..."
            if (selectedItem != null && selectedItem.ToString() == "Add new brand...")
            {
                string newBrand = null;

                // Opening the Add New Brand form
                using (Brand addForm = new Brand())
                {
                    // Ensure dialog result is OK
                    if (addForm.ShowDialog() == DialogResult.OK)
                    {
                        newBrand = addForm.BrandName;

                        if (!string.IsNullOrWhiteSpace(newBrand))
                        {
                            AddNewBrandToDatabase(newBrand);
                        }
                    }
                }

                // Reload the brands after adding a new one
                LoadBrands();
                txtProductBrand.SelectedItem = newBrand;
            }
            else
            {
                var selectedBrand = selectedItem as dynamic;
            }
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductName.Text))
            {
                errorProductName.Visible = true;
            }
            else
            {
                errorProductName.Visible = false;
            }
        }

        private void txtProductDesc_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductDesc.Text))
            {
                errorProductDesc.Visible = true;
            }
            else
            {
                errorProductDesc.Visible = false;
            }
        }

        private void txtProductColor_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductColor.Text))
            {
                errorProductColor.Visible = true;
            }
            else
            {
                errorProductColor.Visible = false;
            }
        }
        private void txtProductPrice_TextChanged(object sender, EventArgs e)
        {
            string input = txtProductPrice.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                errorProductPrice.Text = "Price is required.";
                errorProductPrice.Visible = true;
            }
            else if (!decimal.TryParse(input, out decimal price))
            {
                errorProductPrice.Text = "Enter a valid number.";
                errorProductPrice.Visible = true;
            }
            else if (price <= 0)
            {
                errorProductPrice.Text = "Price must be greater than zero.";
                errorProductPrice.Visible = true;
            }
            else
            {
                errorProductPrice.Visible = false;
            }
        }

        private void txtProductCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtProductCat.SelectedItem == null)
            {
                errorProductCat.Visible = true;
            }
            else
            {
                errorProductCat.Visible = false;
            }
        }

        private void txtProductUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtProductUnit.SelectedItem == null)
            {
                errorProductUnit.Visible = true;
            }
            else
            {
                errorProductUnit.Visible = false;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            DataTable results = GetProducts(searchTerm);

            if (results.Rows.Count > 0)
            {
                dataGridViewProducts.DataSource = results;
                dataGridViewProducts.Visible = true;
            }
            else
            {
                dataGridViewProducts.Visible = false;
            }

            clearSearch.Visible = !string.IsNullOrEmpty(searchTerm);
            dataGridViewProducts.AllowUserToAddRows = false;
            dataGridViewProducts.ReadOnly = true;
        }

        private void clearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            dataGridViewProducts.DataSource = GetProducts();
            clearSearch.Visible = false;
            dataGridViewProducts.Visible = true;
            dataGridViewProducts.AllowUserToAddRows = false;
            dataGridViewProducts.ReadOnly = true;
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select an Image";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(ofd.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                    // Hide error if the image is no longer the default
                    if (!IsDefaultImage(pictureBox1.Image))
                    {
                        errorProductImage.Visible = false;
                    }
                }
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            bool isValid = true;

            // Product Name validation
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                errorProductName.Visible = true;
                isValid = false;
            }
            else
            {
                errorProductName.Visible = false;
            }

            // Product Description validation
            if (string.IsNullOrWhiteSpace(txtProductDesc.Text))
            {
                errorProductDesc.Visible = true;
                isValid = false;
            }
            else
            {
                errorProductDesc.Visible = false;
            }

            // Product Color validation
            if (string.IsNullOrWhiteSpace(txtProductColor.Text))
            {
                errorProductColor.Visible = true;
                isValid = false;
            }
            else
            {
                errorProductColor.Visible = false;
            }

            // Product price validation
            if (string.IsNullOrEmpty(txtProductPrice.Text))
            {
                errorProductPrice.Text = "Price is required.";
                errorProductPrice.Visible = true;
            }
            else if (!decimal.TryParse(txtProductPrice.Text, out decimal price))
            {
                errorProductPrice.Text = "Enter a valid number.";
                errorProductPrice.Visible = true;
            }
            else if (price <= 0)
            {
                errorProductPrice.Text = "Price must be greater than zero.";
                errorProductPrice.Visible = true;
            }
            else
            {
                errorProductPrice.Visible = false;
            }

            // Product Category validation
            if (txtProductCat.SelectedItem == null)
            {
                errorProductCat.Visible = true;
                isValid = false;
            }
            else
            {
                errorProductCat.Visible = false;
            }

            // Product Unit validation
            if (txtProductUnit.SelectedItem == null)
            {
                errorProductUnit.Visible = true;
                isValid = false;
            }
            else
            {
                errorProductUnit.Visible = false;
            }

            // Product Brand validation
            if (txtProductBrand.SelectedItem == null || txtProductBrand.SelectedItem.ToString() == "Add new brand...")
            {
                errorProductBrand.Visible = true;
                isValid = false;
            }
            else
            {
                errorProductBrand.Visible = false;
            }

            // Image validation
            if (pictureBox1.Image == null || IsDefaultImage(pictureBox1.Image))
            {
                errorProductImage.Visible = true;
                isValid = false;
            }
            else
            {
                errorProductImage.Visible = false;
            }

            // Stop if invalid
            if (!isValid)
            {
                return;
            }

            if (ID == 0)
            {
                using (var confirm = new Logout("CONFIRMATION", "Are you sure you want to add this product?"))
                {
                    if (confirm.ShowDialog() != DialogResult.OK)
                    {
                        return; // User cancelled
                    }
                }
                // Proceed with saving
                SaveProduct();
            }
            else
            {
                using (var confirm = new Logout("CONFIRMATION", "Are you sure you want to update this product?"))
                {
                    if (confirm.ShowDialog() != DialogResult.OK)
                    {
                        return; // User cancelled
                    }
                }
                UpdateProduct();
            }

            // Reset form
            ID = 0;
            txtProductName.Clear();
            txtProductDesc.Clear();
            txtProductColor.Clear();
            txtProductPrice.Clear();
            txtProductCat.SelectedIndex = -1;
            txtProductBrand.SelectedIndex = -1;
            txtProductUnit.SelectedIndex = -1;
            pictureBox1.Image = Properties.Resources.no_image;
            label1.Text = "Add Product";
            btnAddProduct.Text = "ADD PRODUCT";

            errorProductName.Visible = false;
            errorProductDesc.Visible = false;
            errorProductColor.Visible = false;
            errorProductCat.Visible = false;
            errorProductBrand.Visible = false;
            errorProductImage.Visible = false;
            errorProductPrice.Visible = false;
            errorProductUnit.Visible = false;

            LoadProducts();
        }

        private void SaveProduct()
        {
            string prodName = txtProductName.Text.Trim();
            string prodDesc = txtProductDesc.Text.Trim();
            string prodColor = txtProductColor.Text.Trim();
            string prodCat = txtProductCat.SelectedItem.ToString();
            string brandName = txtProductBrand.SelectedItem.ToString();
            string prodUnit = txtProductUnit.SelectedItem.ToString();
            string price = txtProductPrice.Text.Trim();
            decimal prodPrice = decimal.Parse(price);

            byte[] prodImageBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                prodImageBytes = ms.ToArray();
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Check if product name already exists
                string checkQuery = "SELECT COUNT(*) FROM Product WHERE prodName = @prodName AND prodStatus = 'Active'";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@prodName", prodName);
                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Product name already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Get the brandId
                string getBrandIdQuery = "SELECT brandId FROM Brand WHERE brandName = @BrandName";
                int brandId;
                using (SqlCommand getBrandIdCmd = new SqlCommand(getBrandIdQuery, conn))
                {
                    getBrandIdCmd.Parameters.AddWithValue("@BrandName", brandName);
                    object result = getBrandIdCmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("Brand not found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    brandId = Convert.ToInt32(result);
                }

                // Insert the product
                string insertProductQuery = @"
                    INSERT INTO Product (prodName, prodDesc, prodImage, prodCat, prodColor, brandId, prodStatus, prodPrice, prodUnit)
                    VALUES (@prodName, @prodDesc, @prodImage, @prodCat, @prodColor, @brandId, 'Active', @prodPrice, @prodUnit)";

                using (SqlCommand insertCmd = new SqlCommand(insertProductQuery, conn))
                {
                    insertCmd.Parameters.AddWithValue("@prodName", prodName);
                    insertCmd.Parameters.AddWithValue("@prodDesc", prodDesc);
                    insertCmd.Parameters.AddWithValue("@prodImage", prodImageBytes);
                    insertCmd.Parameters.AddWithValue("@prodCat", prodCat);
                    insertCmd.Parameters.AddWithValue("@prodColor", prodColor);
                    insertCmd.Parameters.AddWithValue("@brandId", brandId);
                    insertCmd.Parameters.AddWithValue("@prodPrice", prodPrice);
                    insertCmd.Parameters.AddWithValue("@prodUnit", prodUnit);

                    insertCmd.ExecuteNonQuery();
                }

                using (var confirm = new Information("SUCCESS", "Product added successfully!"))
                {
                    confirm.ShowDialog();
                }
            }
        }
        private void UpdateProduct()
        {
            string prodName = txtProductName.Text.Trim();
            string prodDesc = txtProductDesc.Text.Trim();
            string prodColor = txtProductColor.Text.Trim();
            string prodCat = txtProductCat.SelectedItem.ToString();
            string brandName = txtProductBrand.SelectedItem.ToString();
            string prodUnit = txtProductUnit.SelectedItem.ToString();
            string price = txtProductPrice.Text.Trim();
            decimal prodPrice = decimal.Parse(price);

            byte[] prodImageBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                prodImageBytes = ms.ToArray();
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Check if product name already exists
                string checkQuery = "SELECT COUNT(*) FROM Product WHERE prodName = @prodName AND prodStatus = 'Active' AND prodId != @prodId";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@prodName", prodName);
                    checkCmd.Parameters.AddWithValue("@prodId", ID);
                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Product name already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Get the brandId
                string getBrandIdQuery = "SELECT brandId FROM Brand WHERE brandName = @BrandName";
                int brandId;
                using (SqlCommand getBrandIdCmd = new SqlCommand(getBrandIdQuery, conn))
                {
                    getBrandIdCmd.Parameters.AddWithValue("@BrandName", brandName);
                    object result = getBrandIdCmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("Brand not found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    brandId = Convert.ToInt32(result);
                }

                // Update the product
                string insertProductQuery = @"
                    UPDATE Product SET prodName = @prodName, prodDesc = @prodDesc, prodImage = @prodImage,
                    prodCat = @prodCat, prodColor = @prodColor, prodPrice = @prodPrice, brandId = @brandId, prodUnit = @prodUnit
                    WHERE prodId = @prodId";

                using (SqlCommand insertCmd = new SqlCommand(insertProductQuery, conn))
                {
                    insertCmd.Parameters.AddWithValue("@prodName", prodName);
                    insertCmd.Parameters.AddWithValue("@prodDesc", prodDesc);
                    insertCmd.Parameters.AddWithValue("@prodImage", prodImageBytes);
                    insertCmd.Parameters.AddWithValue("@prodCat", prodCat);
                    insertCmd.Parameters.AddWithValue("@prodColor", prodColor);
                    insertCmd.Parameters.AddWithValue("@brandId", brandId);
                    insertCmd.Parameters.AddWithValue("@prodPrice", prodPrice);
                    insertCmd.Parameters.AddWithValue("@prodUnit", prodUnit);
                    insertCmd.Parameters.AddWithValue("@prodId", ID);

                    insertCmd.ExecuteNonQuery();
                }

                using (var confirm = new Information("SUCCESS", "Product updated successfully!"))
                {
                    confirm.ShowDialog();
                }
            }
        }

        private void LoadProducts()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                SELECT 
                    P.prodId,
                    P.prodName,
                    P.prodCat,
                    P.prodQuantityInStock,
                    P.prodUnit,
                    B.brandName
                FROM Product P
                JOIN Brand B ON P.brandId = B.brandId
                WHERE P.prodStatus = 'Active'";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridViewProducts.DataSource = table;
                }

                dataGridViewProducts.AllowUserToAddRows = false;
                dataGridViewProducts.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message);
            }
        }

        private void LoadBrands()
        {
            txtProductBrand.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT brandName FROM Brand ORDER BY brandName";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            txtProductBrand.Items.Add(reader["brandName"].ToString());
                        }
                    }
                }
            }

            // Add the special "Add new brand..." item
            txtProductBrand.Items.Add("Add new brand...");
        }

        private void dataGridViewProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridViewProducts.Columns[e.ColumnIndex].Name == "delete")
                {
                    int productId = Convert.ToInt32(dataGridViewProducts.Rows[e.RowIndex].Cells["productId"].Value);
                    using (var confirm = new Logout("CONFIRMATION", "Are you sure you want to delete this product?"))
                    {
                        if (confirm.ShowDialog() != DialogResult.OK)
                        {
                            return;
                        }
                    }

                    DeleteProduct(productId);

                    using (var info = new Information("SUCCESS", "Product deleted successfully!"))
                    {
                        info.ShowDialog();
                    }

                    LoadProducts();
                }
                if (dataGridViewProducts.Columns[e.ColumnIndex].Name == "view")
                {
                    int productId = Convert.ToInt32(dataGridViewProducts.Rows[e.RowIndex].Cells["productId"].Value);
                    viewProducts viewProducts = new viewProducts(productId);
                    viewProducts.ShowDialog();
                }
                if (dataGridViewProducts.Columns[e.ColumnIndex].Name == "edit")
                {
                    int productId = Convert.ToInt32(dataGridViewProducts.Rows[e.RowIndex].Cells["productId"].Value);
                    ID = productId;
                    ViewProducts(productId);
                }
            }
        }

        private void DeleteProduct(int productId)
        {
            string query = "UPDATE Product SET prodStatus = 'Deleted' WHERE prodId = @ProductID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void AddNewBrandToDatabase(string brandName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Check if the brand already exists
                string checkQuery = "SELECT COUNT(*) FROM Brand WHERE brandName = @BrandName";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@BrandName", brandName);

                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        using (var info = new Information("DUPLICATE BRAND", "The brand already exists!"))
                        {
                            info.ShowDialog();
                        }
                        return; // Exit without inserting
                    }
                }

                // Insert new brand if it doesn't exist
                string insertQuery = "INSERT INTO Brand (brandName) VALUES (@BrandName)";
                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                {
                    insertCmd.Parameters.AddWithValue("@BrandName", brandName);
                    insertCmd.ExecuteNonQuery();
                }
            }
        }

        private DataTable GetProducts(string searchTerm = "")
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        P.prodId,
                        P.prodName,
                        P.prodCat,
                        P.prodQuantityInStock,
                        P.prodUnit,
                        B.brandName
                    FROM Product P
                    JOIN Brand B ON P.brandId = B.brandId
                    WHERE P.prodStatus = 'Active' AND (
                        P.prodName LIKE @search OR 
                        P.prodColor LIKE @search OR 
                        P.prodCat LIKE @search OR
                        B.brandName LIKE @search
                    )";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }

            return dt;
        }

        private bool IsDefaultImage(Image img)
        {
            using (var ms1 = new System.IO.MemoryStream())
            using (var ms2 = new System.IO.MemoryStream())
            {
                img.Save(ms1, System.Drawing.Imaging.ImageFormat.Png);
                Properties.Resources.no_image.Save(ms2, System.Drawing.Imaging.ImageFormat.Png);

                byte[] imgBytes1 = ms1.ToArray();
                byte[] imgBytes2 = ms2.ToArray();

                return imgBytes1.SequenceEqual(imgBytes2);
            }
        }

        private void txtProductPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits, control characters, and one decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Only allow one decimal point
            if (e.KeyChar == '.' && txtProductPrice.Text.Contains("."))
            {
                e.Handled = true;
            }
        }
        private void ViewProducts(int prodId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT p.prodId, p.prodName, p.prodDesc, p.prodImage, p.prodCat, 
                               p.prodColor, p.prodPrice, b.brandName, p.prodUnit
                        FROM Product p 
                        INNER JOIN Brand b ON p.brandId = b.brandId
                        WHERE p.prodStatus = 'Active' AND p.prodId = @Id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", prodId);
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtProductName.Text = reader["prodName"].ToString();
                                txtProductDesc.Text = reader["prodDesc"].ToString();
                                txtProductCat.Text = reader["prodCat"].ToString();
                                txtProductColor.Text = reader["prodColor"].ToString();
                                txtProductPrice.Text = Convert.ToDecimal(reader["prodPrice"]).ToString();
                                txtProductBrand.Text = reader["brandName"].ToString();
                                txtProductUnit.Text = reader["prodUnit"].ToString();

                                // Load image
                                if (reader["prodImage"] != DBNull.Value)
                                {
                                    byte[] imageBytes = (byte[])reader["prodImage"];
                                    using (MemoryStream ms = new MemoryStream(imageBytes))
                                    {
                                        pictureBox1.Image = Image.FromStream(ms);
                                    }
                                }
                                label1.Text = "Edit Product";
                                btnAddProduct.Text = "EDIT PRODUCT";
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ID = 0;
            txtProductName.Clear();
            txtProductDesc.Clear();
            txtProductColor.Clear();
            txtProductPrice.Clear();
            txtProductCat.SelectedIndex = -1;
            txtProductBrand.SelectedIndex = -1;
            txtProductUnit.SelectedIndex = -1;
            pictureBox1.Image = Properties.Resources.no_image;
            label1.Text = "Add Product";
            btnAddProduct.Text = "ADD PRODUCT";

            errorProductName.Visible = false;
            errorProductDesc.Visible = false;
            errorProductColor.Visible = false;
            errorProductCat.Visible = false;
            errorProductBrand.Visible = false;
            errorProductImage.Visible = false;
            errorProductPrice.Visible = false;
            errorProductUnit.Visible = false;

            LoadProducts();
        }
    }
}
