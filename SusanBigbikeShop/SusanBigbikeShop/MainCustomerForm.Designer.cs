namespace SusanBigbikeShop
{
    partial class MainCustomerForm
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
            this.btnBookingCustomer = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnLogOutOwner = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBookingCustomer
            // 
            this.btnBookingCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBookingCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.btnBookingCustomer.FlatAppearance.BorderSize = 0;
            this.btnBookingCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookingCustomer.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookingCustomer.ForeColor = System.Drawing.Color.White;
            this.btnBookingCustomer.Location = new System.Drawing.Point(7, 31);
            this.btnBookingCustomer.Name = "btnBookingCustomer";
            this.btnBookingCustomer.Size = new System.Drawing.Size(208, 40);
            this.btnBookingCustomer.TabIndex = 5;
            this.btnBookingCustomer.Text = "Booking";
            this.btnBookingCustomer.UseVisualStyleBackColor = false;
            this.btnBookingCustomer.Click += new System.EventHandler(this.btnBookingCustomer_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Impact", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(9, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 22);
            this.label3.TabIndex = 8;
            this.label3.Text = "Operations";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.panel3.Controls.Add(this.btnBookingCustomer);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(5, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(222, 80);
            this.panel3.TabIndex = 25;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.panel4.Controls.Add(this.btnLogOutOwner);
            this.panel4.Location = new System.Drawing.Point(5, 510);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(222, 60);
            this.panel4.TabIndex = 26;
            // 
            // btnLogOutOwner
            // 
            this.btnLogOutOwner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogOutOwner.BackColor = System.Drawing.Color.Red;
            this.btnLogOutOwner.FlatAppearance.BorderSize = 0;
            this.btnLogOutOwner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOutOwner.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOutOwner.ForeColor = System.Drawing.Color.White;
            this.btnLogOutOwner.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogOutOwner.Location = new System.Drawing.Point(7, 10);
            this.btnLogOutOwner.Name = "btnLogOutOwner";
            this.btnLogOutOwner.Size = new System.Drawing.Size(208, 40);
            this.btnLogOutOwner.TabIndex = 15;
            this.btnLogOutOwner.Text = "Log Out";
            this.btnLogOutOwner.UseVisualStyleBackColor = false;
            this.btnLogOutOwner.Click += new System.EventHandler(this.btnLogOutOwner_Click);
            // 
            // MainCustomerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(8)))), ((int)(((byte)(10)))));
            this.ClientSize = new System.Drawing.Size(232, 575);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Name = "MainCustomerForm";
            this.Text = "MainCustomerForm";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBookingCustomer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnLogOutOwner;
    }
}