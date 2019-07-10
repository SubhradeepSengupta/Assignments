using Microsoft.EntityFrameworkCore.Migrations;

namespace DotnetAssignment1.data.Migrations
{
    public partial class NewMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Like",
                table: "Messages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Like",
                table: "Messages",
                nullable: false,
                defaultValue: 0);
        }
    }
}
