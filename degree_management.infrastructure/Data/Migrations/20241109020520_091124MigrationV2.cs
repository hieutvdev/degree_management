using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace degree_management.infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class _091124MigrationV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DegreeTypeInWard");

            migrationBuilder.CreateTable(
                name: "StockInInvSuggestDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockInInvSuggestId = table.Column<int>(type: "int", nullable: false),
                    DegreeTypeId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockInInvSuggestDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockInInvSuggestDetails_StockInInvSuggests_StockInInvSuggestId",
                        column: x => x.StockInInvSuggestId,
                        principalTable: "StockInInvSuggests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockInInvSuggestDetails_StockInInvSuggestId",
                table: "StockInInvSuggestDetails",
                column: "StockInInvSuggestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockInInvSuggestDetails");

            migrationBuilder.CreateTable(
                name: "DegreeTypeInWard",
                columns: table => new
                {
                    StockInInvSuggestId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DegreeTypeId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DegreeTypeInWard", x => new { x.StockInInvSuggestId, x.Id });
                    table.ForeignKey(
                        name: "FK_DegreeTypeInWard_StockInInvSuggests_StockInInvSuggestId",
                        column: x => x.StockInInvSuggestId,
                        principalTable: "StockInInvSuggests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
