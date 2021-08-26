using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
                Console.WriteLine("Grades about CS");
                var gradesCS = ctx.Grades.Where(x => x.SchoolSubject.Equals("CS"));
                foreach (var grade in gradesCS)
                {
                    Console.WriteLine($"{grade.GradeID}, {grade.SchoolSubject}, {grade.GradeValue}");
                }

                // creating simple Student entity
                var student = new Student()
                {
                    StudentName = "John Smith",
                    DateOfBirth = new DateTime(2000, 01, 01)
                };
                ctx.Students.Add(student);

                // creating Student entity with some grade
                // adding 2 grades: Math-3 , CS-5
                student = new Student()
                {
                    StudentName = "Ana Smith",
                    DateOfBirth = new DateTime(2001, 04, 01),                    
                };
                // Math-3
                Grade gradeMath3 = ctx.Grades.Where(x => x.SchoolSubject.Equals("Math") 
                                        && x.GradeValue == 3).First();
                // CS-5
                Grade gradCS5 = ctx.Grades.Where(x => x.SchoolSubject.Equals("CS")
                                        && x.GradeValue == 5).First();
                student.Grades = new List<Grade>();
                if (gradeMath3!=null)
                    student.Grades.Add(gradeMath3);
                if (gradCS5!=null) 
                    student.Grades.Add(gradCS5);
                ctx.Students.Add(student);

                ctx.SaveChanges(); // store changes to db

                // SQL raw command execution
                var studentList = ctx.Students.SqlQuery("SELECT * FROM Students").ToList<Student>();
                foreach (var st in studentList)
                {
                    Console.WriteLine($"{st.StudentID}, {st.StudentName}");
                }

                int studentId = 10;
                String sql = "SELECT StudentName FROM Students WHERE StudentID=" + studentId;
                //string studName = ctx.Database.
                //    SqlQuery<String>("SELECT StudentName FROM Students WHERE StudentID=1 ").FirstOrDefault();
                string studName = ctx.Database.
                    SqlQuery<String>("SELECT StudentName FROM Students WHERE StudentID=@id", 
                    new SqlParameter("@id",1) ).
                    FirstOrDefault();

                Console.WriteLine($"Student name: {studName}");

                // update DOB for Student with StudentID=1
                student = ctx.Students.Find(1);
                student.DateOfBirth = new DateTime(2002, 12, 12);
                ctx.Entry(student).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();

                // delete Student entity with StudentID=2
                student = ctx.Students.Find(2);
                //ctx.Entry(student).State = System.Data.Entity.EntityState.Deleted;
                ctx.Students.Remove(student);
                ctx.SaveChanges();
                

                ctx.Database.Connection.Close();

                Console.ReadKey();

            }
        }
    }
}
