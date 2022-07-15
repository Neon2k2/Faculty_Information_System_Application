using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Faculty_Information_System_Application.Data
{
    public class Faculty
    {
        public Faculty()
        {
            WorkHistories = new HashSet<WorkHistory>();
            CourseTaughts = new HashSet<CourseTaught>();
            Publications = new HashSet<Publication>();
            Grants = new HashSet<Grant>();
            Degrees = new HashSet<Degree>();
            
        }
        [Key]
        public int FacultyId { get; set; }



        [Required(ErrorMessage = "Please Enter User ID"), MaxLength(3)]
        public int UserId { get; set; }


        public virtual User User { get; set; }



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

        [Required(ErrorMessage = "Please Enter Pincode"), MaxLength(6)]

        public string Pincode { get; set; }

        [Required(ErrorMessage = "Please Enter MObileNumber"), MaxLength(10)]
        [Phone]
        public string MobileNumber { get; set; }



        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime HireDate { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Dob { get; set; }



        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public int DesignationId { get; set; }

        public virtual Designation Designation { get; set; }

        public virtual ICollection<WorkHistory> WorkHistories { get; set; }
        public virtual ICollection<CourseTaught> CourseTaughts { get; set; }
        public virtual ICollection<Publication> Publications { get; set; }
        public virtual ICollection<Degree> Degrees { get; set; }
        public virtual ICollection<Grant> Grants { get; set; }

    }
}