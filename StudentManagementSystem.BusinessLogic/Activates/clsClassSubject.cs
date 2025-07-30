using StudentManagementSystem.BusinessLogic.Assets;
using StudentManagementSystem.BusinessLogic.Humans;
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
        private clsSchoolClass _schoolclass = null;
        private clsTeacher _teacher = null;
        private clsSubject _subject = null;
        public int ClassID { get; set; }
        public clsSchoolClass SchoolClass
        {
            get
            {
                if( _schoolclass == null )
                {
                    _schoolclass = clsSchoolClass.Find(ClassID);
                    return _schoolclass;
                }

                return _schoolclass;
            }
        }
        public int SubjectID { get; set; }
        public clsSubject Subject
        {
            get
            {
                if(_subject == null)
                {
                    _subject = clsSubject.Find(SubjectID);
                    return _subject;
                }

                return _subject;
            }
        }
        public int TeacherID { get; set; }
        public clsTeacher Teacher
        {
            get
            {
                if(_teacher == null)
                {
                    _teacher = clsTeacher.Find(TeacherID);
                    return _teacher;
                }

                return _teacher;
            }
        }
        public string ScheduleDay { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string RoomNumber { get; set; }

        public List<clsGrade> Marks 
        {
            get
            {
                return clsGrade.GetAllGrades().Where(g => g.ClassSubjectID == this.ID).ToList();
            }
        }

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

        public static List<clsClassSubject> GetAllClassSubjects(Func<clsClassSubject, bool> func)
        {
            return GetAllClassSubjects().Where(func).ToList();
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
