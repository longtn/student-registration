using StudentRegistration.Core.Entities;
using System.Collections.Generic;

namespace StudentRegistration.Core.Services.Abstractions
{
    public interface ISubjectService
    {
        List<Subject> GetSubjects();
        List<Subject> GetSubjectsByStudent(int id);
    }
}
