using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class changename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detil_SPRs_Headers_IdRef",
                table: "Detil_SPRs");

            migrationBuilder.DropForeignKey(
                name: "FK_Detil_SPRs_Materials_MaterialId",
                table: "Detil_SPRs");

            migrationBuilder.DropForeignKey(
                name: "FK_Headers_Proyeks_ProyekId",
                table: "Headers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Headers",
                table: "Headers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Detil_SPRs",
                table: "Detil_SPRs");

            migrationBuilder.RenameTable(
                name: "Headers",
                newName: "Header_SP");

            migrationBuilder.RenameTable(
                name: "Detil_SPRs",
                newName: "Detils_SPR");

            migrationBuilder.RenameIndex(
                name: "IX_Headers_ProyekId",
                table: "Header_SP",
                newName: "IX_Header_SP_ProyekId");

            migrationBuilder.RenameIndex(
                name: "IX_Detil_SPRs_MaterialId",
                table: "Detils_SPR",
                newName: "IX_Detils_SPR_MaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_Detil_SPRs_IdRef",
                table: "Detils_SPR",
                newName: "IX_Detils_SPR_IdRef");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Header_SP",
                table: "Header_SP",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Detils_SPR",
                table: "Detils_SPR",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Detils_SPR_Header_SP_IdRef",
                table: "Detils_SPR",
                column: "IdRef",
                principalTable: "Header_SP",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Detils_SPR_Materials_MaterialId",
                table: "Detils_SPR",
                column: "MaterialId",
                principalTable: "Materials",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detils_SPR_Header_SP_IdRef",
                table: "Detils_SPR");

            migrationBuilder.DropForeignKey(
                name: "FK_Detils_SPR_Materials_MaterialId",
                table: "Detils_SPR");

            migrationBuilder.DropForeignKey(
                name: "FK_Header_SP_Proyeks_ProyekId",
                table: "Header_SP");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Header_SP",
                table: "Header_SP");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Detils_SPR",
                table: "Detils_SPR");

            migrationBuilder.RenameTable(
                name: "Header_SP",
                newName: "Headers");

            migrationBuilder.RenameTable(
                name: "Detils_SPR",
                newName: "Detil_SPRs");

            migrationBuilder.RenameIndex(
                name: "IX_Header_SP_ProyekId",
                table: "Headers",
                newName: "IX_Headers_ProyekId");

            migrationBuilder.RenameIndex(
                name: "IX_Detils_SPR_MaterialId",
                table: "Detil_SPRs",
                newName: "IX_Detil_SPRs_MaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_Detils_SPR_IdRef",
                table: "Detil_SPRs",
                newName: "IX_Detil_SPRs_IdRef");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Headers",
                table: "Headers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Detil_SPRs",
                table: "Detil_SPRs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Detil_SPRs_Headers_IdRef",
                table: "Detil_SPRs",
                column: "IdRef",
                principalTable: "Headers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Detil_SPRs_Materials_MaterialId",
                table: "Detil_SPRs",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Headers_Proyeks_ProyekId",
                table: "Headers",
                column: "ProyekId",
                principalTable: "Proyeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
