using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodManager.Infrastructure.Persistence.Ef.Migrations
{
    /// <inheritdoc />
    public partial class AddBloodTypesToDonorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BloodRhFactor",
                table: "tbl_Donor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BloodType",
                table: "tbl_Donor",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BloodRhFactor",
                table: "tbl_Donor");

            migrationBuilder.DropColumn(
                name: "BloodType",
                table: "tbl_Donor");
        }
    }
}
