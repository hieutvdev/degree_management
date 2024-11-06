using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace degree_management.infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class _061124Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Periods",
                newName: "Active");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Periods",
                newName: "Status");
        }
    }
}
