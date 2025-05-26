using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Forms;

namespace SCHOOL_SUPPLY_SHOP_MANAGEMENT_SYSTEM
{
    partial class customerData
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(customerData));
            panel11 = new Panel();
            lblTitle = new Label();
            panel13 = new Panel();
            panel18 = new Panel();
            panel19 = new Panel();
            txtSearch = new TextBox();
            clearSearch = new PictureBox();
            panel17 = new Panel();
            btnSearch = new PictureBox();
            panel1 = new Panel();
            exportExcel = new PictureBox();
            panel20 = new Panel();
            dataGridViewCustomerData = new DataGridView();
            custId = new DataGridViewTextBoxColumn();
            custFullname = new DataGridViewTextBoxColumn();
            custAddress = new DataGridViewTextBoxColumn();
            custMobile = new DataGridViewTextBoxColumn();
            totalPurchaseAmount = new DataGridViewTextBoxColumn();
            panel11.SuspendLayout();
            panel13.SuspendLayout();
            panel18.SuspendLayout();
            panel19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)clearSearch).BeginInit();
            panel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnSearch).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)exportExcel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCustomerData).BeginInit();
            SuspendLayout();
            // 
            // panel11
            // 
            panel11.Controls.Add(lblTitle);
            panel11.Dock = DockStyle.Top;
            panel11.Location = new Point(20, 20);
            panel11.Name = "panel11";
            panel11.Padding = new Padding(20, 20, 20, 0);
            panel11.Size = new Size(1602, 83);
            panel11.TabIndex = 24;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Georgia", 20F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1562, 63);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "CUSTOMER DATA";
            // 
            // panel13
            // 
            panel13.Controls.Add(panel18);
            panel13.Controls.Add(panel17);
            panel13.Controls.Add(panel1);
            panel13.Dock = DockStyle.Top;
            panel13.Location = new Point(20, 103);
            panel13.Name = "panel13";
            panel13.Size = new Size(1602, 47);
            panel13.TabIndex = 25;
            // 
            // panel18
            // 
            panel18.Controls.Add(panel19);
            panel18.Dock = DockStyle.Right;
            panel18.Location = new Point(897, 0);
            panel18.Name = "panel18";
            panel18.Padding = new Padding(0, 18, 0, 0);
            panel18.Size = new Size(609, 47);
            panel18.TabIndex = 24;
            // 
            // panel19
            // 
            panel19.BackColor = Color.White;
            panel19.Controls.Add(txtSearch);
            panel19.Controls.Add(clearSearch);
            panel19.Dock = DockStyle.Fill;
            panel19.Location = new Point(0, 18);
            panel19.Name = "panel19";
            panel19.Padding = new Padding(5, 0, 0, 0);
            panel19.Size = new Size(609, 29);
            panel19.TabIndex = 15;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(26, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search customer name";
            txtSearch.Size = new Size(552, 20);
            txtSearch.TabIndex = 16;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // clearSearch
            // 
            clearSearch.Cursor = Cursors.Hand;
            clearSearch.Dock = DockStyle.Right;
            clearSearch.Image = Properties.Resources.icons8_x_button_301;
            clearSearch.Location = new Point(574, 0);
            clearSearch.Name = "clearSearch";
            clearSearch.Padding = new Padding(3);
            clearSearch.Size = new Size(35, 29);
            clearSearch.SizeMode = PictureBoxSizeMode.Zoom;
            clearSearch.TabIndex = 15;
            clearSearch.TabStop = false;
            clearSearch.Visible = false;
            clearSearch.Click += clearSearch_Click;
            // 
            // panel17
            // 
            panel17.Controls.Add(btnSearch);
            panel17.Dock = DockStyle.Right;
            panel17.Location = new Point(1506, 0);
            panel17.Name = "panel17";
            panel17.Padding = new Padding(10, 18, 0, 0);
            panel17.Size = new Size(48, 47);
            panel17.TabIndex = 23;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Black;
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.Dock = DockStyle.Fill;
            btnSearch.Image = Properties.Resources.icons8_search_50;
            btnSearch.Location = new Point(10, 18);
            btnSearch.Name = "btnSearch";
            btnSearch.Padding = new Padding(5);
            btnSearch.Size = new Size(38, 29);
            btnSearch.SizeMode = PictureBoxSizeMode.Zoom;
            btnSearch.TabIndex = 15;
            btnSearch.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(exportExcel);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(1554, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10, 18, 0, 0);
            panel1.Size = new Size(48, 47);
            panel1.TabIndex = 25;
            // 
            // exportExcel
            // 
            exportExcel.BackColor = Color.Black;
            exportExcel.Cursor = Cursors.Hand;
            exportExcel.Dock = DockStyle.Fill;
            exportExcel.Image = Properties.Resources.icons8_xls_export_30__2_;
            exportExcel.Location = new Point(10, 18);
            exportExcel.Name = "exportExcel";
            exportExcel.Padding = new Padding(5);
            exportExcel.Size = new Size(38, 29);
            exportExcel.SizeMode = PictureBoxSizeMode.Zoom;
            exportExcel.TabIndex = 15;
            exportExcel.TabStop = false;
            // 
            // panel20
            // 
            panel20.Dock = DockStyle.Top;
            panel20.Location = new Point(20, 150);
            panel20.Name = "panel20";
            panel20.Size = new Size(1602, 10);
            panel20.TabIndex = 26;
            // 
            // dataGridViewCustomerData
            // 
            dataGridViewCustomerData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCustomerData.BackgroundColor = Color.FromArgb(235, 229, 215);
            dataGridViewCustomerData.BorderStyle = BorderStyle.None;
            dataGridViewCustomerData.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewCustomerData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCustomerData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCustomerData.Columns.AddRange(new DataGridViewColumn[] { custId, custFullname, custAddress, custMobile, totalPurchaseAmount });
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = SystemColors.Window;
            dataGridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dataGridViewCustomerData.DefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCustomerData.Dock = DockStyle.Fill;
            dataGridViewCustomerData.Location = new Point(20, 160);
            dataGridViewCustomerData.Name = "dataGridViewCustomerData";
            dataGridViewCustomerData.ReadOnly = true;
            dataGridViewCustomerData.RowHeadersVisible = false;
            dataGridViewCustomerData.RowHeadersWidth = 50;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dataGridViewCustomerData.RowsDefaultCellStyle = dataGridViewCellStyle8;
            dataGridViewCustomerData.ScrollBars = ScrollBars.Vertical;
            dataGridViewCustomerData.Size = new Size(1602, 638);
            dataGridViewCustomerData.TabIndex = 27;
            dataGridViewCustomerData.GridColor = Color.FromArgb(235, 223, 215);
            // 
            // custId
            // 
            custId.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            custId.DataPropertyName = "custId";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            custId.DefaultCellStyle = dataGridViewCellStyle2;
            custId.Frozen = true;
            custId.HeaderText = "Customer ID";
            custId.MinimumWidth = 200;
            custId.Name = "custId";
            custId.ReadOnly = true;
            custId.Width = 200;
            // 
            // custFullname
            // 
            custFullname.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            custFullname.DataPropertyName = "fullname";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            custFullname.DefaultCellStyle = dataGridViewCellStyle3;
            custFullname.Frozen = true;
            custFullname.HeaderText = "Full Name";
            custFullname.MinimumWidth = 480;
            custFullname.Name = "custFullname";
            custFullname.ReadOnly = true;
            custFullname.Width = 480;
            // 
            // custAddress
            // 
            custAddress.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            custAddress.DataPropertyName = "custAddress";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            custAddress.DefaultCellStyle = dataGridViewCellStyle4;
            custAddress.HeaderText = "Address";
            custAddress.MinimumWidth = 320;
            custAddress.Name = "custAddress";
            custAddress.ReadOnly = true;
            custAddress.Width = 320;
            // 
            // custMobile
            // 
            custMobile.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            custMobile.DataPropertyName = "custMobile";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            custMobile.DefaultCellStyle = dataGridViewCellStyle5;
            custMobile.HeaderText = "Mobile Number";
            custMobile.MinimumWidth = 300;
            custMobile.Name = "custMobile";
            custMobile.ReadOnly = true;
            custMobile.Width = 300;
            // 
            // totalPurchaseAmount
            // 
            totalPurchaseAmount.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            totalPurchaseAmount.DataPropertyName = "totalAmount";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            totalPurchaseAmount.DefaultCellStyle = dataGridViewCellStyle6;
            totalPurchaseAmount.HeaderText = "Total Purchase Amount (₱)";
            totalPurchaseAmount.MinimumWidth = 298;
            totalPurchaseAmount.Name = "totalPurchaseAmount";
            totalPurchaseAmount.ReadOnly = true;
            totalPurchaseAmount.Width = 298;
            // 
            // customerData
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 229, 215);
            ClientSize = new Size(1642, 818);
            Controls.Add(dataGridViewCustomerData);
            Controls.Add(panel20);
            Controls.Add(panel13);
            Controls.Add(panel11);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(1660, 865);
            MinimizeBox = false;
            MinimumSize = new Size(1660, 865);
            Name = "customerData";
            Padding = new Padding(20);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CUSTOMER DATA";
            panel11.ResumeLayout(false);
            panel13.ResumeLayout(false);
            panel18.ResumeLayout(false);
            panel19.ResumeLayout(false);
            panel19.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)clearSearch).EndInit();
            panel17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnSearch).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)exportExcel).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCustomerData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel11;
        private Label lblTitle;
        private Panel panel13;
        private Panel panel18;
        private Panel panel19;
        private TextBox txtSearch;
        private PictureBox clearSearch;
        private Panel panel17;
        private PictureBox btnSearch;
        private Panel panel1;
        private PictureBox exportExcel;
        private Panel panel20;
        private DataGridView dataGridViewCustomerData;
        private DataGridViewTextBoxColumn custId;
        private DataGridViewTextBoxColumn custFullname;
        private DataGridViewTextBoxColumn custAddress;
        private DataGridViewTextBoxColumn custMobile;
        private DataGridViewTextBoxColumn totalPurchaseAmount;
    }
}