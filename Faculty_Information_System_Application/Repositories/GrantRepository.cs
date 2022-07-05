using Faculty_Information_System_Application.Data;
using System.Collections.Generic;
using System.Linq;

namespace Faculty_Information_System_Application.Repositories
{
    public class GrantRepository : IGrantRepository
    {
        private FacultyInformationSystemContext _db;
        public GrantRepository(FacultyInformationSystemContext context)
        {
            this._db = context;

        }
        public Grant AddGrant(Grant gran)
        {
            _db.Grants.Add(gran);
            _db.SaveChanges();

            return gran;
        }

        public bool DeleteGrant(int grantId)
        {
            var gran = _db.Grants.FirstOrDefault(e => e.GrantId == grantId);
            if (gran != null)
            {
                _db.Grants.Remove(gran);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Grant> GetGrant()
        {
            var grantList = _db.Grants;
            return grantList;
        }

        public Grant SearchGrant(int grantId)
        {
            var gran = _db.Grants.FirstOrDefault(e => e.GrantId == grantId);
            if (gran != null)
            {
                return gran;
            }
            else
            {
                return null;
            }
        }

        public void UpdateGrant(int grantId, Grant gran)
        {
            var newGrant = _db.Grants.FirstOrDefault(e => e.GrantId == grantId);
            if (newGrant != null)
            {
                newGrant.Faculty = gran.Faculty;
                newGrant.GrantTitle = gran.GrantTitle;
                newGrant.GrantDescription = gran.GrantDescription;
                _db.SaveChanges();
            }
        }
    }
}
