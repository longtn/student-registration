using StudentRegistration.Core.Data;
using StudentRegistration.Core.Entities;
using StudentRegistration.Core.Models;
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

        public Student GetStudent(int id)
        {
            var student = _studentRepo.GetById(id);
            return student;
        }

        public List<Student> GetStudents()
        {
            var student = _studentRepo.GetAll().ToList();
            return student;
        }

        public List<Student> GetStudents(SearchModel searchModel)
        {
            var student = _studentRepo.GetAll().ToList();
            return student;
        }

        public Student CreateStudent(Student model)
        {
            model.CreatedDate = DateTime.UtcNow;
            model.UpdatedDate = DateTime.UtcNow;
            var createdStudent = _studentRepo.Create(model);

            var studentSubjects = model.Subjects.ToList();
            foreach (var item in studentSubjects)
            {
                item.StudentId = createdStudent.Id;
                item.CreatedDate = DateTime.Now;
                item.UpdatedDate = DateTime.Now;
            }

            _studentSubjectRepo.Create(studentSubjects);
            _uow.SaveChanges();

            return createdStudent;
        }

        public Student UpdateStudent(Student model)
        {
            var oldStudentSubjects = _studentSubjectRepo.Where(a => a.StudentId == model.Id).ToList();
            _studentSubjectRepo.Delete(oldStudentSubjects);

            model.UpdatedDate = DateTime.UtcNow;
            var isUpdated = _studentRepo.Update(model);

            var newStudentSubjects = model.Subjects.ToList();
            foreach (var item in newStudentSubjects)
            {
                item.CreatedDate = DateTime.Now;
                item.UpdatedDate = DateTime.Now;
            }

            _studentSubjectRepo.Create(newStudentSubjects);
            _uow.SaveChanges();

            return model;
        }

        public bool DeleteStudent(Student model)
        {
            _studentRepo.Delete(model);
            _uow.SaveChanges();

            return true;
        }
    }
}