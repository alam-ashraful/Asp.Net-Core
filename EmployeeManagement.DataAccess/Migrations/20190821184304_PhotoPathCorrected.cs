using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.DataAccess.Migrations
{
    public partial class PhotoPathCorrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoPat",
                table: "Employees",
                newName: "PhotoPath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoPath",
                table: "Employees",
                newName: "PhotoPat");
        }
    }
}
