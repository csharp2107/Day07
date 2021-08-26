using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace EntityFrameworkCodeFirst
{
    class StudentConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentConfiguration()
        {
            this.HasOptional(s => s.Address).WithRequired(sa => sa.Student);

            this.Property(s => s.StudentName).IsRequired().HasMaxLength(50);
        }
    }
}
