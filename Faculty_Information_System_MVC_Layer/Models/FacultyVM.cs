using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Faculty_Information_System_MVC_Layer.Models
{
    public class FacultyVM
    {
        public FacultyVM()
        {
            WorkHistories = new HashSet<WorkHistoryVM>();
            CourseTaughts = new HashSet<CourseTaughtVM>();
            Publications = new HashSet<PublicationVM>();
            Grants = new HashSet<GrantVM>();
            Degrees = new HashSet<DegreeVM>();

        }
        [Key]
        public int FacultyId { get; set; }

        public int? UserId { get; set; }



        public virtual UserVM User { get; set; }



        [Required(ErrorMessage = "Please Enter First Name"), MaxLength(30)]
        public string Fname { get; set; }

        [Required(ErrorMessage = "Please Enter Last Name"), MaxLength(30)]
        public string Lname { get; set; }

        [Required(ErrorMessage = "Please Enter Address"), MaxLength(50)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Enter City"), MaxLength(30)]
        public string City { get; set; }

        [Required(ErrorMessage = "Please Enter State"), MaxLength(30)]

        public string State { get; set; }

        [Required(ErrorMessage = "Please Enter Pincode")]

        public string Pincode { get; set; }

        
        [Phone]
        public string MobileNumber { get; set; }



        [Required]
        public DateTime HireDate { get; set; }


        [Required]
        [EmailAddress]
        
        public string Email { get; set; }

        [Required]
        public string Dob { get; set; }



        public int DepartmentId { get; set; }
        public virtual DepartmentVM Department { get; set; }

        public int DesignationId { get; set; }

        public virtual DesignationVM Designation { get; set; }

        public virtual ICollection<WorkHistoryVM> WorkHistories { get; set; }
        public virtual ICollection<CourseTaughtVM> CourseTaughts { get; set; }
        public virtual ICollection<PublicationVM> Publications { get; set; }
        public virtual ICollection<DegreeVM> Degrees { get; set; }
        public virtual ICollection<GrantVM> Grants { get; set; }


    }
}
