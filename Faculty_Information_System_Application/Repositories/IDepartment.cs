using Faculty_Information_System_Application.Data;
using System.Collections.Generic;

namespace Faculty_Information_System_Application.Repositories
{
    public interface IDepartment
    {
        Department AddDepartment(Department dep);
        Department SearchDepartment(int departmentId);
        bool DeleteDepartment(int departmentId);
        IEnumerable<Department> GetDepartment();
        void UpdateDepartment(int departmentId, Department dep);
    }
}
