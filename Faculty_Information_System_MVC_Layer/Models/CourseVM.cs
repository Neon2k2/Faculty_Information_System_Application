using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Faculty_Information_System_MVC_Layer.Models
{
    public class CourseVM
    {
        public CourseVM()
        {
            CourseTaughts = new HashSet<CourseTaughtVM>();
            CourseSubjects = new HashSet<CourseSubjectVM>();
        }

        [Key]
        public int CourseId { get; set; }


        [Required(ErrorMessage = "Please Enter Course Name")]
        public string CourseName { get; set; }


        public int CourseCredits { get; set; }

        [Required(ErrorMessage = "Please enter depId")]
        public int DeptId { get; set; }

        public virtual DepartmentVM Dept { get; set; }


        public virtual ICollection<CourseTaughtVM> CourseTaughts { get; set; }
        public virtual ICollection<CourseSubjectVM> CourseSubjects { get; set; } 
    }
}
