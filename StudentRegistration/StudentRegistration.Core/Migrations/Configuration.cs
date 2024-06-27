using StudentRegistration.Core.Entities;
using System;
using System.Data.Entity.Migrations;

namespace StudentRegistration.Core.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<StudentRegistration.Core.Data.StudentRegistrationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "StudentRegistration.Core.Data.StudentRegistrationContext";
        }

        protected override void Seed(StudentRegistration.Core.Data.StudentRegistrationContext context)
        {
            var now = DateTime.Now;

            context.Students.AddOrUpdate(i => i.Id,
                new Student() { Id = 1, CreatedDate = now, UpdatedDate = now, NRIC = "S1234567A", Name = "Tom", Gender = "M", Birthday = DateTime.Parse("Jul 24, 2003") },
                new Student() { Id = 2, CreatedDate = now, UpdatedDate = now, NRIC = "S7654321A", Name = "Green", Gender = "F", Birthday = DateTime.Parse("Sep 28, 2000") }
            );

            context.Subjects.AddOrUpdate(i => i.Id,
                new Subject() { Id = 1, CreatedDate = now, UpdatedDate = now, Name = "English" },
                new Subject() { Id = 2, CreatedDate = now, UpdatedDate = now, Name = "Math" },
                new Subject() { Id = 3, CreatedDate = now, UpdatedDate = now, Name = "Science" }
            );

            context.StudentsSubjects.AddOrUpdate(i => i.Id,
                new StudentSubject() { Id = 1, CreatedDate = now, UpdatedDate = now, StudentId = 1, SubjectId = 1 },
                new StudentSubject() { Id = 1, CreatedDate = now, UpdatedDate = now, StudentId = 1, SubjectId = 2 },
                new StudentSubject() { Id = 1, CreatedDate = now, UpdatedDate = now, StudentId = 1, SubjectId = 3 }
            );
        }
    }
}
