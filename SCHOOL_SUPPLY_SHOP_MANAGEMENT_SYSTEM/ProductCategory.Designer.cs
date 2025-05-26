namespace SCHOOL_SUPPLY_SHOP_MANAGEMENT_SYSTEM
{
    partial class ProductCategory
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
            btnCategories = new Button();
            SuspendLayout();
            // 
            // btnCategories
            // 
            btnCategories.BackColor = Color.Black;
            btnCategories.Cursor = Cursors.Hand;
            btnCategories.FlatAppearance.BorderSize = 0;
            btnCategories.FlatStyle = FlatStyle.Flat;
            btnCategories.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCategories.ForeColor = Color.White;
            btnCategories.ImageAlign = ContentAlignment.MiddleLeft;
            btnCategories.Location = new Point(0, 0);
            btnCategories.Name = "btnCategories";
            btnCategories.RightToLeft = RightToLeft.No;
            btnCategories.Size = new Size(301, 41);
            btnCategories.TabIndex = 3;
            btnCategories.Text = "Categories";
            btnCategories.UseVisualStyleBackColor = false;
            btnCategories.Click += btnCategories_Click;
            // 
            // ProductCategory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 223, 215);
            Controls.Add(btnCategories);
            Name = "ProductCategory";
            Size = new Size(301, 41);
            ResumeLayout(false);
        }

        #endregion

        private Button btnCategories;
    }
}
