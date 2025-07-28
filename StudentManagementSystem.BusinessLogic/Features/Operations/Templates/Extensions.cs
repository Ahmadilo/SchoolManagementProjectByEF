using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.BusinessLogic.Features.Operations.Templates
{
    public static class Extensions
    {
        public static void Save(this List<tmpStudentExm> list)
        {
            foreach (var student in list)
                student.Save();
        }

        public static void Save(this tmpStudentExm[] array)
        {
            foreach(var student in array)
                student.Save();
        }
    }
}
