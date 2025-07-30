using StudentManagementSystem.BusinessLogic.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.BusinessLogic.Features.Services
{
    public class clsClassService
    {
        public int ClassID { get; set; }
        public string ErrorMssage { get; private set; }

        public clsClassService(int classid)
        {
            this.ClassID = classid;
        }

        private clsClassService(string Errormassge)
        {
            this.ClassID = -1;
            this.ErrorMssage = Errormassge;
        }

        public clsClassService GetClassServiceByCondation(Func<clsSchoolClass, bool> condation)
        {
            var _class = clsSchoolClass.GetAllClasses().FirstOrDefault(condation);

            if (_class.Equals(default(clsSchoolClass)))
                return new clsClassService("The Class is not Found!");

            return new clsClassService(_class.ID);
        }

        public Dictionary<string, int> GetAllSubjects()
        {
            if(ClassID == -1)
            {
                ErrorMssage = "The ClassID is not Defaind!";
                return null;
            }

            var Class = clsSchoolClass.Find(ClassID);

            if (Class == null)
            {
                ErrorMssage = "The Class is not Found!";
                return null;
            }

            return Class.PeriodsList.Select(p => p.Subject).GroupBy(s => s.SubjectName).ToDictionary(s => s.Key, s => s.First().ID);
        }

        public static Dictionary<string, int> GetAllClasses()
        {
            return clsSchoolClass.GetAllClasses().ToDictionary(c => c.ClassName, c => c.ID);
        }
    }
}
