using Faculty_Information_System_Application.Data;
using System.Collections.Generic;


namespace Faculty_Information_System_Application.Repositories
{
    public interface IDegreeRepository
    {
        Degree AddDegree(Degree deg);
        Degree SearchDegree(int degreeId);
        bool DeleteDegree(int degreeId);
        IEnumerable<Degree> GetDegree();
        void UpdateDegree(int degreeId, Degree deg);
    }
}
