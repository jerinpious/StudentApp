using StudentApp.Models;


namespace StudentApp.Services
{
    public interface IStudentService
    {
        void AddStudent(Student studentToAdd);
        Student GetStudentById(int id);
        List<Student> GetStudents();
        void UpdateStudent(int studentId, Student studentToEdit);


    }
}
