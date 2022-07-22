using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Base;

namespace DataAccess.Repositories.Implementations
{
    public class StudentRepository : IRepository<Student>
    {

        public Student Create(Student entity)
        {
            DbContext.Students.Add(entity);
            return entity;
        }
        public void Delete(Student entity)
        {
            DbContext.Students.Remove(entity);
        }

        public void Update(Student entity)
        {
            var student = DbContext.Students.Find(g => g.Id == entity.Id);
            if (student != null)
            {
                student.Name = entity.Name;
                student.Surname = entity.Surname;
            }
        }
        public Student Get(Predicate<Student> filter = null)
        {
            if (filter == null)
            {
                return DbContext.Students[0];
            }
            else
            {
                return DbContext.Students.Find(filter);
            }
        }

        public List<Student> GetAll(Predicate<Student> filter = null)
        {
            if (filter == null)
            {
                return DbContext.Students;
            }
            else
            {
                return DbContext.Students.FindAll(filter);
            }
        }
    }

}
