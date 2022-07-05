using Faculty_Information_System_Application.Data;
using System.Collections.Generic;

namespace Faculty_Information_System_Application.Repositories
{
    public interface IFacultyRepository
    {
        Faculty AddFaculty(Faculty fac);
        Faculty SearchFaculty(int facultyId);
        bool DeleteFaculty(int facultyId);
        IEnumerable<Faculty> GetFaculty();
        void UpdateFaculty(int facultyId, Faculty fac);
 
    }
}
