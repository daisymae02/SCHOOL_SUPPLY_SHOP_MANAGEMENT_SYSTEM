namespace SCHOOL_SUPPLY_SHOP_MANAGEMENT_SYSTEM
{
    partial class Information
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Information));
            panel1 = new Panel();
            button2 = new Button();
            lblMessage = new Label();
            lblTitle = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button2);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(20, 110);
            panel1.Name = "panel1";
            panel1.Size = new Size(409, 47);
            panel1.TabIndex = 0;
            // 
            // button2
            // 
            button2.BackColor = Color.OliveDrab;
            button2.DialogResult = DialogResult.OK;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Georgia", 10F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(3, 3);
            button2.Name = "button2";
            button2.Size = new Size(404, 40);
            button2.TabIndex = 2;
            button2.Text = "OK";
            button2.UseVisualStyleBackColor = false;
            // 
            // lblMessage
            // 
            lblMessage.Font = new Font("Segoe UI", 12F);
            lblMessage.Location = new Point(20, 66);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(409, 28);
            lblMessage.TabIndex = 2;
            lblMessage.Text = "Are you sure you want to logout?";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Georgia", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(409, 39);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "LOGOUT";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Information
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 229, 215);
            ClientSize = new Size(449, 177);
            Controls.Add(lblMessage);
            Controls.Add(lblTitle);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Information";
            Padding = new Padding(20);
            StartPosition = FormStartPosition.CenterScreen;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblMessage;
        private Label lblTitle;
        private Button button2;
    }
}