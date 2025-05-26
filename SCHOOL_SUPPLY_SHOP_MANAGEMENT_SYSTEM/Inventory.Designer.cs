namespace SCHOOL_SUPPLY_SHOP_MANAGEMENT_SYSTEM
{
    partial class Inventory
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
            panel1 = new Panel();
            panel11 = new Panel();
            btnCancel = new Button();
            panel12 = new Panel();
            btnAddStock = new Button();
            panel5 = new Panel();
            panel6 = new Panel();
            errorProduct = new PictureBox();
            label3 = new Label();
            panel7 = new Panel();
            txtProduct = new ComboBox();
            panel10 = new Panel();
            panel3 = new Panel();
            errorStockQuantity = new PictureBox();
            label2 = new Label();
            panel4 = new Panel();
            txtStockQuantity = new TextBox();
            panel2 = new Panel();
            showAddProduct = new Panel();
            label1 = new Label();
            panel8 = new Panel();
            panel9 = new Panel();
            dataGridViewStocks = new DataGridView();
            stockId = new DataGridViewTextBoxColumn();
            productQuantity = new DataGridViewTextBoxColumn();
            productName = new DataGridViewTextBoxColumn();
            createdAt = new DataGridViewTextBoxColumn();
            fullName = new DataGridViewTextBoxColumn();
            panel13 = new Panel();
            panel18 = new Panel();
            panel19 = new Panel();
            txtSearch = new TextBox();
            clearSearch = new PictureBox();
            panel17 = new Panel();
            btnSearch = new PictureBox();
            panel15 = new Panel();
            clearFromTo = new PictureBox();
            panel16 = new Panel();
            dateTimePickerTo = new DateTimePicker();
            label6 = new Label();
            label4 = new Label();
            panel14 = new Panel();
            dateTimePickerFrom = new DateTimePicker();
            label5 = new Label();
            panel20 = new Panel();
            panel1.SuspendLayout();
            panel11.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProduct).BeginInit();
            panel7.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorStockQuantity).BeginInit();
            panel4.SuspendLayout();
            showAddProduct.SuspendLayout();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStocks).BeginInit();
            panel13.SuspendLayout();
            panel18.SuspendLayout();
            panel19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)clearSearch).BeginInit();
            panel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnSearch).BeginInit();
            panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)clearFromTo).BeginInit();
            panel16.SuspendLayout();
            panel14.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(235, 223, 215);
            panel1.Controls.Add(panel11);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(showAddProduct);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(238, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(20);
            panel1.Size = new Size(864, 211);
            panel1.TabIndex = 0;
            // 
            // panel11
            // 
            panel11.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel11.Controls.Add(btnCancel);
            panel11.Controls.Add(panel12);
            panel11.Controls.Add(btnAddStock);
            panel11.Location = new Point(20, 135);
            panel11.Name = "panel11";
            panel11.Padding = new Padding(10, 10, 0, 10);
            panel11.Size = new Size(824, 55);
            panel11.TabIndex = 20;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.IndianRed;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Dock = DockStyle.Right;
            btnCancel.FlatStyle = FlatStyle.Popup;
            btnCancel.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(352, 10);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(231, 35);
            btnCancel.TabIndex = 21;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // panel12
            // 
            panel12.Dock = DockStyle.Right;
            panel12.Location = new Point(583, 10);
            panel12.Name = "panel12";
            panel12.Size = new Size(10, 35);
            panel12.TabIndex = 20;
            // 
            // btnAddStock
            // 
            btnAddStock.BackColor = Color.Black;
            btnAddStock.Cursor = Cursors.Hand;
            btnAddStock.Dock = DockStyle.Right;
            btnAddStock.FlatStyle = FlatStyle.Popup;
            btnAddStock.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddStock.ForeColor = Color.White;
            btnAddStock.Location = new Point(593, 10);
            btnAddStock.Name = "btnAddStock";
            btnAddStock.Size = new Size(231, 35);
            btnAddStock.TabIndex = 13;
            btnAddStock.Text = "ADD STOCK";
            btnAddStock.UseVisualStyleBackColor = false;
            btnAddStock.Click += btnAddStock_Click;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel5.Controls.Add(panel6);
            panel5.Controls.Add(panel10);
            panel5.Controls.Add(panel3);
            panel5.Location = new Point(20, 80);
            panel5.Name = "panel5";
            panel5.Size = new Size(824, 55);
            panel5.TabIndex = 19;
            // 
            // panel6
            // 
            panel6.Controls.Add(errorProduct);
            panel6.Controls.Add(label3);
            panel6.Controls.Add(panel7);
            panel6.Dock = DockStyle.Right;
            panel6.Location = new Point(1, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(483, 55);
            panel6.TabIndex = 18;
            // 
            // errorProduct
            // 
            errorProduct.BackColor = Color.Transparent;
            errorProduct.Image = Properties.Resources.icons8_warning_48;
            errorProduct.Location = new Point(111, 0);
            errorProduct.Name = "errorProduct";
            errorProduct.Size = new Size(20, 20);
            errorProduct.SizeMode = PictureBoxSizeMode.StretchImage;
            errorProduct.TabIndex = 15;
            errorProduct.TabStop = false;
            errorProduct.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Georgia", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.No;
            label3.Size = new Size(107, 20);
            label3.TabIndex = 11;
            label3.Text = "PRODUCT:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            panel7.BackColor = Color.White;
            panel7.Controls.Add(txtProduct);
            panel7.Dock = DockStyle.Bottom;
            panel7.Location = new Point(0, 21);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(6, 2, 6, 0);
            panel7.Size = new Size(483, 34);
            panel7.TabIndex = 7;
            // 
            // txtProduct
            // 
            txtProduct.Dock = DockStyle.Fill;
            txtProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            txtProduct.FlatStyle = FlatStyle.Flat;
            txtProduct.Font = new Font("Microsoft Sans Serif", 11F);
            txtProduct.FormattingEnabled = true;
            txtProduct.Location = new Point(6, 2);
            txtProduct.Name = "txtProduct";
            txtProduct.Size = new Size(471, 30);
            txtProduct.TabIndex = 16;
            txtProduct.SelectedIndexChanged += txtProduct_SelectedIndexChanged;
            // 
            // panel10
            // 
            panel10.Dock = DockStyle.Right;
            panel10.Location = new Point(484, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(20, 55);
            panel10.TabIndex = 19;
            // 
            // panel3
            // 
            panel3.Controls.Add(errorStockQuantity);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(504, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(320, 55);
            panel3.TabIndex = 19;
            // 
            // errorStockQuantity
            // 
            errorStockQuantity.BackColor = Color.Transparent;
            errorStockQuantity.Image = Properties.Resources.icons8_warning_48;
            errorStockQuantity.Location = new Point(119, 0);
            errorStockQuantity.Name = "errorStockQuantity";
            errorStockQuantity.Size = new Size(20, 20);
            errorStockQuantity.SizeMode = PictureBoxSizeMode.StretchImage;
            errorStockQuantity.TabIndex = 15;
            errorStockQuantity.TabStop = false;
            errorStockQuantity.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Georgia", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.No;
            label2.Size = new Size(115, 20);
            label2.TabIndex = 11;
            label2.Text = "QUANTITY:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(txtStockQuantity);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 21);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(6);
            panel4.Size = new Size(320, 34);
            panel4.TabIndex = 7;
            // 
            // txtStockQuantity
            // 
            txtStockQuantity.BackColor = Color.White;
            txtStockQuantity.BorderStyle = BorderStyle.None;
            txtStockQuantity.Dock = DockStyle.Fill;
            txtStockQuantity.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStockQuantity.Location = new Point(6, 6);
            txtStockQuantity.Name = "txtStockQuantity";
            txtStockQuantity.RightToLeft = RightToLeft.Yes;
            txtStockQuantity.Size = new Size(308, 21);
            txtStockQuantity.TabIndex = 0;
            txtStockQuantity.TextChanged += txtStockQuantity_TextChanged;
            txtStockQuantity.KeyPress += txtStockQuantity_KeyPress;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(20, 70);
            panel2.Name = "panel2";
            panel2.Size = new Size(824, 10);
            panel2.TabIndex = 18;
            // 
            // showAddProduct
            // 
            showAddProduct.Controls.Add(label1);
            showAddProduct.Dock = DockStyle.Top;
            showAddProduct.Location = new Point(20, 20);
            showAddProduct.Name = "showAddProduct";
            showAddProduct.Size = new Size(824, 50);
            showAddProduct.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(0, 9);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(160, 32);
            label1.TabIndex = 0;
            label1.Text = "Add Stock";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            panel8.Controls.Add(panel1);
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(20, 20);
            panel8.Name = "panel8";
            panel8.Size = new Size(1102, 211);
            panel8.TabIndex = 1;
            // 
            // panel9
            // 
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(20, 231);
            panel9.Name = "panel9";
            panel9.Size = new Size(1102, 20);
            panel9.TabIndex = 2;
            // 
            // dataGridViewStocks
            // 
            dataGridViewStocks.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewStocks.BackgroundColor = Color.FromArgb(235, 229, 215);
            dataGridViewStocks.BorderStyle = BorderStyle.None;
            dataGridViewStocks.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewStocks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewStocks.ColumnHeadersHeight = 29;
            dataGridViewStocks.Columns.AddRange(new DataGridViewColumn[] { stockId, productQuantity, productName, createdAt, fullName });
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = SystemColors.Window;
            dataGridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dataGridViewStocks.DefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewStocks.Dock = DockStyle.Fill;
            dataGridViewStocks.GridColor = Color.FromArgb(235, 223, 215);
            dataGridViewStocks.Location = new Point(20, 308);
            dataGridViewStocks.Name = "dataGridViewStocks";
            dataGridViewStocks.ReadOnly = true;
            dataGridViewStocks.RowHeadersVisible = false;
            dataGridViewStocks.RowHeadersWidth = 50;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dataGridViewStocks.RowsDefaultCellStyle = dataGridViewCellStyle8;
            dataGridViewStocks.Size = new Size(1102, 248);
            dataGridViewStocks.TabIndex = 17;
            // 
            // stockId
            // 
            stockId.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            stockId.DataPropertyName = "stockId";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            stockId.DefaultCellStyle = dataGridViewCellStyle2;
            stockId.HeaderText = "Stock ID";
            stockId.MinimumWidth = 200;
            stockId.Name = "stockId";
            stockId.ReadOnly = true;
            stockId.Width = 200;
            // 
            // productQuantity
            // 
            productQuantity.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            productQuantity.DataPropertyName = "stockQuantityChanged";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            productQuantity.DefaultCellStyle = dataGridViewCellStyle3;
            productQuantity.HeaderText = "Product Quantity";
            productQuantity.MinimumWidth = 200;
            productQuantity.Name = "productQuantity";
            productQuantity.ReadOnly = true;
            productQuantity.Width = 200;
            // 
            // productName
            // 
            productName.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            productName.DataPropertyName = "prodName";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            productName.DefaultCellStyle = dataGridViewCellStyle4;
            productName.HeaderText = "Product Name";
            productName.MinimumWidth = 400;
            productName.Name = "productName";
            productName.ReadOnly = true;
            productName.Width = 400;
            // 
            // createdAt
            // 
            createdAt.DataPropertyName = "formattedDate";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            createdAt.DefaultCellStyle = dataGridViewCellStyle5;
            createdAt.HeaderText = "Stock Added";
            createdAt.MinimumWidth = 400;
            createdAt.Name = "createdAt";
            createdAt.ReadOnly = true;
            createdAt.Width = 400;
            // 
            // fullName
            // 
            fullName.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            fullName.DataPropertyName = "fullName";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            fullName.DefaultCellStyle = dataGridViewCellStyle6;
            fullName.HeaderText = "Stock Added By";
            fullName.MinimumWidth = 400;
            fullName.Name = "fullName";
            fullName.ReadOnly = true;
            fullName.Width = 400;
            // 
            // panel13
            // 
            panel13.Controls.Add(panel18);
            panel13.Controls.Add(panel17);
            panel13.Controls.Add(panel15);
            panel13.Controls.Add(panel16);
            panel13.Controls.Add(label4);
            panel13.Controls.Add(panel14);
            panel13.Dock = DockStyle.Top;
            panel13.Location = new Point(20, 251);
            panel13.Name = "panel13";
            panel13.Size = new Size(1102, 47);
            panel13.TabIndex = 18;
            // 
            // panel18
            // 
            panel18.Controls.Add(panel19);
            panel18.Dock = DockStyle.Right;
            panel18.Location = new Point(445, 0);
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
            txtSearch.Location = new Point(16, 7);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search product name";
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
            clearSearch.SizeMode = PictureBoxSizeMode.StretchImage;
            clearSearch.TabIndex = 15;
            clearSearch.TabStop = false;
            clearSearch.Visible = false;
            clearSearch.Click += clearSearch_Click;
            // 
            // panel17
            // 
            panel17.Controls.Add(btnSearch);
            panel17.Dock = DockStyle.Right;
            panel17.Location = new Point(1054, 0);
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
            btnSearch.Padding = new Padding(3);
            btnSearch.Size = new Size(38, 29);
            btnSearch.SizeMode = PictureBoxSizeMode.StretchImage;
            btnSearch.TabIndex = 15;
            btnSearch.TabStop = false;
            // 
            // panel15
            // 
            panel15.Controls.Add(clearFromTo);
            panel15.Dock = DockStyle.Left;
            panel15.Location = new Point(564, 0);
            panel15.Name = "panel15";
            panel15.Padding = new Padding(5);
            panel15.Size = new Size(46, 47);
            panel15.TabIndex = 22;
            // 
            // clearFromTo
            // 
            clearFromTo.Cursor = Cursors.Hand;
            clearFromTo.Dock = DockStyle.Left;
            clearFromTo.Image = Properties.Resources.icons8_x_button_301;
            clearFromTo.Location = new Point(5, 5);
            clearFromTo.Name = "clearFromTo";
            clearFromTo.Padding = new Padding(5);
            clearFromTo.Size = new Size(35, 37);
            clearFromTo.SizeMode = PictureBoxSizeMode.StretchImage;
            clearFromTo.TabIndex = 16;
            clearFromTo.TabStop = false;
            clearFromTo.Visible = false;
            // 
            // panel16
            // 
            panel16.Controls.Add(dateTimePickerTo);
            panel16.Controls.Add(label6);
            panel16.Dock = DockStyle.Left;
            panel16.Location = new Point(300, 0);
            panel16.Name = "panel16";
            panel16.Size = new Size(264, 47);
            panel16.TabIndex = 21;
            // 
            // dateTimePickerTo
            // 
            dateTimePickerTo.CalendarFont = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerTo.CalendarMonthBackground = Color.FromArgb(235, 229, 215);
            dateTimePickerTo.CalendarTitleBackColor = Color.FromArgb(235, 229, 215);
            dateTimePickerTo.CalendarTitleForeColor = Color.FromArgb(235, 229, 215);
            dateTimePickerTo.Dock = DockStyle.Bottom;
            dateTimePickerTo.Location = new Point(0, 20);
            dateTimePickerTo.Name = "dateTimePickerTo";
            dateTimePickerTo.Size = new Size(264, 27);
            dateTimePickerTo.TabIndex = 17;
            dateTimePickerTo.Value = new DateTime(2025, 5, 4, 19, 13, 53, 0);
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Georgia", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.RightToLeft = RightToLeft.No;
            label6.Size = new Size(41, 20);
            label6.TabIndex = 11;
            label6.Text = "TO:";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Left;
            label4.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label4.Location = new Point(264, 0);
            label4.Name = "label4";
            label4.Size = new Size(36, 47);
            label4.TabIndex = 19;
            label4.Text = "-";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel14
            // 
            panel14.Controls.Add(dateTimePickerFrom);
            panel14.Controls.Add(label5);
            panel14.Dock = DockStyle.Left;
            panel14.Location = new Point(0, 0);
            panel14.Name = "panel14";
            panel14.Size = new Size(264, 47);
            panel14.TabIndex = 18;
            // 
            // dateTimePickerFrom
            // 
            dateTimePickerFrom.CalendarFont = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerFrom.CalendarMonthBackground = Color.FromArgb(235, 229, 215);
            dateTimePickerFrom.CalendarTitleBackColor = Color.FromArgb(235, 229, 215);
            dateTimePickerFrom.CalendarTitleForeColor = Color.FromArgb(235, 229, 215);
            dateTimePickerFrom.Dock = DockStyle.Bottom;
            dateTimePickerFrom.Location = new Point(0, 20);
            dateTimePickerFrom.Name = "dateTimePickerFrom";
            dateTimePickerFrom.Size = new Size(264, 27);
            dateTimePickerFrom.TabIndex = 17;
            dateTimePickerFrom.Value = new DateTime(2025, 5, 4, 19, 13, 53, 0);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Georgia", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.RightToLeft = RightToLeft.No;
            label5.Size = new Size(71, 20);
            label5.TabIndex = 11;
            label5.Text = "FROM:";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel20
            // 
            panel20.Dock = DockStyle.Top;
            panel20.Location = new Point(20, 298);
            panel20.Name = "panel20";
            panel20.Size = new Size(1102, 10);
            panel20.TabIndex = 19;
            // 
            // Inventory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 229, 215);
            ClientSize = new Size(1142, 576);
            ControlBox = false;
            Controls.Add(dataGridViewStocks);
            Controls.Add(panel20);
            Controls.Add(panel13);
            Controls.Add(panel9);
            Controls.Add(panel8);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Inventory";
            Padding = new Padding(20);
            ShowIcon = false;
            Load += Inventory_Load;
            panel1.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProduct).EndInit();
            panel7.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorStockQuantity).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            showAddProduct.ResumeLayout(false);
            showAddProduct.PerformLayout();
            panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewStocks).EndInit();
            panel13.ResumeLayout(false);
            panel18.ResumeLayout(false);
            panel19.ResumeLayout(false);
            panel19.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)clearSearch).EndInit();
            panel17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnSearch).EndInit();
            panel15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)clearFromTo).EndInit();
            panel16.ResumeLayout(false);
            panel16.PerformLayout();
            panel14.ResumeLayout(false);
            panel14.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel showAddProduct;
        private Label label1;
        private Panel panel5;
        private Panel panel2;
        private Panel panel3;
        private PictureBox errorStockQuantity;
        private Label label2;
        private Panel panel4;
        private TextBox txtStockQuantity;
        private Panel panel10;
        private Panel panel11;
        private Button btnCancel;
        private Panel panel12;
        private Button btnAddStock;
        private Panel panel6;
        private PictureBox errorProduct;
        private Label label3;
        private Panel panel7;
        private ComboBox txtProduct;
        private Panel panel8;
        private Panel panel9;
        private DataGridView dataGridViewStocks;
        private DataGridViewTextBoxColumn stockId;
        private DataGridViewTextBoxColumn productQuantity;
        private DataGridViewTextBoxColumn productName;
        private DataGridViewTextBoxColumn createdAt;
        private DataGridViewTextBoxColumn fullName;
        private Panel panel13;
        private Label label4;
        private Panel panel14;
        private DateTimePicker dateTimePickerFrom;
        private Label label5;
        private Panel panel16;
        private DateTimePicker dateTimePickerTo;
        private Label label6;
        private Panel panel15;
        private PictureBox clearFromTo;
        private Panel panel17;
        private PictureBox btnSearch;
        private Panel panel18;
        private Panel panel19;
        private TextBox txtSearch;
        private PictureBox clearSearch;
        private Panel panel20;
    }
}