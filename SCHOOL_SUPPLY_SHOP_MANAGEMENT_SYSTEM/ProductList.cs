using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCHOOL_SUPPLY_SHOP_MANAGEMENT_SYSTEM
{
    public partial class ProductList : UserControl
    {
        public ProductList()
        {
            InitializeComponent();
        }

        public Image productImage
        {
            get => prodImage.Image; set => prodImage.Image = value;
        }

        public string productName
        {
            get => prodName.Text; set => prodName.Text = value;
        }

        public string productCategory
        {
            get => prodCat.Text; set => prodCat.Text = value;
        }

        public string productPrice
        {
            get => prodPrice.Text; set => prodPrice.Text = value;
        }

        public string productQuantityInStock
        {
            get => prodStocks.Text; set => prodStocks.Text = value;
        }

        public int productID
        {
            get => btnAddtoCart.Tag != null ? (int)btnAddtoCart.Tag : -1;
            set => btnAddtoCart.Tag = value;
        }

        public event EventHandler AddToCartClicked;

        private void btnAddtoCart_Click_1(object sender, EventArgs e)
        {
            AddToCartClicked?.Invoke(this, EventArgs.Empty);
        }

        public void DisableAddToCartButton()
        {
            btnAddtoCart.Enabled = false;
            btnAddtoCart.Text = " Added";
            btnAddtoCart.BackColor = Color.FromArgb(230, 95, 43);
            btnAddtoCart.ForeColor = Color.White;
        }
        public void DisableAddToCartButton2()
        {
            btnAddtoCart.Enabled = false;
            btnAddtoCart.Text = " Out of Stock";
            btnAddtoCart.BackColor = Color.FromArgb(230, 95, 43);
            btnAddtoCart.ForeColor = Color.White;
        }

        public void EnableAddToCartButton()
        {
            btnAddtoCart.Enabled = true;
            btnAddtoCart.Text = "Add to Cart";
            btnAddtoCart.BackColor = Color.Black;
            btnAddtoCart.ForeColor = Color.White;
        }

        public event EventHandler ProductInfoClicked;
        private void productInfo_Click(object sender, EventArgs e)
        {
            ProductInfoClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
