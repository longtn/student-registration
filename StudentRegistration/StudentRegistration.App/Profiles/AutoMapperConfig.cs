using AutoMapper;

namespace StudentRegistration.App.Profiles
{
    public class AutoMapperConfig
    {
        public IMapper RegisterAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<StudentProfile>();
                cfg.AddProfile<SubjectProfile>();
            });
            return config.CreateMapper();
        }
    }
}