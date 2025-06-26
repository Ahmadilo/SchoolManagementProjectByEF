namespace SchoolManagementSystem.WinForm.Apps
{
    partial class frmAddStudentToClass
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
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ucSaveBar1 = new SchoolManagementSystem.WinForm.UserControls.ucSaveBar();
            this.humansTable2 = new SchoolManagementSystem.WinForm.HumansTable();
            this.humansTable1 = new SchoolManagementSystem.WinForm.HumansTable();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtClassName);
            this.groupBox1.Controls.Add(this.txtStudentName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(772, 118);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Student Class Form";
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(551, 58);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(139, 20);
            this.txtClassName.TabIndex = 4;
            // 
            // txtStudentName
            // 
            this.txtStudentName.Location = new System.Drawing.Point(243, 59);
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.Size = new System.Drawing.Size(139, 20);
            this.txtStudentName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(424, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Class Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(115, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucSaveBar1
            // 
            this.ucSaveBar1.Location = new System.Drawing.Point(14, 143);
            this.ucSaveBar1.Name = "ucSaveBar1";
            this.ucSaveBar1.Size = new System.Drawing.Size(772, 66);
            this.ucSaveBar1.TabIndex = 2;
            this.ucSaveBar1.SaveChange += new System.EventHandler(this.SaveClick);
            this.ucSaveBar1.ClearInputsChange += new System.EventHandler(this.ClearClick);
            // 
            // humansTable2
            // 
            this.humansTable2.Location = new System.Drawing.Point(404, 217);
            this.humansTable2.Name = "humansTable2";
            this.humansTable2.Size = new System.Drawing.Size(382, 227);
            this.humansTable2.TabIndex = 1;
            this.humansTable2.EditClicked += new System.EventHandler<int>(this.ClassEditClick);
            // 
            // humansTable1
            // 
            this.humansTable1.Location = new System.Drawing.Point(14, 217);
            this.humansTable1.Name = "humansTable1";
            this.humansTable1.Size = new System.Drawing.Size(382, 227);
            this.humansTable1.TabIndex = 0;
            this.humansTable1.EditClicked += new System.EventHandler<int>(this.StudentEditClick);
            // 
            // frmAddStudentToClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ucSaveBar1);
            this.Controls.Add(this.humansTable2);
            this.Controls.Add(this.humansTable1);
            this.Name = "frmAddStudentToClass";
            this.Text = "frmAddStudentToClass";
            this.Load += new System.EventHandler(this.frmAddStudentToClass_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private HumansTable humansTable1;
        private HumansTable humansTable2;
        private UserControls.ucSaveBar ucSaveBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.TextBox txtStudentName;
    }
}