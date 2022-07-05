using System.ComponentModel.DataAnnotations.Schema;

namespace Faculty_Information_System_Application.Data
{

    public class CourseSubject
    {
        public int CourseSubjectId { get; set; }

        [ForeignKey("CourseId")]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        [ForeignKey("SubjectId")]
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

    }
}