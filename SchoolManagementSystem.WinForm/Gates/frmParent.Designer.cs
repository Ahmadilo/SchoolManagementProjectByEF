namespace SchoolManagementSystem.WinForm.Gates
{
    partial class frmParent
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.personsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.staffsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teachersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applcationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addStudentToClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSubjectToClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentExamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentsRepoeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classesRepportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentExamsReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attendacesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentAttendaceRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.personsToolStripMenuItem,
            this.assetsToolStripMenuItem,
            this.applcationsToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // personsToolStripMenuItem
            // 
            this.personsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersToolStripMenuItem,
            this.personsToolStripMenuItem1,
            this.staffsToolStripMenuItem,
            this.studentsToolStripMenuItem,
            this.teachersToolStripMenuItem});
            this.personsToolStripMenuItem.Name = "personsToolStripMenuItem";
            this.personsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.personsToolStripMenuItem.Text = " Pe&ople";
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.usersToolStripMenuItem.Text = "&Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // personsToolStripMenuItem1
            // 
            this.personsToolStripMenuItem1.Name = "personsToolStripMenuItem1";
            this.personsToolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
            this.personsToolStripMenuItem1.Text = "&Persons";
            this.personsToolStripMenuItem1.Click += new System.EventHandler(this.personsToolStripMenuItem1_Click);
            // 
            // staffsToolStripMenuItem
            // 
            this.staffsToolStripMenuItem.Name = "staffsToolStripMenuItem";
            this.staffsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.staffsToolStripMenuItem.Text = " &Staff";
            this.staffsToolStripMenuItem.Click += new System.EventHandler(this.staffsToolStripMenuItem_Click);
            // 
            // studentsToolStripMenuItem
            // 
            this.studentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentDetailsToolStripMenuItem});
            this.studentsToolStripMenuItem.Name = "studentsToolStripMenuItem";
            this.studentsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.studentsToolStripMenuItem.Text = " S&tudents";
            this.studentsToolStripMenuItem.Click += new System.EventHandler(this.studentsToolStripMenuItem_Click);
            // 
            // studentDetailsToolStripMenuItem
            // 
            this.studentDetailsToolStripMenuItem.Name = "studentDetailsToolStripMenuItem";
            this.studentDetailsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.studentDetailsToolStripMenuItem.Text = "Student&Details";
            this.studentDetailsToolStripMenuItem.Click += new System.EventHandler(this.studentDetailsToolStripMenuItem_Click);
            // 
            // teachersToolStripMenuItem
            // 
            this.teachersToolStripMenuItem.Name = "teachersToolStripMenuItem";
            this.teachersToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.teachersToolStripMenuItem.Text = " T&eacher";
            this.teachersToolStripMenuItem.Click += new System.EventHandler(this.teachersToolStripMenuItem_Click);
            // 
            // assetsToolStripMenuItem
            // 
            this.assetsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.classesToolStripMenuItem,
            this.subjectsToolStripMenuItem});
            this.assetsToolStripMenuItem.Name = "assetsToolStripMenuItem";
            this.assetsToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.assetsToolStripMenuItem.Text = "&Assets";
            // 
            // classesToolStripMenuItem
            // 
            this.classesToolStripMenuItem.Name = "classesToolStripMenuItem";
            this.classesToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.classesToolStripMenuItem.Text = "&Classes";
            this.classesToolStripMenuItem.Click += new System.EventHandler(this.classesToolStripMenuItem_Click);
            // 
            // subjectsToolStripMenuItem
            // 
            this.subjectsToolStripMenuItem.Name = "subjectsToolStripMenuItem";
            this.subjectsToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.subjectsToolStripMenuItem.Text = "&Subjects";
            this.subjectsToolStripMenuItem.Click += new System.EventHandler(this.subjectsToolStripMenuItem_Click);
            // 
            // applcationsToolStripMenuItem
            // 
            this.applcationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addStudentToClassToolStripMenuItem,
            this.addSubjectToClassToolStripMenuItem,
            this.gradsToolStripMenuItem,
            this.attendacesToolStripMenuItem});
            this.applcationsToolStripMenuItem.Name = "applcationsToolStripMenuItem";
            this.applcationsToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.applcationsToolStripMenuItem.Text = "A&pplcations";
            // 
            // addStudentToClassToolStripMenuItem
            // 
            this.addStudentToClassToolStripMenuItem.Name = "addStudentToClassToolStripMenuItem";
            this.addStudentToClassToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.addStudentToClassToolStripMenuItem.Text = "Add &Student To Class";
            this.addStudentToClassToolStripMenuItem.Click += new System.EventHandler(this.addStudentToClassToolStripMenuItem_Click);
            // 
            // addSubjectToClassToolStripMenuItem
            // 
            this.addSubjectToClassToolStripMenuItem.Name = "addSubjectToClassToolStripMenuItem";
            this.addSubjectToClassToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.addSubjectToClassToolStripMenuItem.Text = "Add Sub&ject To Class";
            this.addSubjectToClassToolStripMenuItem.Click += new System.EventHandler(this.addSubjectToClassToolStripMenuItem_Click);
            // 
            // gradsToolStripMenuItem
            // 
            this.gradsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentExamToolStripMenuItem});
            this.gradsToolStripMenuItem.Name = "gradsToolStripMenuItem";
            this.gradsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.gradsToolStripMenuItem.Text = "&Grads";
            // 
            // studentExamToolStripMenuItem
            // 
            this.studentExamToolStripMenuItem.Name = "studentExamToolStripMenuItem";
            this.studentExamToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.studentExamToolStripMenuItem.Text = "Student &Exam";
            this.studentExamToolStripMenuItem.Click += new System.EventHandler(this.studentExamToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.classToolStripMenuItem,
            this.studentsRepoeToolStripMenuItem,
            this.studentReportToolStripMenuItem,
            this.classesRepportToolStripMenuItem,
            this.studentExamsReportToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "&Reports";
            // 
            // classToolStripMenuItem
            // 
            this.classToolStripMenuItem.Name = "classToolStripMenuItem";
            this.classToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.classToolStripMenuItem.Text = "Class &And Student";
            this.classToolStripMenuItem.Click += new System.EventHandler(this.classToolStripMenuItem_Click);
            // 
            // studentsRepoeToolStripMenuItem
            // 
            this.studentsRepoeToolStripMenuItem.Name = "studentsRepoeToolStripMenuItem";
            this.studentsRepoeToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.studentsRepoeToolStripMenuItem.Text = "&Students Report";
            this.studentsRepoeToolStripMenuItem.Click += new System.EventHandler(this.studentsRepoeToolStripMenuItem_Click);
            // 
            // studentReportToolStripMenuItem
            // 
            this.studentReportToolStripMenuItem.Name = "studentReportToolStripMenuItem";
            this.studentReportToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.studentReportToolStripMenuItem.Text = "S&tudent Report";
            this.studentReportToolStripMenuItem.Click += new System.EventHandler(this.studentReportToolStripMenuItem_Click);
            // 
            // classesRepportToolStripMenuItem
            // 
            this.classesRepportToolStripMenuItem.Name = "classesRepportToolStripMenuItem";
            this.classesRepportToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.classesRepportToolStripMenuItem.Text = "&Classes Repport";
            this.classesRepportToolStripMenuItem.Click += new System.EventHandler(this.classesRepportToolStripMenuItem_Click);
            // 
            // studentExamsReportToolStripMenuItem
            // 
            this.studentExamsReportToolStripMenuItem.Name = "studentExamsReportToolStripMenuItem";
            this.studentExamsReportToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.studentExamsReportToolStripMenuItem.Text = "Student E&xams Report";
            this.studentExamsReportToolStripMenuItem.Click += new System.EventHandler(this.studentExamsReportToolStripMenuItem_Click);
            // 
            // attendacesToolStripMenuItem
            // 
            this.attendacesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentAttendaceRecordToolStripMenuItem});
            this.attendacesToolStripMenuItem.Name = "attendacesToolStripMenuItem";
            this.attendacesToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.attendacesToolStripMenuItem.Text = "&Attendaces";
            // 
            // studentAttendaceRecordToolStripMenuItem
            // 
            this.studentAttendaceRecordToolStripMenuItem.Name = "studentAttendaceRecordToolStripMenuItem";
            this.studentAttendaceRecordToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.studentAttendaceRecordToolStripMenuItem.Text = "&Student Attendace Record";
            this.studentAttendaceRecordToolStripMenuItem.Click += new System.EventHandler(this.studentAttendaceRecordToolStripMenuItem_Click);
            // 
            // frmParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmParent";
            this.Text = "frmParent";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem personsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem staffsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teachersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applcationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addStudentToClassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSubjectToClassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentsRepoeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classesRepportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gradsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentExamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentExamsReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem attendacesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentAttendaceRecordToolStripMenuItem;
    }
}