using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApp.Models;
using StudentApp.Services;

namespace StudentApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly StudentDbContext _context;

        public StudentController(IStudentService studentService, StudentDbContext context)
        {
            _studentService = studentService;
            _context = context;
        }

        public IActionResult List()
        {
            var students = _studentService.GetStudents();
            return View(students);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Programs = _context.Programs.ToList();
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
            ViewBag.Programs = _context.Programs.ToList();
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(int id, Student studentToUpdate)
        {
            _studentService.UpdateStudent(id, studentToUpdate);
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            _context.SaveChanges();
            return RedirectToAction(nameof(List)); 
        }

    }
}
