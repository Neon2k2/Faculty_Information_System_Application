using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Faculty_Information_System_Application.Data
{
    public class Subject
    {
        [Key]
        public int SubjectID { set; get; }

        [Required]
        public string SubjectName { set; get; }

        public virtual ICollection<CourseTaught> CourseTaughts { get; set; }
        public virtual ICollection<CourseSubject> CourseSubjects { get; set; }
    }
}