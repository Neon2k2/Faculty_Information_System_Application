using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Faculty_Information_System_Application.Data
{
    public class User
    {

        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please Enter username Name"), MaxLength(10)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter the Role"), MaxLength(1)]
        public int RoleLookupId { get; set; }
        public virtual RoleLookup RoleLookup {get; set;}

    }
}