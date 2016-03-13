using SES.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SES.Domain.Entities;
using SES.Domain.DatabaseContext;

namespace SES.Domain.Repositories
{
    public class EFCourseRepository : ICourseRepository
    {
        private EFDBContext efDbContext = new EFDBContext();
        public IQueryable<Course> Courses
        {
            get
            {
                return GetAll();
            }
        }

        public Course Create(Course entity)
        {
            efDbContext.Courses.Add(entity);
            return entity;
        }

        public void Delete(Course entity)
        {
            efDbContext.Courses.Remove(entity);
        }

        public Course Get(int id)
        {
            return efDbContext.Courses.Find(id);
        }

        public IQueryable<Course> GetAll()
        {
            return efDbContext.Courses;
        }

        public void SaveDbChanges()
        {
            efDbContext.SaveChanges();
        }
    }
}
