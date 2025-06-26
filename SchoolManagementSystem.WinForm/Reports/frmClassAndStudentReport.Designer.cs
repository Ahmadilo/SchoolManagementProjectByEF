namespace SchoolManagementSystem.WinForm.Reports
{
    partial class frmClassAndStudentReport
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
            this.btnClear = new System.Windows.Forms.Button();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.StudentTable = new SchoolManagementSystem.WinForm.HumansTable();
            this.ClassTable = new SchoolManagementSystem.WinForm.HumansTable();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ClassTable);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 169);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Class Table";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.StudentTable);
            this.groupBox2.Location = new System.Drawing.Point(12, 264);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 174);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Student Table";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnClear);
            this.groupBox3.Controls.Add(this.txtClassName);
            this.groupBox3.Controls.Add(this.txtStudentName);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(12, 187);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(776, 71);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data Selecter";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(630, 28);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(77, 20);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(450, 27);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(139, 20);
            this.txtClassName.TabIndex = 8;
            // 
            // txtStudentName
            // 
            this.txtStudentName.Location = new System.Drawing.Point(142, 28);
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.Size = new System.Drawing.Size(139, 20);
            this.txtStudentName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(323, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "Class Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(14, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "Student Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // StudentTable
            // 
            this.StudentTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StudentTable.Location = new System.Drawing.Point(3, 16);
            this.StudentTable.Name = "StudentTable";
            this.StudentTable.Size = new System.Drawing.Size(770, 155);
            this.StudentTable.TabIndex = 0;
            this.StudentTable.EditClicked += new System.EventHandler<int>(this.StudentEditClick);
            // 
            // ClassTable
            // 
            this.ClassTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClassTable.Location = new System.Drawing.Point(3, 16);
            this.ClassTable.Name = "ClassTable";
            this.ClassTable.Size = new System.Drawing.Size(770, 150);
            this.ClassTable.TabIndex = 0;
            this.ClassTable.EditClicked += new System.EventHandler<int>(this.ClassEditClick);
            // 
            // frmClassAndStudentReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmClassAndStudentReport";
            this.Text = "frmClassAndStudentReport";
            this.Load += new System.EventHandler(this.frmClassAndStudentReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private HumansTable ClassTable;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private HumansTable StudentTable;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}