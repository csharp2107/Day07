using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EntityFrameworkCodeFirst
{
    class DBSchoolContext : DbContext 
    {
        // initializing db connection with connection string
        public DBSchoolContext() : base("CSDBSchool")
        {
            //TODO: set initializer for db strategy
            Database.SetInitializer<DBSchoolContext>(new DBSchoolInit());
        }

        // declare entities in the db context
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
