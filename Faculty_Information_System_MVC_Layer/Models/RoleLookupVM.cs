using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Faculty_Information_System_MVC_Layer.Models
{
    public class RoleLookupVM
    {
        public RoleLookupVM()
        {
            Administrators = new HashSet<AdministratorVM>();
            Users = new HashSet<UserVM>();
        }

        [Key]
        public short RoleLookupId { get; set; }
        public string Role { get; set; }

        public virtual ICollection<AdministratorVM> Administrators { get; set; }
        public virtual ICollection<UserVM> Users { get; set; }
    }
}
