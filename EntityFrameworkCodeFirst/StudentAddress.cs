using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirst
{
    class StudentAddress
    {
        public int StudentAddressID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        // relation to Student class
        public virtual Student Student { get; set; }
    }
}
