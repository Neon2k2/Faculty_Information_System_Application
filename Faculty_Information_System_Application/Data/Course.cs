using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Faculty_Information_System_Application.Data
{
    public class Course
    {
        public Course()
        {
            CourseTaughts = new HashSet<CourseTaught>();
            CourseSubjects = new HashSet<CourseSubject>();
        }

        [Key]
        public int CourseId { get; set; }
        

        [Required(ErrorMessage = "Please Enter Course Name")]
        public string CourseName { get; set; }


        public int CourseCredits { get; set; }

        [Required(ErrorMessage ="Please enter depId")]
        public int DeptId { get; set; }

        public virtual Department Dept { get; set; }


        public virtual ICollection<CourseTaught> CourseTaughts { get; set; }
        public virtual ICollection<CourseSubject> CourseSubjects { get; set; }


    }
}