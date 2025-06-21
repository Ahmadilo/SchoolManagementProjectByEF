using StudentManagementSystem.DataAccess.DatabaseContext;
using StudentManagementSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem.DataAccess.Services
{
    public partial class PeopleService
    {
        // إضافة شخص جديد
        public int AddPerson(Person person)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    db.People.Add(person);
                    db.SaveChanges();
                    return person.PersonID;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        // تعديل بيانات شخص
        public bool UpdatePerson(Person person)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var existing = db.People.FirstOrDefault(p => p.PersonID == person.PersonID);
                    if (existing == null) return false;

                    // تحديث الحقول
                    existing.UserID = person.UserID;
                    existing.FirstName = person.FirstName;
                    existing.LastName = person.LastName;
                    existing.DateOfBirth = person.DateOfBirth;
                    existing.Gender = person.Gender;
                    existing.Email = person.Email;
                    existing.Phone = person.Phone;
                    existing.Address = person.Address;
                    existing.Photo = person.Photo;

                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        // حذف شخص
        public bool DeletePerson(int personId)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var person = db.People.FirstOrDefault(p => p.PersonID == personId);
                    if (person == null) return false;

                    db.People.Remove(person);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        // جلب شخص واحد
        public Person GetPersonById(int personId)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.People.Include("User").FirstOrDefault(p => p.PersonID == personId);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool ChickUserId(int PersonID)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var person = db.People.FirstOrDefault(p => p.PersonID == PersonID);
                    if (person == null) return false;

                    return person.UserID.HasValue && person.UserID > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        // جلب كل الأشخاص
        public List<Person> GetAllPeople()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.People.Include("User").ToList();
                }
            }
            catch (Exception)
            {
                return new List<Person>();
            }
        }
    }
}
