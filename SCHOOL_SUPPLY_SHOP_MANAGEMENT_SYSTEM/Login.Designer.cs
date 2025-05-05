namespace SCHOOL_SUPPLY_SHOP_MANAGEMENT_SYSTEM
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            pictureBox3 = new PictureBox();
            panel2 = new Panel();
            panel3 = new Panel();
            panel6 = new Panel();
            label2 = new Label();
            btnSignup = new LinkLabel();
            btnLogin = new Button();
            forgotPassword = new LinkLabel();
            panel4 = new Panel();
            hideShow = new PictureBox();
            pictureBox2 = new PictureBox();
            txtPassword = new TextBox();
            panel5 = new Panel();
            pictureBox1 = new PictureBox();
            txtUsername = new TextBox();
            panel8 = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel6.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)hideShow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel8.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(pictureBox3);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(509, 366);
            panel1.TabIndex = 0;
            // 
            // pictureBox3
            // 
            pictureBox3.Dock = DockStyle.Fill;
            pictureBox3.Image = Properties.Resources.art;
            pictureBox3.Location = new Point(0, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(509, 366);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(235, 229, 215);
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(0, 331);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(50, 10, 50, 50);
            panel2.Size = new Size(509, 314);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(235, 229, 215);
            panel3.Controls.Add(panel6);
            panel3.Location = new Point(53, 13);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(30, 0, 30, 0);
            panel3.Size = new Size(403, 248);
            panel3.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.Controls.Add(label2);
            panel6.Controls.Add(btnSignup);
            panel6.Controls.Add(btnLogin);
            panel6.Controls.Add(forgotPassword);
            panel6.Controls.Add(panel4);
            panel6.Controls.Add(panel5);
            panel6.Controls.Add(panel8);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(30, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(343, 248);
            panel6.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 215);
            label2.Name = "label2";
            label2.Size = new Size(163, 20);
            label2.TabIndex = 10;
            label2.Text = "Don't have an account?";
            // 
            // btnSignup
            // 
            btnSignup.ActiveLinkColor = Color.Black;
            btnSignup.AutoSize = true;
            btnSignup.LinkColor = Color.Black;
            btnSignup.Location = new Point(186, 215);
            btnSignup.Name = "btnSignup";
            btnSignup.Size = new Size(128, 20);
            btnSignup.TabIndex = 0;
            btnSignup.TabStop = true;
            btnSignup.Text = "Create an account";
            btnSignup.LinkClicked += btnSignup_LinkClicked;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Black;
            btnLogin.FlatStyle = FlatStyle.Popup;
            btnLogin.Font = new Font("Georgia", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(66, 171);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(220, 41);
            btnLogin.TabIndex = 8;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // forgotPassword
            // 
            forgotPassword.ActiveLinkColor = Color.Black;
            forgotPassword.AutoSize = true;
            forgotPassword.LinkColor = Color.Black;
            forgotPassword.Location = new Point(215, 138);
            forgotPassword.Name = "forgotPassword";
            forgotPassword.Size = new Size(127, 20);
            forgotPassword.TabIndex = 7;
            forgotPassword.TabStop = true;
            forgotPassword.Text = "Forgot password?";
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(hideShow);
            panel4.Controls.Add(pictureBox2);
            panel4.Controls.Add(txtPassword);
            panel4.Location = new Point(0, 101);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(34, 0, 0, 0);
            panel4.Size = new Size(343, 34);
            panel4.TabIndex = 6;
            // 
            // hideShow
            // 
            hideShow.BackColor = Color.White;
            hideShow.Image = Properties.Resources.hide__2_;
            hideShow.Location = new Point(315, 6);
            hideShow.Name = "hideShow";
            hideShow.Size = new Size(20, 20);
            hideShow.SizeMode = PictureBoxSizeMode.StretchImage;
            hideShow.TabIndex = 11;
            hideShow.TabStop = false;
            hideShow.Click += hideShow_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.White;
            pictureBox2.Image = Properties.Resources.icons8_user_48;
            pictureBox2.Location = new Point(10, 5);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(25, 25);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.White;
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(40, 6);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(303, 21);
            txtPassword.TabIndex = 0;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Controls.Add(pictureBox1);
            panel5.Controls.Add(txtUsername);
            panel5.Location = new Point(0, 56);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(34, 0, 0, 0);
            panel5.Size = new Size(343, 34);
            panel5.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Image = Properties.Resources.icons8_user_48;
            pictureBox1.Location = new Point(10, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(25, 25);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.White;
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(40, 6);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Username";
            txtUsername.Size = new Size(303, 21);
            txtUsername.TabIndex = 0;
            // 
            // panel8
            // 
            panel8.Controls.Add(label1);
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(343, 50);
            panel8.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(117, 9);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(115, 32);
            label1.TabIndex = 0;
            label1.Text = "LOGIN";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 229, 215);
            ClientSize = new Size(509, 644);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MaximizeBox = false;
            MaximumSize = new Size(527, 691);
            MinimizeBox = false;
            MinimumSize = new Size(527, 691);
            Name = "Login";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += Login_FormClosing;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)hideShow).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel5;
        private PictureBox pictureBox1;
        private TextBox txtUsername;
        private Panel panel8;
        private Label label1;
        private Panel panel6;
        private Panel panel4;
        private PictureBox pictureBox2;
        private TextBox txtPassword;
        private LinkLabel forgotPassword;
        private Button btnLogin;
        private Label label2;
        private LinkLabel btnSignup;
        private PictureBox pictureBox3;
        private PictureBox hideShow;
    }
}
