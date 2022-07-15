using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Faculty_Information_System_Application.Data
{
    public class Department
    {
        public Department()
        {
            Faculties = new HashSet<Faculty>();
            Courses = new HashSet<Course>();
        }


        [Key]
        public int DepartmentId { get; set; }


        [Required(ErrorMessage = "Please Enter Department Name")]
        public string DepartmentName { get; set; }

        public virtual ICollection<Faculty> Faculties { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

    }
}