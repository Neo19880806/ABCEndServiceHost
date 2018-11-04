using System;
using System.Runtime.Serialization;

namespace ABCEndServiceLib.DB
{
    [DataContract]
    public class Student
    {
        [DataMember]
        public string StudentID { get; set; }
        [DataMember]
        public string StduentName { get; set; }
        [DataMember]
        public DateTime DateEnrolled { get; set; }
    }
}
