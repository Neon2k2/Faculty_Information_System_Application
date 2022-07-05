using Faculty_Information_System_Application.Data;
using System.Collections.Generic;

namespace Faculty_Information_System_Application.Repositories
{
    public interface ICourseRepository
    {
        Course AddCourse(Course cour);
        Course SearchCourse(int courseId);

        bool DeleteCourse(int courseId);
        IEnumerable<Course> GetCourse();
        void UpdateCourse(int courseId, Course cour);
    }
}
