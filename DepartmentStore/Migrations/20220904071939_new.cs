using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DepartmentStore.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Repassword",
                table: "register",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Repassword",
                table: "register");
        }
    }
}
