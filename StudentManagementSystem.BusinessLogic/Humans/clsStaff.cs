using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.DataAccess.Models;
using StudentManagementSystem.DataAccess.Services;

namespace StudentManagementSystem.BusinessLogic.Humans
{
    public class clsStaff : clsBase<clsStaff>
    {
        private readonly StaffService _staffService = new StaffService();
        public int PersonID { get; set; }
        public string StaffNumber { get; set; }
        public string Position { get; set; }
        public DateTime HireDate { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }

        public clsStaff()
        {
            IsNew = true;
        }

        private clsStaff(Staff staff)
        {
            this.ModelStaffToclsStaff(staff);
            IsNew = false;
        }

        protected override bool DeleteByID(int id)
        {
            return _staffService.DeleteStaff(id);
        }

        public static bool Delete(int id)
        {
            return new clsStaff().DeleteByID(id);
        }

        protected override clsStaff GetByID(int id)
        {
            Staff staff = _staffService.GetStaffById(id);

            if(staff == null)
                return null;

            clsStaff Staff = new clsStaff(staff);

            return Staff;
        }

        public static clsStaff Find(int id)
        {
            return new clsStaff().GetByID(id);
        }

        protected override List<clsStaff> GetAll()
        {
            List<Staff> modelStaffs = _staffService.GetAllStaffs();

            if (modelStaffs == null)
                return new List<clsStaff>();

            if (modelStaffs.Count == 0)
                return new List<clsStaff>();

            List<clsStaff> StaffList = new List<clsStaff>();

            for (int i = 0; i < modelStaffs.Count; i++)
            {
                Staff staff = modelStaffs[i];

                if (staff == null)
                    continue;

                clsStaff clsStaff = new clsStaff(staff);
                StaffList.Add(clsStaff);
            }

            return StaffList;
        }

        public static List<clsStaff> GetAllStaff()
        {
            return new clsStaff().GetAll();
        }

        private Staff clsStaffToModelStaff()
        {
            return new Staff
            {
                StaffID = this.ID,
                PersonID = this.PersonID,
                StaffNumber = this.StaffNumber,
                Position = this.Position,
                HireDate = this.HireDate,
                Department = this.Department,
                Salary = this.Salary,
            };
        }

        public override bool Validate()
        {
            _ErrorMessages.Clear();
            _ErrorMessages = StaffService.StaffValidationBasic(clsStaffToModelStaff());
            return !_ErrorMessages.Any();
        }

        private void ModelStaffToclsStaff(Staff staff)
        {
            //public int PersonID { get; set; }
            //public string StaffNumber { get; set; }
            //public string Position { get; set; }
            //public DateTime HireDate { get; set; }
            //public string Department { get; set; }
            //public decimal Salary { get; set; }

            this._id = staff.StaffID;
            this.PersonID = staff.PersonID;
            this.StaffNumber = staff.StaffNumber;
            this.Position = staff.Position;
            this.HireDate = staff.HireDate ?? DateTime.MinValue;
            this.Department = staff.Department;
            this.Salary = staff.Salary ?? -1;
        }

        protected override bool _Add()
        {
            Staff staff = clsStaffToModelStaff();

            staff.StaffID = _staffService.AddStaff(staff);

            if(staff.StaffID == -1)
            {
                _ErrorMessages.Add(_ErrorStart + "Faild To add Staff.");
                return false;
            }

            ModelStaffToclsStaff(staff);

            return true;
        }

        protected override bool _Update()
        {
            Staff staff = clsStaffToModelStaff();

            if(_staffService.UpdateStaff(staff))
            {
                ModelStaffToclsStaff(staff);
                return true;
            }
            else
            {
                _ErrorMessages.Add(_ErrorStart + "Failed to update Staff.");
                return false;
            }

            throw new NotImplementedException();
        }
    }
}
