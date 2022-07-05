using Faculty_Information_System_Application.Data;
using System.Linq;

namespace Faculty_Information_System_Application.Repositories
{
    public class AdminstratorSearchRepository : IAdministratorSearchRepository
    {
        private FacultyInformationSystemContext _db;
        public AdminstratorSearchRepository(FacultyInformationSystemContext context)
        {
            this._db = context;
        }
        public Administrator SearchAdministratorByName(string adminName)
        {
            var admin = _db.Administrators.FirstOrDefault(e => e.FullName == adminName);
            if (admin != null)
            {
                return admin;
            }
            else
            {
                return null;
            }
        }

        
    }
}
