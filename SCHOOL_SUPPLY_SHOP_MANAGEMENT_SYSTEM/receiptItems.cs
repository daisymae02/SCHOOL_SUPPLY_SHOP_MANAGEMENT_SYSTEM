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
    public partial class receiptItems : UserControl
    {
        public receiptItems()
        {
            InitializeComponent();
        }

        public string ReceiptItemName 
        { 
            get => lblProductname.Text; set => lblProductname.Text = value; 
        }
        public string ReceiptItemPrice 
        { 
            get => lblPrice.Text; set => lblPrice.Text = value; 
        }
        public string ReceiptItemQuantity 
        { 
            get => lblQuantity.Text; set => lblQuantity.Text = value; 
        }
        public string ReceiptItemSubtotal 
        { 
            get => lblSubtotal.Text; set => lblSubtotal.Text = value; 
        }
    }
}
