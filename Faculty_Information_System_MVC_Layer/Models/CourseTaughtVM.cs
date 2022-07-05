using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Faculty_Information_System_MVC_Layer.Models
{
    public class CourseTaughtVM
    {
        [Key]
        public int CoureseTaughtId { get; set; }

        [ForeignKey("CourseId")]
        public int CourseId { get; set; }

        public virtual CourseVM Course { get; set; }

        [ForeignKey("FacultyId")]
        public int? FacultyId { get; set; }
        public virtual FacultyVM Faculty { get; set; }


        [ForeignKey("SubjectId")]
        public int SubjectId { get; set; }
        public virtual SubjectVM Subject { get; set; }


        [Required]
        public DateTime FirstDateTaught { get; set; }
    }
}
