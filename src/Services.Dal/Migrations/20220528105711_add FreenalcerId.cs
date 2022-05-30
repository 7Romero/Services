using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Services.Dal.Migrations
{
    public partial class addFreenalcerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FreelancerId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FreelancerId",
                table: "Orders",
                column: "FreelancerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_FreelancerId",
                table: "Orders",
                column: "FreelancerId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_FreelancerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_FreelancerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FreelancerId",
                table: "Orders");
        }
    }
}
