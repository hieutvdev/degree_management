using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace degree_management.infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class _061124MigrationV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Degrees_DegreeTypes_DegreeTypeId",
                table: "Degrees");

            migrationBuilder.DropIndex(
                name: "IX_DegreeTypes_SpecializationId",
                table: "DegreeTypes");

            migrationBuilder.DropIndex(
                name: "IX_Degrees_DegreeTypeId",
                table: "Degrees");

            migrationBuilder.DropColumn(
                name: "DegreeTypeId",
                table: "Degrees");

            migrationBuilder.CreateIndex(
                name: "IX_DegreeTypes_SpecializationId",
                table: "DegreeTypes",
                column: "SpecializationId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DegreeTypes_SpecializationId",
                table: "DegreeTypes");

            migrationBuilder.AddColumn<int>(
                name: "DegreeTypeId",
                table: "Degrees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DegreeTypes_SpecializationId",
                table: "DegreeTypes",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_Degrees_DegreeTypeId",
                table: "Degrees",
                column: "DegreeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Degrees_DegreeTypes_DegreeTypeId",
                table: "Degrees",
                column: "DegreeTypeId",
                principalTable: "DegreeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
