namespace SCHOOL_SUPPLY_SHOP_MANAGEMENT_SYSTEM
{
    partial class Brand
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
            panel1 = new Panel();
            button2 = new Button();
            button1 = new Button();
            label1 = new Label();
            panel2 = new Panel();
            label2 = new Label();
            panel5 = new Panel();
            textBoxBrandName = new TextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(20, 132);
            panel1.Name = "panel1";
            panel1.Size = new Size(409, 45);
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
            button2.Location = new Point(206, 3);
            button2.Name = "button2";
            button2.Size = new Size(200, 40);
            button2.TabIndex = 2;
            button2.Text = "CONFIRM";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.IndianRed;
            button1.DialogResult = DialogResult.Cancel;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Georgia", 10F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(200, 40);
            button1.TabIndex = 1;
            button1.Text = "CANCEL";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 15F, FontStyle.Bold);
            label1.Location = new Point(105, 21);
            label1.Name = "label1";
            label1.Size = new Size(253, 30);
            label1.TabIndex = 1;
            label1.Text = "ADD NEW BRAND";
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Controls.Add(panel5);
            panel2.Location = new Point(23, 62);
            panel2.Name = "panel2";
            panel2.Size = new Size(403, 55);
            panel2.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Georgia", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.No;
            label2.Size = new Size(143, 20);
            label2.TabIndex = 11;
            label2.Text = "BRAND NAME:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Controls.Add(textBoxBrandName);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(0, 21);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(6);
            panel5.Size = new Size(403, 34);
            panel5.TabIndex = 7;
            // 
            // textBoxBrandName
            // 
            textBoxBrandName.BackColor = Color.White;
            textBoxBrandName.BorderStyle = BorderStyle.None;
            textBoxBrandName.Dock = DockStyle.Fill;
            textBoxBrandName.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxBrandName.Location = new Point(6, 6);
            textBoxBrandName.Name = "textBoxBrandName";
            textBoxBrandName.Size = new Size(391, 21);
            textBoxBrandName.TabIndex = 0;
            // 
            // Brand
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 229, 215);
            ClientSize = new Size(449, 197);
            Controls.Add(panel2);
            Controls.Add(label1);
            Controls.Add(panel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Brand";
            Padding = new Padding(20);
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Button button2;
        private Label label1;
        private Panel panel2;
        private Label label2;
        private Panel panel5;
        private TextBox textBoxBrandName;
    }
}