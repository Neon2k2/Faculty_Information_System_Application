using Faculty_Information_System_Application.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Faculty_Information_System_Application.Repositories
{
    public class CourseSubjectRepository : ICourseSubjectRepository
    {
        private FacultyInformationSystemContext _db;
        public CourseSubjectRepository(FacultyInformationSystemContext context)
        {
            this._db = context;
        }

        public CourseSubject AddCourseSubject(CourseSubject courSub)
        {
            _db.CourseSubjects.Add(courSub);
            _db.SaveChanges();

            return courSub;
        }

        public bool DeleteCourseSubject(int courseSubjectId)
        {
            var courSub = _db.CourseSubjects.FirstOrDefault(e => e.CourseSubjectId == courseSubjectId);
            if (courSub != null)
            {
                _db.CourseSubjects.Remove(courSub);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<CourseSubject> GetCourseSubject()
        {
            var courSubList = _db.CourseSubjects.Include(cs => cs.Course);
            return courSubList;
        }

        public CourseSubject SearchCourseSubject(int courseSubjectId)
        {
            var courSub = _db.CourseSubjects.FirstOrDefault(e => e.CourseSubjectId == courseSubjectId);
            if (courSub != null)
            {
                return courSub;
            }
            else
            {
                return null;
            }
        }

        public void UpdateCourseSubject(int courseSubjectId, CourseSubject courSub)
        {
            var newCourSub = _db.CourseSubjects.FirstOrDefault(e => e.CourseSubjectId == courseSubjectId);
            if (newCourSub != null)
            {
                newCourSub.Course = courSub.Course;
                newCourSub.Subject = courSub.Subject;
                
                _db.SaveChanges();
            }
        }
    }
}
