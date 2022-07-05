using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Faculty_Information_System_Application.Data
{
    public class WorkHistory
    {
        [Key]
        public int WorkHistoryId { get; set; }

        public int FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }

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