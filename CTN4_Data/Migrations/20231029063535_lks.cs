using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CTN4_Data.Migrations
{
    public partial class lks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("0a5d02eb-3768-4359-92d1-354f274a43a0"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("0f5a019b-88cd-4d04-9552-206818e31751"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("13b66bbd-9b67-4bd4-b087-b9b80b1f9be4"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("6787a642-25ad-4c91-97e3-16189b27cd8b"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("b2581e32-0dd9-4010-aba6-0a823ee4737b"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("c7e54988-8e66-4455-b3df-6543b04a5c40"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("d702138e-0617-4d80-ad48-e47cf009f9c9"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("e51593da-1e91-41af-949c-9459a4d720b1"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("e8419cdd-8936-465b-8ebd-071ded1d8f3d"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("f3ef6bbf-f539-49b8-aa73-369affecf51a"));

            migrationBuilder.InsertData(
                table: "SanPhamChiTiets",
                columns: new[] { "Id", "GhiChu", "GiaBan", "GiaNhap", "GiaNiemYet", "IdChatLieu", "IdMau", "IdNSX", "IdSize", "IdSp", "Is_detele", "MaSp", "MoTa", "SoLuong", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("177c0a97-1082-4d4c-8d44-c58ee4d24cb3"), "", 650000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081121"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081154"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081911"), true, "SP08", "oke la", 100, true },
                    { new Guid("195dd146-bd5d-4dca-a559-3d0c64e62233"), "", 700000f, 600000f, 70000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081137"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081112"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081125"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081148"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081411"), true, "SP03", "oke la", 100, true },
                    { new Guid("249ebd81-128f-4063-b9a9-59e8014aa885"), "", 700000f, 300000f, 750000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081138"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081116"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081152"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081711"), true, "SP06", "oke la", 100, true },
                    { new Guid("2f13024f-d777-4852-912b-d5da4ab5840e"), "", 600000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081138"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081112"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081156"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081123"), true, "SP10", "oke la", 100, true },
                    { new Guid("6f066217-13a9-4cb2-bf02-8a5e862ab85d"), "", 500000f, 300000f, 450000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081137"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081112"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081146"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081211"), true, "SP01", "oke la", 100, true },
                    { new Guid("7e16c2e8-9819-4ba4-b2fa-78a308df6f7e"), "", 4500000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081137"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081110"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081127"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081150"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081611"), true, "SP05", "oke la", 100, true },
                    { new Guid("87f9013f-5eab-4658-87b0-82c61d4bd99d"), "", 500000f, 400000f, 450000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081138"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081113"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081153"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081811"), true, "SP07", "oke la", 100, true },
                    { new Guid("9a08196f-45a1-492d-a6e7-a3bdf1b653d3"), "", 600000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081138"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081131"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081125"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081147"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081311"), true, "SP02", "oke la", 100, true },
                    { new Guid("e417e146-fe3c-4159-8ad4-8d274330e52c"), "", 600000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081131"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081155"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081122"), true, "SP09", "oke la", 100, true },
                    { new Guid("e5933606-50f6-4cff-8400-85824d0bd0d9"), "", 600000f, 300000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081110"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081126"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081149"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081511"), true, "SP04", "oke la", 100, true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("177c0a97-1082-4d4c-8d44-c58ee4d24cb3"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("195dd146-bd5d-4dca-a559-3d0c64e62233"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("249ebd81-128f-4063-b9a9-59e8014aa885"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("2f13024f-d777-4852-912b-d5da4ab5840e"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("6f066217-13a9-4cb2-bf02-8a5e862ab85d"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("7e16c2e8-9819-4ba4-b2fa-78a308df6f7e"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("87f9013f-5eab-4658-87b0-82c61d4bd99d"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("9a08196f-45a1-492d-a6e7-a3bdf1b653d3"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("e417e146-fe3c-4159-8ad4-8d274330e52c"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("e5933606-50f6-4cff-8400-85824d0bd0d9"));

            migrationBuilder.InsertData(
                table: "SanPhamChiTiets",
                columns: new[] { "Id", "GhiChu", "GiaBan", "GiaNhap", "GiaNiemYet", "IdChatLieu", "IdMau", "IdNSX", "IdSize", "IdSp", "Is_detele", "MaSp", "MoTa", "SoLuong", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("0a5d02eb-3768-4359-92d1-354f274a43a0"), "", 4500000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081137"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081110"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081127"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081150"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081611"), true, "SP05", "oke la", 100, true },
                    { new Guid("0f5a019b-88cd-4d04-9552-206818e31751"), "", 600000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081138"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081112"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081156"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081123"), true, "SP10", "oke la", 100, true },
                    { new Guid("13b66bbd-9b67-4bd4-b087-b9b80b1f9be4"), "", 600000f, 300000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081110"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081126"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081149"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081511"), true, "SP04", "oke la", 100, true },
                    { new Guid("6787a642-25ad-4c91-97e3-16189b27cd8b"), "", 700000f, 600000f, 70000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081137"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081112"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081125"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081148"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081411"), true, "SP03", "oke la", 100, true },
                    { new Guid("b2581e32-0dd9-4010-aba6-0a823ee4737b"), "", 650000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081121"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081154"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081911"), true, "SP08", "oke la", 100, true },
                    { new Guid("c7e54988-8e66-4455-b3df-6543b04a5c40"), "", 500000f, 300000f, 450000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081137"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081112"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081146"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081211"), true, "SP01", "oke la", 100, true },
                    { new Guid("d702138e-0617-4d80-ad48-e47cf009f9c9"), "", 600000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081138"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081131"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081125"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081147"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081311"), true, "SP02", "oke la", 100, true },
                    { new Guid("e51593da-1e91-41af-949c-9459a4d720b1"), "", 600000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081131"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081155"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081122"), true, "SP09", "oke la", 100, true },
                    { new Guid("e8419cdd-8936-465b-8ebd-071ded1d8f3d"), "", 700000f, 300000f, 750000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081138"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081116"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081152"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081711"), true, "SP06", "oke la", 100, true },
                    { new Guid("f3ef6bbf-f539-49b8-aa73-369affecf51a"), "", 500000f, 400000f, 450000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081138"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081113"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081153"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081811"), true, "SP07", "oke la", 100, true }
                });
        }
    }
}
