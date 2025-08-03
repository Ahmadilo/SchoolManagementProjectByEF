namespace SchoolManagementSystem.WinForm.Reports
{
    partial class frmStudentsMarksReportForSelectedSubject
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbClasses = new System.Windows.Forms.ComboBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbSubjects = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClean = new System.Windows.Forms.Button();
            this.ucExcelExport1 = new SchoolManagementSystem.WinForm.UserControls.ucExcelExport();
            this.ucShowTable1 = new SchoolManagementSystem.WinForm.ucShowTable();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbSubjects);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbClasses);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter Bar";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClean);
            this.groupBox2.Controls.Add(this.lblStatus);
            this.groupBox2.Controls.Add(this.btnApply);
            this.groupBox2.Location = new System.Drawing.Point(284, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(504, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Active Bar";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ucShowTable1);
            this.groupBox3.Location = new System.Drawing.Point(12, 181);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(776, 257);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Show Table";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(19, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Classes";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbClasses
            // 
            this.cmbClasses.FormattingEnabled = true;
            this.cmbClasses.Location = new System.Drawing.Point(125, 55);
            this.cmbClasses.Name = "cmbClasses";
            this.cmbClasses.Size = new System.Drawing.Size(121, 21);
            this.cmbClasses.TabIndex = 1;
            this.cmbClasses.SelectedIndexChanged += new System.EventHandler(this.cmbClasses_SelectedIndexChanged);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(423, 39);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 0;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblStatus.Location = new System.Drawing.Point(6, 40);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(246, 21);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status: ";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbSubjects
            // 
            this.cmbSubjects.Enabled = false;
            this.cmbSubjects.FormattingEnabled = true;
            this.cmbSubjects.Location = new System.Drawing.Point(125, 29);
            this.cmbSubjects.Name = "cmbSubjects";
            this.cmbSubjects.Size = new System.Drawing.Size(121, 21);
            this.cmbSubjects.TabIndex = 3;
            this.cmbSubjects.SelectedIndexChanged += new System.EventHandler(this.cmbSubjects_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(19, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Subjects";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClean
            // 
            this.btnClean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClean.Enabled = false;
            this.btnClean.Location = new System.Drawing.Point(340, 39);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(75, 23);
            this.btnClean.TabIndex = 3;
            this.btnClean.Text = "Clean";
            this.btnClean.UseVisualStyleBackColor = true;
            // 
            // ucExcelExport1
            // 
            this.ucExcelExport1.isValidtion = true;
            this.ucExcelExport1.Location = new System.Drawing.Point(12, 118);
            this.ucExcelExport1.Name = "ucExcelExport1";
            this.ucExcelExport1.Size = new System.Drawing.Size(776, 57);
            this.ucExcelExport1.TabIndex = 3;
            // 
            // ucShowTable1
            // 
            this.ucShowTable1.ColumnsSetting = null;
            this.ucShowTable1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucShowTable1.Location = new System.Drawing.Point(3, 16);
            this.ucShowTable1.Name = "ucShowTable1";
            this.ucShowTable1.Size = new System.Drawing.Size(770, 238);
            this.ucShowTable1.TabIndex = 0;
            this.ucShowTable1.TypeRow = null;
            // 
            // frmStudentsMarksReportForSelectedSubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ucExcelExport1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmStudentsMarksReportForSelectedSubject";
            this.Text = "frmStudentsMarksReportForSelectedSubject";
            this.Load += new System.EventHandler(this.frmStudentsMarksReportForSelectedSubject_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbClasses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.GroupBox groupBox3;
        private ucShowTable ucShowTable1;
        private System.Windows.Forms.ComboBox cmbSubjects;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Label lblStatus;
        private UserControls.ucExcelExport ucExcelExport1;
    }
}