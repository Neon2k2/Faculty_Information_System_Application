using Faculty_Information_System_Application.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Faculty_Information_System_Application.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        //as the dbcontext has been fed as Ioc container as services it will create the instance of the lifetime of the object
        private FacultyInformationSystemContext _db;
        public CourseRepository(FacultyInformationSystemContext context)
        {
            this._db = context;
        }

        //adding course
        public Course AddCourse(Course cour)
        {
            _db.Courses.Add(cour);
            _db.SaveChanges();

            return cour;
        }

        //deleting course
        public bool DeleteCourse(int courseId)
        {
            var cour = _db.Courses.FirstOrDefault(e=> e.CourseId == courseId);
            if (cour != null)
            {
                _db.Courses.Remove(cour);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        //getting the list of the courses

        public IEnumerable<Course> GetCourse()
        {
            var courList = _db.Courses;
            return courList;
        }

        //searching a specific course
        public Course SearchCourse(int courseId)
        {
            var cour = _db.Courses.FirstOrDefault(e => e.CourseId == courseId);
            if (cour != null)
            {
                return cour;
            }
            else
            {
                return null;
            }
        }


        //updating a course
        public void UpdateCourse(int courseId, Course cour)
        {
            var newCour = _db.Courses.FirstOrDefault(e => e.CourseId == courseId);
            if (newCour != null)
            {
                newCour.CourseName = cour.CourseName;
                newCour.CourseCredits = cour.CourseCredits;
                newCour.Dept = cour.Dept;
                _db.SaveChanges();
            }
        }
    }
}
