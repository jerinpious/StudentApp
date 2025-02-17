using Microsoft.AspNetCore.Mvc;
using StudentApp.Models;
using StudentApp.Services;

namespace StudentApp.Controllers
{
    public class StudentController : Controller
    {
        IStudentService studentService = new StudentServiceInMemory();

        public IActionResult List()
        {
            var students = studentService.GetStudents(); // Fetch updated list
            Console.WriteLine("Students in List: ");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}");
            }
            return View(students);
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
                studentService.AddStudent(studentToAdd);
                return RedirectToAction("List", studentService.GetStudents());
            }

            return View(studentToAdd);
        }

        [HttpGet]

        public IActionResult Edit(int id)
        {
            return View(studentService.GetStudentById(id));
        }

        [HttpPost]
        public IActionResult Edit(int id,Student studentToUpdate) {

            studentService.UpdateStudent(id, studentToUpdate);

            return RedirectToAction("List");
        }

    }
}
