using Faculty_Information_System_Application.Data;
using System.Collections.Generic;
using System.Linq;

namespace Faculty_Information_System_Application.Repositories
{
    public class DesignationRepository : IDesignationRepository
    {
        private FacultyInformationSystemContext _db;
        public DesignationRepository(FacultyInformationSystemContext context)
        {
            this._db = context;

        }

        public Designation AddDesignation(Designation desig)
        {
            _db.Designations.Add(desig);
            _db.SaveChanges();

            return desig;
        }

        public bool DeleteDesignation(int designationId)
        {
            var desig = _db.Designations.FirstOrDefault(e => e.DesignationId == designationId);
            if (desig != null)
            {
                _db.Designations.Remove(desig);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Designation> GetDesignation()
        {
            var desigList = _db.Designations;
            return desigList;
        }

        public Designation SearchDesignation(int designationId)
        {
            var desig = _db.Designations.FirstOrDefault(e => e.DesignationId == designationId);
            if (desig != null)
            {
                return desig;
            }
            else
            {
                return null;
            }
        }

        public void UpdateDesignation(int designationId, Designation desig)
        {
            var newDesig = _db.Designations.FirstOrDefault(e => e.DesignationId == designationId);
            if (newDesig != null)
            {
                newDesig.DesignationName = desig.DesignationName;
                _db.SaveChanges();
            }
        }
    }
}
