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
            Database.SetInitializer<DBSchoolContext>(null);
        }
    }
}
