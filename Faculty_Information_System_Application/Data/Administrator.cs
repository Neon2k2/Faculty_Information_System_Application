using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Faculty_Information_System_Application.Data
{
    public class Administrator
    {
        
        [Key]
        public int AdministratorId { get; set; }
        

        public int UserId { get; set; }
        public virtual User User { set; get; }


        [Required(ErrorMessage = "Please Enter First Name"), MaxLength(30)]
        public string FullName { set; get; }

        [Required(ErrorMessage = "Please Enter Last Name"), MaxLength(30)]
        public string LastName { get; set; }

        [Phone(ErrorMessage = "enter 10 digit phone number"), MaxLength(10)]
        public string ContactDetails { get; set; }

        public short? RoleLookupId { get; set; }

        public virtual RoleLookup RoleLookup { get; set; }
        public bool? IsActive { get; set; }




    }
}