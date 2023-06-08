using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkspacePlacement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "WorkspacePlacementId",
                table: "workspace",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");
            
            migrationBuilder.CreateTable(
                name: "workspacePlacement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WorkspaceId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PositionX = table.Column<int>(type: "int", nullable: false),
                    PositionY = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Rotation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workspacePlacement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_workspacePlacement_workspace_WorkspaceId",
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

            migrationBuilder.CreateIndex(
                name: "IX_workspacePlacement_WorkspaceId",
                table: "workspacePlacement",
                column: "WorkspaceId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "workspaceCharacteristic");

            migrationBuilder.DropTable(
                name: "workspacePlacement");

            migrationBuilder.DropColumn(
                name: "WorkspacePlacementId",
                table: "workspace");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "characteristic",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
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
