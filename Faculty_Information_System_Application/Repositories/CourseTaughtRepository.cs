using Faculty_Information_System_Application.Data;
using System.Collections.Generic;
using System.Linq;

namespace Faculty_Information_System_Application.Repositories
{
    public class CourseTaughtRepository : ICourseTaughtRepository
    {
        private FacultyInformationSystemContext _db;
        public CourseTaughtRepository(FacultyInformationSystemContext context)
        {
            this._db = context;
        }
        public CourseTaught AddCourseTaught(CourseTaught courTaut)
        {
            _db.CourseTaughts.Add(courTaut);
            _db.SaveChanges();

            return courTaut;
        }

        public bool DeleteCourseTaught(int courseTaughtId)
        {
            var courTaut = _db.CourseTaughts.FirstOrDefault(e => e.CoureseTaughtId == courseTaughtId);
            if (courTaut != null)
            {
                _db.CourseTaughts.Remove(courTaut);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<CourseTaught> GetCourseTaught()
        {
            var courTautList = _db.CourseTaughts;
            return courTautList;
        }

        public CourseTaught SearchCourseTaught(int courseTaughtId)
        {
            var courTautSub = _db.CourseTaughts.FirstOrDefault(e => e.CoureseTaughtId == courseTaughtId);
            if (courTautSub != null)
            {
                return courTautSub;
            }
            else
            {
                return null;
            }
        }

        public void UpdateCourseTaught(int courseTaughtId, CourseTaught courTaut)
        {
            var newCourTaut = _db.CourseTaughts.FirstOrDefault(e => e.CoureseTaughtId == courseTaughtId);
            if (newCourTaut != null)
            {
                newCourTaut.Course = courTaut.Course;
                newCourTaut.Faculty = courTaut.Faculty;
                newCourTaut.Subject = courTaut.Subject;
                newCourTaut.FirstDateTaught = courTaut.FirstDateTaught;
                _db.SaveChanges();
            }
        }
    }
}
