namespace SchoolManagementSystem.WinForm.Humans
{
    partial class frmManagementTeachers
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
            this.btnSelectStaff = new System.Windows.Forms.Button();
            this.lblStaffID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSubjectSpecialization = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // humansTable1
            // 
            this.humansTable1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.humansTable1.Location = new System.Drawing.Point(19, 269);
            this.humansTable1.Name = "humansTable1";
            this.humansTable1.Size = new System.Drawing.Size(544, 169);
            this.humansTable1.TabIndex = 0;
            // 
            // ucSaveBar1
            // 
            this.ucSaveBar1.Location = new System.Drawing.Point(17, 197);
            this.ucSaveBar1.Name = "ucSaveBar1";
            this.ucSaveBar1.Size = new System.Drawing.Size(546, 66);
            this.ucSaveBar1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSelectStaff);
            this.groupBox1.Controls.Add(this.lblStaffID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSubjectSpecialization);
            this.groupBox1.Location = new System.Drawing.Point(19, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(544, 171);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Teacher Form";
            // 
            // btnSelectStaff
            // 
            this.btnSelectStaff.Location = new System.Drawing.Point(216, 94);
            this.btnSelectStaff.Name = "btnSelectStaff";
            this.btnSelectStaff.Size = new System.Drawing.Size(75, 23);
            this.btnSelectStaff.TabIndex = 7;
            this.btnSelectStaff.Text = "Select Staff";
            this.btnSelectStaff.UseVisualStyleBackColor = true;
            // 
            // lblStaffID
            // 
            this.lblStaffID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblStaffID.Location = new System.Drawing.Point(6, 94);
            this.lblStaffID.Name = "lblStaffID";
            this.lblStaffID.Size = new System.Drawing.Size(190, 20);
            this.lblStaffID.TabIndex = 6;
            this.lblStaffID.Text = "Staff ID";
            this.lblStaffID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(6, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Subject Specialization";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSubjectSpecialization
            // 
            this.txtSubjectSpecialization.Location = new System.Drawing.Point(202, 47);
            this.txtSubjectSpecialization.Name = "txtSubjectSpecialization";
            this.txtSubjectSpecialization.Size = new System.Drawing.Size(178, 20);
            this.txtSubjectSpecialization.TabIndex = 4;
            // 
            // frmManagementTeachers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ucSaveBar1);
            this.Controls.Add(this.humansTable1);
            this.Name = "frmManagementTeachers";
            this.Text = "frmManagementTeachers";
            this.Load += new System.EventHandler(this.frmManagementTeachers_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }



        #endregion

        private ucShowTable humansTable1;
        private UserControls.ucSaveBar ucSaveBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSubjectSpecialization;
        private System.Windows.Forms.Button btnSelectStaff;
        private System.Windows.Forms.Label lblStaffID;
    }
}