using StudentApp.Models;
using System;
using System.Collections.Generic;

namespace StudentApp.Services
{
    public class StudentServiceInMemory : IStudentService
    {
        private List<Student> students = new List<Student>
        {
            new Student { Id = 1, FirstName = "Bart", LastName = "Simpson", DateOfBirth = new DateTime(1971, 5, 31), GPA = 2.7, Hobby = "Loves skateboarding" },
            new Student { Id = 2, FirstName = "Lisa", LastName = "Simpson", DateOfBirth = new DateTime(1973, 8, 5), GPA = 4.0, Hobby = "Plays the saxophone" }
        };

        public List<Student> GetStudents()
        {
            return students;
        }
    }
}
