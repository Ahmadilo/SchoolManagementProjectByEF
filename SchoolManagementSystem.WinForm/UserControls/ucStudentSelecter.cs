using StudentManagementSystem.BusinessLogic.Humans;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SchoolManagementSystem.WinForm.UserControls
{
    public partial class ucStudentSelecter : UserControl
    {
        private class clsSelect
        {
            public string SelectType = string.Empty;
            public object SelectValue = null;

            public clsSelect(ComboBox box)
            {
                SelectType = box.Name;
                SelectValue = box.Items[box.SelectedIndex];
            }
        }

        private void SetValueToComboBox(object sender, EventArgs e)
        {
            if (sender is ComboBox cmb)
            {
                if (cmb.SelectedIndex != 0)
                {
                    cmb.Tag = cmb.Items[cmb.SelectedIndex].ToString();
                }
                else if (cmb.SelectedIndex == 0)
                    cmb.Tag = null;
            }
        }

        public ucStudentSelecter()
        {
            InitializeComponent();
        }

        private void txtStudentID_TextChanged(object sender, EventArgs e)
        {
            string input = txtStudentID.Text;

            // إذا كان النص يحتوي على شيء غير أرقام، أو يبدأ بـ 0 أو علامة سالبة
            if (!Regex.IsMatch(input, @"^[1-9][0-9]*$"))
            {
                // إما مسحه:
                txtStudentID.Text = "";
                // أو إظهار رسالة (اختياري)
                // MessageBox.Show("الرجاء إدخال رقم صحيح موجب فقط");
            }

            // تأكد من إبقاء المؤشر في نهاية النص
            txtStudentID.SelectionStart = txtStudentID.Text.Length;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtStudentID.Text == string.Empty)
                return;

            int studentId = Convert.ToInt32(txtStudentID.Text);

            if(studentId < 1)
            {
                MessageBox.Show("Please enter a valid Student ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsStudent student = clsStudent.Find(studentId);

            if (student == null)
            {
                MessageBox.Show("Student not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ucStudentCard1.StudentID = studentId;
        }
    }
}
