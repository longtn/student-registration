using StudentRegistration.Core.Entities;
using System.Collections.Generic;

namespace StudentRegistration.Core.Services.Abstractions
{
    public interface ISubjectService
    {
        IEnumerable<Subject> GetSubjects();
        IEnumerable<Subject> GetSubjectsByStudent(int id);
    }
}
