using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentManagementSystem.BusinessLogic.Features.Services;
using StudentManagementSystem.BusinessLogic.Features.Operations.Reports;
using StudentSystem.UnitTesting.Cases;
using System.Collections.Generic;

namespace StudentSystem.UnitTesting.BuesinessLogic.Services
{
    [TestClass]
    public class ReportStudentMarksForSelectedSubjectUnitTest
    {
        ICaseDeleteFakeData Cas = null;

        [TestMethod]
        public void GivenNothing_WhenGenrateStudentsMarksReportForSelectedSubjectInSelectedClass_ShouldReturnList()
        {
            casGenrateStudentMarksReportForSelectedSubject FakeData = new casGenrateStudentMarksReportForSelectedSubject();
            this.Cas = FakeData;
            var srv = new clsReportStudentMarksService(classid: FakeData.ClassID, subjectID: FakeData.SubjectID);

            Assert.IsTrue(srv.CheckRoleService());
            Assert.IsInstanceOfType(srv.GetStudentMarksReport(), typeof(List<tmpStudentMarksReport>));
        }

        [TestCleanup]
        public void Clean()
        {
            Cas.DeleteFakeData();
        }
    }
}
