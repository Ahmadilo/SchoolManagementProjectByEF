using System;
using StudentManagementSystem.DataAccess.Services;
using StudentManagementSystem.DataAccess.Views;
using System.Collections.Generic;
using iTextSharp.text;

namespace learnEntityFramwork.ConsoleApp.DataAccessTests
{
    internal class ViewTestsUnit
    {
        public static void GivenNothing_WhenGetStudentAttendeces_returnPostiveNumber()
        {
            List<StudentAttendance> list = ViewService.GetView<StudentAttendance>(sa => true);

            
        }
    }
}
