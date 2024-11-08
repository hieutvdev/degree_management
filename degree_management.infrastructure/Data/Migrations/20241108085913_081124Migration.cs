using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace degree_management.infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class _081124Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "YearGraduations");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Specializations");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Periods");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Majors");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "DegreeTypes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "YearGraduations",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Warehouses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Specializations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Periods",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Majors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Faculties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "DegreeTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
