namespace SCHOOL_SUPPLY_SHOP_MANAGEMENT_SYSTEM
{
    partial class Customers
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
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel13 = new Panel();
            btnSearch = new PictureBox();
            panel14 = new Panel();
            panel15 = new Panel();
            clearSearch = new PictureBox();
            txtSearch = new TextBox();
            panel1 = new Panel();
            dataGridViewCustomers = new DataGridView();
            custID = new DataGridViewTextBoxColumn();
            lastname = new DataGridViewTextBoxColumn();
            firstname = new DataGridViewTextBoxColumn();
            middlename = new DataGridViewTextBoxColumn();
            mobile = new DataGridViewTextBoxColumn();
            address = new DataGridViewTextBoxColumn();
            view = new DataGridViewButtonColumn();
            delete = new DataGridViewButtonColumn();
            flowLayoutPanel1.SuspendLayout();
            panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnSearch).BeginInit();
            panel14.SuspendLayout();
            panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)clearSearch).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCustomers).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(panel13);
            flowLayoutPanel1.Controls.Add(panel14);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(150, 50);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1297, 57);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // panel13
            // 
            panel13.Controls.Add(btnSearch);
            panel13.Cursor = Cursors.Hand;
            panel13.Location = new Point(1246, 3);
            panel13.Name = "panel13";
            panel13.Padding = new Padding(10, 9, 0, 9);
            panel13.Size = new Size(48, 51);
            panel13.TabIndex = 16;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Black;
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.Dock = DockStyle.Fill;
            btnSearch.Image = Properties.Resources.icons8_search_50;
            btnSearch.Location = new Point(10, 9);
            btnSearch.Name = "btnSearch";
            btnSearch.Padding = new Padding(5);
            btnSearch.Size = new Size(38, 33);
            btnSearch.SizeMode = PictureBoxSizeMode.StretchImage;
            btnSearch.TabIndex = 15;
            btnSearch.TabStop = false;
            // 
            // panel14
            // 
            panel14.Controls.Add(panel15);
            panel14.Dock = DockStyle.Fill;
            panel14.Location = new Point(631, 3);
            panel14.Name = "panel14";
            panel14.Padding = new Padding(0, 9, 0, 9);
            panel14.Size = new Size(609, 51);
            panel14.TabIndex = 17;
            // 
            // panel15
            // 
            panel15.BackColor = Color.White;
            panel15.Controls.Add(clearSearch);
            panel15.Controls.Add(txtSearch);
            panel15.Dock = DockStyle.Fill;
            panel15.Location = new Point(0, 9);
            panel15.Name = "panel15";
            panel15.Padding = new Padding(5, 0, 0, 0);
            panel15.Size = new Size(609, 33);
            panel15.TabIndex = 15;
            // 
            // clearSearch
            // 
            clearSearch.Cursor = Cursors.Hand;
            clearSearch.Dock = DockStyle.Right;
            clearSearch.Image = Properties.Resources.icons8_x_button_301;
            clearSearch.Location = new Point(574, 0);
            clearSearch.Name = "clearSearch";
            clearSearch.Padding = new Padding(5);
            clearSearch.Size = new Size(35, 33);
            clearSearch.SizeMode = PictureBoxSizeMode.StretchImage;
            clearSearch.TabIndex = 15;
            clearSearch.TabStop = false;
            clearSearch.Visible = false;
            clearSearch.Click += clearSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(13, 7);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search customer";
            txtSearch.Size = new Size(560, 20);
            txtSearch.TabIndex = 16;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(150, 107);
            panel1.Name = "panel1";
            panel1.Size = new Size(1297, 35);
            panel1.TabIndex = 1;
            // 
            // dataGridViewCustomers
            // 
            dataGridViewCustomers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCustomers.BackgroundColor = Color.FromArgb(235, 229, 215);
            dataGridViewCustomers.BorderStyle = BorderStyle.None;
            dataGridViewCustomers.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewCustomers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCustomers.Columns.AddRange(new DataGridViewColumn[] { custID, lastname, firstname, middlename, mobile, address, view, delete });
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = SystemColors.Window;
            dataGridViewCellStyle10.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle10.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            dataGridViewCustomers.DefaultCellStyle = dataGridViewCellStyle10;
            dataGridViewCustomers.Dock = DockStyle.Fill;
            dataGridViewCustomers.Location = new Point(150, 142);
            dataGridViewCustomers.Name = "dataGridViewCustomers";
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = SystemColors.Control;
            dataGridViewCellStyle11.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle11.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.True;
            dataGridViewCustomers.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dataGridViewCustomers.RowHeadersVisible = false;
            dataGridViewCustomers.RowHeadersWidth = 51;
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
            dataGridViewCustomers.RowsDefaultCellStyle = dataGridViewCellStyle12;
            dataGridViewCustomers.Size = new Size(1297, 333);
            dataGridViewCustomers.TabIndex = 2;
            dataGridViewCustomers.CellClick += dataGridViewCustomers_CellClick;
            // 
            // custID
            // 
            custID.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            custID.DataPropertyName = "custId";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            custID.DefaultCellStyle = dataGridViewCellStyle2;
            custID.HeaderText = "ID";
            custID.MinimumWidth = 50;
            custID.Name = "custID";
            custID.Width = 57;
            // 
            // lastname
            // 
            lastname.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            lastname.DataPropertyName = "custLname";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            lastname.DefaultCellStyle = dataGridViewCellStyle3;
            lastname.HeaderText = "Last Name";
            lastname.MinimumWidth = 200;
            lastname.Name = "lastname";
            lastname.Width = 200;
            // 
            // firstname
            // 
            firstname.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            firstname.DataPropertyName = "custFname";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            firstname.DefaultCellStyle = dataGridViewCellStyle4;
            firstname.HeaderText = "First Name";
            firstname.MinimumWidth = 220;
            firstname.Name = "firstname";
            firstname.Width = 220;
            // 
            // middlename
            // 
            middlename.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            middlename.DataPropertyName = "custMname";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            middlename.DefaultCellStyle = dataGridViewCellStyle5;
            middlename.HeaderText = "Middle Name";
            middlename.MinimumWidth = 200;
            middlename.Name = "middlename";
            middlename.Width = 200;
            // 
            // mobile
            // 
            mobile.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            mobile.DataPropertyName = "custMobile";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            mobile.DefaultCellStyle = dataGridViewCellStyle6;
            mobile.HeaderText = "Mobile No.";
            mobile.MinimumWidth = 180;
            mobile.Name = "mobile";
            mobile.Width = 180;
            // 
            // address
            // 
            address.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            address.DataPropertyName = "custAddress";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            address.DefaultCellStyle = dataGridViewCellStyle7;
            address.HeaderText = "Address";
            address.MinimumWidth = 200;
            address.Name = "address";
            address.Width = 200;
            // 
            // view
            // 
            view.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = Color.DodgerBlue;
            dataGridViewCellStyle8.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = Color.White;
            dataGridViewCellStyle8.NullValue = "View";
            dataGridViewCellStyle8.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle8.SelectionForeColor = Color.White;
            view.DefaultCellStyle = dataGridViewCellStyle8;
            view.FlatStyle = FlatStyle.Popup;
            view.HeaderText = "View";
            view.MinimumWidth = 100;
            view.Name = "view";
            view.SortMode = DataGridViewColumnSortMode.Automatic;
            view.Text = "View";
            // 
            // delete
            // 
            delete.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(245, 206, 200);
            dataGridViewCellStyle9.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(238, 32, 28);
            dataGridViewCellStyle9.NullValue = "Delete";
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(245, 206, 200);
            dataGridViewCellStyle9.SelectionForeColor = Color.FromArgb(238, 32, 28);
            delete.DefaultCellStyle = dataGridViewCellStyle9;
            delete.FlatStyle = FlatStyle.Popup;
            delete.HeaderText = "Delete";
            delete.MinimumWidth = 100;
            delete.Name = "delete";
            delete.SortMode = DataGridViewColumnSortMode.Automatic;
            delete.Text = "Delete";
            // 
            // Customers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 229, 215);
            ClientSize = new Size(1647, 575);
            ControlBox = false;
            Controls.Add(dataGridViewCustomers);
            Controls.Add(panel1);
            Controls.Add(flowLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Customers";
            Padding = new Padding(150, 50, 200, 100);
            ShowIcon = false;
            Load += Customers_Load;
            flowLayoutPanel1.ResumeLayout(false);
            panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnSearch).EndInit();
            panel14.ResumeLayout(false);
            panel15.ResumeLayout(false);
            panel15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)clearSearch).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCustomers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel13;
        private PictureBox btnSearch;
        private Panel panel14;
        private Panel panel15;
        private PictureBox clearSearch;
        private TextBox txtSearch;
        private Panel panel1;
        private DataGridView dataGridViewCustomers;
        private DataGridViewTextBoxColumn custID;
        private DataGridViewTextBoxColumn lastname;
        private DataGridViewTextBoxColumn firstname;
        private DataGridViewTextBoxColumn middlename;
        private DataGridViewTextBoxColumn mobile;
        private DataGridViewTextBoxColumn address;
        private DataGridViewButtonColumn view;
        private DataGridViewButtonColumn delete;
    }
}