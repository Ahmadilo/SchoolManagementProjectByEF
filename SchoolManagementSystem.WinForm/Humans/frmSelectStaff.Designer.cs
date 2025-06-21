namespace SchoolManagementSystem.WinForm.Humans
{
    partial class frmSelectStaff
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
            this.humansTable1 = new SchoolManagementSystem.WinForm.HumansTable();
            this.lblHumanID = new System.Windows.Forms.Label();
            this.btnSelectHuman = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // humansTable1
            // 
            this.humansTable1.Location = new System.Drawing.Point(12, 12);
            this.humansTable1.Name = "humansTable1";
            this.humansTable1.Size = new System.Drawing.Size(762, 265);
            this.humansTable1.TabIndex = 0;
            // 
            // lblHumanID
            // 
            this.lblHumanID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblHumanID.Location = new System.Drawing.Point(288, 305);
            this.lblHumanID.Name = "lblHumanID";
            this.lblHumanID.Size = new System.Drawing.Size(129, 23);
            this.lblHumanID.TabIndex = 1;
            this.lblHumanID.Text = "ID";
            this.lblHumanID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSelectHuman
            // 
            this.btnSelectHuman.Location = new System.Drawing.Point(423, 305);
            this.btnSelectHuman.Name = "btnSelectHuman";
            this.btnSelectHuman.Size = new System.Drawing.Size(75, 23);
            this.btnSelectHuman.TabIndex = 2;
            this.btnSelectHuman.Text = "Select";
            this.btnSelectHuman.UseVisualStyleBackColor = true;
            // 
            // frmSelectStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 356);
            this.Controls.Add(this.btnSelectHuman);
            this.Controls.Add(this.lblHumanID);
            this.Controls.Add(this.humansTable1);
            this.Name = "frmSelectStaff";
            this.Text = "frmSelectStaff";
            this.Load += new System.EventHandler(this.frmSelectStaff_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private HumansTable humansTable1;
        private System.Windows.Forms.Label lblHumanID;
        private System.Windows.Forms.Button btnSelectHuman;
    }
}