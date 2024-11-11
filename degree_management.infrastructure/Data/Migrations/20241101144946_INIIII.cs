using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace degree_management.infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class INIIII : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentCode",
                table: "StudentGraduateds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentCode",
                table: "StudentGraduateds");
        }
    }
}
