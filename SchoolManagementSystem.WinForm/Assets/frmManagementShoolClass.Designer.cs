namespace SchoolManagementSystem.WinForm.Assets
{
    partial class frmManagementShoolClass
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
            this.humansTable1 = new SchoolManagementSystem.WinForm.ucShowTable();
            this.ucSaveBar1 = new SchoolManagementSystem.WinForm.UserControls.ucSaveBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGradeLevel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAcademicYear = new System.Windows.Forms.TextBox();
            this.btnSelectTeacher = new System.Windows.Forms.Button();
            this.lblTeacherID = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // humansTable1
            // 
            this.humansTable1.Location = new System.Drawing.Point(19, 239);
            this.humansTable1.Name = "humansTable1";
            this.humansTable1.Size = new System.Drawing.Size(762, 199);
            this.humansTable1.TabIndex = 0;
            // 
            // ucSaveBar1
            // 
            this.ucSaveBar1.Location = new System.Drawing.Point(19, 167);
            this.ucSaveBar1.Name = "ucSaveBar1";
            this.ucSaveBar1.Size = new System.Drawing.Size(762, 66);
            this.ucSaveBar1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTeacherID);
            this.groupBox1.Controls.Add(this.btnSelectTeacher);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtAcademicYear);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtGradeLevel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtClassName);
            this.groupBox1.Location = new System.Drawing.Point(19, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(762, 156);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Class Form";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(31, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Class Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(137, 34);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(100, 20);
            this.txtClassName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(31, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Grade Level";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtGradeLevel
            // 
            this.txtGradeLevel.Location = new System.Drawing.Point(137, 78);
            this.txtGradeLevel.Name = "txtGradeLevel";
            this.txtGradeLevel.Size = new System.Drawing.Size(100, 20);
            this.txtGradeLevel.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(275, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Academic Year";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAcademicYear
            // 
            this.txtAcademicYear.Location = new System.Drawing.Point(397, 36);
            this.txtAcademicYear.Name = "txtAcademicYear";
            this.txtAcademicYear.Size = new System.Drawing.Size(100, 20);
            this.txtAcademicYear.TabIndex = 8;
            // 
            // btnSelectTeacher
            // 
            this.btnSelectTeacher.Location = new System.Drawing.Point(397, 78);
            this.btnSelectTeacher.Name = "btnSelectTeacher";
            this.btnSelectTeacher.Size = new System.Drawing.Size(100, 23);
            this.btnSelectTeacher.TabIndex = 12;
            this.btnSelectTeacher.Text = "Select Teacher";
            this.btnSelectTeacher.UseVisualStyleBackColor = true;
            // 
            // lblTeacherID
            // 
            this.lblTeacherID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblTeacherID.Location = new System.Drawing.Point(243, 76);
            this.lblTeacherID.Name = "lblTeacherID";
            this.lblTeacherID.Size = new System.Drawing.Size(148, 20);
            this.lblTeacherID.TabIndex = 14;
            this.lblTeacherID.Text = "TeacherID";
            this.lblTeacherID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmManagementShoolClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ucSaveBar1);
            this.Controls.Add(this.humansTable1);
            this.Name = "frmManagementShoolClass";
            this.Text = "frmManagementShoolClass";
            this.Load += new System.EventHandler(this.frmManagementShoolClass_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ucShowTable humansTable1;
        private UserControls.ucSaveBar ucSaveBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGradeLevel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAcademicYear;
        private System.Windows.Forms.Label lblTeacherID;
        private System.Windows.Forms.Button btnSelectTeacher;
    }
}