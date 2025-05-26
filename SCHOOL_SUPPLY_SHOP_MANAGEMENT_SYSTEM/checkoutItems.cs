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
    public partial class checkoutItems : UserControl
    {
        public checkoutItems()
        {
            InitializeComponent();
        }
        public int NumericQuantity { get; set; }
        public decimal NumericPrice { get; set; }

        public Image checkoutImage
        {
            get => itemImage.Image; set => itemImage.Image = value;
        }

        public string checkoutName
        {
            get => itemName.Text; set => itemName.Text = value;
        }

        public string checkoutQuantity
        {
            get => itemQuantity.Text; set => itemQuantity.Text = value;
        }

        public string checkoutPrice
        {
            get => itemTotalPrice.Text; set => itemTotalPrice.Text = value;
        }
    }
}
