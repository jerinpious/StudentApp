using System;
using System.Collections.Generic;

namespace StudentApp.Models
{
    public class Program
    {
        public string ProgramCode { get; set; } 
        public string ProgramName { get; set; } 
        
        public ICollection<Student> Students { get; set; }
    }
}
