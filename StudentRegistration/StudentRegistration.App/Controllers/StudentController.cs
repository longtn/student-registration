using AutoMapper;
using StudentRegistration.App.DTOs;
using StudentRegistration.Core.Entities;
using StudentRegistration.Core.Services.Abstractions;
using System;
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

        public ActionResult Index()
        {
            var students = _studentService.GetStudents();
            var result = _mapper.Map<List<StudentDTO>>(students);

            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NRIC,Name,Gender,Birthday,AvailableDate,CreatedDate,UpdatedDate")] StudentDTO student)
        {
            if (ModelState.IsValid)
            {
                //student.CreatedDate = DateTime.Now;
                //student.UpdatedDate = DateTime.Now;
                //db.Students.Add(student);
                //await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        public ActionResult Edit(int id)
        {
            var student = _studentService.GetStudent(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            var subjects = _subjectService.GetSubjects();
            var result = _mapper.Map<StudentDTO>(student);

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
                var subjects = _subjectService.GetSubjects();
                
                data.UpdatedDate = DateTime.Now;
                data.Subjects = (IEnumerable<StudentSubject>)subjects.Where(i => student.SelectedSubjects.Contains(i.Id)).ToList();

                //_studentService.UpdateStudent(data);
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

            //Student student = await db.Students.FindAsync(id);
            //if (student == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Student student = await db.Students.FindAsync(id);
            //db.Students.Remove(student);
            //await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
