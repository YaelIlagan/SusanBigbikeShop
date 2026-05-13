namespace SusanBigbikeShop
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.PnlLogo = new System.Windows.Forms.Panel();
            this.PnlNavBar = new System.Windows.Forms.Panel();
            this.PnlRightPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // PnlLogo
            // 
            this.PnlLogo.BackColor = System.Drawing.Color.Black;
            this.PnlLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PnlLogo.BackgroundImage")));
            this.PnlLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PnlLogo.Location = new System.Drawing.Point(12, 12);
            this.PnlLogo.Name = "PnlLogo";
            this.PnlLogo.Size = new System.Drawing.Size(250, 100);
            this.PnlLogo.TabIndex = 0;
            // 
            // PnlNavBar
            // 
            this.PnlNavBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PnlNavBar.BackColor = System.Drawing.Color.Black;
            this.PnlNavBar.Location = new System.Drawing.Point(12, 119);
            this.PnlNavBar.Name = "PnlNavBar";
            this.PnlNavBar.Size = new System.Drawing.Size(250, 622);
            this.PnlNavBar.TabIndex = 1;
            // 
            // PnlRightPanel
            // 
            this.PnlRightPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlRightPanel.BackColor = System.Drawing.Color.Black;
            this.PnlRightPanel.Location = new System.Drawing.Point(268, 12);
            this.PnlRightPanel.Name = "PnlRightPanel";
            this.PnlRightPanel.Size = new System.Drawing.Size(982, 729);
            this.PnlRightPanel.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1262, 753);
            this.Controls.Add(this.PnlRightPanel);
            this.Controls.Add(this.PnlNavBar);
            this.Controls.Add(this.PnlLogo);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlLogo;
        private System.Windows.Forms.Panel PnlNavBar;
        private System.Windows.Forms.Panel PnlRightPanel;
    }
}