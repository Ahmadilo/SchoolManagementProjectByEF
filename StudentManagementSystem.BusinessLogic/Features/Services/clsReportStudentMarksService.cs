using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.BusinessLogic.Features.Operations.Reports;
using StudentManagementSystem.BusinessLogic.Features.Operations.Templates;
using StudentManagementSystem.BusinessLogic.Features.Roles;

namespace StudentManagementSystem.BusinessLogic.Features.Services
{
    public class clsReportStudentMarksService
    {
        public int ClassID { get; private set; }
        public int SubjectID { get; private set; }
        public string ErrorMessage { get; private set; }
        private bool isValid { get; }
        

        public clsReportStudentMarksService(int classid, int subjectID)
        {
            this.ClassID = classid;
            this.SubjectID = subjectID;
            isValid = clsGradesRoles.CanGeneratStudentMarksReportList(ClassID: ClassID, SubjectID: SubjectID);
        }

        public bool CheckRoleService()
        {
            if(!this.isValid)
            {
                ErrorMessage = "The Rows of Marks in Context is not Currect to Genrate Report";
            }
            return this.isValid;
        }

        public List<tmpStudentMarksReport> GetStudentMarksReport()
        {
            if (!this.isValid)
                return null;

            return new List<tmpStudentMarksReport>();
        }
    }
}
