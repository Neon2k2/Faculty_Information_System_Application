using Faculty_Information_System_Application.Data;
using System.Collections.Generic;
using System.Linq;

namespace Faculty_Information_System_Application.Repositories
{
    public class WorkHistoryRepository : IWorkHistoryRepository
    {
        private FacultyInformationSystemContext _db;
        public WorkHistoryRepository(FacultyInformationSystemContext context)
        {
            this._db = context;

        }
        public WorkHistory AddWorkHistory(WorkHistory work)
        {
            _db.WorkHistories.Add(work);
            _db.SaveChanges();

            return work;
        }

        public bool DeleteWorkHistory(int workHistoryId)
        {
            var work = _db.WorkHistories.FirstOrDefault(e => e.WorkHistoryId == workHistoryId);
            if (work != null)
            {
                _db.WorkHistories.Remove(work);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<WorkHistory> GetWorkHistory()
        {
            var workList = _db.WorkHistories;
            return workList;
        }

        public WorkHistory SearchWorkHistory(int workHistoryId)
        {
            var work = _db.WorkHistories.FirstOrDefault(e => e.WorkHistoryId== workHistoryId);
            if (work != null)
            {
                return work;
            }
            else
            {
                return null;
            }
        }

        public void UpdateWorkHistory(int workHistoryId, WorkHistory work)
        {
            var newWork = _db.WorkHistories.FirstOrDefault(e => e.WorkHistoryId == workHistoryId);
            if (newWork != null)
            {
                newWork.Faculty = work.Faculty;
                newWork.Organisation = work.Organisation;
                newWork.JobTitle = work.JobTitle;
                newWork.JobBeginDate = work.JobBeginDate;
                newWork.JobEndDate = work.JobEndDate;
                newWork.JobResponsibilities = work.JobResponsibilities;
                newWork.JobType = work.JobType;
                _db.SaveChanges();   
            }
        }
    }
}
