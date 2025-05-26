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
    public partial class ProductCategory : UserControl
    {
        public ProductCategory()
        {
            InitializeComponent();
        }

        public string productCategory
        {
            get => btnCategories.Text; set => btnCategories.Text = value;
        }

        public event EventHandler CategoryClicked;

        private void btnCategories_Click(object sender, EventArgs e)
        {
            CategoryClicked?.Invoke(this, EventArgs.Empty);
        }

        public void SetActiveStyle()
        {
            btnCategories.BackColor = Color.FromArgb(235, 229, 215);
            btnCategories.ForeColor = Color.FromArgb(230, 95, 43);
        }

        public void ResetStyle()
        {
            btnCategories.BackColor = Color.Black;
            btnCategories.ForeColor = Color.White;
        }
    }
}
