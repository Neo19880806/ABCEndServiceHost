using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ABCEndServiceLib.DB;
using ABCEndServiceLib.Model;

namespace ABCEndServiceLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DBService" in both code and config file together.
    public class DBService : IDBService
    {
        public List<Course> GetAllCourses()
        {
            List<Course> list = new List<Course>();
            TafeDBEntities context = new TafeDBEntities();
            foreach (var tblCourse in context.tblCourses)
            {
                Course c = new Course
                {
                    CourseID = tblCourse.CourseID,
                    CourseName = tblCourse.CourseName,
                    Cost = tblCourse.Cost??0
                };
                list.Add(c);
            }
            return list;
        }

        public List<Student> GetAllStudents()
        {
            List<Student> list = new List<Student>();
            TafeDBEntities context = new TafeDBEntities();
            foreach(var tblStudent in context.tblStudents)
            {
                Student s = new Student
                {
                    StudentID = tblStudent.StudentID,
                    StduentName = tblStudent.StduentName,
                    DateEnrolled = tblStudent.DateEnrolled??DateTime.Now
                };
                list.Add(s);
            }
            return list;
        }

        public List<Course> GetEnrollmentsForStudent(string studentId)
        {
            List<Course> list = new List<Course>();
            TafeDBEntities context = new TafeDBEntities();
            var results = context.tblEnrollments.Where(e => e.StudentID == studentId).ToList();
            foreach (var tblEnrollment in results)
            {
                var tblCourse = context.tblCourses.Where(v=>v.CourseID == tblEnrollment.CourseID).FirstOrDefault();
                Course c = new Course
                {
                    CourseID = tblCourse.CourseID,
                    CourseName = tblCourse.CourseName,
                    Cost = tblCourse.Cost??0
                };
                list.Add(c);
            }
            return list;
        }

        public List<Student> getStudentsEnrolledInCourse(string courseId)
        {
            List<Student> list = new List<Student>();
            TafeDBEntities context = new TafeDBEntities();
            var results = context.tblEnrollments.Where(e => e.CourseID == courseId).ToList();

            foreach (var tblEnrollment in results)
            {
                var tblStudent = context.tblStudents.Where(v => v.StudentID == tblEnrollment.StudentID).FirstOrDefault();
                Student s = new Student
                {
                    StudentID = tblStudent.StudentID,
                    StduentName= tblStudent.StduentName,
                    DateEnrolled = tblStudent.DateEnrolled??DateTime.Now
                };
                list.Add(s);
            }
            return list;
        }

        public int InsertACourse(Course c)
        {
            TafeDBEntities context = new TafeDBEntities();
            context.tblCourses.Add(new tblCourse
            { CourseName = c.CourseName,
              CourseID = c.CourseID,
              Cost = c.Cost
            });
            int result = context.SaveChanges();
            return result;
        }

        public int InsertAStudent(Student s)
        {
            TafeDBEntities context = new TafeDBEntities();
            context.tblStudents.Add(new tblStudent
            {
                StudentID = s.StudentID,
                StduentName = s.StduentName,
                DateEnrolled = s.DateEnrolled
            });
            int result = context.SaveChanges();
            return result;
        }

        public int InsertEnrolment(Enrollment e)
        {
            TafeDBEntities context = new TafeDBEntities();
            context.tblEnrollments.Add(new tblEnrollment
            {
                StudentID = e.StudentID,
                CourseID = e.CourseID,
                Grade = e.Grade
            });
            int result = context.SaveChanges();
            return result;
        }
    }
}
