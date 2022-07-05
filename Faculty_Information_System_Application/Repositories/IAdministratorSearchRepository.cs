using Faculty_Information_System_Application.Data;

namespace Faculty_Information_System_Application.Repositories
{
    public interface IAdministratorSearchRepository
    {
        Administrator SearchAdministratorByName(string adminName);
    }
}
