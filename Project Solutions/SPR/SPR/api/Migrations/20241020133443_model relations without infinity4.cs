using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class modelrelationswithoutinfinity4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "logSPRs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SPRId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserApproverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TanggalAction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Keterangan = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logSPRs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NamaMaterial = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TipeMaterial = table.Column<int>(type: "int", nullable: false),
                    StokMaterial = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proyeks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaProyek = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LokasiProyek = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TanggalMulai = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TanggalSelesai = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyeks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Headers_SP",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TanggalMinta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusSPR = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ZonaSPR = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    TujuanSPR = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProyekId = table.Column<int>(type: "int", nullable: false),
                    UserPemintaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Headers_SP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Headers_SP_Proyeks_ProyekId",
                        column: x => x.ProyekId,
                        principalTable: "Proyeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Headers_SP_Users_UserPemintaId",
                        column: x => x.UserPemintaId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "approvalSPRs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SPRId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserApproverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TanggalApproval = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusApproval = table.Column<bool>(type: "bit", nullable: false),
                    Komentar = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_approvalSPRs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_approvalSPRs_Headers_SP_SPRId",
                        column: x => x.SPRId,
                        principalTable: "Headers_SP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_approvalSPRs_Users_UserApproverId",
                        column: x => x.UserApproverId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_approvalSPRs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Detils_SPR",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SPRId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Volume = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TanggalRencanaTerima = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusDisetujui = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detils_SPR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Detils_SPR_Headers_SP_SPRId",
                        column: x => x.SPRId,
                        principalTable: "Headers_SP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detils_SPR_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_approvalSPRs_SPRId",
                table: "approvalSPRs",
                column: "SPRId");

            migrationBuilder.CreateIndex(
                name: "IX_approvalSPRs_UserApproverId",
                table: "approvalSPRs",
                column: "UserApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_approvalSPRs_UserId",
                table: "approvalSPRs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Detils_SPR_MaterialId",
                table: "Detils_SPR",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Detils_SPR_SPRId",
                table: "Detils_SPR",
                column: "SPRId");

            migrationBuilder.CreateIndex(
                name: "IX_Headers_SP_ProyekId",
                table: "Headers_SP",
                column: "ProyekId");

            migrationBuilder.CreateIndex(
                name: "IX_Headers_SP_UserPemintaId",
                table: "Headers_SP",
                column: "UserPemintaId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "approvalSPRs");

            migrationBuilder.DropTable(
                name: "Detils_SPR");

            migrationBuilder.DropTable(
                name: "logSPRs");

            migrationBuilder.DropTable(
                name: "Headers_SP");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Proyeks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
