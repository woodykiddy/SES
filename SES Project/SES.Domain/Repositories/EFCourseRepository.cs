using SES.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SES.Domain.Entities;
using SES.Domain.DatabaseContext;
using System.Data.Entity;

namespace SES.Domain.Repositories
{
    public class EFCourseRepository : IRepository<Course>
    {
        private EFDBContext efDbContext = new EFDBContext();
        
        public Course Create(Course entity)
        {
            efDbContext.Courses.Add(entity);
            SaveDbChanges();
            return entity;
        }

        public async Task<Course> CreateAsync(Course entity)
        {
            efDbContext.Courses.Add(entity);
            await SaveDbChangesAsync();
            return entity;
        }

        public void Update(Course entity)
        {
            efDbContext.Entry(entity).State = EntityState.Modified;
            SaveDbChanges();
        }

        public async Task UpdateAsync(Course entity)
        {
            efDbContext.Entry(entity).State = EntityState.Modified;
            await SaveDbChangesAsync();
        }

        public void Delete(Course entity)
        {
            efDbContext.Courses.Remove(entity);
            SaveDbChanges();
        }

        public async Task DeleteAsync(Course entity)
        {
            efDbContext.Courses.Remove(entity);
            await SaveDbChangesAsync();
        }

        public Course GetById(int id)
        {
            return efDbContext.Courses.Find(id);
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            return await efDbContext.Courses.FindAsync(id);
        }

        public IQueryable<Course> GetAll()
        {
            return efDbContext.Courses;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await efDbContext.Courses.ToListAsync();
        }

        public void SaveDbChanges()
        {
            efDbContext.SaveChanges();
        }

        public async Task SaveDbChangesAsync()
        {
            await efDbContext.SaveChangesAsync();
        }

        public void DisposeDbContext()
        {
            efDbContext.Dispose();
        }
    }
}
