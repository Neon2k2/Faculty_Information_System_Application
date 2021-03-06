using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Faculty_Information_System_Application.Data
{
    public class Degree
    {
        [Key]
        public int DegreeId { set; get; }

        [ForeignKey("FacultyId")]
        public int FacultyId { set; get; }
        public virtual Faculty Faculty { set; get; }


        [Required(ErrorMessage = "Please Enter Degree Name"), MaxLength(50)]
        public string DegreeName { set; get; }
        [Required]
        public DateTime DegreeYear { set; get; }
        [Required]
        public string Grade { set; get; }

    }
}