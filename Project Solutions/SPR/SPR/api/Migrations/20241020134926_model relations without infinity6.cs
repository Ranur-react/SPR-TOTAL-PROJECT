using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class modelrelationswithoutinfinity6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_approvalSPRs_Users_UserId",
                table: "approvalSPRs");

            migrationBuilder.DropIndex(
                name: "IX_approvalSPRs_UserId",
                table: "approvalSPRs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "approvalSPRs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "approvalSPRs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_approvalSPRs_UserId",
                table: "approvalSPRs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_approvalSPRs_Users_UserId",
                table: "approvalSPRs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
