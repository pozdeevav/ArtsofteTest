using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1
{
    public class DataBaseContext : DbContext
    {
        public DbSet<EmployeesModel> employees { get; set; }

        public DbSet<DepartamentsModel> departaments { get; set; }

        public DbSet<ProgrammingLanguagesModel> programmingLanguages { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
