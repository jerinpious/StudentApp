using StudentApp.Models;
using System;
using System.Collections.Generic;

namespace StudentApp.Services
{
    public class StudentServiceInMemory : IStudentService
    {
        // Use a static list to persist the students across requests
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, FirstName = "Bart", LastName = "Simpson", DateOfBirth = new DateTime(1971, 5, 31), GPA = 2.7, Hobby = "Loves skateboarding" },
            new Student { Id = 2, FirstName = "Lisa", LastName = "Simpson", DateOfBirth = new DateTime(1973, 8, 5), GPA = 4.0, Hobby = "Plays the saxophone" }
        };

        public void AddStudent(Student studentToAdd)
        {
            // Assign a new ID for the added student
            studentToAdd.Id = students.Count + 1;
            students.Add(studentToAdd);

            // Debug output to verify
            Console.WriteLine($"Added new student: {studentToAdd.FirstName} {studentToAdd.LastName}, Id: {studentToAdd.Id}");
        }

        public Student GetStudentById(int id)
        {
            Student? s = students.Find(s => s.Id == id);
            if(s == null)
            {
                return new Student();
            }
            return s;
        }

        public List<Student> GetStudents()
        {
            return students;
        }

        public void UpdateStudent(int studentId,Student studentToUpdate)
        {
            Student studentInMemory = GetStudentById(studentId);
            studentInMemory.LastName = studentToUpdate.LastName;
            studentInMemory.FirstName = studentToUpdate.FirstName;
            studentInMemory.DateOfBirth = studentToUpdate.DateOfBirth;
            studentInMemory.GPA = studentToUpdate.GPA;
            studentInMemory.Hobby = studentToUpdate.Hobby;
        }
    }
}
