using StudentRegistration.Core.Entities;
using System.Collections.Generic;

namespace StudentRegistration.Core.Services.Abstractions
{
    public interface IStudentService
    {
        Student GetStudent(int id);
        IEnumerable<Student> GetStudents();
        IEnumerable<Student> GetStudents(string searchStr);
        Student CreateStudent(Student model);
        Student UpdateStudent(Student model);
        bool DeleteStudent(Student model);
    }
}
