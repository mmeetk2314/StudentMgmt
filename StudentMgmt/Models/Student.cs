using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMgmt.Models
{
    public class Student
    {
        [Key]
        
        public int student_ID { get; set; }
        public string student_Name { get; set; }
        public string student_Email { get; set; }
        public string student_Mobile { get; set; }
        public string student_Address { get; set; }
        //Foreign Key definiation where course_obj is the object of the course class 
        public int course_ID { get; set; }
        public Course Course_obj { get; set; }
    }
}
