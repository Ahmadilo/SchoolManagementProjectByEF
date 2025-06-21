using StudentManagementSystem.DataAccess.DatabaseContext;
using StudentManagementSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem.DataAccess.Services
{
    public partial class PeopleService
    {
        private static string ErrorStart = "Validation Error: ";

        private static List<string> ValidateFirstName(string firstName)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(firstName))
                errors.Add(ErrorStart + "First Name is required.");
            else if (firstName.Length > 50)
                errors.Add(ErrorStart + "First Name must be 50 characters or less.");

            return errors;
        }

        private static List<string> ValidateLastName(string lastName)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(lastName))
                errors.Add(ErrorStart + "Last Name is required.");
            else if (lastName.Length > 50)
                errors.Add(ErrorStart + "Last Name must be 50 characters or less.");

            return errors;
        }

        private static List<string> ValidateEmail(string email)
        {
            var errors = new List<string>();

            if (!string.IsNullOrWhiteSpace(email) && email.Length > 100)
                errors.Add(ErrorStart + "Email must be 100 characters or less.");

            return errors;
        }

        private static List<string> ValidatePhone(string phone)
        {
            var errors = new List<string>();

            if (!string.IsNullOrWhiteSpace(phone) && phone.Length > 20)
                errors.Add(ErrorStart + "Phone must be 20 characters or less.");

            return errors;
        }

        private static List<string> ValidateAddress(string address)
        {
            var errors = new List<string>();

            if (!string.IsNullOrWhiteSpace(address) && address.Length > 200)
                errors.Add(ErrorStart + "Address must be 200 characters or less.");

            return errors;
        }

        private static List<string> ValidateDateOfBirth(DateTime? dob)
        {
            var errors = new List<string>();

            if (dob.HasValue && dob.Value > DateTime.Today)
                errors.Add(ErrorStart + "Date of Birth cannot be in the future.");

            return errors;
        }

        private static List<string> ValidateGender(string gender)
        {
            var errors = new List<string>();

            if (!string.IsNullOrWhiteSpace(gender) && gender.Length > 10)
                errors.Add(ErrorStart + "Gender must be 10 characters or less.");

            return errors;
        }

        private static List<string> ValidateUserID(int? userId)
        {
            var errors = new List<string>();

            if (userId.HasValue)
            {
                if (userId.Value <= 0)
                    errors.Add(ErrorStart + "User ID must be greater than zero.");
                else if (!new UserService().ChickUserId(userId.Value))
                    errors.Add(ErrorStart + "User ID does not exist.");
            }

            return errors;
        }

        public static List<string> PersonValidationBasic(Person person)
        {
            var errors = new List<string>();

            errors.AddRange(ValidateFirstName(person.FirstName));
            errors.AddRange(ValidateLastName(person.LastName));
            errors.AddRange(ValidateDateOfBirth(person.DateOfBirth));
            errors.AddRange(ValidateGender(person.Gender));
            errors.AddRange(ValidateEmail(person.Email));
            errors.AddRange(ValidatePhone(person.Phone));
            errors.AddRange(ValidateAddress(person.Address));
            errors.AddRange(ValidateUserID(person.UserID));

            return errors;
        }
    }
}
