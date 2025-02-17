using StudentApp.Models;


namespace StudentApp.Services
{
    public interface IStudentService
    {
        List<Student> GetStudents();
    }
}
