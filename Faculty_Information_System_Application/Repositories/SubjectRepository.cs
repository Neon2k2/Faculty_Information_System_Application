using Faculty_Information_System_Application.Data;
using System.Collections.Generic;
using System.Linq;

namespace Faculty_Information_System_Application.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private FacultyInformationSystemContext _db;
        public SubjectRepository(FacultyInformationSystemContext context)
        {
            this._db = context;

        }
        public Subject AddSubject(Subject sub)
        {
            _db.Subjects.Add(sub);
            _db.SaveChanges();

            return sub;
        }

        public bool DeleteSubject(int subjectId)
        {
            var sub = _db.Subjects.FirstOrDefault(e => e.SubjectID == subjectId);
            if (sub != null)
            {
                _db.Subjects.Remove(sub);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Subject> GetSubject()
        {
            var subList = _db.Subjects;
            return subList;
        }

        public Subject SearchSubject(int subjectId)
        {
            var sub = _db.Subjects.FirstOrDefault(e => e.SubjectID == subjectId);
            if (sub!= null)
            {
                return sub;
            }
            else
            {
                return null;
            }
        }

        public void UpdateSubject(int subjectId, Subject sub)
        {
            var newSub = _db.Subjects.FirstOrDefault(e => e.SubjectID == subjectId);
            if (newSub != null)
            {
                newSub.SubjectName = sub.SubjectName;
                _db.SaveChanges();
            }
            
        }

    }
}
