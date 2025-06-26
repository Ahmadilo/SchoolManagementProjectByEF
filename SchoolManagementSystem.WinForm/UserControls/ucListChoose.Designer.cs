namespace SchoolManagementSystem.WinForm.UserControls
{
    partial class ucListChoose
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.pctIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lblTitle.Location = new System.Drawing.Point(64, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(196, 57);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Click += new System.EventHandler(this.conClick);
            this.lblTitle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseClick);
            // 
            // pctIcon
            // 
            this.pctIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.pctIcon.Location = new System.Drawing.Point(0, 0);
            this.pctIcon.Name = "pctIcon";
            this.pctIcon.Size = new System.Drawing.Size(58, 57);
            this.pctIcon.TabIndex = 1;
            this.pctIcon.TabStop = false;
            this.pctIcon.Click += new System.EventHandler(this.conClick);
            this.pctIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseClick);
            // 
            // ucListChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Controls.Add(this.pctIcon);
            this.Controls.Add(this.lblTitle);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ucListChoose";
            this.Size = new System.Drawing.Size(260, 57);
            ((System.ComponentModel.ISupportInitialize)(this.pctIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pctIcon;
    }
}
