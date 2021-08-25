using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirst
{
    class DBSchoolInit : DropCreateDatabaseAlways<DBSchoolContext>
    {

        protected override void Seed(DBSchoolContext context)
        {
            // store initial data in db
            IList<Grade> grades = new List<Grade>();
            for (int i = 1; i <=6; i++)
            {
                grades.Add(new Grade() { SchoolSubject = "Math", GradeValue = i });
                grades.Add(new Grade() { SchoolSubject = "CS", GradeValue = i });
            }
            context.Grades.AddRange(grades);

            base.Seed(context);
        }

    }
}
