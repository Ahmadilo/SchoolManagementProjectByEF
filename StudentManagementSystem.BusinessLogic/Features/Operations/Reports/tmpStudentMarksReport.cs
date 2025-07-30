using StudentManagementSystem.BusinessLogic.Activates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.BusinessLogic.Features.Operations.Reports
{
    public class tmpStudentMarksReport
    {
        public int StudentID { get; private set; }
        public string StudentName { get; private set; }
        public string SubjectName { get; private set; }
        public string HomewrokMark { get; private set; }
        public string QuizMark { get; private set; }
        public string TestMark { get; private set; }
        public string ProjectMark { get; private set; }
        public string PracticalMark { get; private set; }
        public string ParticipationMark { get; private set; }
        public string Totle { get; }

        public tmpStudentMarksReport()
        {

        }
    }
}
