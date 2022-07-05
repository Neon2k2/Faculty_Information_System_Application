using Faculty_Information_System_Application.Data;
using System.Collections.Generic;

namespace Faculty_Information_System_Application.Repositories
{
    public interface IAdministratorRepository
    {
        Administrator AddAdministrator(Administrator admin);
        Administrator SearchAdministrator(int administratorId);

        bool DeleteAdministrator(int administratorId);
        IEnumerable<Administrator> GetAdministrator();


        //IEnumerable<Administrator> SearchAdministratorByName(string adminFullName);


        void UpdateAdministrator(int administratorId, Administrator admin);
    }
}
