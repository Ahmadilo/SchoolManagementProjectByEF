namespace SchoolManagementSystem.WinForm.Reports
{
    partial class frmClassCard
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
            this.ucClassCard1 = new SchoolManagementSystem.WinForm.UserControls.ucClassCard();
            this.SuspendLayout();
            // 
            // ucClassCard1
            // 
            this.ucClassCard1.ClassID = -1;
            this.ucClassCard1.Location = new System.Drawing.Point(12, 12);
            this.ucClassCard1.Name = "ucClassCard1";
            this.ucClassCard1.Size = new System.Drawing.Size(532, 179);
            this.ucClassCard1.TabIndex = 0;
            // 
            // frmClassCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 211);
            this.Controls.Add(this.ucClassCard1);
            this.Name = "frmClassCard";
            this.Text = "frmClassCard";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucClassCard ucClassCard1;
    }
}