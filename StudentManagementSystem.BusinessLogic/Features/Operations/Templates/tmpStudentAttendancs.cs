using StudentManagementSystem.BusinessLogic.Activates;
using StudentManagementSystem.DataAccess.Services;
using StudentManagementSystem.DataAccess.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace StudentManagementSystem.BusinessLogic.Features.Operations.Templates
{
    public class tmpStudentAttendancs
    {
        private int _attendanceId = -1;
        public int AttendanceID { get => _attendanceId; }
        public DateTime Date { get; set; }
        public string Status { get; set; }

        private int _classSubjectID = -1;
        public int ClassSubjectID { get => _classSubjectID; }
        public TimeSpan StartTime { get; }
        public TimeSpan EndTime { get; }
        public string ScheduleDay { get; }
        public string RoomNumber { get; }

        private int _teacherID = -1;
        public int TeacherID { get => _teacherID; }
        public string TeacherName { get; }

        private int _studentID = -1;
        public int StudentID { get => _studentID; }
        public string StudentName { get; }

        private int _classID = -1;
        public int ClassID { get => _classID; }
        public string ClassName { get; }

        private int _subjectID = -1;
        public int SubjectID { get => _subjectID; }
        public string SubjectName { get; }

        private tmpStudentAttendancs(StudentsByClass entity)
        {
            this._classID = entity.ClassID;
            this.ClassName = entity.ClassName;

            this._studentID = entity.StudentID;
            this.StudentName = entity.FullName;
        }

        private tmpStudentAttendancs(StudentAttendance entity)
        {
            this._attendanceId = entity.AttendanceID;
            this.Date = entity.Date;
            this.Status = entity.Status;

            this._classSubjectID = entity.ClassSubjectID;
            this.StartTime = entity.StartTime;
            this.EndTime = entity.EndTime;
            this.ScheduleDay = entity.ScheduleDay;
            this.RoomNumber = entity.RoomNumber;

            this._teacherID = entity.TeacherID;
            this.TeacherName = entity.TeacherName;

            this._classID = entity.ClassID;
            this.ClassName = entity.ClassName;

            this._studentID = entity.StudentID;
            this.StudentName = entity.StudentName;

            this._subjectID = entity.SubjectID;
            this.SubjectName = entity.SubjectName;
        }

        public void Save()
        {
            // TODO: There are Error will Explogent from here the Attendace not have ClassSubjectID!!!
            if(AttendanceID == -1)
            {
                clsAttendance newAttendace = new clsAttendance();

                newAttendace.Date = this.Date;
                newAttendace.Status = this.Status;

                newAttendace.Save();

                return;
            }

            clsAttendance EditAttendace = clsAttendance.Find(this.AttendanceID);
            
            EditAttendace.Date = this.Date;
            EditAttendace.Status = this.Status;

            EditAttendace.Save();
        }

        public static List<tmpStudentAttendancs> GetStudentByClass(int ID = 0)
        {
            Expression<Func<StudentsByClass, bool>> func = null;

            if (ID > 0)
                func = entity => entity.ClassID == ID;
            else
                func = entity => true;

            return ViewService
                .GetView(func)
                .Select(sc => new tmpStudentAttendancs(sc))
                .ToList();
        }

        public static List<tmpStudentAttendancs> GetStudentAttendancsByCondation(Func<tmpStudentAttendancs, bool> Condation = null)
        {
            if(Condation == null)
                Condation = delegate(tmpStudentAttendancs entity) { return true; };

            return ViewService
                .GetView<StudentAttendance>(sa => true)
                .Select(sa => new tmpStudentAttendancs(sa))
                .Where(Condation)
                .ToList();
        }

        public static tmpStudentAttendancs Find(int ID)
        {
            return GetStudentAttendancsByCondation(sa => sa.AttendanceID == ID).FirstOrDefault();
        }
    }
}
