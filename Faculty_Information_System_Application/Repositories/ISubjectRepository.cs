using Faculty_Information_System_Application.Data;
using System.Collections.Generic;

namespace Faculty_Information_System_Application.Repositories
{
    public interface ISubjectRepository
    {
            Subject AddSubject(Subject sub);
            Subject SearchSubject(int subjectId);
            bool DeleteSubject(int subjectId);
            IEnumerable<Subject> GetSubject();
            void UpdateSubject(int subjectId, Subject sub);

    }
}
