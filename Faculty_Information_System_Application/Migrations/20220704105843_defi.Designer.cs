﻿// <auto-generated />
using System;
using Faculty_Information_System_Application.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Faculty_Information_System_Application.Migrations
{
    [DbContext(typeof(FacultyInformationSystemContext))]
    [Migration("20220704105843_defi")]
    partial class defi
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Faculty_Information_System_Application.Data.Administrator", b =>
                {
                    b.Property<int>("AdministratorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactDetails")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<short?>("RoleLookupId")
                        .HasColumnType("smallint");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AdministratorId");

                    b.HasIndex("RoleLookupId");

                    b.HasIndex("UserId");

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("Faculty_Information_System_Application.Data.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CourseCredits")
                        .HasColumnType("int");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DeptId")
                        .HasColumnType("int");

                    b.HasKey("CourseId");

                    b.HasIndex("DeptId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Faculty_Information_System_Application.Data.CourseSubject", b =>
                {
                    b.Property<int>("CourseSubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("CourseSubjectId");

                    b.HasIndex("CourseId");

                    b.HasIndex("SubjectId");

                    b.ToTable("CourseSubjects");
                });

            modelBuilder.Entity("Faculty_Information_System_Application.Data.CourseTaught", b =>
                {
                    b.Property<int>("CoureseTaughtId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int?>("FacultyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FirstDateTaught")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("CoureseTaughtId");

                    b.HasIndex("CourseId");

                    b.HasIndex("FacultyId");

                    b.HasIndex("SubjectId");

                    b.ToTable("CourseTaughts");
                });

            modelBuilder.Entity("Faculty_Information_System_Application.Data.Degree", b =>
                {
                    b.Property<int>("DegreeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DegreeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DegreeYear")
                        .HasColumnType("datetime2");

                    b.Property<int>("FacultyId")
                        .HasColumnType("int");

                    b.Property<string>("Grade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DegreeId");

                    b.HasIndex("FacultyId");

                    b.ToTable("Degrees");
                });

            modelBuilder.Entity("Faculty_Information_System_Application.Data.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Faculty_Information_System_Application.Data.Designation", b =>
                {
                    b.Property<int>("DesignationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DesignationName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("DesignationId");

                    b.ToTable("Designations");
                });

            modelBuilder.Entity("Faculty_Information_System_Application.Data.Faculty", b =>
                {
                    b.Property<int>("FacultyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("DesignationId")
                        .HasColumnType("int");

                    b.Property<string>("Dob")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pincode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("FacultyId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("DesignationId");

                    b.HasIndex("UserId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("Faculty_Information_System_Application.Data.Grant", b =>
                {
                    b.Property<int>("GrantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FacultyId")
                        .HasColumnType("int");

                    b.Property<string>("GrantDescription")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("GrantTitle")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("GrantId");

                    b.HasIndex("FacultyId");

                    b.ToTable("Grants");
                });

            modelBuilder.Entity("Faculty_Information_System_Application.Data.Publication", b =>
                {
                    b.Property<int>("PublicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArticleName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("CitationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FacultyId")
                        .HasColumnType("int");

                    b.Property<string>("PublicationTitle")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PublisherLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublisherName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("PublicationId");

                    b.HasIndex("FacultyId");

                    b.ToTable("Publications");
                });

            modelBuilder.Entity("Faculty_Information_System_Application.Data.RoleLookup", b =>
                {
                    b.Property<short>("RoleLookupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleLookupId");

                    b.ToTable("RoleLookups");
                });

            modelBuilder.Entity("Faculty_Information_System_Application.Data.Subject", b =>
                {
                    b.Property<int>("SubjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectID");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Faculty_Information_System_Application.Data.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleLookupId")
                        .HasColumnType("int");

                    b.Property<short?>("RoleLookupId1")
                        .HasColumnType("smallint");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("RoleLookupId1");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Faculty_Information_System_Application.Data.WorkHistory", b =>
                {
                    b.Property<int>("WorkHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FacultyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("JobBeginDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("JobEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("JobResponsibilities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("JobType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Organisation")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("WorkHistoryId");

                    b.HasIndex("FacultyId");

                    b.ToTable("WorkHistories");
                });

            modelBuilder.Entity("Faculty_Information_System_Application.Data.Administrator", b =>
                {
                    b.HasOne("Faculty_Information_System_Application.Data.RoleLookup", "RoleLookup")
                        .WithMany("Administrators")
                        .HasForeignKey("RoleLookupId");

                    b.HasOne("Faculty_Information_System_Application.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoleLookup");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Faculty_Information_System_Application.Data.Course", b =>
                {
                    b.HasOne("Faculty_Information_System_Application.Data.Department", "Dept")
                        .WithMany("Courses")
                        .HasForeignKey("DeptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dept");
                });

            modelBuilder.Entity("Faculty_Information_System_Application.Data.CourseSubject", b =>
                {
                    b.HasOne("Faculty_Information_System_Application.Data.Course", "Course")
                        .WithMany("CourseSubjects")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Faculty_Information_System_Application.Data.Subject", "Subject")
                        .WithMany("CourseSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Faculty_Information_System_Application.Data.CourseTaught", b =>
                {
                    b.HasOne("Faculty_Information_System_Application.Data.Course", "Course")
                        .WithMany("CourseTaughts")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Faculty_Information_System_Application.Data.Faculty", "Faculty")
                        .WithMany("CourseTaughts")
                        .HasForeignKey("FacultyId");

                    b.HasOne("Faculty_Information_System_Application.Data.Subject", "Subject")
                        .WithMany("CourseTaughts")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Faculty");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Faculty_Information_System_Application.Data.Degree", b =>
                {
                    b.HasOne("Faculty_Information_System_Application.Data.Faculty", "Faculty")
                        .WithMany("Degrees")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("Faculty_Information_System_Application.Data.Faculty", b =>
                {
                    b.HasOne("Faculty_Information_System_Application.Data.Department", "Department")
                        .WithMany("Faculties")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Faculty_Information_System_Application.Data.Designation", "Designation")
                        .WithMany("Faculties")
                        .HasForeignKey("DesignationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Faculty_Information_System_Application.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Department");

                    b.Navigation("Designation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Faculty_Information_System_Application.Data.Grant", b =>
                {
                    b.HasOne("Faculty_Information_System_Application.Data.Faculty", "Faculty")
                        .WithMany("Grants")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("Faculty_Information_System_Application.Data.Publication", b =>
                {
                    b.HasOne("Faculty_Information_System_Application.Data.Faculty", "Faculty")
                        .WithMany("Publications")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("Faculty_Information_System_Application.Data.User", b =>
                {
                    b.HasOne("Faculty_Information_System_Application.Data.RoleLookup", null)
                        .WithMany("Users")
                        .HasForeignKey("RoleLookupId1");
                });

            modelBuilder.Entity("Faculty_Information_System_Application.Data.WorkHistory", b =>
                {
                    b.HasOne("Faculty_Information_System_Application.Data.Faculty", "Faculty")
                        .WithMany("WorkHistories")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("Faculty_Information_System_Application.Data.Course", b =>
                {
                    b.Navigation("CourseSubjects");

                    b.Navigation("CourseTaughts");
                });

            modelBuilder.Entity("Faculty_Information_System_Application.Data.Department", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Faculties");
                });

            modelBuilder.Entity("Faculty_Information_System_Application.Data.Designation", b =>
                {
                    b.Navigation("Faculties");
                });

            modelBuilder.Entity("Faculty_Information_System_Application.Data.Faculty", b =>
                {
                    b.Navigation("CourseTaughts");

                    b.Navigation("Degrees");

                    b.Navigation("Grants");

                    b.Navigation("Publications");

                    b.Navigation("WorkHistories");
                });

            modelBuilder.Entity("Faculty_Information_System_Application.Data.RoleLookup", b =>
                {
                    b.Navigation("Administrators");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Faculty_Information_System_Application.Data.Subject", b =>
                {
                    b.Navigation("CourseSubjects");

                    b.Navigation("CourseTaughts");
                });
#pragma warning restore 612, 618
        }
    }
}
