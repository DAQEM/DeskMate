using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class wrkspaceAndcharacteristicMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "workplaceCharacteristic");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "characteristic",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "workspaceCharacteristic",
                columns: table => new
                {
                    WorkspaceId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CharacteristicId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workspaceCharacteristic", x => new { x.WorkspaceId, x.CharacteristicId });
                    table.ForeignKey(
                        name: "FK_workspaceCharacteristic_characteristic_CharacteristicId",
                        column: x => x.CharacteristicId,
                        principalTable: "characteristic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_workspaceCharacteristic_workspace_WorkspaceId",
                        column: x => x.WorkspaceId,
                        principalTable: "workspace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_workspaceCharacteristic_CharacteristicId",
                table: "workspaceCharacteristic",
                column: "CharacteristicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "workspaceCharacteristic");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "characteristic",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "workplaceCharacteristic",
                columns: table => new
                {
                    WorkspaceId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CharacteristicId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workplaceCharacteristic", x => new { x.WorkspaceId, x.CharacteristicId });
                    table.ForeignKey(
                        name: "FK_workplaceCharacteristic_characteristic_CharacteristicId",
                        column: x => x.CharacteristicId,
                        principalTable: "characteristic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_workplaceCharacteristic_workspace_WorkspaceId",
                        column: x => x.WorkspaceId,
                        principalTable: "workspace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_workplaceCharacteristic_CharacteristicId",
                table: "workplaceCharacteristic",
                column: "CharacteristicId");
        }
    }
}
