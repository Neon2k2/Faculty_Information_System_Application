using System;
using System.ComponentModel.DataAnnotations;

namespace Faculty_Information_System_MVC_Layer.Models
{
    public class WorkHistoryVM
    {
        [Key]
        public int WorkHistoryId { get; set; }

        public int FacultyId { get; set; }
        public virtual FacultyVM Faculty { get; set; }

        [Required(ErrorMessage = "Please Enter Organisation Name"), MaxLength(30)]
        public string Organisation { get; set; }

        [Required(ErrorMessage = "Please Enter Job Title"), MaxLength(30)]
        public string JobTitle { get; set; }

        [Required]
        public DateTime JobBeginDate { get; set; }

        [Required]
        public DateTime JobEndDate { get; set; }


        public string? JobResponsibilities { get; set; }
        public string? JobType { get; set; }
    }
}
