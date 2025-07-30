using iTextSharp.text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentManagementSystem.BusinessLogic.Activates;
using StudentManagementSystem.BusinessLogic.Features.Roles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentSystem.UnitTesting.BuesinessLogic.Roles
{
    [TestClass]
    public class GardeRoleUntTests
    {
        public clsGrade GetNotSaveGradToTest(string GetType)
        {
            clsGrade grade = new clsGrade();

            grade.GradeType = GetType;

            return grade;
        }

        [TestMethod]
        public void GivenValidListMarksForSingelStudents_WhenCheckIfValidToGenratedReport_ShouldReturnTrue()
        {
            List<clsGrade> TestGrad = new List<clsGrade>();

            foreach(var name in Enum.GetNames(typeof(enmGradesType)))
            {
                TestGrad.Add(GetNotSaveGradToTest(name));
            }

            Assert.IsTrue(clsGradesRoles.InGradesType(TestGrad));
        }

        [TestMethod]
        public void GivenValidListMarksForMultepStudents_WhenCheckIfValidToGenratedReport_ShouldReturnTrue()
        {
            List<clsGrade> TestGrades = new List<clsGrade>();

            TestGrades.AddRange(Enum.GetNames(typeof(enmGradesType)).Select(e => GetNotSaveGradToTest(e)).ToArray());
            TestGrades.AddRange(Enum.GetNames(typeof(enmGradesType)).Select(e => GetNotSaveGradToTest(e)).ToArray());
            TestGrades.AddRange(Enum.GetNames(typeof(enmGradesType)).Select(e => GetNotSaveGradToTest(e)).ToArray());

            Assert.IsTrue(clsGradesRoles.InGradesType(TestGrades));
        }

        [TestMethod]
        public void GivenUnvalidListMarksForSingleStudent_WhenCheckIfValidToGenratedReport_ShouldReturnFalse()
        {
            List<clsGrade> TestGrades = new List<clsGrade>();
            var list = Enum.GetNames(typeof(enmGradesType));
            for (int i = 1; i < list.Length; i++)
            {
                TestGrades.Add(GetNotSaveGradToTest(list[i]));
            }

            Assert.IsFalse(clsGradesRoles.InGradesType(TestGrades));
        }
    }
}
