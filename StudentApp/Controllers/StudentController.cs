using Microsoft.AspNetCore.Mvc;
using StudentApp.Models;
using StudentApp.Services;

namespace StudentApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public IActionResult List()
        {
            return View(_studentService.GetStudents());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new Student());
        }

        [HttpPost]
        public IActionResult Add(Student studentToAdd)
        {
            if (ModelState.IsValid)
            {
                _studentService.AddStudent(studentToAdd);
                return RedirectToAction("List");
            }

            return View(studentToAdd);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(int id, Student studentToUpdate)
        {
            _studentService.UpdateStudent(id, studentToUpdate);
            return RedirectToAction("List");
        }
    }
}
