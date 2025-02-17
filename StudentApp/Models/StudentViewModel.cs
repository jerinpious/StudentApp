using System;

namespace StudentApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public double GPA { get; set; }
        public string Hobby { get; set; }

        // Calculated Age based on DateOfBirth
        public int Age
        {
            get
            {
                return DateOfBirth.HasValue ? DateTime.Now.Year - DateOfBirth.Value.Year : 0;
            }
        }

        // Calculated GPA Scale based on GPA value
        public string GPAScale
        {
            get
            {
                if (GPA >= 3.7) return "Excellent";
                else if (GPA >= 3.0) return "Very Good";
                else if (GPA >= 2.0) return "Good";
                else if (GPA >= 1.0) return "Satisfactory";
                else return "Unsatisfactory";
            }
        }
    }
}
