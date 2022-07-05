using Faculty_Information_System_Application.Data;
using System.Collections.Generic;
using System.Linq;

namespace Faculty_Information_System_Application.Repositories
{
    public class FacultyRepository : IFacultyRepository
    {
        private FacultyInformationSystemContext _db;
        public FacultyRepository(FacultyInformationSystemContext context)
        {
            this._db = context;

        }
        public Faculty AddFaculty(Faculty fac)
        {
            _db.Faculties.Add(fac);
            _db.SaveChanges();

            return fac;
        }

        public bool DeleteFaculty(int facultyId)
        {
            var fac = _db.Faculties.FirstOrDefault(e => e.FacultyId == facultyId);
            if (fac != null)
            {
                _db.Faculties.Remove(fac);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Faculty> GetFaculty()
        {
            var facList = _db.Faculties;
            return facList;
        }

        public Faculty SearchFaculty(int facultyId)
        {
            var fac = _db.Faculties.FirstOrDefault(e => e.FacultyId == facultyId);
            if (fac != null)
            {
                return fac;
            }
            else
            {
                return null;
            }
        }

        public void UpdateFaculty(int facultyId, Faculty fac)
        {
            var newFac = _db.Faculties.FirstOrDefault(e => e.FacultyId == facultyId);
            if (newFac != null)
            {
                newFac.Fname = fac.Fname;
                newFac.Lname = fac.Lname;
                newFac.User = fac.User;
                newFac.Address = fac.Address;
                newFac.City = fac.City;
                newFac.State = fac.State;
                newFac.Pincode = fac.Pincode;
                newFac.MobileNumber = fac.MobileNumber;
                newFac.HireDate = fac.HireDate;
                newFac.Email = fac.Email;
                newFac.Dob = fac.Dob;
                newFac.Department = fac.Department;
                newFac.Designation = fac.Designation;
                _db.SaveChanges();
            }
        }
    }
}
