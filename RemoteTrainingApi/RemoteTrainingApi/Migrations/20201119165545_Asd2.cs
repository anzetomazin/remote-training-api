using Microsoft.EntityFrameworkCore.Migrations;

namespace RemoteTrainingApi.Migrations
{
    public partial class Asd2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Group",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
