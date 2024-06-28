using StudentRegistration.Core.Entities;
using StudentRegistration.Core.Models;
using System.Collections.Generic;

namespace StudentRegistration.Core.Services.Abstractions
{
    public interface IStudentService
    {
        Student GetStudent(int id);
        List<Student> GetStudents();
        List<Student> GetStudents(SearchModel searchModel);
        Student CreateStudent(Student model);
        Student UpdateStudent(Student model);
        bool DeleteStudent(Student model);
    }
}
