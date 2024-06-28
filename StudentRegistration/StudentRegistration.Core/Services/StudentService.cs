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

        public Student GetStudent(int id)
        {
            var student = _studentRepo.GetById(id);
            return student;
        }

        public List<Student> GetStudents()
        {
            var students = _studentRepo.GetAll().ToList();
            return students;
        }

        public List<Student> GetStudents(string searchStr)
        {
            var students = _studentRepo.ToQueryable();

            students = !string.IsNullOrWhiteSpace(searchStr)
                ? students.Where(a => a.Name.Contains(searchStr) || a.NRIC.Contains(searchStr))
                : students;

            var result = students
                .OrderBy(a => a.Id)
                .ToList();

            result.ForEach(a => a.Subjects = _studentSubjectRepo.Where(b => b.StudentId == a.Id).ToList());
            return result;
        }

        public Student CreateStudent(Student student)
        {
            student.CreatedDate = DateTime.UtcNow;
            student.UpdatedDate = DateTime.UtcNow;
            var createdStudent = _studentRepo.Create(student);

            var studentSubjects = student.Subjects.ToList();
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

        public Student UpdateStudent(Student student)
        {
            var oldStudentSubjects = _studentSubjectRepo.Where(a => a.StudentId == student.Id).ToList();
            _studentSubjectRepo.Delete(oldStudentSubjects);

            student.UpdatedDate = DateTime.UtcNow;
            var isUpdated = _studentRepo.Update(student);

            var newStudentSubjects = student.Subjects.ToList();
            foreach (var item in newStudentSubjects)
            {
                item.CreatedDate = DateTime.Now;
                item.UpdatedDate = DateTime.Now;
            }

            _studentSubjectRepo.Create(newStudentSubjects);
            _uow.SaveChanges();

            return student;
        }

        public bool DeleteStudent(Student student)
        {
            _studentRepo.Delete(student);
            _uow.SaveChanges();

            return true;
        }
    }
}