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
    public partial class CartList : UserControl
    {
        private int quantity = 1;
        private int maxStock = int.MaxValue;
        public int Quantity => quantity;


        public CartList()
        {
            InitializeComponent();
            UpdateQuantityDisplay();
            minus.Enabled = quantity > 1;
        }
        public int MaxStock
        {
            get => maxStock;
            set
            {
                maxStock = value;
                // If current quantity > maxStock, reset quantity to maxStock
                if (quantity > maxStock)
                {
                    quantity = maxStock;
                    UpdateQuantityDisplay();
                    UpdateTotalPrice();
                    QuantityChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        private string productCartNameValue;
        public string productCartName
        {
            get => productCartNameValue;
            set
            {
                productCartNameValue = value;
                cartName.Text = value;
            }
        }

        private bool isInitializing = false;

        // Expose a method to signal init start/end
        public void BeginInit() => isInitializing = true;
        public void EndInit()
        {
            isInitializing = false;
            UpdateQuantityDisplay();
            UpdateTotalPrice();
        }

        private decimal productPriceValue;
        public string productCartPrice
        {
            get => productPriceValue.ToString("₱ 0.00");
            set
            {
                if (decimal.TryParse(value.Replace("₱", "").Trim(), out var price))
                {
                    productPriceValue = price;
                    cartPrice.Text = value;
                    if (!isInitializing)
                    {
                        UpdateTotalPrice();
                    }
                }
            }
        }

        public int productCartID { get; set; }

        private void UpdateQuantityDisplay()
        {
            label5.Text = $"x{quantity}";
            minus.Enabled = quantity > 1;
            plus.Enabled = quantity < maxStock;
        }

        private void UpdateTotalPrice()
        {
            decimal total = productPriceValue * quantity;
            totalPrice.Text = $"₱ {total:N2}";
        }

        public decimal GetTotalPrice()
        {
            return productPriceValue * quantity;
        }

        public event EventHandler QuantityChanged;
        public event EventHandler ItemRemoved;

        private void btnRemove_Click(object sender, EventArgs e)
        {
            this.Parent?.Controls.Remove(this);
            ItemRemoved?.Invoke(this, EventArgs.Empty);
        }

        private void plus_Click(object sender, EventArgs e)
        {
            if (quantity < maxStock)
            {
                quantity++;
                UpdateQuantityDisplay();
                UpdateTotalPrice();
                QuantityChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private void minus_Click(object sender, EventArgs e)
        {
            if (quantity > 1)
            {
                quantity--;
                UpdateQuantityDisplay();
                UpdateTotalPrice();
                QuantityChanged?.Invoke(this, EventArgs.Empty);
            }
        }

    }
}
