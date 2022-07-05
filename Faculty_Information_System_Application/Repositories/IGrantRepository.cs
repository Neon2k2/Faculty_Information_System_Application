using Faculty_Information_System_Application.Data;
using System.Collections.Generic;


namespace Faculty_Information_System_Application.Repositories
{
    public interface IGrantRepository
    {
        Grant AddGrant(Grant gran);
        Grant SearchGrant(int grantId);
        bool DeleteGrant(int grantId);
        IEnumerable<Grant> GetGrant();
        void UpdateGrant(int grantId, Grant gran);
    }
}
