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
            this.pnlbooking = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel9 = new System.Windows.Forms.Panel();
            this.txtInventorySearch = new System.Windows.Forms.TextBox();
            this.cboBoxStatus = new System.Windows.Forms.ComboBox();
            this.btnInventoryRestockItem = new System.Windows.Forms.Button();
            this.cboBoxCategorySearch = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotalItem = new System.Windows.Forms.Label();
            this.lblTotalItemQty = new System.Windows.Forms.Label();
            this.lblLowStock = new System.Windows.Forms.Label();
            this.lblLowStockQty = new System.Windows.Forms.Label();
            this.lblOkStock = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblOutStock = new System.Windows.Forms.Label();
            this.lblOutStockQty = new System.Windows.Forms.Label();
            this.lblAlertDetails = new System.Windows.Forms.Label();
            this.pnlbooking.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel9.SuspendLayout();
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
            this.pnlbooking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(12)))), ((int)(((byte)(16)))));
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
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
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
            this.label12.Font = new System.Drawing.Font("Impact", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(4, 3);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(406, 45);
            this.label12.TabIndex = 4;
            this.label12.Text = "INVENTORY MANAGEMENT";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
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
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(232)))), ((int)(((byte)(234)))));
            this.panel8.Controls.Add(this.dataGridView1);
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Location = new System.Drawing.Point(9, 277);
            this.panel8.Margin = new System.Windows.Forms.Padding(4);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(5);
            this.panel8.Size = new System.Drawing.Size(905, 293);
            this.panel8.TabIndex = 44;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 64);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(887, 220);
            this.dataGridView1.TabIndex = 55;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(16)))), ((int)(((byte)(22)))));
            this.panel9.Controls.Add(this.txtInventorySearch);
            this.panel9.Controls.Add(this.cboBoxStatus);
            this.panel9.Controls.Add(this.btnInventoryRestockItem);
            this.panel9.Controls.Add(this.cboBoxCategorySearch);
            this.panel9.Location = new System.Drawing.Point(8, 8);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(888, 49);
            this.panel9.TabIndex = 54;
            // 
            // txtInventorySearch
            // 
            this.txtInventorySearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInventorySearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInventorySearch.Location = new System.Drawing.Point(5, 5);
            this.txtInventorySearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtInventorySearch.Name = "txtInventorySearch";
            this.txtInventorySearch.Size = new System.Drawing.Size(215, 38);
            this.txtInventorySearch.TabIndex = 52;
            // 
            // cboBoxStatus
            // 
            this.cboBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBoxStatus.FormattingEnabled = true;
            this.cboBoxStatus.Location = new System.Drawing.Point(450, 6);
            this.cboBoxStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cboBoxStatus.Name = "cboBoxStatus";
            this.cboBoxStatus.Size = new System.Drawing.Size(215, 37);
            this.cboBoxStatus.TabIndex = 53;
            // 
            // btnInventoryRestockItem
            // 
            this.btnInventoryRestockItem.BackColor = System.Drawing.Color.Silver;
            this.btnInventoryRestockItem.FlatAppearance.BorderSize = 0;
            this.btnInventoryRestockItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventoryRestockItem.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventoryRestockItem.ForeColor = System.Drawing.Color.Black;
            this.btnInventoryRestockItem.Location = new System.Drawing.Point(673, 6);
            this.btnInventoryRestockItem.Margin = new System.Windows.Forms.Padding(4);
            this.btnInventoryRestockItem.Name = "btnInventoryRestockItem";
            this.btnInventoryRestockItem.Padding = new System.Windows.Forms.Padding(5);
            this.btnInventoryRestockItem.Size = new System.Drawing.Size(210, 37);
            this.btnInventoryRestockItem.TabIndex = 3;
            this.btnInventoryRestockItem.Text = "Restock Item";
            this.btnInventoryRestockItem.UseVisualStyleBackColor = false;
            // 
            // cboBoxCategorySearch
            // 
            this.cboBoxCategorySearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBoxCategorySearch.FormattingEnabled = true;
            this.cboBoxCategorySearch.Location = new System.Drawing.Point(227, 6);
            this.cboBoxCategorySearch.Margin = new System.Windows.Forms.Padding(4);
            this.cboBoxCategorySearch.Name = "cboBoxCategorySearch";
            this.cboBoxCategorySearch.Size = new System.Drawing.Size(215, 37);
            this.cboBoxCategorySearch.TabIndex = 52;
            this.cboBoxCategorySearch.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(232)))), ((int)(((byte)(234)))));
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
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.panel10.Controls.Add(this.lblAlertDetails);
            this.panel10.Location = new System.Drawing.Point(8, 173);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(888, 79);
            this.panel10.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.panel6.Controls.Add(this.lblOutStockQty);
            this.panel6.Controls.Add(this.lblOutStock);
            this.panel6.Location = new System.Drawing.Point(680, 9);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(217, 158);
            this.panel6.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.panel3.Controls.Add(this.lblLowStockQty);
            this.panel3.Controls.Add(this.lblLowStock);
            this.panel3.Location = new System.Drawing.Point(231, 9);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(217, 158);
            this.panel3.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.panel7.Controls.Add(this.label6);
            this.panel7.Controls.Add(this.lblOkStock);
            this.panel7.Location = new System.Drawing.Point(457, 9);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(217, 158);
            this.panel7.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.lblTotalItemQty);
            this.panel1.Controls.Add(this.lblTotalItem);
            this.panel1.Location = new System.Drawing.Point(8, 9);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(217, 158);
            this.panel1.TabIndex = 0;
            // 
            // lblTotalItem
            // 
            this.lblTotalItem.AutoSize = true;
            this.lblTotalItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalItem.ForeColor = System.Drawing.Color.Transparent;
            this.lblTotalItem.Location = new System.Drawing.Point(0, 0);
            this.lblTotalItem.Name = "lblTotalItem";
            this.lblTotalItem.Padding = new System.Windows.Forms.Padding(20, 20, 20, 10);
            this.lblTotalItem.Size = new System.Drawing.Size(148, 55);
            this.lblTotalItem.TabIndex = 0;
            this.lblTotalItem.Text = "Total Items";
            // 
            // lblTotalItemQty
            // 
            this.lblTotalItemQty.AutoSize = true;
            this.lblTotalItemQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalItemQty.ForeColor = System.Drawing.Color.Transparent;
            this.lblTotalItemQty.Location = new System.Drawing.Point(20, 55);
            this.lblTotalItemQty.Name = "lblTotalItemQty";
            this.lblTotalItemQty.Size = new System.Drawing.Size(31, 32);
            this.lblTotalItemQty.TabIndex = 1;
            this.lblTotalItemQty.Text = "0";
            // 
            // lblLowStock
            // 
            this.lblLowStock.AutoSize = true;
            this.lblLowStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowStock.ForeColor = System.Drawing.Color.Transparent;
            this.lblLowStock.Location = new System.Drawing.Point(-1, 0);
            this.lblLowStock.Name = "lblLowStock";
            this.lblLowStock.Padding = new System.Windows.Forms.Padding(20, 20, 20, 10);
            this.lblLowStock.Size = new System.Drawing.Size(143, 55);
            this.lblLowStock.TabIndex = 0;
            this.lblLowStock.Text = "Low Stock";
            // 
            // lblLowStockQty
            // 
            this.lblLowStockQty.AutoSize = true;
            this.lblLowStockQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowStockQty.ForeColor = System.Drawing.Color.Transparent;
            this.lblLowStockQty.Location = new System.Drawing.Point(19, 55);
            this.lblLowStockQty.Name = "lblLowStockQty";
            this.lblLowStockQty.Size = new System.Drawing.Size(31, 32);
            this.lblLowStockQty.TabIndex = 1;
            this.lblLowStockQty.Text = "0";
            // 
            // lblOkStock
            // 
            this.lblOkStock.AutoSize = true;
            this.lblOkStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOkStock.ForeColor = System.Drawing.Color.Transparent;
            this.lblOkStock.Location = new System.Drawing.Point(0, 0);
            this.lblOkStock.Name = "lblOkStock";
            this.lblOkStock.Padding = new System.Windows.Forms.Padding(20, 20, 20, 10);
            this.lblOkStock.Size = new System.Drawing.Size(137, 55);
            this.lblOkStock.TabIndex = 0;
            this.lblOkStock.Text = "OK Stock";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(20, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 32);
            this.label6.TabIndex = 1;
            this.label6.Text = "0";
            // 
            // lblOutStock
            // 
            this.lblOutStock.AutoSize = true;
            this.lblOutStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutStock.ForeColor = System.Drawing.Color.Transparent;
            this.lblOutStock.Location = new System.Drawing.Point(-1, 0);
            this.lblOutStock.Name = "lblOutStock";
            this.lblOutStock.Padding = new System.Windows.Forms.Padding(20, 20, 20, 10);
            this.lblOutStock.Size = new System.Drawing.Size(165, 55);
            this.lblOutStock.TabIndex = 0;
            this.lblOutStock.Text = "Out Of Stock";
            // 
            // lblOutStockQty
            // 
            this.lblOutStockQty.AutoSize = true;
            this.lblOutStockQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutStockQty.ForeColor = System.Drawing.Color.Transparent;
            this.lblOutStockQty.Location = new System.Drawing.Point(19, 55);
            this.lblOutStockQty.Name = "lblOutStockQty";
            this.lblOutStockQty.Size = new System.Drawing.Size(31, 32);
            this.lblOutStockQty.TabIndex = 1;
            this.lblOutStockQty.Text = "0";
            // 
            // lblAlertDetails
            // 
            this.lblAlertDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertDetails.ForeColor = System.Drawing.Color.Transparent;
            this.lblAlertDetails.Location = new System.Drawing.Point(0, 0);
            this.lblAlertDetails.Name = "lblAlertDetails";
            this.lblAlertDetails.Size = new System.Drawing.Size(888, 79);
            this.lblAlertDetails.TabIndex = 2;
            this.lblAlertDetails.Text = "Alert details...";
            // 
            // InventoryForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(8)))), ((int)(((byte)(10)))));
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
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
        private System.Windows.Forms.Button btnInventoryRestockItem;
        private System.Windows.Forms.ComboBox cboBoxCategorySearch;
        private System.Windows.Forms.TextBox txtInventorySearch;
        private System.Windows.Forms.ComboBox cboBoxStatus;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblTotalItem;
        private System.Windows.Forms.Label lblOutStockQty;
        private System.Windows.Forms.Label lblOutStock;
        private System.Windows.Forms.Label lblLowStockQty;
        private System.Windows.Forms.Label lblLowStock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblOkStock;
        private System.Windows.Forms.Label lblTotalItemQty;
        private System.Windows.Forms.Label lblAlertDetails;
    }
}