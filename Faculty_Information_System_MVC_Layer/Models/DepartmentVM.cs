using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Faculty_Information_System_MVC_Layer.Models
{
    public class DepartmentVM
    {
        public DepartmentVM()
        {
            Faculties = new HashSet<FacultyVM>();
            Courses = new HashSet<CourseVM>();
        }


        [Key]
        public int DepartmentId { get; set; }


        [Required(ErrorMessage = "Please Enter Department Name"), MaxLength(30)]
        public string DepartmentName { get; set; }

        public virtual ICollection<FacultyVM> Faculties { get; set; }

        public virtual ICollection<CourseVM> Courses { get; set; }
    }
}
