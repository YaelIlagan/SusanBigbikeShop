namespace SusanBigbikeShop
{
    partial class InventoryForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlbooking = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cboBoxStatus = new System.Windows.Forms.ComboBox();
            this.txtInventorySearch = new System.Windows.Forms.TextBox();
            this.cboBoxCategorySearch = new System.Windows.Forms.ComboBox();
            this.btnInventoryRestockItem = new System.Windows.Forms.Button();
            this.dataGridInventoryList = new System.Windows.Forms.DataGridView();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LowStockThreshold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.lblAlertDetails = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblOutStockQty = new System.Windows.Forms.Label();
            this.lblOutStock = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblLowStockQty = new System.Windows.Forms.Label();
            this.lblLowStock = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblOkStock = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotalItemQty = new System.Windows.Forms.Label();
            this.lblTotalItem = new System.Windows.Forms.Label();
            this.pnlbooking.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInventoryList)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlbooking
            // 
            this.pnlbooking.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlbooking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.pnlbooking.Controls.Add(this.panel4);
            this.pnlbooking.Controls.Add(this.panel5);
            this.pnlbooking.Location = new System.Drawing.Point(12, 12);
            this.pnlbooking.Margin = new System.Windows.Forms.Padding(4);
            this.pnlbooking.Name = "pnlbooking";
            this.pnlbooking.Padding = new System.Windows.Forms.Padding(5);
            this.pnlbooking.Size = new System.Drawing.Size(940, 658);
            this.pnlbooking.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.panel4.Controls.Add(this.label12);
            this.panel4.Location = new System.Drawing.Point(8, 9);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(923, 50);
            this.panel4.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(8, 6);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(437, 48);
            this.label12.TabIndex = 4;
            this.label12.Text = "INVENTORY MANAGEMENT";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.panel2);
            this.panel5.ForeColor = System.Drawing.Color.Black;
            this.panel5.Location = new System.Drawing.Point(8, 67);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(5);
            this.panel5.Size = new System.Drawing.Size(923, 582);
            this.panel5.TabIndex = 3;
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(232)))), ((int)(((byte)(234)))));
            this.panel8.Controls.Add(this.tableLayoutPanel1);
            this.panel8.Controls.Add(this.dataGridInventoryList);
            this.panel8.Location = new System.Drawing.Point(9, 277);
            this.panel8.Margin = new System.Windows.Forms.Padding(4);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(5);
            this.panel8.Size = new System.Drawing.Size(905, 293);
            this.panel8.TabIndex = 44;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.19168F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.80832F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 231F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 191F));
            this.tableLayoutPanel1.Controls.Add(this.cboBoxStatus, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtInventorySearch, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboBoxCategorySearch, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnInventoryRestockItem, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 7);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(887, 45);
            this.tableLayoutPanel1.TabIndex = 56;
            // 
            // cboBoxStatus
            // 
            this.cboBoxStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboBoxStatus.Font = new System.Drawing.Font("Impact", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBoxStatus.FormattingEnabled = true;
            this.cboBoxStatus.Location = new System.Drawing.Point(468, 4);
            this.cboBoxStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cboBoxStatus.Name = "cboBoxStatus";
            this.cboBoxStatus.Size = new System.Drawing.Size(223, 42);
            this.cboBoxStatus.TabIndex = 53;
            this.cboBoxStatus.SelectedIndexChanged += new System.EventHandler(this.cboBoxStatus_SelectedIndexChanged);
            // 
            // txtInventorySearch
            // 
            this.txtInventorySearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInventorySearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInventorySearch.Font = new System.Drawing.Font("Impact", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInventorySearch.Location = new System.Drawing.Point(4, 4);
            this.txtInventorySearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtInventorySearch.Name = "txtInventorySearch";
            this.txtInventorySearch.Size = new System.Drawing.Size(220, 40);
            this.txtInventorySearch.TabIndex = 52;
            this.txtInventorySearch.TextChanged += new System.EventHandler(this.txtInventorySearch_TextChanged);
            // 
            // cboBoxCategorySearch
            // 
            this.cboBoxCategorySearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboBoxCategorySearch.Font = new System.Drawing.Font("Impact", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBoxCategorySearch.FormattingEnabled = true;
            this.cboBoxCategorySearch.Location = new System.Drawing.Point(232, 4);
            this.cboBoxCategorySearch.Margin = new System.Windows.Forms.Padding(4);
            this.cboBoxCategorySearch.Name = "cboBoxCategorySearch";
            this.cboBoxCategorySearch.Size = new System.Drawing.Size(228, 42);
            this.cboBoxCategorySearch.TabIndex = 52;
            this.cboBoxCategorySearch.SelectedIndexChanged += new System.EventHandler(this.cboBoxCategorySearch_SelectedIndexChanged);
            // 
            // btnInventoryRestockItem
            // 
            this.btnInventoryRestockItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInventoryRestockItem.BackColor = System.Drawing.Color.Orange;
            this.btnInventoryRestockItem.FlatAppearance.BorderSize = 0;
            this.btnInventoryRestockItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventoryRestockItem.Font = new System.Drawing.Font("Impact", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventoryRestockItem.ForeColor = System.Drawing.Color.Black;
            this.btnInventoryRestockItem.Location = new System.Drawing.Point(699, 4);
            this.btnInventoryRestockItem.Margin = new System.Windows.Forms.Padding(4);
            this.btnInventoryRestockItem.Name = "btnInventoryRestockItem";
            this.btnInventoryRestockItem.Padding = new System.Windows.Forms.Padding(5);
            this.btnInventoryRestockItem.Size = new System.Drawing.Size(184, 37);
            this.btnInventoryRestockItem.TabIndex = 3;
            this.btnInventoryRestockItem.Text = "Restock Item";
            this.btnInventoryRestockItem.UseVisualStyleBackColor = false;
            this.btnInventoryRestockItem.Click += new System.EventHandler(this.btnInventoryRestockItem_Click);
            // 
            // dataGridInventoryList
            // 
            this.dataGridInventoryList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridInventoryList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Bernard MT Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridInventoryList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridInventoryList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridInventoryList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemID,
            this.ItemName,
            this.Category,
            this.Stock,
            this.UnitPrice,
            this.LowStockThreshold,
            this.Status});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridInventoryList.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridInventoryList.Location = new System.Drawing.Point(9, 57);
            this.dataGridInventoryList.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridInventoryList.Name = "dataGridInventoryList";
            this.dataGridInventoryList.RowHeadersWidth = 51;
            this.dataGridInventoryList.Size = new System.Drawing.Size(887, 227);
            this.dataGridInventoryList.TabIndex = 55;
            // 
            // ItemID
            // 
            this.ItemID.HeaderText = "ID";
            this.ItemID.MinimumWidth = 6;
            this.ItemID.Name = "ItemID";
            this.ItemID.Width = 75;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "ProductName";
            this.ItemName.MinimumWidth = 6;
            this.ItemName.Name = "ItemName";
            this.ItemName.Width = 125;
            // 
            // Category
            // 
            this.Category.HeaderText = "Category";
            this.Category.MinimumWidth = 6;
            this.Category.Name = "Category";
            this.Category.Width = 125;
            // 
            // Stock
            // 
            this.Stock.HeaderText = "Stock";
            this.Stock.MinimumWidth = 6;
            this.Stock.Name = "Stock";
            this.Stock.Width = 125;
            // 
            // UnitPrice
            // 
            this.UnitPrice.HeaderText = "Unit Price";
            this.UnitPrice.MinimumWidth = 6;
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.Width = 125;
            // 
            // LowStockThreshold
            // 
            this.LowStockThreshold.HeaderText = "Min Stock";
            this.LowStockThreshold.MinimumWidth = 6;
            this.LowStockThreshold.Name = "LowStockThreshold";
            this.LowStockThreshold.Width = 125;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(232)))), ((int)(((byte)(234)))));
            this.panel2.Controls.Add(this.panel13);
            this.panel2.Controls.Add(this.panel12);
            this.panel2.Controls.Add(this.panel11);
            this.panel2.Controls.Add(this.panel9);
            this.panel2.Controls.Add(this.panel10);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(9, 9);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(905, 260);
            this.panel2.TabIndex = 17;
            // 
            // panel13
            // 
            this.panel13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.panel13.Location = new System.Drawing.Point(680, 10);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(217, 10);
            this.panel13.TabIndex = 7;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(100)))), ((int)(((byte)(50)))));
            this.panel12.Location = new System.Drawing.Point(457, 10);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(217, 10);
            this.panel12.TabIndex = 7;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(90)))), ((int)(((byte)(20)))));
            this.panel11.Location = new System.Drawing.Point(231, 10);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(217, 10);
            this.panel11.TabIndex = 6;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            this.panel9.Location = new System.Drawing.Point(8, 10);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(217, 10);
            this.panel9.TabIndex = 5;
            // 
            // panel10
            // 
            this.panel10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.panel10.Controls.Add(this.lblAlertDetails);
            this.panel10.Location = new System.Drawing.Point(8, 173);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(3);
            this.panel10.Size = new System.Drawing.Size(888, 79);
            this.panel10.TabIndex = 4;
            // 
            // lblAlertDetails
            // 
            this.lblAlertDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAlertDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(6)))), ((int)(((byte)(5)))));
            this.lblAlertDetails.Font = new System.Drawing.Font("Impact", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertDetails.ForeColor = System.Drawing.Color.Transparent;
            this.lblAlertDetails.Location = new System.Drawing.Point(6, 3);
            this.lblAlertDetails.Name = "lblAlertDetails";
            this.lblAlertDetails.Size = new System.Drawing.Size(876, 73);
            this.lblAlertDetails.TabIndex = 2;
            this.lblAlertDetails.Text = "Alert details...";
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(6)))), ((int)(((byte)(5)))));
            this.panel6.Controls.Add(this.lblOutStockQty);
            this.panel6.Controls.Add(this.lblOutStock);
            this.panel6.Location = new System.Drawing.Point(680, 17);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(217, 150);
            this.panel6.TabIndex = 3;
            // 
            // lblOutStockQty
            // 
            this.lblOutStockQty.AutoSize = true;
            this.lblOutStockQty.Font = new System.Drawing.Font("Bernard MT Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutStockQty.ForeColor = System.Drawing.Color.Transparent;
            this.lblOutStockQty.Location = new System.Drawing.Point(19, 55);
            this.lblOutStockQty.Name = "lblOutStockQty";
            this.lblOutStockQty.Size = new System.Drawing.Size(34, 39);
            this.lblOutStockQty.TabIndex = 1;
            this.lblOutStockQty.Text = "0";
            // 
            // lblOutStock
            // 
            this.lblOutStock.AutoSize = true;
            this.lblOutStock.Font = new System.Drawing.Font("Impact", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutStock.ForeColor = System.Drawing.Color.Transparent;
            this.lblOutStock.Location = new System.Drawing.Point(-1, 0);
            this.lblOutStock.Name = "lblOutStock";
            this.lblOutStock.Padding = new System.Windows.Forms.Padding(20, 20, 20, 10);
            this.lblOutStock.Size = new System.Drawing.Size(191, 65);
            this.lblOutStock.TabIndex = 0;
            this.lblOutStock.Text = "Out Of Stock";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(6)))), ((int)(((byte)(5)))));
            this.panel3.Controls.Add(this.lblLowStockQty);
            this.panel3.Controls.Add(this.lblLowStock);
            this.panel3.Location = new System.Drawing.Point(231, 17);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(217, 150);
            this.panel3.TabIndex = 1;
            // 
            // lblLowStockQty
            // 
            this.lblLowStockQty.AutoSize = true;
            this.lblLowStockQty.Font = new System.Drawing.Font("Bernard MT Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowStockQty.ForeColor = System.Drawing.Color.Transparent;
            this.lblLowStockQty.Location = new System.Drawing.Point(19, 55);
            this.lblLowStockQty.Name = "lblLowStockQty";
            this.lblLowStockQty.Size = new System.Drawing.Size(34, 39);
            this.lblLowStockQty.TabIndex = 1;
            this.lblLowStockQty.Text = "0";
            this.lblLowStockQty.Click += new System.EventHandler(this.lblLowStockQty_Click);
            // 
            // lblLowStock
            // 
            this.lblLowStock.AutoSize = true;
            this.lblLowStock.Font = new System.Drawing.Font("Impact", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowStock.ForeColor = System.Drawing.Color.Transparent;
            this.lblLowStock.Location = new System.Drawing.Point(-1, 0);
            this.lblLowStock.Name = "lblLowStock";
            this.lblLowStock.Padding = new System.Windows.Forms.Padding(20, 20, 20, 10);
            this.lblLowStock.Size = new System.Drawing.Size(168, 65);
            this.lblLowStock.TabIndex = 0;
            this.lblLowStock.Text = "Low Stock";
            this.lblLowStock.Click += new System.EventHandler(this.lblLowStock_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(6)))), ((int)(((byte)(5)))));
            this.panel7.Controls.Add(this.label6);
            this.panel7.Controls.Add(this.lblOkStock);
            this.panel7.Location = new System.Drawing.Point(457, 17);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(217, 150);
            this.panel7.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bernard MT Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(20, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 39);
            this.label6.TabIndex = 1;
            this.label6.Text = "0";
            // 
            // lblOkStock
            // 
            this.lblOkStock.AutoSize = true;
            this.lblOkStock.Font = new System.Drawing.Font("Impact", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOkStock.ForeColor = System.Drawing.Color.Transparent;
            this.lblOkStock.Location = new System.Drawing.Point(0, 0);
            this.lblOkStock.Name = "lblOkStock";
            this.lblOkStock.Padding = new System.Windows.Forms.Padding(20, 20, 20, 10);
            this.lblOkStock.Size = new System.Drawing.Size(154, 65);
            this.lblOkStock.TabIndex = 0;
            this.lblOkStock.Text = "OK Stock";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(6)))), ((int)(((byte)(5)))));
            this.panel1.Controls.Add(this.lblTotalItemQty);
            this.panel1.Controls.Add(this.lblTotalItem);
            this.panel1.Location = new System.Drawing.Point(8, 17);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(217, 150);
            this.panel1.TabIndex = 0;
            // 
            // lblTotalItemQty
            // 
            this.lblTotalItemQty.AutoSize = true;
            this.lblTotalItemQty.Font = new System.Drawing.Font("Bernard MT Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalItemQty.ForeColor = System.Drawing.Color.Transparent;
            this.lblTotalItemQty.Location = new System.Drawing.Point(20, 55);
            this.lblTotalItemQty.Name = "lblTotalItemQty";
            this.lblTotalItemQty.Size = new System.Drawing.Size(34, 39);
            this.lblTotalItemQty.TabIndex = 1;
            this.lblTotalItemQty.Text = "0";
            // 
            // lblTotalItem
            // 
            this.lblTotalItem.AutoSize = true;
            this.lblTotalItem.Font = new System.Drawing.Font("Impact", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalItem.ForeColor = System.Drawing.Color.Transparent;
            this.lblTotalItem.Location = new System.Drawing.Point(0, 0);
            this.lblTotalItem.Name = "lblTotalItem";
            this.lblTotalItem.Padding = new System.Windows.Forms.Padding(20, 20, 20, 10);
            this.lblTotalItem.Size = new System.Drawing.Size(183, 65);
            this.lblTotalItem.TabIndex = 0;
            this.lblTotalItem.Text = "Total Items";
            // 
            // InventoryForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(964, 682);
            this.Controls.Add(this.pnlbooking);
            this.Name = "InventoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InventoryForm";
            this.pnlbooking.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInventoryList)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlbooking;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.DataGridView dataGridInventoryList;
        private System.Windows.Forms.Label lblTotalItem;
        private System.Windows.Forms.Label lblOutStockQty;
        private System.Windows.Forms.Label lblOutStock;
        private System.Windows.Forms.Label lblLowStockQty;
        private System.Windows.Forms.Label lblLowStock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblOkStock;
        private System.Windows.Forms.Label lblTotalItemQty;
        private System.Windows.Forms.Label lblAlertDetails;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnInventoryRestockItem;
        private System.Windows.Forms.ComboBox cboBoxStatus;
        private System.Windows.Forms.TextBox txtInventorySearch;
        private System.Windows.Forms.ComboBox cboBoxCategorySearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn LowStockThreshold;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel11;
    }
}