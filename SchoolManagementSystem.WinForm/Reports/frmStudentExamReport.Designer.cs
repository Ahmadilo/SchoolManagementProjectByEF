namespace SchoolManagementSystem.WinForm.Reports
{
    partial class frmStudentExamReport
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.cmbGrads = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkNotSet = new System.Windows.Forms.CheckBox();
            this.cmbSubjectNames = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ucExcelExport1 = new SchoolManagementSystem.WinForm.UserControls.ucExcelExport();
            this.ucShowTable1 = new SchoolManagementSystem.WinForm.ucShowTable();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnApply);
            this.groupBox1.Controls.Add(this.cmbGrads);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chkNotSet);
            this.groupBox1.Controls.Add(this.cmbSubjectNames);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // btnApply
            // 
            this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnApply.Location = new System.Drawing.Point(569, 50);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(65, 36);
            this.btnApply.TabIndex = 5;
            this.btnApply.Text = " Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // cmbGrads
            // 
            this.cmbGrads.FormattingEnabled = true;
            this.cmbGrads.Location = new System.Drawing.Point(513, 19);
            this.cmbGrads.Name = "cmbGrads";
            this.cmbGrads.Size = new System.Drawing.Size(121, 21);
            this.cmbGrads.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(411, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Grads";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkNotSet
            // 
            this.chkNotSet.AutoSize = true;
            this.chkNotSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.chkNotSet.Location = new System.Drawing.Point(244, 58);
            this.chkNotSet.Name = "chkNotSet";
            this.chkNotSet.Size = new System.Drawing.Size(128, 22);
            this.chkNotSet.TabIndex = 2;
            this.chkNotSet.Text = "Incloud Not Set";
            this.chkNotSet.UseVisualStyleBackColor = true;
            // 
            // cmbSubjectNames
            // 
            this.cmbSubjectNames.FormattingEnabled = true;
            this.cmbSubjectNames.Location = new System.Drawing.Point(244, 19);
            this.cmbSubjectNames.Name = "cmbSubjectNames";
            this.cmbSubjectNames.Size = new System.Drawing.Size(121, 21);
            this.cmbSubjectNames.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(117, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Subject Names";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucExcelExport1
            // 
            this.ucExcelExport1.isValidtion = true;
            this.ucExcelExport1.Location = new System.Drawing.Point(12, 118);
            this.ucExcelExport1.Name = "ucExcelExport1";
            this.ucExcelExport1.Size = new System.Drawing.Size(776, 66);
            this.ucExcelExport1.TabIndex = 1;
            this.ucExcelExport1.Visible = false;
            // 
            // ucShowTable1
            // 
            this.ucShowTable1.ColumnsSetting = null;
            this.ucShowTable1.Location = new System.Drawing.Point(12, 190);
            this.ucShowTable1.Name = "ucShowTable1";
            this.ucShowTable1.Size = new System.Drawing.Size(776, 248);
            this.ucShowTable1.TabIndex = 2;
            this.ucShowTable1.TypeRow = null;
            this.ucShowTable1.Visible = false;
            // 
            // frmStudentExamReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ucShowTable1);
            this.Controls.Add(this.ucExcelExport1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmStudentExamReport";
            this.Text = "frmStudentExamReport";
            this.Load += new System.EventHandler(this.frmStudentExamReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkNotSet;
        private System.Windows.Forms.ComboBox cmbSubjectNames;
        private System.Windows.Forms.Label label1;
        private UserControls.ucExcelExport ucExcelExport1;
        private ucShowTable ucShowTable1;
        private System.Windows.Forms.ComboBox cmbGrads;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnApply;
    }
}