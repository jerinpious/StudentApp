using Microsoft.AspNetCore.Mvc;
using StudentApp.Services;

namespace StudentApp.Controllers
{
    public class StudentController : Controller
    {

        IStudentService studentService = new StudentServiceInMemory();
        public IActionResult List()
        {
            return View(studentService.GetStudents());
        }
    }
}
