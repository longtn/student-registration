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
            if (!IsStudentExists(id)) 
                return null;

            var student = _studentRepo.GetById(id);
            student.Subjects = _studentSubjectRepo.Where(ss => ss.StudentId == student.Id).ToList();
            return student;
        }

        public IEnumerable<Student> GetStudents()
        {
            var students = _studentRepo.GetAll();
            return students;
        }

        public IEnumerable<Student> GetStudents(string searchString)
        {
            var students = _studentRepo.ToQueryable();

            students = !string.IsNullOrWhiteSpace(searchString)
                ? students.Where(s => s.Name.Contains(searchString) || s.NRIC.Contains(searchString))
                : students;

            var result = students
                .OrderBy(s => s.Id)
                .ToList();

            result.ForEach(s => s.Subjects = _studentSubjectRepo.Where(ss => ss.StudentId == s.Id).ToList());
            return result;
        }

        public Student CreateStudent(Student student)
        {
            if (!IsStudentExists(student.Id)) 
                return null;

            student.CreatedDate = DateTime.Now;
            student.UpdatedDate = DateTime.Now;

            var createdStudent = _studentRepo.Create(student);
            if (createdStudent is null) 
                return null;

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
            if (!IsStudentExists(student.Id)) 
                return null;

            var oldStudentSubjects = _studentSubjectRepo.Where(ss => ss.StudentId == student.Id).ToList();
            _studentSubjectRepo.Delete(oldStudentSubjects);
            student.UpdatedDate = DateTime.Now;

            var updatedStudent = _studentRepo.Update(student);
            if (!updatedStudent) 
                return null;

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
            if (!_studentRepo.Delete(student)) 
                return false;

            _uow.SaveChanges();
            return true;
        }

        private bool IsStudentExists(int id)
        {
            return _studentRepo.GetById(id) != null;
        }
    }
}