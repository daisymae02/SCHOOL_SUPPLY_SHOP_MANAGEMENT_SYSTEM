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
    public partial class ChooseReport : Form
    {
        public ChooseReport()
        {
            InitializeComponent();
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.ShowDialog();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.ShowDialog();
        }

        private void panel8_Click(object sender, EventArgs e)
        {
            customerData customerData = new customerData();
            customerData.ShowDialog();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            customerData customerData = new customerData();
            customerData.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            customerData customerData = new customerData();
            customerData.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            customerData customerData = new customerData();
            customerData.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            customerData customerData = new customerData();
            customerData.ShowDialog();
        }
    }
}
