using Faculty_Information_System_Application.Data;
using System.Collections.Generic;


namespace Faculty_Information_System_Application.Repositories
{
    public interface ICourseTaughtRepository
    {
        CourseTaught AddCourseTaught(CourseTaught courTaut);
        CourseTaught SearchCourseTaught(int courseTaughtId);
        bool DeleteCourseTaught(int courseTaughtId);
        IEnumerable<CourseTaught> GetCourseTaught();
        void UpdateCourseTaught(int courseTaughtId, CourseTaught courTaut);
    }
}
