using StudentRegistration.Core.Entities;
using StudentRegistration.Core.Repositories.Abstractions;
using StudentRegistration.Core.Services.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace StudentRegistration.Core.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IGenericRepository<Subject> _subjectRepo;
        private readonly IGenericRepository<StudentSubject> _studentSubjectRepo;

        public SubjectService(
            IGenericRepository<Subject> subjectRepo,
            IGenericRepository<StudentSubject> studentSubjectRepo
            )
        {
            _subjectRepo = subjectRepo;
            _studentSubjectRepo = studentSubjectRepo;
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return _subjectRepo.GetAll();
        }

        public IEnumerable<Subject> GetSubjectsByStudent(int id)
        {
            var subjectIds = _studentSubjectRepo.Where(x => x.StudentId == id).Select(a => a.SubjectId).ToList();
            var subjects = _subjectRepo.Where(a => subjectIds.Contains(a.Id));
            return subjects;
        }
    }
}