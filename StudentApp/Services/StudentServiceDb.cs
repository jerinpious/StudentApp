
using Microsoft.EntityFrameworkCore; 
using StudentApp.Models;


namespace StudentApp.Services
{
    public class StudentServiceDb : IStudentService
    {
        private readonly StudentDbContext _context;

        public StudentServiceDb(StudentDbContext context)
        {
            _context = context;
        }

        public void AddStudent(Student studentToAdd)
        {
            _context.Students.Add(studentToAdd);
            _context.SaveChanges();
        }

        public Student? GetStudentById(int id)
        {
            return _context.Students.Include(s => s.Program).FirstOrDefault(s => s.Id == id); 
        }

        public List<Student> GetStudents()
        {
            return _context.Students.Include(s => s.Program).ToList(); // Include Program data
        }

        public void UpdateStudent(int studentId, Student studentToEdit)
        {
            var studentInDb = _context.Students.Find(studentId);
            if (studentInDb != null)
            {
                studentInDb.FirstName = studentToEdit.FirstName;
                studentInDb.LastName = studentToEdit.LastName;
                studentInDb.DateOfBirth = studentToEdit.DateOfBirth;
                studentInDb.GPA = studentToEdit.GPA;
                studentInDb.Hobby = studentToEdit.Hobby;
                studentInDb.ProgramCode = studentToEdit.ProgramCode; 
                _context.SaveChanges();
            }
        }
    }
}
