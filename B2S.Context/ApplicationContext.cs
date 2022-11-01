using B2S.Infrastructure.EntityFrameworkCore;
using B2S.Model.Courses;
using B2S.Model.StudentCourses;
using B2S.Model.Students;
using Microsoft.EntityFrameworkCore;

namespace B2S.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAuditEntityConfiguration();
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);

            modelBuilder.Entity<StudentCourse>().HasKey(sc => new { sc.StudentId, sc.CourseId });

            //modelBuilder.Entity<Course>().HasData
            //(
            //    new Course
            //    {
            //        Id = 1,
            //        Code = 127094,
            //        Name = "Building a Deployment Pipeline for .NET Applications",
            //        //IsActive = true,
            //    }
            //);            

            //modelBuilder.Entity<Course>().HasData
            //(
            //new Course
            //{
            //    Id = 2,
            //    Code = 112820,
            //    Name = "Building a Web App with ASP.NET Core, MVC, Entity Framework Core, Bootstrap, and Angular",
            //    //IsActive = true,
            //});

            //modelBuilder.Entity<Course>().HasData
            //(
            //new Course
            //{
            //    Id = 3,
            //    Code = 118375,
            //    Name = "Building an API with ASP.NET Core",
            //    //IsActive = true,
            //});

            //modelBuilder.Entity<Course>().HasData
            //(
            //new Course
            //{
            //    Id = 4,
            //    Code = 113442,
            //    Name = "Authentication and Authorization in ASP.NET Core",
            //    //IsActive = true,
            //});

            //modelBuilder.Entity<Course>().HasData
            //(
            //new Course
            //{
            //    Id = 5,
            //    Code = 191588,
            //    Name = "Building GraphQL APIs with ASP.NET Core",
            //    //IsActive = true,
            //});

            //modelBuilder.Entity<Course>().HasData
            //(
            //new Course
            //{
            //    Id = 6,
            //    Code = 124493,
            //    Name = "Securing ASP.NET Core 3 with OAuth2 and OpenID Connect",
            //    //IsActive = true,
            //});

            //modelBuilder.Entity<Course>().HasData
            //(
            //new Course
            //{
            //    Id = 7,
            //    Code = 177710,
            //    Name = "Using gRPC in ASP.NET Core",
            //    //IsActive = true,
            //});

            //modelBuilder.Entity<Course>().HasData
            //(
            //new Course
            //{
            //    Id = 8,
            //    Code = 192136,
            //    Name = "Getting Started with ASP.NET Core SignalR",
            //    //IsActive = true,
            //});

            //modelBuilder.Entity<Course>().HasData
            //(
            //new Course
            //{
            //    Id = 9,
            //    Code = 125457,
            //    Name = "TypeScript: Getting Started",
            //    //IsActive = true,
            //});

            //modelBuilder.Entity<Course>().HasData
            //(
            //new Course
            //{
            //    Id = 10,
            //    Code = 165106,
            //    Name = "TypeScript In-depth",
            //    //IsActive = true,
            //});

            //modelBuilder.Entity<Course>().HasData
            //(
            //new Course
            //{
            //    Id = 11,
            //    Code = 144820,
            //    Name = "Creating and Using Generics in TypeScript",
            //    //IsActive = true,
            //});

            //modelBuilder.Entity<Course>().HasData
            //(
            //new Course
            //{
            //    Id = 12,
            //    Code = 106724,
            //    Name = "RxJS in Angular: Reactive Development",
            //    //IsActive = true,
            //});

            //modelBuilder.Entity<Course>().HasData
            //(
            //new Course
            //{
            //    Id = 13,
            //    Code = 186810,
            //    Name = "Building a Web App with ASP.NET Core, MVC, Entity Framework Core, Bootstrap, and Angular",
            //    //IsActive = true,
            //});

            //modelBuilder.Entity<Course>().HasData
            //(
            //new Course
            //{
            //    Id = 14,
            //    Code = 168977,
            //    Name = "Angular HTTP Communication",
            //    //IsActive = true,
            //});

            //modelBuilder.Entity<Course>().HasData
            //(
            //new Course
            //{
            //    Id = 15,
            //    Code = 173500,
            //    Name = "Angular Best Practices",
            //    //IsActive = true,
            //});

            //modelBuilder.Entity<Course>().HasData
            //(
            //new Course
            //{
            //    Id = 16,
            //    Code = 163112,
            //    Name = "Angular Component Communication",
            //    //IsActive = true,
            //});

            //modelBuilder.Entity<Course>().HasData
            //(
            //new Course
            //{
            //    Id = 17,
            //    Code = 151043,
            //    Name = "Styling Applications with Angular Material",
            //    //IsActive = true,
            //});

            //modelBuilder.Entity<Course>().HasData
            //(
            //new Course
            //{
            //    Id = 18,
            //    Code = 182097,
            //    Name = "Structuring Angular Applications with Angular Libraries",
            //    //IsActive = true,
            //});

            //modelBuilder.Entity<Course>().HasData
            //(
            //new Course
            //{
            //    Id = 19,
            //    Code = 124951,
            //    Name = "Programming SQL Server Database Stored Procedures",
            //    //IsActive = true,
            //});

            //modelBuilder.Entity<Course>().HasData
            //(
            //new Course
            //{
            //    Id = 20,
            //    Code = 187975,
            //    Name = "Combining and Filtering Data with T-SQL",
            //    //IsActive = true,
            //});

            //modelBuilder.Entity<Course>().HasData
            //(
            //new Course
            //{
            //    Id = 21,
            //    Code = 134369,
            //    Name = "Designing a Data Warehouse on the Microsoft SQL Server Platform",
            //    //IsActive = true,
            //});

            //modelBuilder.Entity<Course>().HasData
            //(
            //new Course
            //{
            //    Id = 22,
            //    Code = 113314,
            //    Name = "Creating Automated Browser Tests with Selenium 3 in C#",
            //    //IsActive = true,
            //});

            //modelBuilder.Entity<Course>().HasData
            //(
            //new Course
            //{
            //    Id = 23,
            //    Code = 169303,
            //    Name = "C# Language-Integrated Query (LINQ)",
            //    //IsActive = true,
            //});

            //modelBuilder.Entity<Course>().HasData
            //(
            //new Course
            //{
            //    Id = 24,
            //    Code = 109105,
            //    Name = "SOLID Principles for C# Developers",
            //    //IsActive = true,
            //});

            //modelBuilder.Entity<Course>().HasData
            //(
            //new Course
            //{
            //    Id = 25,
            //    Code = 140961,
            //    Name = "Applying Asynchronous Programming in C#",
            //    //IsActive = true,
            //});

            //modelBuilder.Entity<Course>().HasData
            //(
            //new Course
            //{
            //    Id = 26,
            //    Code = 132529,
            //    Name = "Clean Coding Principles in C#",
            //    //IsActive = true,
            //});

            //modelBuilder.Entity<Course>().HasData
            //(
            //new Course
            //{
            //    Id = 27,
            //    Code = 168733,
            //    Name = "C# Events, Delegates and Lambdas",
            //    //IsActive = true,
            //});

            //modelBuilder.Entity<Course>().HasData
            //(
            //new Course
            //{
            //    Id = 28,
            //    Code = 180658,
            //    Name = "PowerShell: Getting Started",
            //    //IsActive = true,
            //});

            //modelBuilder.Entity<Course>().HasData
            //(
            //new Course
            //{
            //    Id = 29,
            //    Code = 145635,
            //    Name = "Code-first Entity Framework with Legacy Databases",
            //    //IsActive = true,
            //});

            //modelBuilder.Entity<Course>().HasData
            //(
            //new Course
            //{
            //    Id = 30,
            //    Code = 192692,
            //    Name = "Azure Durable Functions Fundamentals",
            //    //IsActive = true,
            //});

            //modelBuilder.Entity<Course>().HasData
            //(
            //new Course
            //{
            //    Id = 31,
            //    Code = 176338,
            //    Name = "Microsoft Azure Security and Privacy Concepts",
            //    //IsActive = true,
            //});

            //modelBuilder.Entity<Course>().HasData
            //(
            //new Course
            //{
            //    Id = 32,
            //    Code = 160005,
            //    Name = "Continuous Delivery and DevOps with Azure DevOps: Release Pipelines",
            //    //IsActive = true,
            //});
        }
    }
}
