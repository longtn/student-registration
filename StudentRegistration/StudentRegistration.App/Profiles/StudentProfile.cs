using AutoMapper;
using StudentRegistration.App.DTOs;
using StudentRegistration.App.Enums;
using StudentRegistration.Core.Entities;
using System.Linq;

namespace StudentRegistration.App.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDTO>()
                    .ForMember(dest => dest.SelectedSubjects, opt => opt.MapFrom(src => src.Subjects.Select(i => i.Id)))
                    .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender == "M" ? GenderEnum.Male : GenderEnum.Female));

            CreateMap<StudentDTO, Student>()
                    .ForMember(dest => dest.Subjects, opt => opt.Ignore())
                    .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender == GenderEnum.Male ? "M" : "F"));
        }
    }
}