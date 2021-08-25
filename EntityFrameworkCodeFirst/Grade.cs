using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirst
{
    class Grade
    {
        public int GradeID { get; set; }
        public int GradeValue { get; set; }
        public string SchoolSubject { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
