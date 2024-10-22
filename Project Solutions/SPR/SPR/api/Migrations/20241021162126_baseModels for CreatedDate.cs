using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class baseModelsforCreatedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Roles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LokasiProyek",
                table: "Proyeks",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Proyeks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Proyeks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Proyeks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Proyeks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Materials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Materials",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Materials",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SPRId",
                table: "logSPRs",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "logSPRs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "logSPRs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "logSPRs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "logSPRs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Headers_SP",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Headers_SP",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Headers_SP",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Headers_SP",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Detils_SPR",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Detils_SPR",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Detils_SPR",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Detils_SPR",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Komentar",
                table: "approvalSPRs",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "approvalSPRs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "approvalSPRs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "approvalSPRs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "approvalSPRs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Proyeks");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Proyeks");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Proyeks");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Proyeks");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "logSPRs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "logSPRs");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "logSPRs");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "logSPRs");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Headers_SP");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Headers_SP");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Headers_SP");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Headers_SP");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Detils_SPR");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Detils_SPR");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Detils_SPR");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Detils_SPR");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "approvalSPRs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "approvalSPRs");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "approvalSPRs");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "approvalSPRs");

            migrationBuilder.AlterColumn<string>(
                name: "LokasiProyek",
                table: "Proyeks",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SPRId",
                table: "logSPRs",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Komentar",
                table: "approvalSPRs",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);
        }
    }
}
