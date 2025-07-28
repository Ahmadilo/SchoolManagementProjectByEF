using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.DataAccess.Models;
using StudentManagementSystem.DataAccess.Services;

namespace StudentManagementSystem.BusinessLogic.Humans
{
    public class clsTeacher : clsBase<clsTeacher>
    {
        private readonly TeacherService _teacherService = new TeacherService();
        public int StaffID { get; set; }
        public string SubjectSpecialization { get; set; }

        public string FullName 
        { 
            get
            {
                if (StaffID <= 0)
                    return "Unknown Teacher";

                var staff = clsStaff.Find(StaffID);

                var person = clsPerson.Find(staff?.PersonID ?? -1);

                if(person != null)
                    return person.FullName;
                return "";
            }
        }

        public clsTeacher()
        {
            IsNew = true;
        }

        public clsTeacher(Teacher teacher)
        {
            ModelTeacherToclsTeacher(teacher);
            IsNew = false;
        }

        protected override bool DeleteByID(int id)
        {
            return _teacherService.DeleteTeacher(id);
        }

        public static bool Delete(int id)
        {
            return new clsTeacher().DeleteByID(id);
        }

        protected override clsTeacher GetByID(int id)
        {
            Teacher teacher = _teacherService.GetTeacherById(id);

            if (teacher == null)
                return null;

            clsTeacher Teacher = new clsTeacher(teacher);

            return Teacher;
        }

        public static clsTeacher Find(int id)
        {
            return new clsTeacher().GetByID(id);
        }

        protected override List<clsTeacher> GetAll()
        {
            List<Teacher> modelTeachers = _teacherService.GetAllTeachers();

            if (modelTeachers == null)
                return new List<clsTeacher>();

            if (modelTeachers.Count == 0)
                return new List<clsTeacher>();

            List<clsTeacher> TeacherList = new List<clsTeacher>();

            for (int i = 0; i < modelTeachers.Count; i++)
            {
                Teacher teacher = modelTeachers[i];

                if (teacher == null)
                    continue;

                clsTeacher Teacher = new clsTeacher(teacher);

                TeacherList.Add(Teacher);
            }

            return TeacherList;
        }

        public static List<clsTeacher> GetAllTeacher()
        {
            return new clsTeacher().GetAll();
        }

        private Teacher clsTeacherToModelTeacher()
        {
            return new Teacher
            {
                TeacherID = this.ID,
                StaffID = this.StaffID,
                SubjectSpecialization = this.SubjectSpecialization
            };
        }

        public override bool Validate()
        {
            _ErrorMessages.Clear();
            _ErrorMessages = TeacherService.TeacherValidationBasic(clsTeacherToModelTeacher());
            return !_ErrorMessages.Any();
            throw new NotImplementedException();
        }

        private void ModelTeacherToclsTeacher(Teacher teacher)
        {
            // Map properties from Teacher model to clsTeacher properties
            this._id = teacher.TeacherID;
            this.StaffID = teacher.StaffID;
            this.SubjectSpecialization = teacher.SubjectSpecialization;
        }

        protected override bool _Add()
        {
            Teacher teacher = clsTeacherToModelTeacher();

            teacher.TeacherID = _teacherService.AddTeacher(teacher);

            if(teacher.TeacherID == -1)
            {
                _ErrorMessages.Add(_ErrorStart + "Faild To add Teacher.");
                return false;
            }

            ModelTeacherToclsTeacher(teacher);

            return true;
        }

        protected override bool _Update()
        {
            Teacher teacher = clsTeacherToModelTeacher();

            if(_teacherService.UpdateTeacher(teacher))
            {
                ModelTeacherToclsTeacher(teacher);
                return true;
            }
            else
            {
                _ErrorMessages.Add(_ErrorStart + "Failed to update Teacher.");
                return false;
            }
        }

        public static clsTeacher FindByUserID(int UserID)
        {
            if(UserID <= 0)
            {
                throw new ArgumentException("UserID must be greater than zero.", nameof(UserID));
            }

            Teacher teacher = new TeacherService().GetTeacherByUserID(UserID);

            if(teacher == null)
            {
                return null;
            }

            return new clsTeacher(teacher);
        }
    }
}
