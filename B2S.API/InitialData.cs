using B2S.Context;
using B2S.Model.Courses;
using B2S.Model.StudentCourses;
using B2S.Model.Students;
using System;
using System.Linq;

namespace B2S.API
{
    public static class InitialData
    {
        public static void SeedData(ApplicationContext context)
        {
            if (context.Students.Count() > 0)
                return;

            var student = new Student
            {
                FirstName = "Luke",
                LastName = "Skywalker",
                Email = "luke@gmail.com"
            };
            student.Create();

            context.Students.Add(student);

            var course = new Course
            {
                Tag = ".Net",
                Name = "C#",
                Code = 123321,
            };
            course.Create();

            context.Courses.Add(course);

            var course1 = new Course
            {
                Tag = ".Net",
                Name = "Xamarin",
                Code = 569965,
            };
            course1.Create();

            context.Courses.Add(course1);

            context.SaveChanges();

            var studentCourse = new StudentCourse();
            studentCourse.CourseId = course.Id;
            studentCourse.StudentId = student.Id;
            studentCourse.Grade = 10;
            studentCourse.Create();
            context.StudentCourses.Add(studentCourse);

            context.SaveChanges();

            var studentCourse2 = new StudentCourse();
            studentCourse2.CourseId = course1.Id;
            studentCourse2.StudentId = student.Id;
            studentCourse2.Grade = 5;
            studentCourse2.Create();
            context.StudentCourses.Add(studentCourse2);

            context.SaveChanges();
        }
    }
}
