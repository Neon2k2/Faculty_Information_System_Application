using Faculty_Information_System_Application.Data;
using System.Collections.Generic;
using System.Linq;

namespace Faculty_Information_System_Application.Repositories
{
    public class UserRepository : IUserRepository
    {
        private FacultyInformationSystemContext _db;
        public UserRepository(FacultyInformationSystemContext context)
        {
            this._db = context;

        }
        public User AddUser(User use)
        {
            _db.Users.Add(use);
            _db.SaveChanges();

            return use;
        }

        public bool DeleteUser(int userId)
        {
            var use = _db.Users.FirstOrDefault(u => u.UserId == userId);
            if (use != null)
            {
                _db.Users.Remove(use);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<User> GetUser()
        {
            var userList = _db.Users;
            return userList;
        }

        public User SearchUser(int userId)
        {
            var use = _db.Users.FirstOrDefault(e => e.UserId == userId);
            if (use != null)
            {
                return use;
            }
            else
            {
                return null;
            }
        }

        public void UpdateUser(int userId, User use)
        {
            var newUser = _db.Users.FirstOrDefault(e => e.UserId == userId);
            if (newUser != null)
            {
                newUser.UserName = use.UserName;
                newUser.Password = use.Password;
                _db.SaveChanges();
            }
        }
    }
}
