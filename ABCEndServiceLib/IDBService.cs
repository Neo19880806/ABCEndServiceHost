using ABCEndServiceLib.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ABCEndServiceLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDBService" in both code and config file together.
    [ServiceContract]
    public interface IDBService
    {
        [OperationContract]
        int InsertAStudent(Student s);
        [OperationContract]
        int InsertACourse(Course c);
        [OperationContract]
        int InsertEnrolment(Enrollment e);
        [OperationContract]
        List<Student> GetAllStudents();
        [OperationContract]
        List<Course> GetAllCourses();

        [OperationContract]
        List<Course> GetEnrollmentsForStudent(string studentId);
        [OperationContract]
        List<Student> getStudentsEnrolledInCourse(string courseId);
    }
}
