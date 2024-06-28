using StudentRegistration.Core.Entities;
using System.Collections.Generic;

namespace StudentRegistration.Core.Services.Abstractions
{
    public interface IStudentService
    {
        Student GetStudent(int id);
        List<Student> GetStudents();
        Student CreateStudent(Student model);
        Student UpdateStudent(Student model);
        bool DeleteStudent(int id);
    }
}
