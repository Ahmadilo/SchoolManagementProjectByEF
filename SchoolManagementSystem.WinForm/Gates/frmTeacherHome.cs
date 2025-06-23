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
            ucAttendanceChoose.Title = "Attendance";
        }

        private void ucClassChoose_ChooseChange(object sender, EventArgs e)
        {
            try
            {
                TabPage tabPage = new TabPage("Classes");
                ucTeacherClasses uc = new ucTeacherClasses();
                uc.Dock = DockStyle.Fill; // مهم جداً لظهوره بشكل ملء التبويبة
                tabPage.Controls.Add(uc);
                tabControl1.TabPages.Add(tabPage);
                tabControl1.SelectedTab = tabPage; // لجعل التبويبة الجديدة مفعلة فوراً
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ: " + ex.Message);
            }
        }

        private void ucSubjectChoose_ChooseChange(object sender, EventArgs e)
        {
            try
            {
                TabPage tabPage = new TabPage("Subjects");
                ucTeacherSubjects uc = new ucTeacherSubjects();
                uc.Dock = DockStyle.Fill; // مهم جداً لظهوره بشكل ملء التبويبة
                tabPage.Controls.Add(uc);
                tabControl1.TabPages.Add(tabPage);
                tabControl1.SelectedTab = tabPage; // لجعل التبويبة الجديدة مفعلة فوراً
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ: " + ex.Message);
            }
        }

        private void ucGradsChoose_ChooseChange(object sender, EventArgs e)
        {
            try
            {
                TabPage tabPage = new TabPage("Grads");
                ucTeacherStudentGrads uc = new ucTeacherStudentGrads();
                uc.Dock = DockStyle.Fill; // مهم جداً لظهوره بشكل ملء التبويبة
                tabPage.Controls.Add(uc);
                tabControl1.TabPages.Add(tabPage);
                tabControl1.SelectedTab = tabPage; // لجعل التبويبة الجديدة مفعلة فوراً
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ: " + ex.Message);
            }
        }

        private void ucAttendanceChoose_ChooseChange(object sender, EventArgs e)
        {
            try
            {
                TabPage tabPage = new TabPage("Attendances");
                ucTeacherStudentAttendances uc = new ucTeacherStudentAttendances();
                uc.Dock = DockStyle.Fill; // مهم جداً لظهوره بشكل ملء التبويبة
                tabPage.Controls.Add(uc);
                tabControl1.TabPages.Add(tabPage);
                tabControl1.SelectedTab = tabPage; // لجعل التبويبة الجديدة مفعلة فوراً
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ: " + ex.Message);
            }
        }
    }
}
