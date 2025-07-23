using StudentManagementSystem.BusinessLogic.Features.Operations.Templates;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.BusinessLogic.Features.Groups
{
    public class StudentAttendaceReportGroup
    {
        public string ReportName { get; internal set; }
        public object ReportExample { get; internal set; }

        public static List<StudentAttendaceReportGroup> GetGroupList()
        {
            return new List<StudentAttendaceReportGroup>
            {
                new StudentAttendaceReportGroup
                {
                    ReportName = "Short Student Attendace Report",
                    ReportExample = tmpStudentAttendacesReport.GetExamble()
                }
            };
        }
    }
}
