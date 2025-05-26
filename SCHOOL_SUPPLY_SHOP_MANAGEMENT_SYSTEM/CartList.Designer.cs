namespace SCHOOL_SUPPLY_SHOP_MANAGEMENT_SYSTEM
{
    partial class CartList
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
            panelCart = new Panel();
            panel8 = new Panel();
            panel10 = new Panel();
            minus = new PictureBox();
            label5 = new Label();
            plus = new PictureBox();
            panel9 = new Panel();
            totalPrice = new Label();
            pictureBox1 = new PictureBox();
            cartPrice = new Label();
            cartName = new Label();
            panelCart.SuspendLayout();
            panel8.SuspendLayout();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)minus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)plus).BeginInit();
            panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panelCart
            // 
            panelCart.BackColor = Color.White;
            panelCart.Controls.Add(panel8);
            panelCart.Controls.Add(cartPrice);
            panelCart.Controls.Add(cartName);
            panelCart.Dock = DockStyle.Fill;
            panelCart.Location = new Point(10, 0);
            panelCart.Name = "panelCart";
            panelCart.Size = new Size(430, 78);
            panelCart.TabIndex = 1;
            // 
            // panel8
            // 
            panel8.Controls.Add(panel10);
            panel8.Controls.Add(panel9);
            panel8.Controls.Add(pictureBox1);
            panel8.Dock = DockStyle.Right;
            panel8.Location = new Point(191, 0);
            panel8.Name = "panel8";
            panel8.Padding = new Padding(0, 22, 0, 22);
            panel8.Size = new Size(239, 78);
            panel8.TabIndex = 2;
            // 
            // panel10
            // 
            panel10.BorderStyle = BorderStyle.FixedSingle;
            panel10.Controls.Add(minus);
            panel10.Controls.Add(label5);
            panel10.Controls.Add(plus);
            panel10.Dock = DockStyle.Right;
            panel10.Location = new Point(7, 22);
            panel10.Name = "panel10";
            panel10.Padding = new Padding(0, 3, 0, 3);
            panel10.Size = new Size(110, 34);
            panel10.TabIndex = 18;
            // 
            // minus
            // 
            minus.Cursor = Cursors.Hand;
            minus.Dock = DockStyle.Right;
            minus.Image = Properties.Resources.minus;
            minus.Location = new Point(0, 3);
            minus.Name = "minus";
            minus.Padding = new Padding(5);
            minus.Size = new Size(28, 26);
            minus.SizeMode = PictureBoxSizeMode.StretchImage;
            minus.TabIndex = 21;
            minus.TabStop = false;
            minus.Click += minus_Click;
            // 
            // label5
            // 
            label5.AutoEllipsis = true;
            label5.Dock = DockStyle.Right;
            label5.Font = new Font("Arial Rounded MT Bold", 10F);
            label5.Location = new Point(28, 3);
            label5.Name = "label5";
            label5.Size = new Size(52, 26);
            label5.TabIndex = 20;
            label5.Text = "x1";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // plus
            // 
            plus.Cursor = Cursors.Hand;
            plus.Dock = DockStyle.Right;
            plus.Image = Properties.Resources.plus;
            plus.Location = new Point(80, 3);
            plus.Name = "plus";
            plus.Padding = new Padding(5);
            plus.Size = new Size(28, 26);
            plus.SizeMode = PictureBoxSizeMode.StretchImage;
            plus.TabIndex = 19;
            plus.TabStop = false;
            plus.Click += plus_Click;
            // 
            // panel9
            // 
            panel9.Controls.Add(totalPrice);
            panel9.Dock = DockStyle.Right;
            panel9.Location = new Point(117, 22);
            panel9.Name = "panel9";
            panel9.Padding = new Padding(0, 10, 0, 10);
            panel9.Size = new Size(87, 34);
            panel9.TabIndex = 17;
            // 
            // totalPrice
            // 
            totalPrice.AutoEllipsis = true;
            totalPrice.Dock = DockStyle.Fill;
            totalPrice.Font = new Font("Arial", 9F, FontStyle.Bold);
            totalPrice.Location = new Point(0, 10);
            totalPrice.Name = "totalPrice";
            totalPrice.Size = new Size(87, 14);
            totalPrice.TabIndex = 2;
            totalPrice.Text = " ₱ 245.00";
            totalPrice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Image = Properties.Resources.icons8_x_button_301;
            pictureBox1.Location = new Point(204, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Padding = new Padding(5);
            pictureBox1.Size = new Size(35, 34);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            pictureBox1.Click += btnRemove_Click;
            // 
            // cartPrice
            // 
            cartPrice.AutoEllipsis = true;
            cartPrice.Font = new Font("Arial", 9F);
            cartPrice.Location = new Point(10, 41);
            cartPrice.Name = "cartPrice";
            cartPrice.Size = new Size(195, 22);
            cartPrice.TabIndex = 1;
            cartPrice.Text = " ₱ 245.00";
            // 
            // cartName
            // 
            cartName.AutoEllipsis = true;
            cartName.Font = new Font("Arial Rounded MT Bold", 11F);
            cartName.Location = new Point(10, 16);
            cartName.Name = "cartName";
            cartName.Size = new Size(183, 25);
            cartName.TabIndex = 0;
            cartName.Text = "Eagle Ring Binder 103D315 Blue Legal 1\"";
            // 
            // CartList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(panelCart);
            Name = "CartList";
            Padding = new Padding(10, 0, 10, 10);
            Size = new Size(450, 88);
            panelCart.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)minus).EndInit();
            ((System.ComponentModel.ISupportInitialize)plus).EndInit();
            panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelCart;
        private Panel panel8;
        private Panel panel10;
        private Label label5;
        private PictureBox plus;
        private Panel panel9;
        private Label totalPrice;
        private PictureBox pictureBox1;
        private Label cartPrice;
        private Label cartName;
        private PictureBox minus;
    }
}
