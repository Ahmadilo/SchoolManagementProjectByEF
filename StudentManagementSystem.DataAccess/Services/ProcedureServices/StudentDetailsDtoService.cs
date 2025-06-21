using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.DataAccess.DatabaseContext;
using StudentManagementSystem.DataAccess.StoredProcedures;

namespace StudentManagementSystem.DataAccess.Services.ProcedureServices
{
    public static class StudentDetailsDtoService
    {
        public static StudentDetailsDto GetStudentDetail(int studentId)
        {
            using (var context = new AppDbContext())
            {
                return context.Database.SqlQuery<StudentDetailsDto>(
                    "EXEC sp_GetStudentDetails @StudentID",
                    new SqlParameter("@StudentID", studentId)
                ).FirstOrDefault();
            }
        }

        public static List<StudentDetailsDto> GetAllStudentDetails()
        {
            using (var context = new AppDbContext())
            {
                List<int> StudentIDList = context.Students.OrderBy(s => s.StudentID).Select(s => s.StudentID).ToList();
                List<StudentDetailsDto> studentDetailsList = new List<StudentDetailsDto>();

                foreach (var studentId in StudentIDList)
                {
                    var studentDetail = GetStudentDetail(studentId);
                    if (studentDetail != null)
                    {
                        studentDetailsList.Add(studentDetail);
                    }
                }

                return studentDetailsList;
            }
        }
    }
}
