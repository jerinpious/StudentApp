using StudentApp.Data;
using StudentApp.Models;
using System.Collections.Generic;
using System.Linq;

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
            return _context.Students.Find(id);
        }

        public List<Student> GetStudents()
        {
            return _context.Students.ToList();
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
                _context.SaveChanges();
            }
        }
    }
}
