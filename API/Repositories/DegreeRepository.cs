using Faculty_Information_System_Application.Data;
using System.Collections.Generic;
using System.Linq;

namespace Faculty_Information_System_Application.Repositories
{
    public class DegreeRepository : IDegreeRepository
    {
        private FacultyInformationSystemContext _db;
        public DegreeRepository(FacultyInformationSystemContext context)
        {
            this._db = context;
        }
        public Degree AddDegree(Degree deg)
        {
            _db.Degrees.Add(deg);
            _db.SaveChanges();

            return deg;
        }


        public bool DeleteDegree(int degreeId)
        {
            var deg = _db.Degrees.FirstOrDefault(e => e.DegreeId == degreeId);
            if (deg != null)
            {
                _db.Degrees.Remove(deg);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Degree> GetDegree()
        {
            var degList = _db.Degrees;
            return degList;
        }

        public Degree SearchDegree(int degreeId)
        {
            var deg = _db.Degrees.FirstOrDefault(e => e.DegreeId == degreeId);
            if (deg != null)
            {
                return deg;
            }
            else
            {
                return null;
            }
        }

        public void UpdateDegree(int degreeId, Degree deg)
        {
            var newDeg = _db.Degrees.FirstOrDefault(e => e.DegreeId == degreeId);
            if (newDeg != null)
            {
                newDeg.DegreeId = deg.DegreeId;
                newDeg.Faculty = deg.Faculty;
                newDeg.DegreeName = deg.DegreeName;
                newDeg.DegreeYear = deg.DegreeYear;
                newDeg.Grade = deg.Grade;
                _db.SaveChanges();

            }
            
        }
    }
}
