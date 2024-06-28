using AutoMapper;
using StudentRegistration.App.Profiles;
using StudentRegistration.Core.Data;
using StudentRegistration.Core.Repositories;
using StudentRegistration.Core.Repositories.Abstractions;
using StudentRegistration.Core.Services;
using StudentRegistration.Core.Services.Abstractions;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace StudentRegistration.App
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<StudentRegistrationContext>(TypeLifetime.PerResolve);
            container.RegisterType<IUnitOfWork, UnitOfWork>(TypeLifetime.PerResolve);
            container.RegisterType(typeof(IGenericRepository<>), typeof(GenericRepository<>)).RegisterInstance(TypeLifetime.PerResolve);
            container.RegisterType<ISubjectService, SubjectService>(TypeLifetime.PerResolve);
            container.RegisterType<IStudentService, StudentService>(TypeLifetime.PerResolve);
            container.RegisterInstance<IMapper>(new AutoMapperConfig().RegisterAutoMapper());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}