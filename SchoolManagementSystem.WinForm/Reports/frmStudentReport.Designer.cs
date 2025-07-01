namespace SchoolManagementSystem.WinForm.Reports
{
    partial class frmStudentReport
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
            this.ucStudentCard1 = new SchoolManagementSystem.WinForm.UserControls.ucStudentCard();
            this.SuspendLayout();
            // 
            // ucStudentCard1
            // 
            this.ucStudentCard1.Location = new System.Drawing.Point(8, 12);
            this.ucStudentCard1.Name = "ucStudentCard1";
            this.ucStudentCard1.Size = new System.Drawing.Size(643, 313);
            this.ucStudentCard1.StudentID = 0;
            this.ucStudentCard1.TabIndex = 0;
            // 
            // frmStudentReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 332);
            this.Controls.Add(this.ucStudentCard1);
            this.Name = "frmStudentReport";
            this.Text = "frmStudentReport";
            this.Load += new System.EventHandler(this.frmStudentReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucStudentCard ucStudentCard1;
    }
}