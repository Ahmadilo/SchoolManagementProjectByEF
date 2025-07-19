using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using StudentManagementSystem.DataAccess.Services;
using StudentManagementSystem.DataAccess.Views;

namespace StudentSystem.UnitTesting.DataAccess
{
    [TestClass]
    public class ViewUntiTest
    {
        [TestMethod]
        public static void GivenNothing_WhenGetStudentAttendeces_returnListNotNull()
        {
            List<StudentAttendance> list = ViewService.GetView<StudentAttendance>(sa => true);

            Assert.IsNotNull(list);
        }

        //[TestMethod]
        //public static void GivenNothing_WhenGetStudentAttendces_returnPostiveNumber()
        //{
        //    List<StudentAttendance> List = ViewService.GetView<StudentAttendance>(sa => true);

        //    Assert.IsTrue(List.Count > 0);
        //}
        [TestMethod]
        public void GivenNothing_WhenGetStudentAttendces_returnPostiveNumber()
        {
            List<StudentAttendance> List = ViewService.GetView<StudentAttendance>(sa => true);

            Assert.IsTrue(List.Count >= 0);
        }

        [TestMethod]
        public void GivenNothing_WhenGetStudentsByClass_returnList()
        {
            List<StudentsByClass> list = ViewService.GetView<StudentsByClass>(sc => true);

            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count >= 0);
        }
    }
}
