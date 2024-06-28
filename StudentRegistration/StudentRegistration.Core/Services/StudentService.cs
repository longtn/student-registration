using StudentRegistration.Core.Data;
using StudentRegistration.Core.Entities;
using StudentRegistration.Core.Repositories.Abstractions;
using StudentRegistration.Core.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentRegistration.Core.Services
{
    public class StudentService : IStudentService
    {
        private readonly IGenericRepository<Student> _studentRepo;
        private readonly IGenericRepository<StudentSubject> _studentSubjectRepo;
        private readonly IUnitOfWork _uow;

        public StudentService(
            IGenericRepository<Student> studentRepo,
            IGenericRepository<StudentSubject> studentSubjectRepo,
            IUnitOfWork uow
            )
        {
            _studentRepo = studentRepo;
            _studentSubjectRepo = studentSubjectRepo;
            _uow = uow;
        }

        public List<Student> GetStudents()
        {
            var student = _studentRepo.GetAll().ToList();
            return student;
        }

        public Student GetStudent(int id)
        {
            var student = _studentRepo.GetById(id);
            return student;
        }

        public Student CreateStudent(Student model)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateStudent(Student model)
        {
            var subjects = _studentSubjectRepo.Where(a => a.StudentId == model.Id).ToList();
            _studentSubjectRepo.Delete(subjects);

            model.UpdatedDate = DateTime.UtcNow;
            var isUpdated = _studentRepo.Update(model);

            _studentSubjectRepo.Create(model.Subjects.ToList());
            _uow.SaveChanges();

            return true;
        }

        Student IStudentService.UpdateStudent(Student model)
        {
            throw new NotImplementedException();
        }

        public bool DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }
    }
}