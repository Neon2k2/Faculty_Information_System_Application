using System.ComponentModel.DataAnnotations;

namespace Faculty_Information_System_MVC_Layer.Models
{
    public class UserVM
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
