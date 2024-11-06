using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace degree_management.infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class _051124Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentGraduateds_Periods_PeriodId",
                table: "StudentGraduateds");

            migrationBuilder.DropColumn(
                name: "PreiodId",
                table: "StudentGraduateds");

            migrationBuilder.AlterColumn<int>(
                name: "PeriodId",
                table: "StudentGraduateds",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGraduateds_Periods_PeriodId",
                table: "StudentGraduateds",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentGraduateds_Periods_PeriodId",
                table: "StudentGraduateds");

            migrationBuilder.AlterColumn<int>(
                name: "PeriodId",
                table: "StudentGraduateds",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PreiodId",
                table: "StudentGraduateds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGraduateds_Periods_PeriodId",
                table: "StudentGraduateds",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id");
        }
    }
}
