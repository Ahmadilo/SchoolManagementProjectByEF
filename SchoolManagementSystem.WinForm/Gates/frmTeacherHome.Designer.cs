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
            this.ucAttendanceChoose = new SchoolManagementSystem.WinForm.UserControls.ucListChoose();
            this.ucGradsChoose = new SchoolManagementSystem.WinForm.UserControls.ucListChoose();
            this.ucSubjectChoose = new SchoolManagementSystem.WinForm.UserControls.ucListChoose();
            this.ucClassChoose = new SchoolManagementSystem.WinForm.UserControls.ucListChoose();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.tblTeacherList.SuspendLayout();
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
            this.ucAttendanceChoose.DoubleClickChange += new System.EventHandler(this.CloseOpenTab);
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
            this.ucGradsChoose.DoubleClickChange += new System.EventHandler(this.CloseOpenTab);
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
            this.ucSubjectChoose.DoubleClickChange += new System.EventHandler(this.CloseOpenTab);
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
            this.ucClassChoose.DoubleClickChange += new System.EventHandler(this.CloseOpenTab);
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(157, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(640, 444);
            this.tabControl1.TabIndex = 2;
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
    }
}