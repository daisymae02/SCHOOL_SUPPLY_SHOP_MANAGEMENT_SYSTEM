namespace SCHOOL_SUPPLY_SHOP_MANAGEMENT_SYSTEM
{
    partial class ProductList
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
            panel5 = new Panel();
            panel2 = new Panel();
            productInfo = new PictureBox();
            prodImage = new PictureBox();
            btnAddtoCart = new Button();
            prodPrice = new Label();
            panel1 = new Panel();
            prodCat = new Label();
            prodName = new Label();
            prodStocks = new Label();
            panel5.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)productInfo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)prodImage).BeginInit();
            SuspendLayout();
            // 
            // panel5
            // 
            panel5.Controls.Add(panel2);
            panel5.Controls.Add(prodImage);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(10, 10);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(50, 0, 0, 0);
            panel5.Size = new Size(230, 125);
            panel5.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(productInfo);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(197, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(33, 125);
            panel2.TabIndex = 1;
            // 
            // productInfo
            // 
            productInfo.Cursor = Cursors.Hand;
            productInfo.Dock = DockStyle.Top;
            productInfo.Image = Properties.Resources.information__1_;
            productInfo.Location = new Point(0, 0);
            productInfo.Name = "productInfo";
            productInfo.Padding = new Padding(0, 0, 0, 30);
            productInfo.Size = new Size(33, 25);
            productInfo.SizeMode = PictureBoxSizeMode.Zoom;
            productInfo.TabIndex = 2;
            productInfo.TabStop = false;
            productInfo.Click += productInfo_Click;
            // 
            // prodImage
            // 
            prodImage.Dock = DockStyle.Left;
            prodImage.Image = Properties.Resources.no_image;
            prodImage.Location = new Point(50, 0);
            prodImage.Name = "prodImage";
            prodImage.Size = new Size(130, 125);
            prodImage.SizeMode = PictureBoxSizeMode.Zoom;
            prodImage.TabIndex = 0;
            prodImage.TabStop = false;
            // 
            // btnAddtoCart
            // 
            btnAddtoCart.BackColor = Color.Black;
            btnAddtoCart.Cursor = Cursors.Hand;
            btnAddtoCart.Dock = DockStyle.Bottom;
            btnAddtoCart.FlatStyle = FlatStyle.Popup;
            btnAddtoCart.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddtoCart.ForeColor = Color.White;
            btnAddtoCart.Image = Properties.Resources.icons8_products_30;
            btnAddtoCart.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddtoCart.Location = new Point(10, 260);
            btnAddtoCart.Name = "btnAddtoCart";
            btnAddtoCart.Padding = new Padding(30, 0, 0, 0);
            btnAddtoCart.Size = new Size(230, 41);
            btnAddtoCart.TabIndex = 10;
            btnAddtoCart.Text = "Add to Cart";
            btnAddtoCart.UseVisualStyleBackColor = false;
            btnAddtoCart.Click += btnAddtoCart_Click_1;
            // 
            // prodPrice
            // 
            prodPrice.AutoEllipsis = true;
            prodPrice.Dock = DockStyle.Bottom;
            prodPrice.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            prodPrice.ForeColor = Color.FromArgb(230, 95, 43);
            prodPrice.Location = new Point(10, 241);
            prodPrice.Name = "prodPrice";
            prodPrice.Size = new Size(230, 19);
            prodPrice.TabIndex = 15;
            prodPrice.Text = " ₱ 245.00";
            prodPrice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 135);
            panel1.Name = "panel1";
            panel1.Size = new Size(230, 10);
            panel1.TabIndex = 12;
            // 
            // prodCat
            // 
            prodCat.AutoEllipsis = true;
            prodCat.Dock = DockStyle.Top;
            prodCat.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            prodCat.ForeColor = SystemColors.ControlDarkDark;
            prodCat.Location = new Point(10, 191);
            prodCat.Name = "prodCat";
            prodCat.Size = new Size(230, 19);
            prodCat.TabIndex = 14;
            prodCat.Text = "General Supplies";
            prodCat.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // prodName
            // 
            prodName.AutoEllipsis = true;
            prodName.Dock = DockStyle.Top;
            prodName.Font = new Font("Arial Rounded MT Bold", 11F);
            prodName.Location = new Point(10, 145);
            prodName.Name = "prodName";
            prodName.Size = new Size(230, 46);
            prodName.TabIndex = 13;
            prodName.Text = "Eagle Ring Binder 103D315 Blue Legal 1\"";
            prodName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // prodStocks
            // 
            prodStocks.AutoEllipsis = true;
            prodStocks.Dock = DockStyle.Bottom;
            prodStocks.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            prodStocks.ForeColor = Color.OliveDrab;
            prodStocks.Location = new Point(10, 222);
            prodStocks.Name = "prodStocks";
            prodStocks.Size = new Size(230, 19);
            prodStocks.TabIndex = 15;
            prodStocks.Text = " Stock: 4 pieces";
            prodStocks.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ProductList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(prodStocks);
            Controls.Add(prodCat);
            Controls.Add(prodName);
            Controls.Add(panel1);
            Controls.Add(prodPrice);
            Controls.Add(btnAddtoCart);
            Controls.Add(panel5);
            Name = "ProductList";
            Padding = new Padding(10);
            Size = new Size(250, 311);
            panel5.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)productInfo).EndInit();
            ((System.ComponentModel.ISupportInitialize)prodImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel5;
        private PictureBox prodImage;
        private Button btnAddtoCart;
        private Label prodPrice;
        private Panel panel1;
        private Label prodCat;
        private Label prodName;
        private Label prodStocks;
        private Panel panel2;
        private PictureBox productInfo;
    }
}
