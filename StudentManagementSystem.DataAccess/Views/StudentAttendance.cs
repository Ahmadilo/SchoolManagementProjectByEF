using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace StudentManagementSystem.DataAccess.Views
{
    [Table("vwStudent_Attendances")]
    public class StudentAttendance
    {
        [Key]
        public int AttendanceID { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }

        public int ClassSubjectID { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string ScheduleDay { get; set; }
        public string RoomNumber { get; set; }

        public int TeacherID { get; set; }
        public string TeacherName { get; set; }

        public int StudentID { get; set; }
        public string StudentName { get; set; }

        public int ClassID { get; set; }
        public string ClassName { get; set; }

        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
    }

}
