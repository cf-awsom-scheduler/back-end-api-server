using Microsoft.EntityFrameworkCore.Migrations;

namespace awsomAPI.Migrations
{
    public partial class StringDataTypesInModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Zip",
                table: "Users",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "TrialRequests",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "HasInstrument",
                table: "TrialRequests",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<string>(
                name: "Instrument",
                table: "TrialRequests",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Instrument",
                table: "TrialRequests");

            migrationBuilder.AlterColumn<int>(
                name: "Zip",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ZipCode",
                table: "TrialRequests",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<bool>(
                name: "HasInstrument",
                table: "TrialRequests",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
