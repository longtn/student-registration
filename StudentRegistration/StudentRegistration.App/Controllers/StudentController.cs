using AutoMapper;
using PagedList;
using StudentRegistration.App.DTOs;
using StudentRegistration.Core.Entities;
using StudentRegistration.Core.Services.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace StudentRegistration.App.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;

        public StudentController(
            IStudentService studentService,
            ISubjectService subjectService,
            IMapper mapper
            )
        {
            _studentService = studentService;
            _subjectService = subjectService;
            _mapper = mapper;
        }

        public ActionResult Index(string search, string currentSearch, int? page)
        {
            if (search != null)
            {
                page = 1;
            }
            else
            {
                search = currentSearch;
            }

            var students = _studentService.GetStudents(search);
            var result = _mapper.Map<List<StudentDTO>>(students);

            ViewBag.CurrentSearch = search;
            return View(result.ToPagedList(page ?? 1, 10));
        }

        public ActionResult Create()
        {
            var student = new StudentDTO();
            var subjects = _subjectService.GetSubjects();
            ViewBag.Subjects = subjects.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NRIC,Name,Gender,Birthday,AvailableDate,CreatedDate,UpdatedDate")] StudentDTO student)
        {
            if (ModelState.IsValid)
            {
                var data = _mapper.Map<Student>(student);
                var subjects = new List<StudentSubject>();
                foreach (var selected in student.SelectedSubjects)
                {
                    subjects.Add(new StudentSubject() { SubjectId = selected });
                }

                data.Subjects = subjects;
                _studentService.CreateStudent(data);

                return RedirectToAction("Index");
            }

            return View(student);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var student = _studentService.GetStudent((int)id);
            if (student == null)
            {
                return HttpNotFound();
            }

            var result = _mapper.Map<StudentDTO>(student);
            var subjects = _subjectService.GetSubjects();
            ViewBag.Subjects = subjects.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NRIC,Name,Gender,Birthday,AvailableDate,CreatedDate,SelectedSubjects")] StudentDTO student)
        {
            if (ModelState.IsValid)
            {
                var data = _mapper.Map<Student>(student);
                var subjects = new List<StudentSubject>();
                foreach (var selected in student.SelectedSubjects)
                {
                    subjects.Add(new StudentSubject()
                    {
                        StudentId = data.Id,
                        SubjectId = selected,
                    });
                }

                data.Subjects = subjects;
                _studentService.UpdateStudent(data);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var student = _studentService.GetStudent((int)id);
            if (student == null)
            {
                return HttpNotFound();
            }

            var result = _mapper.Map<StudentDTO>(student);
            return View(result);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var student = _studentService.GetStudent((int)id);
            if (student == null)
            {
                return HttpNotFound();
            }

            _studentService.DeleteStudent(student);
            return RedirectToAction("Index");
        }
    }
}
