using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Faculty_Information_System_Application.Data
{
    
    public class CourseTaught
    {

        [Key]
        public int CoureseTaughtId { get; set; }

        [ForeignKey("CourseId")]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        [ForeignKey("FacultyId")]
        public int? FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }


        [ForeignKey("SubjectId")]
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }


        [Required]
        public DateTime FirstDateTaught { get; set; }

    }
}