namespace SchoolManagementSystem.WinForm.Gates
{
    partial class frmTeacherHome
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tblTeacherList = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.ucAttendanceChoose = new SchoolManagementSystem.WinForm.UserControls.ucListChoose();
            this.ucGradsChoose = new SchoolManagementSystem.WinForm.UserControls.ucListChoose();
            this.ucSubjectChoose = new SchoolManagementSystem.WinForm.UserControls.ucListChoose();
            this.ucClassChoose = new SchoolManagementSystem.WinForm.UserControls.ucListChoose();
            this.ucTeacherClasses1 = new SchoolManagementSystem.WinForm.UserControls.ucTeacherClasses();
            this.ucTeacherSubjects1 = new SchoolManagementSystem.WinForm.UserControls.ucTeacherSubjects();
            this.ucTeacherStudentGrads1 = new SchoolManagementSystem.WinForm.UserControls.ucTeacherStudentGrads();
            this.ucTeacherStudentAttendances1 = new SchoolManagementSystem.WinForm.UserControls.ucTeacherStudentAttendances();
            this.tableLayoutPanel1.SuspendLayout();
            this.tblTeacherList.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.2727F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.72729F));
            this.tableLayoutPanel1.Controls.Add(this.tblTeacherList, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tblTeacherList
            // 
            this.tblTeacherList.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tblTeacherList.ColumnCount = 1;
            this.tblTeacherList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblTeacherList.Controls.Add(this.ucAttendanceChoose, 0, 3);
            this.tblTeacherList.Controls.Add(this.ucGradsChoose, 0, 2);
            this.tblTeacherList.Controls.Add(this.ucSubjectChoose, 0, 1);
            this.tblTeacherList.Controls.Add(this.ucClassChoose, 0, 0);
            this.tblTeacherList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblTeacherList.Location = new System.Drawing.Point(3, 3);
            this.tblTeacherList.Name = "tblTeacherList";
            this.tblTeacherList.RowCount = 5;
            this.tblTeacherList.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblTeacherList.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblTeacherList.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblTeacherList.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblTeacherList.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblTeacherList.Size = new System.Drawing.Size(148, 444);
            this.tblTeacherList.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(157, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(640, 444);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ucTeacherClasses1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(632, 418);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ucTeacherSubjects1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(632, 418);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ucTeacherStudentGrads1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(632, 418);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.ucTeacherStudentAttendances1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(632, 418);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // ucAttendanceChoose
            // 
            this.ucAttendanceChoose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucAttendanceChoose.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ucAttendanceChoose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucAttendanceChoose.Location = new System.Drawing.Point(3, 192);
            this.ucAttendanceChoose.Name = "ucAttendanceChoose";
            this.ucAttendanceChoose.Size = new System.Drawing.Size(142, 57);
            this.ucAttendanceChoose.TabIndex = 3;
            this.ucAttendanceChoose.Title = "Title";
            this.ucAttendanceChoose.ChooseChange += new System.EventHandler(this.ucAttendanceChoose_ChooseChange);
            // 
            // ucGradsChoose
            // 
            this.ucGradsChoose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucGradsChoose.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ucGradsChoose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucGradsChoose.Location = new System.Drawing.Point(3, 129);
            this.ucGradsChoose.Name = "ucGradsChoose";
            this.ucGradsChoose.Size = new System.Drawing.Size(142, 57);
            this.ucGradsChoose.TabIndex = 2;
            this.ucGradsChoose.Title = "Title";
            this.ucGradsChoose.ChooseChange += new System.EventHandler(this.ucGradsChoose_ChooseChange);
            // 
            // ucSubjectChoose
            // 
            this.ucSubjectChoose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSubjectChoose.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ucSubjectChoose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucSubjectChoose.Location = new System.Drawing.Point(3, 66);
            this.ucSubjectChoose.Name = "ucSubjectChoose";
            this.ucSubjectChoose.Size = new System.Drawing.Size(142, 57);
            this.ucSubjectChoose.TabIndex = 1;
            this.ucSubjectChoose.Title = "Title";
            this.ucSubjectChoose.ChooseChange += new System.EventHandler(this.ucSubjectChoose_ChooseChange);
            // 
            // ucClassChoose
            // 
            this.ucClassChoose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucClassChoose.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ucClassChoose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucClassChoose.Location = new System.Drawing.Point(3, 3);
            this.ucClassChoose.Name = "ucClassChoose";
            this.ucClassChoose.Size = new System.Drawing.Size(142, 57);
            this.ucClassChoose.TabIndex = 0;
            this.ucClassChoose.Title = "Title";
            this.ucClassChoose.ChooseChange += new System.EventHandler(this.ucClassChoose_ChooseChange);
            // 
            // ucTeacherClasses1
            // 
            this.ucTeacherClasses1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTeacherClasses1.Location = new System.Drawing.Point(3, 3);
            this.ucTeacherClasses1.Name = "ucTeacherClasses1";
            this.ucTeacherClasses1.Size = new System.Drawing.Size(626, 412);
            this.ucTeacherClasses1.TabIndex = 0;
            // 
            // ucTeacherSubjects1
            // 
            this.ucTeacherSubjects1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTeacherSubjects1.Location = new System.Drawing.Point(3, 3);
            this.ucTeacherSubjects1.Name = "ucTeacherSubjects1";
            this.ucTeacherSubjects1.Size = new System.Drawing.Size(626, 412);
            this.ucTeacherSubjects1.TabIndex = 0;
            // 
            // ucTeacherStudentGrads1
            // 
            this.ucTeacherStudentGrads1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTeacherStudentGrads1.Location = new System.Drawing.Point(3, 3);
            this.ucTeacherStudentGrads1.Name = "ucTeacherStudentGrads1";
            this.ucTeacherStudentGrads1.Size = new System.Drawing.Size(626, 412);
            this.ucTeacherStudentGrads1.TabIndex = 0;
            // 
            // ucTeacherStudentAttendances1
            // 
            this.ucTeacherStudentAttendances1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTeacherStudentAttendances1.Location = new System.Drawing.Point(3, 3);
            this.ucTeacherStudentAttendances1.Name = "ucTeacherStudentAttendances1";
            this.ucTeacherStudentAttendances1.Size = new System.Drawing.Size(626, 412);
            this.ucTeacherStudentAttendances1.TabIndex = 0;
            // 
            // frmTeacherHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.IsMdiContainer = true;
            this.Name = "frmTeacherHome";
            this.Text = "frmTeacherHome";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tblTeacherList.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tblTeacherList;
        private UserControls.ucListChoose ucAttendanceChoose;
        private UserControls.ucListChoose ucGradsChoose;
        private UserControls.ucListChoose ucSubjectChoose;
        private UserControls.ucListChoose ucClassChoose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private UserControls.ucTeacherClasses ucTeacherClasses1;
        private UserControls.ucTeacherSubjects ucTeacherSubjects1;
        private System.Windows.Forms.TabPage tabPage3;
        private UserControls.ucTeacherStudentGrads ucTeacherStudentGrads1;
        private System.Windows.Forms.TabPage tabPage4;
        private UserControls.ucTeacherStudentAttendances ucTeacherStudentAttendances1;
    }
}