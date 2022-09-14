using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddSocialMediaAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserSocialMediaAddresses",
                columns: new[] { "Id", "GithubUrl", "UserId" },
                values: new object[] { 1, "https://github.com/aktasilyas", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserSocialMediaAddresses",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
