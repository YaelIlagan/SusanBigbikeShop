namespace SusanBigbikeShop
{
    partial class RestockItemForm
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
            this.pnlrestockbg = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pnlitemdata = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMinimunStockThreshold = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddQuantity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboxCategory = new System.Windows.Forms.ComboBox();
            this.txtCurrentStock = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlrestockbg.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlitemdata.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlrestockbg
            // 
            this.pnlrestockbg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(12)))), ((int)(((byte)(16)))));
            this.pnlrestockbg.Controls.Add(this.panel4);
            this.pnlrestockbg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlrestockbg.Location = new System.Drawing.Point(0, 0);
            this.pnlrestockbg.Margin = new System.Windows.Forms.Padding(4);
            this.pnlrestockbg.Name = "pnlrestockbg";
            this.pnlrestockbg.Padding = new System.Windows.Forms.Padding(5);
            this.pnlrestockbg.Size = new System.Drawing.Size(472, 646);
            this.pnlrestockbg.TabIndex = 9;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.panel4.Controls.Add(this.pnlitemdata);
            this.panel4.Location = new System.Drawing.Point(13, 13);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(5);
            this.panel4.Size = new System.Drawing.Size(446, 624);
            this.panel4.TabIndex = 6;
            // 
            // pnlitemdata
            // 
            this.pnlitemdata.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(232)))), ((int)(((byte)(234)))));
            this.pnlitemdata.Controls.Add(this.btnCancel);
            this.pnlitemdata.Controls.Add(this.btnSave);
            this.pnlitemdata.Controls.Add(this.label6);
            this.pnlitemdata.Controls.Add(this.txtMinimunStockThreshold);
            this.pnlitemdata.Controls.Add(this.label5);
            this.pnlitemdata.Controls.Add(this.txtAddQuantity);
            this.pnlitemdata.Controls.Add(this.label4);
            this.pnlitemdata.Controls.Add(this.cboxCategory);
            this.pnlitemdata.Controls.Add(this.txtCurrentStock);
            this.pnlitemdata.Controls.Add(this.label3);
            this.pnlitemdata.Controls.Add(this.label2);
            this.pnlitemdata.Controls.Add(this.txtProductName);
            this.pnlitemdata.Controls.Add(this.label14);
            this.pnlitemdata.Controls.Add(this.label9);
            this.pnlitemdata.Controls.Add(this.label1);
            this.pnlitemdata.Location = new System.Drawing.Point(10, 9);
            this.pnlitemdata.Margin = new System.Windows.Forms.Padding(4);
            this.pnlitemdata.Name = "pnlitemdata";
            this.pnlitemdata.Padding = new System.Windows.Forms.Padding(5);
            this.pnlitemdata.Size = new System.Drawing.Size(427, 606);
            this.pnlitemdata.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Tomato;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Impact", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(220, 535);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(190, 48);
            this.btnCancel.TabIndex = 51;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Impact", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(18, 535);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(190, 48);
            this.btnSave.TabIndex = 50;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(16)))), ((int)(((byte)(22)))));
            this.label6.Location = new System.Drawing.Point(9, 515);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(409, 2);
            this.label6.TabIndex = 49;
            // 
            // txtMinimunStockThreshold
            // 
            this.txtMinimunStockThreshold.BackColor = System.Drawing.Color.White;
            this.txtMinimunStockThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinimunStockThreshold.Location = new System.Drawing.Point(9, 462);
            this.txtMinimunStockThreshold.Margin = new System.Windows.Forms.Padding(4);
            this.txtMinimunStockThreshold.Name = "txtMinimunStockThreshold";
            this.txtMinimunStockThreshold.Size = new System.Drawing.Size(409, 38);
            this.txtMinimunStockThreshold.TabIndex = 47;
            this.txtMinimunStockThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMinimunStockThreshold_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bernard MT Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(7, 429);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(305, 36);
            this.label5.TabIndex = 48;
            this.label5.Text = "Minimun Stock Threshold";
            // 
            // txtAddQuantity
            // 
            this.txtAddQuantity.BackColor = System.Drawing.Color.White;
            this.txtAddQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddQuantity.Location = new System.Drawing.Point(9, 376);
            this.txtAddQuantity.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddQuantity.Name = "txtAddQuantity";
            this.txtAddQuantity.Size = new System.Drawing.Size(409, 38);
            this.txtAddQuantity.TabIndex = 45;
            this.txtAddQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAddQuantity_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bernard MT Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(7, 343);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 36);
            this.label4.TabIndex = 46;
            this.label4.Text = "Add Quantity";
            // 
            // cboxCategory
            // 
            this.cboxCategory.BackColor = System.Drawing.Color.White;
            this.cboxCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxCategory.FormattingEnabled = true;
            this.cboxCategory.Location = new System.Drawing.Point(9, 199);
            this.cboxCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cboxCategory.Name = "cboxCategory";
            this.cboxCategory.Size = new System.Drawing.Size(409, 39);
            this.cboxCategory.TabIndex = 44;
            // 
            // txtCurrentStock
            // 
            this.txtCurrentStock.BackColor = System.Drawing.Color.White;
            this.txtCurrentStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentStock.Location = new System.Drawing.Point(9, 289);
            this.txtCurrentStock.Margin = new System.Windows.Forms.Padding(4);
            this.txtCurrentStock.Name = "txtCurrentStock";
            this.txtCurrentStock.Size = new System.Drawing.Size(409, 38);
            this.txtCurrentStock.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bernard MT Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(7, 256);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 36);
            this.label3.TabIndex = 23;
            this.label3.Text = "Current Stock";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bernard MT Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(7, 166);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 36);
            this.label2.TabIndex = 21;
            this.label2.Text = "Category";
            // 
            // txtProductName
            // 
            this.txtProductName.BackColor = System.Drawing.Color.White;
            this.txtProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.Location = new System.Drawing.Point(9, 116);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(4);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(409, 38);
            this.txtProductName.TabIndex = 18;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Bernard MT Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(7, 83);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(176, 36);
            this.label14.TabIndex = 19;
            this.label14.Text = "Product Name";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(16)))), ((int)(((byte)(22)))));
            this.label9.Location = new System.Drawing.Point(9, 70);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(409, 2);
            this.label9.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(16)))), ((int)(((byte)(22)))));
            this.label1.Font = new System.Drawing.Font("Impact", 16.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(409, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "RESTOCK ITEM";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RestockItemForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(472, 646);
            this.Controls.Add(this.pnlrestockbg);
            this.Name = "RestockItemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RestockItemForm";
            this.pnlrestockbg.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.pnlitemdata.ResumeLayout(false);
            this.pnlitemdata.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlrestockbg;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel pnlitemdata;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCurrentStock;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtMinimunStockThreshold;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAddQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboxCategory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}