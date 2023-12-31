using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodManager.Infrastructure.Persistence.Ef.Migrations
{
    /// <inheritdoc />
    public partial class CreateUniqueIndexStockTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tbl_Stock_BloodType_BloodRhFactor",
                table: "tbl_Stock",
                columns: new[] { "BloodType", "BloodRhFactor" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tbl_Stock_BloodType_BloodRhFactor",
                table: "tbl_Stock");
        }
    }
}
