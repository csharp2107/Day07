using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirst
{
    class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public byte[] Photo { get; set; }

        // virtual property with relations
        public virtual ICollection<Grade> Grades { get; set; }

        public virtual StudentAddress Address { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
