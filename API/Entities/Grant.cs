using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Faculty_Information_System_Application.Data
{
    public class Grant
    {
        [Key]
        public int GrantId { get; set; }

        [ForeignKey("FacultyId")]
        public int FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }

        
        public string GrantTitle { get; set; }

        
        public string GrantDescription { get; set; }
    }
}