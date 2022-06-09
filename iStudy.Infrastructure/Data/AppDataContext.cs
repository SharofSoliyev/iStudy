using iStudy.Core.Constants;
using iStudy.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iStudy.Infrastructure.Data
{
    public class AppDataContext : DbContext
    {

        public DbSet<STUDENTS> Students { get; set; }
        
        public DbSet<CITIES> Cities { get; set; }

        public DbSet<DEPARTMENTS> Departments { get; set; }

        public DbSet<STUDENTS_SUBJECTS> Student_Subjects { get; set; }
        
        public DbSet<SUBJECTS> Subjects { get; set; }

        public DbSet<TEACHERS> Teachers { get; set; }

        public DbSet<TEACHERS_SUBJECTS> Teachers_Subjects { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={Variables.DatabaseUrl}");
        }

    }
}
