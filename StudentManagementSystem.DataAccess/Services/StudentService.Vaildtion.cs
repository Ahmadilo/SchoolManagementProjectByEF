using StudentManagementSystem.DataAccess.DatabaseContext;
using StudentManagementSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.DataAccess.Services
{
	public partial class StudentService
	{
		private static string ErrorStart = "Validation Error: ";

		private static List<string> ValidateEnrollmentNumber(string enrollmentNumber, int StudentID)
		{
			var errors = new List<string>();

			if (!string.IsNullOrWhiteSpace(enrollmentNumber))
			{
				if (enrollmentNumber.Length > 20)
					errors.Add(ErrorStart + "Enrollment Number must be 20 characters or less.");

				if (IsEnrollmentNumberTaken(enrollmentNumber, StudentID))
					errors.Add(ErrorStart + "Enrollment Number already exists.");
			}

			return errors;
		}

		private static List<string> ValidateEnrollmentDate(DateTime? enrollmentDate)
		{
			var errors = new List<string>();

			if (enrollmentDate.HasValue && enrollmentDate.Value >= DateTime.Now)
				errors.Add(ErrorStart + "Enrollment Date cannot be in the future.");

			return errors;
		}

		private static List<string> ValidatePersonID(int personId)
		{
			var errors = new List<string>();

			if (personId <= 0)
			{
				errors.Add(ErrorStart + "Person ID must be greater than 0.");
			}
			else if (!PersonExists(personId))
			{
				errors.Add(ErrorStart + "Person does not exist.");
			}

			return errors;
		}

		private static List<string> ValidateParentID(int? parentId)
		{
			var errors = new List<string>();

			if (parentId.HasValue && parentId.Value > 0 && !PersonExists(parentId.Value))
			{
				errors.Add(ErrorStart + "Parent does not exist.");
			}

			return errors;
		}

		private static List<string> ValidateGradeLevel(int? grade)
		{
			var errors = new List<string>();

			if (grade.HasValue && (grade < 1 || grade > 12))
			{
				errors.Add(ErrorStart + "Grade level must be between 1 and 12.");
			}

			return errors;
		}

		public static List<string> StudentValidationBasic(Student student)
		{
			var errors = new List<string>();

			errors.AddRange(ValidatePersonID(student.PersonID));
			errors.AddRange(ValidateEnrollmentNumber(student.EnrollmentNumber, student.StudentID));
			errors.AddRange(ValidateEnrollmentDate(student.EnrollmentDate));
			errors.AddRange(ValidateParentID(student.ParentID));
			errors.AddRange(ValidateGradeLevel(student.CurrentGradeLevel));

			return errors;
		}

		// فحص التكرار
		public static bool IsEnrollmentNumberTaken(string enrollmentNumber, int id = -1)
		{
			return IsEnrollmentNumberUnick(enrollmentNumber, id);
		}

		// فحص وجود الشخص
		private static bool PersonExists(int personId)
		{
			using (var context = new AppDbContext())
			{
				return context.People.Any(p => p.PersonID == personId);
			}
		}
	}
}
