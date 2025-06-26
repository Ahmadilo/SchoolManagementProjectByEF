namespace SchoolManagementSystem.WinForm.Apps
{
    partial class frmAddSubjectToClass
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
            this.SubjectsTable = new SchoolManagementSystem.WinForm.HumansTable();
            this.ClassesTable = new SchoolManagementSystem.WinForm.HumansTable();
            this.ucSaveBar1 = new SchoolManagementSystem.WinForm.UserControls.ucSaveBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbDays = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mskEndTime = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mskStartTime = new System.Windows.Forms.MaskedTextBox();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSubjectName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SubjectsTable
            // 
            this.SubjectsTable.Location = new System.Drawing.Point(12, 259);
            this.SubjectsTable.Name = "SubjectsTable";
            this.SubjectsTable.Size = new System.Drawing.Size(382, 227);
            this.SubjectsTable.TabIndex = 1;
            this.SubjectsTable.EditClicked += new System.EventHandler<int>(this.SubjectTableEditClick);
            // 
            // ClassesTable
            // 
            this.ClassesTable.Location = new System.Drawing.Point(406, 259);
            this.ClassesTable.Name = "ClassesTable";
            this.ClassesTable.Size = new System.Drawing.Size(382, 227);
            this.ClassesTable.TabIndex = 2;
            this.ClassesTable.EditClicked += new System.EventHandler<int>(this.ClassTableEditClick);
            // 
            // ucSaveBar1
            // 
            this.ucSaveBar1.Location = new System.Drawing.Point(12, 187);
            this.ucSaveBar1.Name = "ucSaveBar1";
            this.ucSaveBar1.Size = new System.Drawing.Size(776, 66);
            this.ucSaveBar1.TabIndex = 3;
            this.ucSaveBar1.SaveChange += new System.EventHandler(this.SaveClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbDays);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.mskEndTime);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.mskStartTime);
            this.groupBox1.Controls.Add(this.txtClassName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSubjectName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 169);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Form Add Subject To Class";
            // 
            // cmbDays
            // 
            this.cmbDays.FormattingEnabled = true;
            this.cmbDays.Location = new System.Drawing.Point(382, 34);
            this.cmbDays.Name = "cmbDays";
            this.cmbDays.Size = new System.Drawing.Size(139, 21);
            this.cmbDays.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label5.Location = new System.Drawing.Point(255, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 21);
            this.label5.TabIndex = 12;
            this.label5.Text = "Day";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mskEndTime
            // 
            this.mskEndTime.Location = new System.Drawing.Point(566, 115);
            this.mskEndTime.Mask = "00:00";
            this.mskEndTime.Name = "mskEndTime";
            this.mskEndTime.Size = new System.Drawing.Size(139, 20);
            this.mskEndTime.TabIndex = 11;
            this.mskEndTime.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label4.Location = new System.Drawing.Point(438, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "EndTime";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(72, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "Start Time";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mskStartTime
            // 
            this.mskStartTime.Location = new System.Drawing.Point(200, 117);
            this.mskStartTime.Mask = "00:00";
            this.mskStartTime.Name = "mskStartTime";
            this.mskStartTime.Size = new System.Drawing.Size(139, 20);
            this.mskStartTime.TabIndex = 8;
            this.mskStartTime.ValidatingType = typeof(System.DateTime);
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(566, 75);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(139, 20);
            this.txtClassName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(438, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "Class Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSubjectName
            // 
            this.txtSubjectName.Location = new System.Drawing.Point(200, 74);
            this.txtSubjectName.Name = "txtSubjectName";
            this.txtSubjectName.Size = new System.Drawing.Size(139, 20);
            this.txtSubjectName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(72, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Subject Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmAddSubjectToClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 498);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ucSaveBar1);
            this.Controls.Add(this.ClassesTable);
            this.Controls.Add(this.SubjectsTable);
            this.Name = "frmAddSubjectToClass";
            this.Text = "frmAddSubjectToClass";
            this.Load += new System.EventHandler(this.frmAddSubjectToClass_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private HumansTable SubjectsTable;
        private HumansTable ClassesTable;
        private UserControls.ucSaveBar ucSaveBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSubjectName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mskEndTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox mskStartTime;
        private System.Windows.Forms.ComboBox cmbDays;
        private System.Windows.Forms.Label label5;
    }
}