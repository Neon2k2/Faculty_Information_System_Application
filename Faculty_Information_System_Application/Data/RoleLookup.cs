using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Faculty_Information_System_Application.Data
{
    public class RoleLookup
    {
        public RoleLookup()
        {
            Administrators = new HashSet<Administrator>();
            Users = new HashSet<User>();
        }

        [Key]
        public short RoleLookupId { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Administrator> Administrators { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
