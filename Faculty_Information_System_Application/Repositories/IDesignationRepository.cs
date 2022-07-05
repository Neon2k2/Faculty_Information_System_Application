using Faculty_Information_System_Application.Data;
using System.Collections.Generic;


namespace Faculty_Information_System_Application.Repositories
{
    public interface IDesignationRepository
    {
        Designation AddDesignation(Designation desig);
        Designation SearchDesignation(int designationId);
        bool DeleteDesignation(int designationId);
        IEnumerable<Designation> GetDesignation();
        void UpdateDesignation(int designationId, Designation desig);
    }
}
