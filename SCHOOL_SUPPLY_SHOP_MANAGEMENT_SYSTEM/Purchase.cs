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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace SCHOOL_SUPPLY_SHOP_MANAGEMENT_SYSTEM
{
    public partial class Purchase : Form
    {
        string connectionString = "Data Source=ESTORBA-PC\\SQLEXPRESS02;Initial Catalog=MANAGEMENT_SYSTEM;Integrated Security=True;Encrypt=False;";
        private ProductCategory selectedCategoryItem = null;
        private HashSet<int> cartProductIds = new HashSet<int>();
        int userID;
        public Purchase(int id)
        {
            InitializeComponent();
            this.userID = id;
        }

        private void Purchase_Load(object sender, EventArgs e)
        {
            LoadCategories();
            btnCategories.PerformClick();
        }

        private void LoadCategories()
        {
            string query = "SELECT DISTINCT prodCat FROM Product";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string category = reader["prodCat"].ToString();

                    var item = new ProductCategory
                    {
                        productCategory = category,
                    };

                    item.CategoryClicked += (s, e) =>
                    {
                        HighlightCategory(item);
                        FilterProductsByCategory(category);
                    };

                    flowLayoutCategory.Controls.Add(item);
                }
            }
        }

        private void LoadProducts()
        {
            string query = "SELECT * FROM Product ORDER BY prodName";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["prodId"]);
                    string name = reader["prodName"].ToString();
                    string category = reader["prodCat"].ToString();
                    string unit = reader["prodUnit"].ToString();

                    decimal price = Convert.ToDecimal(reader["prodPrice"]);
                    string formattedPrice = "₱ " + price.ToString("N2");

                    int quantityInStock = Convert.ToInt32(reader["prodQuantityInStock"]);

                    // Basic pluralization logic
                    string pluralizedUnit = quantityInStock == 1
                        ? unit
                        : unit.EndsWith("s") || unit.EndsWith("x") || unit.EndsWith("z") || unit.EndsWith("ch") || unit.EndsWith("sh")
                            ? unit + "es"
                            : unit + "s";

                    string formattedStock = $"Stock/s: {quantityInStock} {pluralizedUnit}";

                    var item = new ProductList
                    {
                        productName = name,
                        productCategory = category,
                        productPrice = formattedPrice,
                        productQuantityInStock = formattedStock,
                        productID = id
                    };

                    if (reader["prodImage"] != DBNull.Value)
                    {
                        byte[] imageBytes = (byte[])reader["prodImage"];

                        if (imageBytes.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {
                                item.productImage = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            item.productImage = Properties.Resources.no_image;
                        }
                    }

                    if (quantityInStock == 0)
                    {
                        item.DisableAddToCartButton2();
                    }
                    else if (cartProductIds.Contains(item.productID))
                    {
                        item.DisableAddToCartButton();
                    }
                    else
                    {
                        item.AddToCartClicked += (s, e) => AddToCart(item);
                    }

                    item.ProductInfoClicked += (s, e) => ViewProduct(item);
                    flowLayoutProducts.Controls.Add(item);
                }
            }
        }

        private void FilterProductsByCategory(string category)
        {
            flowLayoutProducts.Controls.Clear(); // Clear existing items

            string query = "SELECT * FROM Product WHERE prodCat = @category ORDER BY prodName";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@category", category);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["prodId"]);
                    string name = reader["prodName"].ToString();
                    string prodCat = reader["prodCat"].ToString();
                    string unit = reader["prodUnit"].ToString();

                    decimal price = Convert.ToDecimal(reader["prodPrice"]);
                    string formattedPrice = "₱ " + price.ToString("N2");

                    int quantityInStock = Convert.ToInt32(reader["prodQuantityInStock"]);

                    // Basic pluralization logic
                    string pluralizedUnit = quantityInStock == 1
                        ? unit
                        : unit.EndsWith("s") || unit.EndsWith("x") || unit.EndsWith("z") || unit.EndsWith("ch") || unit.EndsWith("sh")
                            ? unit + "es"
                            : unit + "s";

                    string formattedStock = $"Stock/s: {quantityInStock} {pluralizedUnit}";

                    var item = new ProductList
                    {
                        productName = name,
                        productCategory = prodCat,
                        productPrice = formattedPrice,
                        productQuantityInStock = formattedStock,
                        productID = id
                    };

                    if (reader["prodImage"] != DBNull.Value)
                    {
                        byte[] imageBytes = (byte[])reader["prodImage"];
                        if (imageBytes.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {
                                item.productImage = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            item.productImage = Properties.Resources.no_image;
                        }
                    }

                    if (quantityInStock == 0)
                    {
                        item.DisableAddToCartButton2();
                    }
                    else if (cartProductIds.Contains(item.productID))
                    {
                        item.DisableAddToCartButton();
                    }
                    else
                    {
                        item.AddToCartClicked += (s, e) => AddToCart(item);
                    }

                    item.ProductInfoClicked += (s, e) => ViewProduct(item);
                    flowLayoutProducts.Controls.Add(item);
                }
            }
        }

        private void FilterProductsByName(string name)
        {
            flowLayoutProducts.Controls.Clear(); // Clear existing items

            string query = "SELECT * FROM Product WHERE prodName LIKE @name AND prodStatus = 'Active' ORDER BY prodName";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", "%" + name + "%"); // Wildcard search

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["prodId"]);
                    string prodName = reader["prodName"].ToString();
                    string prodCat = reader["prodCat"].ToString();
                    string unit = reader["prodUnit"].ToString();

                    decimal price = Convert.ToDecimal(reader["prodPrice"]);
                    string formattedPrice = "₱ " + price.ToString("N2");

                    int quantityInStock = Convert.ToInt32(reader["prodQuantityInStock"]);

                    // Basic pluralization logic
                    string pluralizedUnit = quantityInStock == 1
                        ? unit
                        : unit.EndsWith("s") || unit.EndsWith("x") || unit.EndsWith("z") || unit.EndsWith("ch") || unit.EndsWith("sh")
                            ? unit + "es"
                            : unit + "s";

                    string formattedStock = $"Stock/s: {quantityInStock} {pluralizedUnit}";

                    var item = new ProductList
                    {
                        productName = prodName,
                        productCategory = prodCat,
                        productPrice = formattedPrice,
                        productQuantityInStock = formattedStock,
                        productID = id
                    };

                    if (reader["prodImage"] != DBNull.Value)
                    {
                        byte[] imageBytes = (byte[])reader["prodImage"];
                        if (imageBytes.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {
                                item.productImage = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            item.productImage = Properties.Resources.no_image;
                        }
                    }

                    if (quantityInStock == 0)
                    {
                        item.DisableAddToCartButton2();
                    }
                    else if (cartProductIds.Contains(item.productID))
                    {
                        item.DisableAddToCartButton();
                    }
                    else
                    {
                        item.AddToCartClicked += (s, e) => AddToCart(item);
                    }

                    item.ProductInfoClicked += (s, e) => ViewProduct(item);
                    flowLayoutProducts.Controls.Add(item);
                }
            }
        }

        private void ViewProduct(ProductList product)
        {
            if (cartProductIds.Contains(product.productID))
                return;

            viewProducts viewProducts = new viewProducts(product.productID);
            viewProducts.ShowDialog();
        }

        private void AddToCart(ProductList product)
        {
            if (cartProductIds.Contains(product.productID))
                return;

            int maxStock = GetStockFromFormattedString(product.productQuantityInStock);

            CartList cartItem = new CartList();
            cartItem.BeginInit();  // tell CartList we’re setting props
            cartItem.productCartName = product.productName;
            cartItem.productCartPrice = product.productPrice;
            cartItem.productCartID = product.productID;
            cartItem.MaxStock = maxStock;
            cartItem.EndInit();  // done setting, now update UI properly

            cartItem.QuantityChanged += (s, e) => UpdateSubtotal();
            cartItem.ItemRemoved += (s, e) =>
            {
                cartProductIds.Remove(cartItem.productCartID);
                UpdateSubtotal();
                product.EnableAddToCartButton();
            };

            flowLayoutCart.Controls.Add(cartItem);
            product.DisableAddToCartButton();
            cartProductIds.Add(product.productID);

            UpdateSubtotal();
        }

        private int GetStockFromFormattedString(string formattedStock)
        {
            if (string.IsNullOrEmpty(formattedStock))
                return 0;

            var parts = formattedStock.Split(' ');
            if (parts.Length > 1 && int.TryParse(parts[1], out int stock))
                return stock;

            return 0;
        }


        private void HighlightCategory(ProductCategory clickedItem)
        {
            ResetAllCategoryStyles();
            btnCategories.BackColor = Color.Black;
            btnCategories.ForeColor = Color.White;

            clickedItem.SetActiveStyle();
            selectedCategoryItem = clickedItem;
        }

        private void ResetAllCategoryStyles()
        {
            foreach (Control control in flowLayoutCategory.Controls)
            {
                if (control is ProductCategory category)
                {
                    category.ResetStyle();
                }
            }

            // Reset btnCategories (the "All" button)
            btnCategories.BackColor = Color.Black;
            btnCategories.ForeColor = Color.White;
        }

        private void HighlightAllCategory()
        {
            ResetAllCategoryStyles();

            btnCategories.BackColor = Color.FromArgb(235, 229, 215);
            btnCategories.ForeColor = Color.FromArgb(230, 95, 43);

            selectedCategoryItem = null;
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            HighlightAllCategory();
            flowLayoutProducts.Controls.Clear();
            LoadProducts();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            clearSearch.Visible = !string.IsNullOrEmpty(txtSearch.Text.Trim());
            HighlightAllCategory();
            FilterProductsByName(txtSearch.Text.Trim());
        }

        private void clearSearch_Click(object sender, EventArgs e)
        {
            clearSearch.Visible = false;
            txtSearch.Clear();
            flowLayoutProducts.Controls.Clear();
            HighlightAllCategory();
            LoadProducts();
        }

        private void UpdateSubtotal()
        {
            decimal subtotal = 0m;

            // Calculate subtotal from all cart items
            foreach (Control control in flowLayoutCart.Controls)
            {
                if (control is CartList cartItem)
                {
                    subtotal += cartItem.GetTotalPrice();
                }
            }

            // Calculate discount (10%) and VAT (12%)
            decimal discountRate = 0.10m;
            decimal vatRate = 0.12m;

            decimal discountAmount = subtotal * discountRate;
            decimal discountedSubtotal = subtotal - discountAmount;

            decimal vatAmount = discountedSubtotal * vatRate;
            decimal total = discountedSubtotal + vatAmount;

            // Update labels
            lblSubtotal.Text = $"₱ {subtotal:N2}";
            lblDiscount.Text = $"- ₱ {discountAmount:N2}";
            lblVat.Text = $"+ ₱ {vatAmount:N2}";
            lblTotal.Text = $"₱ {total:N2}";
        }

        private void deleteAllitemsCart_Click(object sender, EventArgs e)
        {
            List<Control> controlsToRemove = new List<Control>();

            foreach (Control control in flowLayoutCart.Controls)
            {
                if (control != panel6 && control != panel7)
                {
                    if (control is CartList cartItem)
                    {
                        cartProductIds.Remove(cartItem.productCartID);

                        foreach (Control prodControl in flowLayoutProducts.Controls)
                        {
                            if (prodControl is ProductList prodList && prodList.productID == cartItem.productCartID)
                            {
                                prodList.EnableAddToCartButton();
                                break;
                            }
                        }
                    }

                    controlsToRemove.Add(control);
                }
            }
            foreach (Control control in controlsToRemove)
            {
                flowLayoutCart.Controls.Remove(control);
            }

            UpdateSubtotal();
        }

        private staffHomepage parentForm;

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            var cartItems = flowLayoutCart.Controls
                .OfType<CartList>()
                .Where(c => c.Name != "panel6" && c.Name != "panel7")
                .ToList();

            if (cartItems.Count == 0)
            {
                using (var info = new Information("CART IS EMPTY", "No items in cart to checkout."))
                {
                    info.ShowDialog();
                }
                return;
            }

            Checkout checkout = new Checkout(userID);
            checkout.LoadCartItems(cartItems);

            checkout.CheckoutCompleted += () =>
            {
                // Inform staffHomepage that checkout was done, so we can switch MDI child
                if (this.MdiParent is staffHomepage parent)
                {
                    parent.SwitchToStaffHome();
                }
            };

            checkout.ShowDialog();
        }

    }
}
