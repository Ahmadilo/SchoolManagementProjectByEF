using StudentManagementSystem.BusinessLogic.Assets;
using StudentManagementSystem.BusinessLogic.Humans;
using StudentManagementSystem.DataAccess.Models;
using StudentManagementSystem.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem.BusinessLogic.Activates
{
    public class clsStudentClass : clsBase<clsStudentClass>
    {
        private readonly StudentClassService _service = new StudentClassService();
        private clsStudent _student = null;
        private clsSchoolClass _class = null;

        public int StudentID { get; set; }
        public int ClassID { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public clsStudent Student { get => clsPublic.GetInstansOfID(ID: StudentID, obj: _student); }
        public clsSchoolClass Class { get => clsPublic.GetInstansOfID(ID: ClassID, obj: _class); }

        public clsStudentClass()
        {
            IsNew = true;
            EnrollmentDate = DateTime.Now;
        }

        private clsStudentClass(StudentClass model)
        {
            FromModel(model);
            IsNew = false;
        }

        private void FromModel(StudentClass model)
        {
            this._id = model.StudentClassID;
            this.StudentID = model.StudentID;
            this.ClassID = model.ClassID;
            this.EnrollmentDate = model.EnrollmentDate;
        }

        private StudentClass ToModel()
        {
            return new StudentClass
            {
                StudentClassID = _id,
                StudentID = this.StudentID,
                ClassID = this.ClassID,
                EnrollmentDate = this.EnrollmentDate
            };
        }

        public override bool Validate()
        {
            _ErrorMessages.Clear();
            _ErrorMessages = StudentClassService.ValidateStudentClass(ToModel());
            return !_ErrorMessages.Any();
        }

        protected override bool DeleteByID(int id)
        {
            return _service.DeleteStudentClass(id);
        }

        public static bool Delete(int id)
        {
            return new clsStudentClass().DeleteByID(id);
        }

        protected override clsStudentClass GetByID(int id)
        {
            var model = _service.GetStudentClassById(id);
            return model == null ? null : new clsStudentClass(model);
        }

        public static clsStudentClass Find(int id)
        {
            return new clsStudentClass().GetByID(id);
        }

        protected override List<clsStudentClass> GetAll()
        {
            var models = _service.GetAllStudentClasses();
            var list = new List<clsStudentClass>();

            foreach (var model in models)
            {
                if (model != null)
                    list.Add(new clsStudentClass(model));
            }

            return list;
        }

        public static List<clsStudentClass> GetAllStudentClasses()
        {
            return new clsStudentClass().GetAll();
        }

        public static List<clsStudentClass> GetAllStudentClasses(Func<clsStudentClass, bool> func)
        {
            return GetAllStudentClasses().Where(func).ToList();
        }

        protected override bool _Add()
        {
            clsStudent Student = clsStudent.Find(StudentID);

            Student.CurrentGradeLevel = clsSchoolClass.Find(ClassID).GradeLevel;
            Student.Save();

            var model = ToModel();
            model.StudentClassID = _service.AddStudentClass(model);

            if (model.StudentClassID == -1)
            {
                _ErrorMessages.Add(_ErrorStart + "Failed to add StudentClass.");
                return false;
            }

            FromModel(model);
            return true;
        }

        protected override bool _Update()
        {
            var model = ToModel();
            if (_service.UpdateStudentClass(model))
            {
                FromModel(model);
                return true;
            }

            _ErrorMessages.Add(_ErrorStart + "Failed to update StudentClass.");
            return false;
        }
    }
}
