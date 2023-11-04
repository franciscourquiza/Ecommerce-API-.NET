using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_commerce_API.Migrations
{
    /// <inheritdoc />
    public partial class FixSaleOrderLineEntitySOLIDUnnecesary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SaleOrderLineId",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SaleOrderLineId",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
