using StudentManagementSystem.BusinessLogic.Humans;
using StudentManagementSystem.DataAccess.Models;
using StudentManagementSystem.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem.BusinessLogic.Activates
{
    public class clsAttendance : clsBase<clsAttendance>
    {
        private readonly AttendanceService _service = new AttendanceService();
        private clsStudent _student = null;
        private clsClassSubject _classSubject = null;

        public int StudentID { get; set; }
        public clsStudent Student { get => clsPublic.GetInstansOfID(StudentID, _student); }
        public int ClassSubjectID { get; set; }
        public clsClassSubject ClassSubject { get => clsPublic.GetInstansOfID(ClassSubjectID, _classSubject); }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }

        public clsAttendance()
        {
            IsNew = true;
        }

        private clsAttendance(Attendance model)
        {
            FromModel(model);
            IsNew = false;
        }

        private void FromModel(Attendance model)
        {
            _id = model.AttendanceID;
            StudentID = model.StudentID;
            ClassSubjectID = model.ClassSubjectID;
            Date = model.Date;
            Status = model.Status;
            Notes = model.Notes;
        }

        private Attendance ToModel()
        {
            return new Attendance
            {
                AttendanceID = _id,
                StudentID = this.StudentID,
                ClassSubjectID = this.ClassSubjectID,
                Date = this.Date,
                Status = this.Status,
                Notes = this.Notes
            };
        }

        public override bool Validate()
        {
            _ErrorMessages.Clear();
            _ErrorMessages = AttendanceService.ValidateAttendance(ToModel());
            return !_ErrorMessages.Any();
        }

        protected override bool DeleteByID(int id)
        {
            return _service.DeleteAttendance(id);
        }

        public static bool Delete(int id)
        {
            return new clsAttendance().DeleteByID(id);
        }

        protected override clsAttendance GetByID(int id)
        {
            var model = _service.GetAttendanceById(id);
            return model == null ? null : new clsAttendance(model);
        }

        public static clsAttendance Find(int id)
        {
            return new clsAttendance().GetByID(id);
        }

        protected override List<clsAttendance> GetAll()
        {
            var list = new List<clsAttendance>();
            var models = _service.GetAllAttendances();

            foreach (var att in models)
            {
                if (att != null)
                    list.Add(new clsAttendance(att));
            }

            return list;
        }

        public static List<clsAttendance> GetAllAttendances()
        {
            return new clsAttendance().GetAll();
        }

        protected override bool _Add()
        {
            var model = ToModel();
            model.AttendanceID = _service.AddAttendance(model);

            if (model.AttendanceID == -1)
            {
                _ErrorMessages.Add(_ErrorStart + "Failed to add attendance.");
                return false;
            }

            FromModel(model);
            return true;
        }

        protected override bool _Update()
        {
            var model = ToModel();
            if (_service.UpdateAttendance(model))
            {
                FromModel(model);
                return true;
            }

            _ErrorMessages.Add(_ErrorStart + "Failed to update attendance.");
            return false;
        }
    }
}
