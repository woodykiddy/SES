using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SES.Domain.Entities;

namespace SES.Domain.DatabaseContext
{
    public class EFDBContext : DbContext
    {
        public EFDBContext()
        {
            Database.SetInitializer<EFDBContext>(new DropCreateDatabaseIfModelChanges<EFDBContext>());
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }

        
    }
}


