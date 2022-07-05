using Faculty_Information_System_Application.Data;
using System.Collections.Generic;
using System.Linq;

namespace Faculty_Information_System_Application.Repositories
{
    public class DepartmentRepository : IDepartment
    {
        private FacultyInformationSystemContext _db;
        public DepartmentRepository(FacultyInformationSystemContext context)
        {
            this._db = context;

        }
        public Department AddDepartment(Department dep)
        {
            _db.Departments.Add(dep);
            _db.SaveChanges();

            return dep;
        }

        public bool DeleteDepartment(int departmentId)
        {
            var dep = _db.Departments.FirstOrDefault(e => e.DepartmentId == departmentId);
            if (dep != null)
            {
                _db.Departments.Remove(dep);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Department> GetDepartment()
        {
            var depList = _db.Departments;
            return depList;
        }

        public Department SearchDepartment(int departmentId)
        {
            var dep = _db.Departments.FirstOrDefault(e => e.DepartmentId == departmentId);
            if (dep != null)
            {
                return dep;
            }
            else
            {
                return null;
            }
        }

        public void UpdateDepartment(int departmentId, Department dep)
        {
            var newDep = _db.Departments.FirstOrDefault(e => e.DepartmentId == departmentId);
            if (newDep != null)
            {
                newDep.DepartmentName = dep.DepartmentName;
                _db.SaveChanges();
            }
        }
    }
}
