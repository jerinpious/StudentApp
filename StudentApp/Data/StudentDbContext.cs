using Microsoft.EntityFrameworkCore;
using StudentApp.Models;

namespace StudentApp.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Program> Programs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Program>()
                .HasKey(p => p.ProgramCode);  // ProgramCode is the primary key

            // Seed the Program data
            modelBuilder.Entity<Program>().HasData(
                new Program { ProgramCode = "CPA", ProgramName = "Computer Programmer Analyst" },
                new Program { ProgramCode = "BACS", ProgramName = "Bachelor of Applied Computer Science" }
            );

           
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Program) // A student has one program
                .WithMany() // Program can be associated with many students
                .HasForeignKey(s => s.ProgramCode) // ProgramCode is the foreign key
                .IsRequired();

            // Seed Student data
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    FirstName = "Goku",
                    LastName = "Son",
                    DateOfBirth = new DateTime(737, 4, 16),
                    GPA = 4.0,
                    Hobby = "Training, Eating",
                    ProgramCode = "BACS"
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Vegeta",
                    LastName = "Saiyan",
                    DateOfBirth = new DateTime(732, 10, 6),
                    GPA = 3.9,
                    Hobby = "Fighting, Training",
                    ProgramCode = "CPA"
                },
                new Student
                {
                    Id = 3,
                    FirstName = "Gohan",
                    LastName = "Son",
                    DateOfBirth = new DateTime(757, 5, 18),
                    GPA = 3.8,
                    Hobby = "Studying, Protecting Earth",
                    ProgramCode = "BACS"
                },
                new Student
                {
                    Id = 4,
                    FirstName = "Trunks",
                    LastName = "Brief",
                    DateOfBirth = new DateTime(766, 7, 10),
                    GPA = 3.7,
                    Hobby = "Sword Fighting, Training",
                    ProgramCode = "BACS"
                },
                new Student
                {
                    Id = 5,
                    FirstName = "Piccolo",
                    LastName = "Namekian",
                    DateOfBirth = new DateTime(732, 6, 24),
                    GPA = 4.0,
                    Hobby = "Training, Meditation",
                    ProgramCode = "CPA"
                }
            );
        }

    }
}
