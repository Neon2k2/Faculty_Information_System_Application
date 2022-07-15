using Faculty_Information_System_Application.Data;
using System.Collections.Generic;

namespace Faculty_Information_System_Application.Repositories
{
    public class RoleLookupRepository : IRoleLookupRepository
    {
        private FacultyInformationSystemContext _db;


        public RoleLookupRepository(FacultyInformationSystemContext context)
        {
            this._db = context;
        }
        public IEnumerable<RoleLookup> GetRoleLookup()
        {
            var roleLookupList = _db.RoleLookups;
            return roleLookupList;
        }

        

        

       
    }
}
