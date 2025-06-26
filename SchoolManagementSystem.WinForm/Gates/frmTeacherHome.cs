using SchoolManagementSystem.WinForm.Humans;
using SchoolManagementSystem.WinForm.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem.WinForm.Gates
{
    public partial class frmTeacherHome : Form
    {
        private void OpenTab(string Name, UserControl userControl)
        {
            try
            {
                TabPage tabPage = new TabPage(Name);
                userControl.Dock = DockStyle.Fill; // مهم جداً لظهوره بشكل ملء التبويبة
                tabPage.Controls.Add(userControl);
                tabControl1.TabPages.Add(tabPage);
                tabControl1.SelectedTab = tabPage; // لجعل التبويبة الجديدة مفعلة فوراً
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ: " + ex.Message);
            }
        }

        public frmTeacherHome()
        {
            InitializeComponent();
            frmTeacherSideBar sideb = new frmTeacherSideBar();
            sideb.MdiParent = this;
            sideb.Dock = DockStyle.Left;
            sideb.ClientSize = new Size(300, sideb.ClientSize.Height);
            sideb.Show();
            //MessageBox.Show("Width of SideBar is: " + sideb.ClientSize.Width);

            ucClassChoose.Title = "Classes";
            ucSubjectChoose.Title = "Subjects";
            ucGradsChoose.Title = "Grades";
            ucAttendanceChoose.Title = "Attendances";
        }

        private void ucClassChoose_ChooseChange(object sender, EventArgs e)
        {
            OpenTab("Classes", new ucTeacherClasses());
        }

        private void ucSubjectChoose_ChooseChange(object sender, EventArgs e)
        {
            OpenTab("Subjects", new ucTeacherSubjects());
        }

        private void ucGradsChoose_ChooseChange(object sender, EventArgs e)
        {
            OpenTab("Grads", new ucTeacherStudentGrads());
        }

        private void ucAttendanceChoose_ChooseChange(object sender, EventArgs e)
        {
            OpenTab("Attendances", new ucTeacherStudentAttendances());
        }

        private void CloseTab(string Name)
        {
            for(int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                if (tabControl1.TabPages[i].Text == Name)
                {
                    tabControl1.TabPages.RemoveAt(i);
                    break;
                }
            }
        }

        private string GetTitle(UserControl control)
        {
            if(control is ucTeacherClasses) return "Classes";

            if (control is ucTeacherSubjects) return "Subjects";

            if (control is ucTeacherStudentGrads) return "Grads";

            if (control is ucTeacherStudentAttendances) return "Attendances";

            return string.Empty;
        }

        private void CloseOpenTab(object sender, EventArgs e)
        {
            if (sender is UserControl control && tabControl1.TabPages.Count != 0)
            {
                string title = GetTitle(control);
                CloseTab(title);
            }
        }
    }
}
