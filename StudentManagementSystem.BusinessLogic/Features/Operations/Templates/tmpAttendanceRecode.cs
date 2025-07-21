using StudentManagementSystem.BusinessLogic.Humans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.BusinessLogic.Features.Operations.Templates
{
    public class tmpAttendanceRecode
    {
        public int StudentID { get; private set; }
        public string StudentName { get; private set; } // للعرض فقط
        public bool Present { get; set; }
        public string Note { get; set; }

        private int _attendanceID = -1;
        
        public void SetAttendanceID(int ID)
        {
            _attendanceID = ID;
        }

        public int GetAttendanceID()
        {
            return _attendanceID;
        }

        public tmpAttendanceRecode(clsStudent student)
        {
            this.StudentID = student.ID;
            this.StudentName = student.FullName;
        }

        public tmpAttendanceRecode()
        {

        }
    }
}

