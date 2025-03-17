using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notes.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "note",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_note_ProjectId",
                table: "note",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_note_project_ProjectId",
                table: "note",
                column: "ProjectId",
                principalTable: "project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_note_project_ProjectId",
                table: "note");

            migrationBuilder.DropTable(
                name: "project");

            migrationBuilder.DropIndex(
                name: "IX_note_ProjectId",
                table: "note");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "note");
        }
    }
}
