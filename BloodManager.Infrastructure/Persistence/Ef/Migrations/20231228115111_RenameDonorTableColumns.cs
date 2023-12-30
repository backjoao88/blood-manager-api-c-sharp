using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodManager.Infrastructure.Persistence.Ef.Migrations
{
    /// <inheritdoc />
    public partial class RenameDonorTableColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email_Value",
                table: "tbl_Donor",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Address_Street",
                table: "tbl_Donor",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "Address_State",
                table: "tbl_Donor",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "Address_PostalCode",
                table: "tbl_Donor",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "tbl_Donor",
                newName: "City");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Street",
                table: "tbl_Donor",
                newName: "Address_Street");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "tbl_Donor",
                newName: "Address_State");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "tbl_Donor",
                newName: "Address_PostalCode");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "tbl_Donor",
                newName: "Email_Value");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "tbl_Donor",
                newName: "Address_City");
        }
    }
}
