using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Faculty_Information_System_MVC_Layer.Models
{
    public class GrantVM
    {
        [Key]
        public int GrantId { get; set; }

        [ForeignKey("FacultyId")]
        public int FacultyId { get; set; }
        public virtual FacultyVM Faculty { get; set; }

        [Required]
        public string GrantTitle { get; set; }

        [Required]
        public string GrantDescription { get; set; }
    }
}
