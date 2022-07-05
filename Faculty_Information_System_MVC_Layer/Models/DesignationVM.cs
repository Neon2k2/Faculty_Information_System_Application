using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Faculty_Information_System_MVC_Layer.Models
{
    public class DesignationVM
    {
        public DesignationVM()
        {
            Faculties = new HashSet<FacultyVM>();
        }

        [Key]
        public int DesignationId { set; get; }


        [Required(ErrorMessage = "Please Enter Designation Name"), MaxLength(30)]
        public string DesignationName { set; get; }

        public virtual ICollection<FacultyVM> Faculties { set; get; }
    }
}
