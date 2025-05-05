namespace SCHOOL_SUPPLY_SHOP_MANAGEMENT_SYSTEM
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnSignup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();
            this.Hide();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SidebarMenu sidebarMenu = new SidebarMenu();
            sidebarMenu.Show();
            this.Hide();
        }

        private void hideShow_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar)
            {
                txtPassword.UseSystemPasswordChar = false;
                hideShow.Image = Properties.Resources.show__1_;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                hideShow.Image = Properties.Resources.hide__2_;
            }
        }

        //GWAPA KO
    }
}
