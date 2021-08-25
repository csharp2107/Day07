using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new DBSchoolContext())
            {
                Console.WriteLine(ctx.Grades.Count() ); 
            }
        }
    }
}
