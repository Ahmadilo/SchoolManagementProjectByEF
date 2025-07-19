using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentManagementSystem.BusinessLogic.Features.Operations.Templates;
using System.Collections.Generic;

namespace StudentSystem.UnitTesting.BuesinessLogic
{
    [TestClass]
    public class TamplateUnitTest
    {
        [TestMethod]
        public void GivenNothing_WhenGetStudentByClassUsingStudentAttendancsTemplateFromDataBase_returnList()
        {
            List<tmpStudentAttendancs> list = tmpStudentAttendancs.GetStudentByClass();

            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void GiventIDClass_WhenGetStudentByClassUsingStudentAttendancsTemplateFromDataBase_returnList()
        {
            List<tmpStudentAttendancs> list = tmpStudentAttendancs.GetStudentByClass(6);

            Assert.IsTrue(list.Count > 0);
        }

        [TestMethod]
        public void GivenNothing_WhenGetStudentAttendances_returnList()
        {
            List<tmpStudentAttendancs> list = tmpStudentAttendancs.GetStudentAttendancsByCondation();

            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void GivenNothing_WhenGetStudentAttendances_returnListContainedObjects_WhenThereAreAttendanceRecode()
        {
            List<tmpStudentAttendancs> list = tmpStudentAttendancs.GetStudentAttendancsByCondation();

            Assert.IsTrue(list.Count >= 1);
        }
    }
}
