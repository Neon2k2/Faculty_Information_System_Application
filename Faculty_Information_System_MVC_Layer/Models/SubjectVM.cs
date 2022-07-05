using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Faculty_Information_System_MVC_Layer.Models
{
    public class SubjectVM
    {
        [Key]
        public int SubjectID { set; get; }

        [Required]
        public string SubjectName { set; get; }

        public virtual ICollection<CourseTaughtVM> CourseTaughts { get; set; }
        public virtual ICollection<CourseSubjectVM> CourseSubjects { get; set; }
    }
}
