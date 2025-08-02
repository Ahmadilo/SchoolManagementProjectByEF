using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.DataAccess.Models;
using StudentManagementSystem.DataAccess.Services;

namespace StudentManagementSystem.BusinessLogic.Humans
{
    public class clsPerson : clsBase<clsPerson>
    {
        private readonly PeopleService _peopleService = new PeopleService();
        public int? UserID { get; set; } = null;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public byte[] Photo { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        public clsPerson()
        {
            IsNew = true;
        }

        private clsPerson(Person person)
        {
            this.ModelPersonToclsPerson(person);
            IsNew = false;
        }

        protected override bool DeleteByID(int id)
        {
            return _peopleService.DeletePerson(id);
        }

        public static bool Delete(int id)
        {
            return new clsPerson().DeleteByID(id);
        }

        protected override clsPerson GetByID(int id)
        {
            Person person = _peopleService.GetPersonById(id);

            if (person == null)
            {
                return null;
            }

            clsPerson Person = new clsPerson(person);

            return Person;
        }

        public static clsPerson Find(int id)
        {
            return new clsPerson().GetByID(id);
        }

        protected override List<clsPerson> GetAll()
        {
            List<Person> ModelPersons = _peopleService.GetAllPeople();

            if (ModelPersons == null)
                return new List<clsPerson>();

            if (ModelPersons.Count == 0)
                return new List<clsPerson>();

            List<clsPerson> PersonList = new List<clsPerson>();

            for(int i = 0; i < ModelPersons.Count; i++)
            {
                Person person = ModelPersons[i];

                if (person == null)
                    continue;

                clsPerson Person = new clsPerson(person);

                PersonList.Add(Person);
            }

            return PersonList;
        }

        public static List<clsPerson> GetAllPeople()
        {
            return new clsPerson().GetAll();
        }

        private Person clsPersonToModelPerson()
        {
            return new Person
            {
                PersonID = this.ID,
                UserID = this.UserID,
                FirstName = this.FirstName,
                LastName = this.LastName,
                DateOfBirth = this.DateOfBirth,
                Gender = this.Gender,
                Email = this.Email,
                Phone = this.PhoneNumber,
                Address = this.Address,
                Photo = this.Photo
            };
        }

        public override bool Validate()
        {
            _ErrorMessages.Clear();
            _ErrorMessages = PeopleService.PersonValidationBasic(clsPersonToModelPerson());
            return !_ErrorMessages.Any();
        }

        private void ModelPersonToclsPerson(Person person)
        {
            //public int UserID { get; set; }
            //public string FirstName { get; set; }
            //public string LastName { get; set; }
            //public DateTime DateOfBirth { get; set; }
            //public string Gender { get; set; }
            //public string Email { get; set; }
            //public string PhoneNumber { get; set; }
            //public string Address { get; set; }
            //public byte[] Photo { get; set; }

            this._id = person.PersonID;
            this.UserID = person.UserID; // Assuming UserID can be nullable
            this.FirstName = person.FirstName;
            this.LastName = person.LastName;
            this.DateOfBirth = person.DateOfBirth ?? DateTime.MinValue;
            this.Gender = person.Gender;
            this.Email = person.Email;
            this.PhoneNumber = person.Phone;
            this.Address = person.Address;
            this.Photo = person.Photo;
        }

        protected override bool _Add()
        {
            Person person = clsPersonToModelPerson();

            person.PersonID = _peopleService.AddPerson(person);

            if(person.PersonID == -1)
            {
                _ErrorMessages.Add(_ErrorStart + "Failed to add person. Please check the data and try again.");
                return false;
            }

            ModelPersonToclsPerson(person);

            return true;
        }

        protected override bool _Update()
        {
            Person person = clsPersonToModelPerson();

            if(_peopleService.UpdatePerson(person))
            {
                ModelPersonToclsPerson(person);
                return true;
            }
            else
            {
                _ErrorMessages.Add(_ErrorStart + "Failed to update person. Please check the data and try again.");
                return false;
            }

            throw new NotImplementedException();
        }

        public static clsPerson FindByUserID(int UserId)
        {
            if(UserId <= 0)
            {
                return null;
            }

            Person person = new PeopleService().GetPersonByExpreesion(p => p.UserID == UserId);

            if (person == null)
            {
                return null;
            }

            return new clsPerson(person);
        }
    }
}
