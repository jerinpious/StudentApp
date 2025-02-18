using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    ProgramCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProgramName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.ProgramCode);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GPA = table.Column<double>(type: "float", nullable: false),
                    Hobby = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProgramCode1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Programs_ProgramCode",
                        column: x => x.ProgramCode,
                        principalTable: "Programs",
                        principalColumn: "ProgramCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Programs_ProgramCode1",
                        column: x => x.ProgramCode1,
                        principalTable: "Programs",
                        principalColumn: "ProgramCode");
                });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "ProgramCode", "ProgramName" },
                values: new object[,]
                {
                    { "BACS", "Bachelor of Applied Computer Science" },
                    { "CPA", "Computer Programmer Analyst" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "GPA", "Hobby", "LastName", "ProgramCode", "ProgramCode1" },
                values: new object[,]
                {
                    { 1, new DateTime(737, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Goku", 4.0, "Training, Eating", "Son", "BACS", null },
                    { 2, new DateTime(732, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vegeta", 3.8999999999999999, "Fighting, Training", "Saiyan", "CPA", null },
                    { 3, new DateTime(757, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gohan", 3.7999999999999998, "Studying, Protecting Earth", "Son", "BACS", null },
                    { 4, new DateTime(766, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trunks", 3.7000000000000002, "Sword Fighting, Training", "Brief", "BACS", null },
                    { 5, new DateTime(732, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Piccolo", 4.0, "Training, Meditation", "Namekian", "CPA", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ProgramCode",
                table: "Students",
                column: "ProgramCode");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ProgramCode1",
                table: "Students",
                column: "ProgramCode1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Programs");
        }
    }
}
