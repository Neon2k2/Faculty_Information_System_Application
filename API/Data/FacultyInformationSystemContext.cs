using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Faculty_Information_System_Application.Data
{
    public class FacultyInformationSystemContext: DbContext
    {
        public FacultyInformationSystemContext(DbContextOptions<FacultyInformationSystemContext> options): base(options)
        {

        }


        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseSubject> CourseSubjects{ get; set; }

        public DbSet<CourseTaught> CourseTaughts{ get; set; }
        public DbSet<Degree> Degrees{ get; set; }
        public DbSet<Department> Departments{ get; set; }

        public DbSet<Designation> Designations{ get; set; }
        public DbSet<Faculty> Faculties{ get; set; }
        public DbSet<Grant> Grants{ get; set; }
        public DbSet<Publication> Publications{ get; set; }
        public DbSet<Subject> Subjects{ get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<WorkHistory> WorkHistories{ get; set; }

        public DbSet<RoleLookup> RoleLookups  { get; set; }

    }
}