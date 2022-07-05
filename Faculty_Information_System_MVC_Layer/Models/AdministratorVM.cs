
using System.ComponentModel.DataAnnotations;

namespace Faculty_Information_System_MVC_Layer.Models
{
    public class AdministratorVM
    {

        [Key]
        public int AdministratorId { get; set; }


        public int UserId { get; set; }
        public virtual UserVM User { set; get; }


        [Required(ErrorMessage = "Please Enter First Name"), MaxLength(30)]
        public string FullName { set; get; }

        [Required(ErrorMessage = "Please Enter Last Name"), MaxLength(30)]
        public string LastName { get; set; }

        [Phone(ErrorMessage = "enter 10 digit phone number"), MaxLength(10)]
        public string ContactDetails { get; set; }

        public short? RoleLookupId { get; set; }

        public bool? IsActive { get; set; }

    }
}
