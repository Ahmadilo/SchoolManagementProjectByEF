using StudentManagementSystem.BusinessLogic.Humans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.BusinessLogic.Features.Operations.Templates
{
    public class tmpAddStudentMark
    {
        public int StudentID { get; }
        public string StudentName { get; }
        public Decimal Mark { get; set; }

        internal tmpAddStudentMark(clsStudent s, decimal mark = 0)
        {
            this.StudentID = s.ID;
            this.StudentName = s.FullName;
            this.Mark = mark;
        }
    }
}
