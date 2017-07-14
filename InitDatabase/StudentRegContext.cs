using DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitDatabase
{
    public class StudentRegContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<SysAdmin> SysAdmins { get; set; }
        public DbSet<StudentAcc> StudentAccs { get; set; }
        public DbSet<Specialty> Specialtys { get; set; }
        public DbSet<Period_Category> Period_Categorys { get; set; }
    }
}
