using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace degree_management.infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class _101124Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockInInvSuggests_Warehouses_WarehouseId",
                table: "StockInInvSuggests");

            migrationBuilder.AlterColumn<int>(
                name: "WarehouseId",
                table: "StockInInvSuggests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StockInInvSuggests_Warehouses_WarehouseId",
                table: "StockInInvSuggests",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockInInvSuggests_Warehouses_WarehouseId",
                table: "StockInInvSuggests");

            migrationBuilder.AlterColumn<int>(
                name: "WarehouseId",
                table: "StockInInvSuggests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_StockInInvSuggests_Warehouses_WarehouseId",
                table: "StockInInvSuggests",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id");
        }
    }
}
