namespace SCHOOL_SUPPLY_SHOP_MANAGEMENT_SYSTEM
{
    partial class UserProfile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            lblFullname = new Label();
            lblRole = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.mine;
            pictureBox1.Location = new Point(53, 53);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(300, 300);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(pictureBox1);
            flowLayoutPanel1.Controls.Add(panel1);
            flowLayoutPanel1.Controls.Add(lblFullname);
            flowLayoutPanel1.Controls.Add(lblRole);
            flowLayoutPanel1.Dock = DockStyle.Left;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(50);
            flowLayoutPanel1.Size = new Size(408, 576);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Location = new Point(53, 359);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 5);
            panel1.TabIndex = 1;
            // 
            // lblFullname
            // 
            lblFullname.AutoSize = true;
            lblFullname.Font = new Font("Georgia", 14F, FontStyle.Bold);
            lblFullname.Location = new Point(53, 367);
            lblFullname.Name = "lblFullname";
            lblFullname.Size = new Size(285, 29);
            lblFullname.TabIndex = 2;
            lblFullname.Text = "Estorba, Daisy Mae H.";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Georgia", 10F);
            lblRole.Location = new Point(53, 396);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(69, 20);
            lblRole.TabIndex = 3;
            lblRole.Text = "ADMIN";
            // 
            // UserProfile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 229, 215);
            ClientSize = new Size(1142, 576);
            Controls.Add(flowLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "UserProfile";
            ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private Label lblFullname;
        private Label lblRole;
    }
}