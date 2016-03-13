using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SES.Domain.Entities;

namespace SES.Domain.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
        IQueryable<Course> Courses { get; }
    }
}
