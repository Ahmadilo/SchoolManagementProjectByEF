using StudentManagementSystem.DataAccess.Models;
using StudentManagementSystem.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem.BusinessLogic.Activates
{
    public class clsClassSubject : clsBase<clsClassSubject>
    {
        private readonly ClassSubjectService _service = new ClassSubjectService();

        public int ClassID { get; set; }
        public int SubjectID { get; set; }
        public int TeacherID { get; set; }
        public string ScheduleDay { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string RoomNumber { get; set; }

        public clsClassSubject()
        {
            IsNew = true;
        }

        private clsClassSubject(ClassSubject model)
        {
            FromModel(model);
            IsNew = false;
        }

        private void FromModel(ClassSubject model)
        {
            _id = model.ClassSubjectID;
            ClassID = model.ClassID;
            SubjectID = model.SubjectID;
            TeacherID = model.TeacherID;
            ScheduleDay = model.ScheduleDay;
            StartTime = model.StartTime;
            EndTime = model.EndTime;
            RoomNumber = model.RoomNumber;
        }

        private ClassSubject ToModel()
        {
            return new ClassSubject
            {
                ClassSubjectID = _id,
                ClassID = this.ClassID,
                SubjectID = this.SubjectID,
                TeacherID = this.TeacherID,
                ScheduleDay = this.ScheduleDay,
                StartTime = this.StartTime,
                EndTime = this.EndTime,
                RoomNumber = this.RoomNumber
            };
        }

        public override bool Validate()
        {
            _ErrorMessages.Clear();
            _ErrorMessages = ClassSubjectService.ValidateClassSubject(ToModel());
            return !_ErrorMessages.Any();
        }

        protected override bool DeleteByID(int id)
        {
            return _service.DeleteClassSubject(id);
        }

        public static bool Delete(int id)
        {
            return new clsClassSubject().DeleteByID(id);
        }

        protected override clsClassSubject GetByID(int id)
        {
            var model = _service.GetClassSubjectById(id);
            return model == null ? null : new clsClassSubject(model);
        }

        public static clsClassSubject Find(int id)
        {
            return new clsClassSubject().GetByID(id);
        }

        protected override List<clsClassSubject> GetAll()
        {
            var list = new List<clsClassSubject>();
            var models = _service.GetAllClassSubjects();

            foreach (var cs in models)
            {
                if (cs != null)
                    list.Add(new clsClassSubject(cs));
            }

            return list;
        }

        public static List<clsClassSubject> GetAllClassSubjects()
        {
            return new clsClassSubject().GetAll();
        }

        protected override bool _Add()
        {
            var model = ToModel();
            model.ClassSubjectID = _service.AddClassSubject(model);

            if (model.ClassSubjectID == -1)
            {
                _ErrorMessages.Add(_ErrorStart + "Failed to add class subject.");
                return false;
            }

            FromModel(model);
            return true;
        }

        protected override bool _Update()
        {
            var model = ToModel();
            if (_service.UpdateClassSubject(model))
            {
                FromModel(model);
                return true;
            }

            _ErrorMessages.Add(_ErrorStart + "Failed to update class subject.");
            return false;
        }
    }
}
