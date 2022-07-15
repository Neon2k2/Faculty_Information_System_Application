using Faculty_Information_System_Application.Data;
using System.Collections.Generic;

namespace Faculty_Information_System_Application.Repositories
{
    public interface ICourseSubjectRepository
    {
        CourseSubject AddCourseSubject(CourseSubject courSub);
        CourseSubject SearchCourseSubject(int courseSubjectId);
        bool DeleteCourseSubject(int courseSubjectId);
        IEnumerable<CourseSubject> GetCourseSubject();
        void UpdateCourseSubject(int courseSubjectId, CourseSubject courSub);
    }
}
