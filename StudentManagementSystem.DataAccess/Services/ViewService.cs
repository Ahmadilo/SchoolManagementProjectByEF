using StudentManagementSystem.DataAccess.DatabaseContext;
using StudentManagementSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using StudentManagementSystem.DataAccess.Views;


namespace StudentManagementSystem.DataAccess.Services
{
    public static class ViewService
    {
        public static List<ClassSubjectForTeacher> GetSubjectsForTeacher(Expression<Func<ClassSubjectForTeacher, bool>> expression)
        {
            try
            {
                using(var db = new AppDbContext())
                {
                    return db.ClassSubjectsWithTeachers.Where(expression).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: \n" + ex.ToString());
                if (ex.InnerException != null)
                    Console.WriteLine("Inner Exception: \n" + ex.InnerException.ToString());
                return null;
            }
        }

        public static List<Entity> GetView<Entity>(Expression<Func<Entity, bool>> expression) where Entity : class
        {
            try
            {
                using(var db = new AppDbContext())
                {
                    return db.Set<Entity>().Where(expression).ToList();
                }
            }
            catch(Exception e)
            {
                Logger.LogError(ExceptionHelper.GetRootException(e).Message);
                return new List<Entity>();
            }
        }
    }
}
