using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodManager.Infrastructure.Persistence.Ef.Migrations
{
    /// <inheritdoc />
    public partial class CreateBloodFieldsInDonor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Genre",
                table: "tbl_Donor",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "tbl_Donor");
        }
    }
}
