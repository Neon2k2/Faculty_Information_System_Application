
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Faculty_Information_System_Application.Data
{
    public class Designation
    {
        public Designation()
        {
            Faculties = new HashSet<Faculty>();
        }

        [Key]
        public int DesignationId { set; get; }


        [Required(ErrorMessage = "Please Enter Designation Name"), MaxLength(30)]
        public string DesignationName { set; get; }

        public virtual ICollection<Faculty> Faculties { set; get; }
    }
}