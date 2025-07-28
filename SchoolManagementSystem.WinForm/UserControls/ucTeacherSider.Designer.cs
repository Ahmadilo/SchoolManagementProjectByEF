namespace SchoolManagementSystem.WinForm.UserControls
{
    partial class ucTeacherSider
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
            this.tblTeacherList = new System.Windows.Forms.TableLayoutPanel();
            this.ucListChoose4 = new SchoolManagementSystem.WinForm.UserControls.ucListChoose();
            this.ucListChoose3 = new SchoolManagementSystem.WinForm.UserControls.ucListChoose();
            this.ucListChoose2 = new SchoolManagementSystem.WinForm.UserControls.ucListChoose();
            this.ucClassChoose = new SchoolManagementSystem.WinForm.UserControls.ucListChoose();
            this.tblTeacherList.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblTeacherList
            // 
            this.tblTeacherList.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tblTeacherList.ColumnCount = 1;
            this.tblTeacherList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblTeacherList.Controls.Add(this.ucListChoose4, 0, 3);
            this.tblTeacherList.Controls.Add(this.ucListChoose3, 0, 2);
            this.tblTeacherList.Controls.Add(this.ucListChoose2, 0, 1);
            this.tblTeacherList.Controls.Add(this.ucClassChoose, 0, 0);
            this.tblTeacherList.Location = new System.Drawing.Point(0, 0);
            this.tblTeacherList.Name = "tblTeacherList";
            this.tblTeacherList.RowCount = 5;
            this.tblTeacherList.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblTeacherList.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblTeacherList.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblTeacherList.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblTeacherList.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblTeacherList.Size = new System.Drawing.Size(300, 559);
            this.tblTeacherList.TabIndex = 1;
            // 
            // ucListChoose4
            // 
            this.ucListChoose4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucListChoose4.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ucListChoose4.Location = new System.Drawing.Point(3, 192);
            this.ucListChoose4.Name = "ucListChoose4";
            this.ucListChoose4.Size = new System.Drawing.Size(294, 57);
            this.ucListChoose4.TabIndex = 3;
            // 
            // ucListChoose3
            // 
            this.ucListChoose3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucListChoose3.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ucListChoose3.Location = new System.Drawing.Point(3, 129);
            this.ucListChoose3.Name = "ucListChoose3";
            this.ucListChoose3.Size = new System.Drawing.Size(294, 57);
            this.ucListChoose3.TabIndex = 2;
            // 
            // ucListChoose2
            // 
            this.ucListChoose2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucListChoose2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ucListChoose2.Location = new System.Drawing.Point(3, 66);
            this.ucListChoose2.Name = "ucListChoose2";
            this.ucListChoose2.Size = new System.Drawing.Size(294, 57);
            this.ucListChoose2.TabIndex = 1;
            // 
            // ucClassChoose
            // 
            this.ucClassChoose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucClassChoose.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ucClassChoose.Location = new System.Drawing.Point(3, 3);
            this.ucClassChoose.Name = "ucClassChoose";
            this.ucClassChoose.Size = new System.Drawing.Size(294, 57);
            this.ucClassChoose.TabIndex = 0;
            // 
            // ucTeacherSider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tblTeacherList);
            this.Name = "ucTeacherSider";
            this.Size = new System.Drawing.Size(300, 559);
            this.tblTeacherList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblTeacherList;
        private ucListChoose ucListChoose4;
        private ucListChoose ucListChoose3;
        private ucListChoose ucListChoose2;
        private ucListChoose ucClassChoose;
    }
}
