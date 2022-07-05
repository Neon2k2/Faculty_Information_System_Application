using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Faculty_Information_System_Application.Data
{
    public class User
    {


        [Key]
        public int UserId { get; set; }

        [Required]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public int RoleLookupId { get; set; }


    }
}