using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Services.Dal.Migrations
{
    public partial class addcolumnDescriptionTitleforUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescriptionTitle",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionTitle",
                table: "Users");
        }
    }
}
