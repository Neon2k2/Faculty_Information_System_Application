using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Faculty_Information_System_MVC_Layer.Models
{
    public class PublicationVM
    {
        [Key]
        public int PublicationId { get; set; }

        [ForeignKey("FacultyId")]
        public int FacultyId { get; set; }
        public virtual FacultyVM Faculty { get; set; }

        [Required(ErrorMessage = "Please Enter the Article Title")]
        public string PublicationTitle { get; set; }

        [Required(ErrorMessage = "Please Enter the Article Name")]
        public string ArticleName { get; set; }

        [Required(ErrorMessage = "Please Enter the Publication Name")]
        public string PublisherName { get; set; }

        public string? PublisherLocation { get; set; }


        public DateTime CitationDate { get; set; }
    }
}
