using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Entity;

namespace Labo1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new StudentDbEntities())
            {

                // Display all Blogs from the database 
                var query = from studentCourse in db.StudentCourses
                            join student in db.Students on studentCourse.StudentId equals student.Id
                            join course in db.Courses on studentCourse.CourseId equals course.Id
                            select new {student, courseName = course.Description};
                /*
                var studentQuery = from student in db.Students
                                   select student;*/

                Console.WriteLine("All students in the database:");
                string sauveNom = "";
                foreach (var item in query)
                {
                     if(sauveNom != item.student.FullName)
                    {
                        Console.WriteLine(item.student.FullName + ", " + item.student.Birthday + ", " + item.student.Remark + ", Liste des cours :");
                        sauveNom = item.student.FullName;
                    }
                    Console.WriteLine("\t"+item.courseName);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
