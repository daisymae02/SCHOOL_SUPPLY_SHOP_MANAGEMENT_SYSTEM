namespace SCHOOL_SUPPLY_SHOP_MANAGEMENT_SYSTEM
{
    partial class checkoutItems
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
            itemQuantity = new Label();
            itemTotalPrice = new Label();
            itemName = new Label();
            itemImage = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)itemImage).BeginInit();
            SuspendLayout();
            // 
            // itemQuantity
            // 
            itemQuantity.Dock = DockStyle.Bottom;
            itemQuantity.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            itemQuantity.Location = new Point(80, 45);
            itemQuantity.Name = "itemQuantity";
            itemQuantity.Padding = new Padding(5, 0, 0, 0);
            itemQuantity.Size = new Size(905, 35);
            itemQuantity.TabIndex = 6;
            itemQuantity.Text = "x1";
            itemQuantity.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // itemTotalPrice
            // 
            itemTotalPrice.Dock = DockStyle.Right;
            itemTotalPrice.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            itemTotalPrice.Location = new Point(985, 45);
            itemTotalPrice.Name = "itemTotalPrice";
            itemTotalPrice.Padding = new Padding(5, 0, 0, 0);
            itemTotalPrice.RightToLeft = RightToLeft.No;
            itemTotalPrice.Size = new Size(98, 35);
            itemTotalPrice.TabIndex = 7;
            itemTotalPrice.Text = "100.00";
            itemTotalPrice.TextAlign = ContentAlignment.MiddleRight;
            // 
            // itemName
            // 
            itemName.AutoEllipsis = true;
            itemName.Dock = DockStyle.Top;
            itemName.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            itemName.Location = new Point(80, 10);
            itemName.Name = "itemName";
            itemName.Padding = new Padding(5, 0, 0, 0);
            itemName.Size = new Size(1003, 35);
            itemName.TabIndex = 5;
            itemName.Text = "Office Warehouse Premium Copy Paper 80gsm Letter 500s";
            itemName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // itemImage
            // 
            itemImage.Dock = DockStyle.Left;
            itemImage.Image = Properties.Resources.user;
            itemImage.Location = new Point(10, 10);
            itemImage.Name = "itemImage";
            itemImage.Size = new Size(70, 70);
            itemImage.SizeMode = PictureBoxSizeMode.Zoom;
            itemImage.TabIndex = 4;
            itemImage.TabStop = false;
            // 
            // checkoutItems
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(246, 244, 238);
            Controls.Add(itemQuantity);
            Controls.Add(itemTotalPrice);
            Controls.Add(itemName);
            Controls.Add(itemImage);
            Name = "checkoutItems";
            Padding = new Padding(10);
            Size = new Size(1093, 90);
            ((System.ComponentModel.ISupportInitialize)itemImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label itemQuantity;
        private Label itemTotalPrice;
        private Label itemName;
        private PictureBox itemImage;
    }
}
