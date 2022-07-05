using Faculty_Information_System_Application.Data;
using System.Collections.Generic;

namespace Faculty_Information_System_Application.Repositories
{
    public interface IWorkHistoryRepository
    {
        WorkHistory AddWorkHistory(WorkHistory work);
        WorkHistory SearchWorkHistory(int workHistoryId);
        bool DeleteWorkHistory(int workHistoryId);
        IEnumerable<WorkHistory> GetWorkHistory();
        void UpdateWorkHistory(int workHistoryId, WorkHistory work);
    }
}
