using StudentApp.Models;


namespace StudentApp.Services
{
    public interface IStudentService
    {
        void AddStudent(Student studentToAdd);
        List<Student> GetStudents();
    }
}
