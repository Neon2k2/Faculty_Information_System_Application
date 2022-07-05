using Faculty_Information_System_Application.Data;
using System.Collections.Generic;


namespace Faculty_Information_System_Application.Repositories
{
    public interface IUserRepository
    {
        User AddUser(User use);
        User SearchUser(int userId);
        bool DeleteUser(int userId);
        IEnumerable<User> GetUser();
        void UpdateUser(int userId, User use);
    }
}
