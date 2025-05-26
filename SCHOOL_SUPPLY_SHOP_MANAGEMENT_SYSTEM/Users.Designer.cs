using System.Windows.Forms;

namespace SCHOOL_SUPPLY_SHOP_MANAGEMENT_SYSTEM
{
    partial class Users
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
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel13 = new Panel();
            btnSearch = new PictureBox();
            panel14 = new Panel();
            panel15 = new Panel();
            clearSearch = new PictureBox();
            txtSearch = new TextBox();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            dataGridViewUsers = new DataGridView();
            userID = new DataGridViewTextBoxColumn();
            lastname = new DataGridViewTextBoxColumn();
            firstname = new DataGridViewTextBoxColumn();
            middlename = new DataGridViewTextBoxColumn();
            userName = new DataGridViewTextBoxColumn();
            userRole = new DataGridViewTextBoxColumn();
            userGender = new DataGridViewTextBoxColumn();
            userAddress = new DataGridViewTextBoxColumn();
            userMobile = new DataGridViewTextBoxColumn();
            viewUser = new DataGridViewButtonColumn();
            delete = new DataGridViewButtonColumn();
            flowLayoutPanel1.SuspendLayout();
            panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnSearch).BeginInit();
            panel14.SuspendLayout();
            panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)clearSearch).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.Controls.Add(panel13);
            flowLayoutPanel1.Controls.Add(panel14);
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(342, 50);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(905, 57);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // panel13
            // 
            panel13.Controls.Add(btnSearch);
            panel13.Cursor = Cursors.Hand;
            panel13.Location = new Point(854, 3);
            panel13.Name = "panel13";
            panel13.Padding = new Padding(10, 9, 0, 9);
            panel13.Size = new Size(48, 51);
            panel13.TabIndex = 15;
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
            panel14.Location = new Point(239, 3);
            panel14.Name = "panel14";
            panel14.Padding = new Padding(0, 9, 0, 9);
            panel14.Size = new Size(609, 51);
            panel14.TabIndex = 16;
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
            txtSearch.Location = new Point(8, 7);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search users";
            txtSearch.Size = new Size(560, 20);
            txtSearch.TabIndex = 16;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(75, 50);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(0, 5, 0, 5);
            panel1.Size = new Size(1172, 57);
            panel1.TabIndex = 17;
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = Properties.Resources.icons8_plus_100;
            pictureBox1.Location = new Point(0, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(56, 47);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(75, 107);
            panel2.Name = "panel2";
            panel2.Size = new Size(1172, 10);
            panel2.TabIndex = 18;
            // 
            // dataGridViewUsers
            // 
            dataGridViewUsers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewUsers.BackgroundColor = Color.FromArgb(235, 229, 215);
            dataGridViewUsers.BorderStyle = BorderStyle.None;
            dataGridViewUsers.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsers.Columns.AddRange(new DataGridViewColumn[] { userID, lastname, firstname, middlename, userName, userRole, userGender, userAddress, userMobile, viewUser, delete });
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = SystemColors.Window;
            dataGridViewCellStyle13.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle13.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.True;
            dataGridViewUsers.DefaultCellStyle = dataGridViewCellStyle13;
            dataGridViewUsers.Dock = DockStyle.Fill;
            dataGridViewUsers.Location = new Point(75, 117);
            dataGridViewUsers.Name = "dataGridViewUsers";
            dataGridViewUsers.ReadOnly = true;
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = SystemColors.Control;
            dataGridViewCellStyle14.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle14.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = DataGridViewTriState.True;
            dataGridViewUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            dataGridViewUsers.RowHeadersVisible = false;
            dataGridViewUsers.RowHeadersWidth = 100;
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle15.WrapMode = DataGridViewTriState.True;
            dataGridViewUsers.RowsDefaultCellStyle = dataGridViewCellStyle15;
            dataGridViewUsers.Size = new Size(1172, 359);
            dataGridViewUsers.TabIndex = 19;
            dataGridViewUsers.CellClick += dataGridViewUsers_CellClick;
            // 
            // userID
            // 
            userID.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            userID.DataPropertyName = "userId";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            userID.DefaultCellStyle = dataGridViewCellStyle2;
            userID.HeaderText = "ID";
            userID.MinimumWidth = 50;
            userID.Name = "userID";
            userID.ReadOnly = true;
            userID.Width = 57;
            // 
            // lastname
            // 
            lastname.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            lastname.DataPropertyName = "userLname";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            lastname.DefaultCellStyle = dataGridViewCellStyle3;
            lastname.HeaderText = "Last Name";
            lastname.MinimumWidth = 160;
            lastname.Name = "lastname";
            lastname.ReadOnly = true;
            lastname.Width = 160;
            // 
            // firstname
            // 
            firstname.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            firstname.DataPropertyName = "userFname";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            firstname.DefaultCellStyle = dataGridViewCellStyle4;
            firstname.HeaderText = "First Name";
            firstname.MinimumWidth = 200;
            firstname.Name = "firstname";
            firstname.ReadOnly = true;
            firstname.Width = 200;
            // 
            // middlename
            // 
            middlename.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            middlename.DataPropertyName = "userMname";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            middlename.DefaultCellStyle = dataGridViewCellStyle5;
            middlename.HeaderText = "Middle Name";
            middlename.MinimumWidth = 150;
            middlename.Name = "middlename";
            middlename.ReadOnly = true;
            middlename.Width = 150;
            // 
            // userName
            // 
            userName.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            userName.DataPropertyName = "userName";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            userName.DefaultCellStyle = dataGridViewCellStyle6;
            userName.HeaderText = "Username";
            userName.MinimumWidth = 120;
            userName.Name = "userName";
            userName.ReadOnly = true;
            userName.Width = 123;
            // 
            // userRole
            // 
            userRole.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            userRole.DataPropertyName = "userRole";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            userRole.DefaultCellStyle = dataGridViewCellStyle7;
            userRole.HeaderText = "Role";
            userRole.MinimumWidth = 80;
            userRole.Name = "userRole";
            userRole.ReadOnly = true;
            userRole.Width = 80;
            // 
            // userGender
            // 
            userGender.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            userGender.DataPropertyName = "userGender";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            userGender.DefaultCellStyle = dataGridViewCellStyle8;
            userGender.HeaderText = "Gender";
            userGender.MinimumWidth = 80;
            userGender.Name = "userGender";
            userGender.ReadOnly = true;
            userGender.Width = 99;
            // 
            // userAddress
            // 
            userAddress.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            userAddress.DataPropertyName = "userAddress";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            userAddress.DefaultCellStyle = dataGridViewCellStyle9;
            userAddress.HeaderText = "Address";
            userAddress.MinimumWidth = 200;
            userAddress.Name = "userAddress";
            userAddress.ReadOnly = true;
            userAddress.Width = 200;
            // 
            // userMobile
            // 
            userMobile.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            userMobile.DataPropertyName = "userMobile";
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            userMobile.DefaultCellStyle = dataGridViewCellStyle10;
            userMobile.HeaderText = "Mobile No.";
            userMobile.MinimumWidth = 135;
            userMobile.Name = "userMobile";
            userMobile.ReadOnly = true;
            userMobile.Width = 135;
            // 
            // viewUser
            // 
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = Color.DodgerBlue;
            dataGridViewCellStyle11.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle11.ForeColor = Color.White;
            dataGridViewCellStyle11.NullValue = "View";
            dataGridViewCellStyle11.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle11.SelectionForeColor = Color.White;
            viewUser.DefaultCellStyle = dataGridViewCellStyle11;
            viewUser.FlatStyle = FlatStyle.Popup;
            viewUser.HeaderText = "View";
            viewUser.MinimumWidth = 6;
            viewUser.Name = "viewUser";
            viewUser.ReadOnly = true;
            viewUser.SortMode = DataGridViewColumnSortMode.Automatic;
            viewUser.Text = "View";
            viewUser.Width = 125;
            // 
            // delete
            // 
            delete.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = Color.FromArgb(245, 206, 200);
            dataGridViewCellStyle12.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle12.ForeColor = Color.FromArgb(238, 32, 28);
            dataGridViewCellStyle12.NullValue = "Delete";
            dataGridViewCellStyle12.SelectionBackColor = Color.FromArgb(245, 206, 200);
            dataGridViewCellStyle12.SelectionForeColor = Color.FromArgb(238, 32, 28);
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
            delete.DefaultCellStyle = dataGridViewCellStyle12;
            delete.FlatStyle = FlatStyle.Popup;
            delete.HeaderText = "Delete";
            delete.MinimumWidth = 100;
            delete.Name = "delete";
            delete.ReadOnly = true;
            delete.SortMode = DataGridViewColumnSortMode.Automatic;
            delete.Text = "Delete";
            // 
            // Users
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 229, 215);
            ClientSize = new Size(1347, 576);
            ControlBox = false;
            Controls.Add(dataGridViewUsers);
            Controls.Add(panel2);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Users";
            Padding = new Padding(75, 50, 100, 100);
            ShowIcon = false;
            Load += Users_Load;
            flowLayoutPanel1.ResumeLayout(false);
            panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnSearch).EndInit();
            panel14.ResumeLayout(false);
            panel15.ResumeLayout(false);
            panel15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)clearSearch).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).EndInit();
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
        private PictureBox pictureBox1;
        private Panel panel2;
        private DataGridView dataGridViewUsers;
        private DataGridViewTextBoxColumn userID;
        private DataGridViewTextBoxColumn lastname;
        private DataGridViewTextBoxColumn firstname;
        private DataGridViewTextBoxColumn middlename;
        private DataGridViewTextBoxColumn userName;
        private DataGridViewTextBoxColumn userRole;
        private DataGridViewTextBoxColumn userGender;
        private DataGridViewTextBoxColumn userAddress;
        private DataGridViewTextBoxColumn userMobile;
        private DataGridViewButtonColumn viewUser;
        private DataGridViewButtonColumn delete;
    }
}