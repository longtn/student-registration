using AutoMapper;
using StudentRegistration.App.DTOs;
using StudentRegistration.Core.Entities;

namespace StudentRegistration.App.Profiles
{
    public class SubjectProfile : Profile
    {
        public SubjectProfile()
        {
            CreateMap<Subject, StudentDTO>();
        }
    }
}