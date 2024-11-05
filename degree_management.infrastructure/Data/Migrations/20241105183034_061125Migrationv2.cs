using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace degree_management.infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class _061125Migrationv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Degrees_DegreeId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "IssueDate",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CreditsRequired",
                table: "Degrees");

            migrationBuilder.RenameColumn(
                name: "DegreeId",
                table: "Inventories",
                newName: "DegreeTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventories_DegreeId",
                table: "Inventories",
                newName: "IX_Inventories_DegreeTypeId");

            migrationBuilder.AddColumn<int>(
                name: "SpecializationId",
                table: "DegreeTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "IssueDate",
                table: "Degrees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_DegreeTypes_SpecializationId",
                table: "DegreeTypes",
                column: "SpecializationId");

            migrationBuilder.AddForeignKey(
                name: "FK_DegreeTypes_Specializations_SpecializationId",
                table: "DegreeTypes",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_DegreeTypes_DegreeTypeId",
                table: "Inventories",
                column: "DegreeTypeId",
                principalTable: "DegreeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DegreeTypes_Specializations_SpecializationId",
                table: "DegreeTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_DegreeTypes_DegreeTypeId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_DegreeTypes_SpecializationId",
                table: "DegreeTypes");

            migrationBuilder.DropColumn(
                name: "SpecializationId",
                table: "DegreeTypes");

            migrationBuilder.DropColumn(
                name: "IssueDate",
                table: "Degrees");

            migrationBuilder.RenameColumn(
                name: "DegreeTypeId",
                table: "Inventories",
                newName: "DegreeId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventories_DegreeTypeId",
                table: "Inventories",
                newName: "IX_Inventories_DegreeId");

            migrationBuilder.AddColumn<DateTime>(
                name: "IssueDate",
                table: "Inventories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Inventories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CreditsRequired",
                table: "Degrees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Degrees_DegreeId",
                table: "Inventories",
                column: "DegreeId",
                principalTable: "Degrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
