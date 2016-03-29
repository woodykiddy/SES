using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SES.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        T Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveDbChanges();
        void DisposeDbContext();

        #region async calls
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveDbChangesAsync();
        #endregion
    }
}
