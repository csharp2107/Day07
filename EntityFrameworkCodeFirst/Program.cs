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
                Console.WriteLine("starting...");
                int _count = ctx.Grades.Count();
                foreach (var grade in ctx.Grades)
                {
                    Console.WriteLine($"{grade.GradeID}, {grade.SchoolSubject}, {grade.GradeValue}");
                }

                // creating Student entity
                var student = new Student()
                {
                    StudentName = "John Smith",
                    DateOfBirth = new DateTime(2000, 01, 01)
                };
                ctx.Students.Add(student);


                student = new Student()
                {
                    StudentName = "Ana Smith",
                    DateOfBirth = new DateTime(2001, 04, 01)
                };
                ctx.Students.Add(student);

                ctx.SaveChanges();

                Console.ReadKey();

                
            }
        }
    }
}
