using System.ComponentModel.DataAnnotations.Schema;

namespace Faculty_Information_System_MVC_Layer.Models
{
    public class CourseSubjectVM
    {
        public int CourseSubjectId { get; set; }

        [ForeignKey("CourseId")]
        public int CourseId { get; set; }

        public virtual CourseVM Course { get; set; }

        [ForeignKey("SubjectId")]
        public int SubjectId { get; set; }
        public virtual SubjectVM Subject { get; set; }
    }
}
