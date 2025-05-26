namespace SCHOOL_SUPPLY_SHOP_MANAGEMENT_SYSTEM
{
    partial class receiptItems
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblProductname = new Label();
            lblSubtotal = new Label();
            panel1 = new Panel();
            lblQuantity = new Label();
            lblPrice = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblProductname
            // 
            lblProductname.AutoEllipsis = true;
            lblProductname.Dock = DockStyle.Top;
            lblProductname.Font = new Font("Mongolian Baiti", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProductname.Location = new Point(0, 0);
            lblProductname.Name = "lblProductname";
            lblProductname.Padding = new Padding(10, 0, 0, 0);
            lblProductname.Size = new Size(215, 18);
            lblProductname.TabIndex = 1;
            lblProductname.Text = "3M Post-it Page Markers 670-5AN 5Colors";
            lblProductname.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSubtotal
            // 
            lblSubtotal.Dock = DockStyle.Right;
            lblSubtotal.Font = new Font("Mongolian Baiti", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtotal.Location = new Point(215, 0);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Padding = new Padding(0, 0, 10, 0);
            lblSubtotal.RightToLeft = RightToLeft.No;
            lblSubtotal.Size = new Size(123, 38);
            lblSubtotal.TabIndex = 7;
            lblSubtotal.Text = "P 1056.00";
            lblSubtotal.TextAlign = ContentAlignment.TopRight;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblQuantity);
            panel1.Controls.Add(lblPrice);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 18);
            panel1.Name = "panel1";
            panel1.Size = new Size(215, 19);
            panel1.TabIndex = 8;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoEllipsis = true;
            lblQuantity.Dock = DockStyle.Right;
            lblQuantity.Font = new Font("Mongolian Baiti", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuantity.Location = new Point(135, 0);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Padding = new Padding(10, 0, 0, 0);
            lblQuantity.Size = new Size(80, 19);
            lblQuantity.TabIndex = 3;
            lblQuantity.Text = "x1";
            lblQuantity.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPrice
            // 
            lblPrice.AutoEllipsis = true;
            lblPrice.Dock = DockStyle.Left;
            lblPrice.Font = new Font("Mongolian Baiti", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrice.Location = new Point(0, 0);
            lblPrice.Name = "lblPrice";
            lblPrice.Padding = new Padding(10, 0, 0, 0);
            lblPrice.Size = new Size(129, 19);
            lblPrice.TabIndex = 2;
            lblPrice.Text = "P 528.00";
            lblPrice.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // receiptItems
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(lblProductname);
            Controls.Add(lblSubtotal);
            Name = "receiptItems";
            Size = new Size(338, 38);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblProductname;
        private Label lblSubtotal;
        private Panel panel1;
        private Label lblQuantity;
        private Label lblPrice;
    }
}
