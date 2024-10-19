using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class changename2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detils_SPR_Header_SP_IdRef",
                table: "Detils_SPR");

            migrationBuilder.DropForeignKey(
                name: "FK_Header_SP_Proyeks_ProyekId",
                table: "Header_SP");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Header_SP",
                table: "Header_SP");

            migrationBuilder.RenameTable(
                name: "Header_SP",
                newName: "Headers_SP");

            migrationBuilder.RenameIndex(
                name: "IX_Header_SP_ProyekId",
                table: "Headers_SP",
                newName: "IX_Headers_SP_ProyekId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Headers_SP",
                table: "Headers_SP",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Detils_SPR_Headers_SP_IdRef",
                table: "Detils_SPR",
                column: "IdRef",
                principalTable: "Headers_SP",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Headers_SP_Proyeks_ProyekId",
                table: "Headers_SP",
                column: "ProyekId",
                principalTable: "Proyeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detils_SPR_Headers_SP_IdRef",
                table: "Detils_SPR");

            migrationBuilder.DropForeignKey(
                name: "FK_Headers_SP_Proyeks_ProyekId",
                table: "Headers_SP");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Headers_SP",
                table: "Headers_SP");

            migrationBuilder.RenameTable(
                name: "Headers_SP",
                newName: "Header_SP");

            migrationBuilder.RenameIndex(
                name: "IX_Headers_SP_ProyekId",
                table: "Header_SP",
                newName: "IX_Header_SP_ProyekId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Header_SP",
                table: "Header_SP",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Detils_SPR_Header_SP_IdRef",
                table: "Detils_SPR",
                column: "IdRef",
                principalTable: "Header_SP",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Header_SP_Proyeks_ProyekId",
                table: "Header_SP",
                column: "ProyekId",
                principalTable: "Proyeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
