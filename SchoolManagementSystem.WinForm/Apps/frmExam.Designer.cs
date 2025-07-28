namespace SchoolManagementSystem.WinForm.Apps
{
    partial class frmExam
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
            this.label2 = new System.Windows.Forms.Label();
            this.cmbGrade = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSubjcetName = new System.Windows.Forms.ComboBox();
            this.ucSaveBar1 = new SchoolManagementSystem.WinForm.UserControls.ucSaveBar();
            this.ucShowTable1 = new SchoolManagementSystem.WinForm.ucShowTable();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbGrade);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbSubjcetName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 78);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Exam Filters";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(521, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Grade";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbGrade
            // 
            this.cmbGrade.Enabled = false;
            this.cmbGrade.FormattingEnabled = true;
            this.cmbGrade.Location = new System.Drawing.Point(613, 29);
            this.cmbGrade.Name = "cmbGrade";
            this.cmbGrade.Size = new System.Drawing.Size(121, 21);
            this.cmbGrade.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(69, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Subject Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbSubjcetName
            // 
            this.cmbSubjcetName.FormattingEnabled = true;
            this.cmbSubjcetName.Location = new System.Drawing.Point(199, 31);
            this.cmbSubjcetName.Name = "cmbSubjcetName";
            this.cmbSubjcetName.Size = new System.Drawing.Size(121, 21);
            this.cmbSubjcetName.TabIndex = 0;
            // 
            // ucSaveBar1
            // 
            this.ucSaveBar1.Location = new System.Drawing.Point(12, 96);
            this.ucSaveBar1.Name = "ucSaveBar1";
            this.ucSaveBar1.Size = new System.Drawing.Size(776, 66);
            this.ucSaveBar1.TabIndex = 1;
            // 
            // ucShowTable1
            // 
            this.ucShowTable1.ColumnsSetting = null;
            this.ucShowTable1.Location = new System.Drawing.Point(12, 173);
            this.ucShowTable1.Name = "ucShowTable1";
            this.ucShowTable1.Size = new System.Drawing.Size(776, 265);
            this.ucShowTable1.TabIndex = 2;
            this.ucShowTable1.TypeRow = null;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.checkBox1.Location = new System.Drawing.Point(391, 31);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(124, 22);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Set The Marks";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // frmExam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ucShowTable1);
            this.Controls.Add(this.ucSaveBar1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmExam";
            this.Text = "Exam Form";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSubjcetName;
        private UserControls.ucSaveBar ucSaveBar1;
        private ucShowTable ucShowTable1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbGrade;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}