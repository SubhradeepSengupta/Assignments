using Microsoft.EntityFrameworkCore.Migrations;

namespace DotnetAssignment1.data.Migrations
{
    public partial class NewMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Messages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Messages",
                nullable: false,
                defaultValue: 0);
        }
    }
}
