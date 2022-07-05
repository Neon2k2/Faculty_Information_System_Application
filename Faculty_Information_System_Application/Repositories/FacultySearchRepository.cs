using Faculty_Information_System_Application.Data;
using System.Linq;

namespace Faculty_Information_System_Application.Repositories
{
    public class FacultySearchRepository : IFacultySearchRepository
    {
        private FacultyInformationSystemContext _db;
        public FacultySearchRepository(FacultyInformationSystemContext context)
        {
            this._db = context;
        }
        public Faculty SearchFacultyByName(string Fname)
        {
            var name = _db.Faculties.FirstOrDefault(e => e.Fname == Fname);
            if (name != null)
            {
                return name;
            }
            else
            {
                return null;
            }
        }

    }
}

