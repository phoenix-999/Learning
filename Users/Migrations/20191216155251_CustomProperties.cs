using Microsoft.EntityFrameworkCore.Migrations;

namespace Users.Migrations
{
    public partial class CustomProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Qualifications",
                table: "AspNetUsers",
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
