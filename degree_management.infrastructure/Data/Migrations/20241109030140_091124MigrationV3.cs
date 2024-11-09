using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace degree_management.infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class _091124MigrationV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StockInInvSuggestDetails_DegreeTypeId",
                table: "StockInInvSuggestDetails",
                column: "DegreeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockInInvSuggestDetails_DegreeTypes_DegreeTypeId",
                table: "StockInInvSuggestDetails",
                column: "DegreeTypeId",
                principalTable: "DegreeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockInInvSuggestDetails_DegreeTypes_DegreeTypeId",
                table: "StockInInvSuggestDetails");

            migrationBuilder.DropIndex(
                name: "IX_StockInInvSuggestDetails_DegreeTypeId",
                table: "StockInInvSuggestDetails");
        }
    }
}
