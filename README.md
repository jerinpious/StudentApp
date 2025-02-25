# Student Management Application

A simple yet powerful ASP.NET Core MVC application for managing student records with program tracking capabilities.

## Features

- **Student Management**: Add, view, edit, and delete student records
- **Program Tracking**: Associate students with specific academic programs
- **Data Validation**: Form validation for student data entry
- **Responsive UI**: Clean interface using Bootstrap

## Project Structure

- **Models**: Define data entities (Student, Program)
- **Views**: Razor views for UI presentation
- **Controllers**: Handle HTTP requests and responses
- **Services**: Business logic for student operations
- **Database**: Entity Framework Core with SQL Server

## Tech Stack

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Bootstrap (for styling)

## Setup Instructions

### Prerequisites

- .NET 6.0 SDK or later
- SQL Server (LocalDB, Express, or full version)
- Visual Studio 2022 or Visual Studio Code

### Installation

1. Clone the repository
   ```
   git clone https://github.com/yourusername/student-management-app.git
   ```

2. Navigate to the project directory
   ```
   cd student-management-app
   ```

3. Update the connection string in `appsettings.json` to point to your SQL Server instance
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=StudentApp;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   ```

4. Apply database migrations
   ```
   dotnet ef database update
   ```

5. Run the application
   ```
   dotnet run
   ```

6. Access the application in your browser at `https://localhost:5001` or `http://localhost:5000`

## Database Schema

### Students Table
- Id (PK)
- FirstName
- LastName
- DateOfBirth
- GPA
- Hobby
- ProgramCode (FK)

### Programs Table
- ProgramCode (PK)
- ProgramName

## Usage

### Adding a Student
1. Click on "Add New Student" button
2. Fill in the required details: First Name, Last Name, Date of Birth, GPA, Hobby
3. Select a Program from the dropdown
4. Click "Add Student"

### Viewing All Students
- Navigate to the home page or click on the "All Students" link

### Editing a Student
1. On the student list, click "Edit" beside the student record
2. Update the information as needed
3. Click "Save Changes"

### Deleting a Student
1. On the student list, click "Delete" beside the student record
2. Confirm deletion on the confirmation page

## Contributing

1. Fork the repository
2. Create a feature branch: `git checkout -b feature-name`
3. Commit your changes: `git commit -m 'Add some feature'`
4. Push to the branch: `git push origin feature-name`
5. Submit a pull request

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Acknowledgments

- Initial student data is populated with Dragon Ball characters
- Project created as a learning exercise for ASP.NET Core MVC