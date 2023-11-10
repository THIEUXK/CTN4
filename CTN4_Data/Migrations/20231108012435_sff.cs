using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CTN4_Data.Migrations
{
    public partial class sff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "KhuyenMais",
                keyColumn: "Id",
                keyValue: new Guid("13effe44-e728-48a8-9baa-967da4ee38cd"),
                columns: new[] { "NgayBatDau", "NgayKetThuc" },
                values: new object[] { new DateTime(2023, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "KhuyenMais",
                keyColumn: "Id",
                keyValue: new Guid("23bdd26c-d7a3-4307-8e22-d230b653d611"),
                columns: new[] { "NgayBatDau", "NgayKetThuc" },
                values: new object[] { new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "KhuyenMais",
                keyColumn: "Id",
                keyValue: new Guid("da810cca-4fca-4291-a52b-875841d49e34"),
                columns: new[] { "NgayBatDau", "NgayKetThuc" },
                values: new object[] { new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "KhuyenMais",
                keyColumn: "Id",
                keyValue: new Guid("e3e37e9e-7ea3-4f87-94af-1329363a4322"),
                columns: new[] { "NgayBatDau", "NgayKetThuc" },
                values: new object[] { new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "KhuyenMais",
                keyColumn: "Id",
                keyValue: new Guid("f877e80d-2b32-43b0-be70-cf3b15113056"),
                columns: new[] { "NgayBatDau", "NgayKetThuc" },
                values: new object[] { new DateTime(2023, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "KhuyenMais",
                keyColumn: "Id",
                keyValue: new Guid("fa1ae994-6ab0-4ee6-b8b1-ff336cf994a8"),
                column: "NgayKetThuc",
                value: new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "KhuyenMais",
                keyColumn: "Id",
                keyValue: new Guid("13effe44-e728-48a8-9baa-967da4ee38cd"),
                columns: new[] { "NgayBatDau", "NgayKetThuc" },
                values: new object[] { new DateTime(2023, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "KhuyenMais",
                keyColumn: "Id",
                keyValue: new Guid("23bdd26c-d7a3-4307-8e22-d230b653d611"),
                columns: new[] { "NgayBatDau", "NgayKetThuc" },
                values: new object[] { new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "KhuyenMais",
                keyColumn: "Id",
                keyValue: new Guid("da810cca-4fca-4291-a52b-875841d49e34"),
                columns: new[] { "NgayBatDau", "NgayKetThuc" },
                values: new object[] { new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "KhuyenMais",
                keyColumn: "Id",
                keyValue: new Guid("e3e37e9e-7ea3-4f87-94af-1329363a4322"),
                columns: new[] { "NgayBatDau", "NgayKetThuc" },
                values: new object[] { new DateTime(2023, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "KhuyenMais",
                keyColumn: "Id",
                keyValue: new Guid("f877e80d-2b32-43b0-be70-cf3b15113056"),
                columns: new[] { "NgayBatDau", "NgayKetThuc" },
                values: new object[] { new DateTime(2023, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "KhuyenMais",
                keyColumn: "Id",
                keyValue: new Guid("fa1ae994-6ab0-4ee6-b8b1-ff336cf994a8"),
                column: "NgayKetThuc",
                value: new DateTime(2023, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
