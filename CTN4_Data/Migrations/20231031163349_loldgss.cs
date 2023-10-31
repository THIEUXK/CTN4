using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CTN4_Data.Migrations
{
    public partial class loldgss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TenDiaChi",
                table: "DaiChiNhanHangs",
                newName: "phone_code");

            migrationBuilder.AddColumn<string>(
                name: "code",
                table: "DaiChiNhanHangs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "division_type",
                table: "DaiChiNhanHangs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "DaiChiNhanHangs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "code",
                table: "DaiChiNhanHangs");

            migrationBuilder.DropColumn(
                name: "division_type",
                table: "DaiChiNhanHangs");

            migrationBuilder.DropColumn(
                name: "name",
                table: "DaiChiNhanHangs");

            migrationBuilder.RenameColumn(
                name: "phone_code",
                table: "DaiChiNhanHangs",
                newName: "TenDiaChi");
        }
    }
}
