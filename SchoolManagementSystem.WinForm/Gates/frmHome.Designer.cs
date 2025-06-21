namespace SchoolManagementSystem.WinForm.Gates
{
    partial class frmHome
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
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnMangeUser = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPersonForm = new System.Windows.Forms.Button();
            this.btnStudentForm = new System.Windows.Forms.Button();
            this.btnStaffForm = new System.Windows.Forms.Button();
            this.btnTeacherForm = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSubjectForm = new System.Windows.Forms.Button();
            this.btnClassForm = new System.Windows.Forms.Button();
            this.lblUserLogin = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(713, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnMangeUser
            // 
            this.btnMangeUser.Location = new System.Drawing.Point(68, 19);
            this.btnMangeUser.Name = "btnMangeUser";
            this.btnMangeUser.Size = new System.Drawing.Size(75, 23);
            this.btnMangeUser.TabIndex = 1;
            this.btnMangeUser.Text = "User Form";
            this.btnMangeUser.UseVisualStyleBackColor = true;
            this.btnMangeUser.Click += new System.EventHandler(this.btnMangeUser_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTeacherForm);
            this.groupBox1.Controls.Add(this.btnStaffForm);
            this.groupBox1.Controls.Add(this.btnStudentForm);
            this.groupBox1.Controls.Add(this.btnPersonForm);
            this.groupBox1.Controls.Add(this.btnMangeUser);
            this.groupBox1.Location = new System.Drawing.Point(64, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(673, 54);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Persons";
            // 
            // btnPersonForm
            // 
            this.btnPersonForm.Location = new System.Drawing.Point(180, 19);
            this.btnPersonForm.Name = "btnPersonForm";
            this.btnPersonForm.Size = new System.Drawing.Size(75, 23);
            this.btnPersonForm.TabIndex = 2;
            this.btnPersonForm.Text = "Person Form";
            this.btnPersonForm.UseVisualStyleBackColor = true;
            this.btnPersonForm.Click += new System.EventHandler(this.btnPersonForm_Click);
            // 
            // btnStudentForm
            // 
            this.btnStudentForm.Location = new System.Drawing.Point(292, 19);
            this.btnStudentForm.Name = "btnStudentForm";
            this.btnStudentForm.Size = new System.Drawing.Size(82, 23);
            this.btnStudentForm.TabIndex = 3;
            this.btnStudentForm.Text = "Student Form";
            this.btnStudentForm.UseVisualStyleBackColor = true;
            this.btnStudentForm.Click += new System.EventHandler(this.btnStudentForm_Click);
            // 
            // btnStaffForm
            // 
            this.btnStaffForm.Location = new System.Drawing.Point(411, 19);
            this.btnStaffForm.Name = "btnStaffForm";
            this.btnStaffForm.Size = new System.Drawing.Size(75, 23);
            this.btnStaffForm.TabIndex = 4;
            this.btnStaffForm.Text = "Staff Form";
            this.btnStaffForm.UseVisualStyleBackColor = true;
            this.btnStaffForm.Click += new System.EventHandler(this.btnStaffForm_Click);
            // 
            // btnTeacherForm
            // 
            this.btnTeacherForm.Location = new System.Drawing.Point(523, 19);
            this.btnTeacherForm.Name = "btnTeacherForm";
            this.btnTeacherForm.Size = new System.Drawing.Size(81, 23);
            this.btnTeacherForm.TabIndex = 5;
            this.btnTeacherForm.Text = "Teacher Form";
            this.btnTeacherForm.UseVisualStyleBackColor = true;
            this.btnTeacherForm.Click += new System.EventHandler(this.btnTeacherForm_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClassForm);
            this.groupBox2.Controls.Add(this.btnSubjectForm);
            this.groupBox2.Location = new System.Drawing.Point(244, 229);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 54);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Assets";
            // 
            // btnSubjectForm
            // 
            this.btnSubjectForm.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSubjectForm.Location = new System.Drawing.Point(34, 19);
            this.btnSubjectForm.Name = "btnSubjectForm";
            this.btnSubjectForm.Size = new System.Drawing.Size(75, 23);
            this.btnSubjectForm.TabIndex = 6;
            this.btnSubjectForm.Text = "Subjet Form";
            this.btnSubjectForm.UseVisualStyleBackColor = true;
            this.btnSubjectForm.Click += new System.EventHandler(this.btnSubjectForm_Click);
            // 
            // btnClassForm
            // 
            this.btnClassForm.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnClassForm.Location = new System.Drawing.Point(190, 19);
            this.btnClassForm.Name = "btnClassForm";
            this.btnClassForm.Size = new System.Drawing.Size(75, 23);
            this.btnClassForm.TabIndex = 7;
            this.btnClassForm.Text = "Class Form";
            this.btnClassForm.UseVisualStyleBackColor = true;
            this.btnClassForm.Click += new System.EventHandler(this.btnClassForm_Click);
            // 
            // lblUserLogin
            // 
            this.lblUserLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblUserLogin.Location = new System.Drawing.Point(528, 12);
            this.lblUserLogin.Name = "lblUserLogin";
            this.lblUserLogin.Size = new System.Drawing.Size(179, 23);
            this.lblUserLogin.TabIndex = 4;
            this.lblUserLogin.Text = "label1";
            this.lblUserLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblUserLogin);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLogout);
            this.Name = "frmHome";
            this.Text = "frmHome";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnMangeUser;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTeacherForm;
        private System.Windows.Forms.Button btnStaffForm;
        private System.Windows.Forms.Button btnStudentForm;
        private System.Windows.Forms.Button btnPersonForm;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnClassForm;
        private System.Windows.Forms.Button btnSubjectForm;
        private System.Windows.Forms.Label lblUserLogin;
    }
}