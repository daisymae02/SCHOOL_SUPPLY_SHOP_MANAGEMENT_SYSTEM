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
    public partial class SidebarMenu : Form
    {
        public SidebarMenu()
        {
            InitializeComponent();
        }

        private void SidebarMenu_FormClosing (object sender, FormClosingEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void btnLogout_Click (object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();

        }
    }
}
