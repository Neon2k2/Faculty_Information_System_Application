using Faculty_Information_System_Application.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Faculty_Information_System_Application.Repositories
{
    public class AdministratorRepository : IAdministratorRepository
    {
        private FacultyInformationSystemContext _db;
        public AdministratorRepository(FacultyInformationSystemContext context)
        {
            this._db = context;
        }

        public Administrator AddAdministrator(Administrator admin)
        {
            _db.Administrators.Add(admin);
            _db.SaveChanges();

            return admin;
        }


        public bool DeleteAdministrator(int administratorId)
        {
            var admin = _db.Administrators.FirstOrDefault(e => e.AdministratorId == administratorId);
            if (admin != null)
            {
                _db.Administrators.Remove(admin);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Administrator> GetAdministrator()
        {
            var adminList = _db.Administrators.Include(a => a.User);
            return adminList;
        }



        public Administrator SearchAdministrator(int administratorId)
        {
            var admin = _db.Administrators.FirstOrDefault(e => e.AdministratorId == administratorId);
            if (admin != null)
            {
                return admin;
            }
            else
            {
                return null;
            }
        }



        public void UpdateAdministrator(int administratorId, Administrator admin)
        {
            var newAdmin = _db.Administrators.FirstOrDefault(e => e.AdministratorId == administratorId);
            if (newAdmin != null)
            {
                newAdmin.UserId = admin.UserId;
                newAdmin.FullName = admin.FullName;
                newAdmin.LastName = admin.LastName;
                newAdmin.User = admin.User;
                newAdmin.ContactDetails = admin.ContactDetails;
                // newAdmin.RoleLookup = admin.RoleLookup;
                _db.SaveChanges();
            }
        }


    }
}
