using Faculty_Information_System_Application.Models;
using Faculty_Information_System_Application.Data;

namespace Faculty_Information_System_Application.Repositories
{
    public interface IJWTManagerRepository
    {
        MyJwtToken Authenticate(string username, string password);
    }
}
