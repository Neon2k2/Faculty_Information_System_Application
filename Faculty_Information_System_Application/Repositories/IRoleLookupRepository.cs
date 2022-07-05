
using Faculty_Information_System_Application.Data;
using System.Collections.Generic;

namespace Faculty_Information_System_Application.Repositories
{
    public interface IRoleLookupRepository
    {
        IEnumerable<RoleLookup> GetRoleLookup();
    }
}
