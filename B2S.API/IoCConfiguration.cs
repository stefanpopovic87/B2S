using B2S.Client.Extensions;
using B2S.Contract.Courses;
using B2S.Contract.StudentCourses;
using B2S.Contract.Students;
using B2S.Infrastructure.Domain;
using B2S.Infrastructure.EntityFrameworkCore;
using B2S.Model.Courses;
using B2S.Model.StudentCourses;
using B2S.Model.Students;
using B2S.Query.Courses;
using B2S.Query.Students;
using B2S.Repository;
using B2S.Repository.Courses;
using B2S.Repository.StudentCourses;
using B2S.Repository.Students;
using B2S.Service.Courses;
using B2S.Service.StudentCoursesService;
using B2S.Service.Students;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace B2S.API
{
    public static class IoCConfiguration
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureRepositories(services);
            ConfigureApplicationServices(services);
            ConfigureQueries(services);
            ConfigureClients(services, configuration);
        }

        private static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<IStudentCoursesRepository, StudentCoursesRepository>();
        }

        private static void ConfigureApplicationServices(IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<IStudentCoursesService, StudentCoursesService>();
        }

        private static void ConfigureQueries(IServiceCollection services)
        {
            services.AddTransient<IStudentQuery, StudentQuery>();
            services.AddTransient<ICourseQuery, CourseQuery>();
        }

        private static void ConfigureClients(IServiceCollection services, IConfiguration configuration)
        {
            services.AddExternalApiClient(configuration);
        }
    }
}
