using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CTN4_Data.Migrations
{
    public partial class kok : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("1c03f1ca-365c-4e25-968c-36ff95b16374"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("2c0646d5-9341-4c06-8102-8495b423a17e"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("2d91e0e8-671b-4495-b6d0-7fce091c7cb6"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("31425bcc-f1c4-4c7f-8df2-ea8c91f01eca"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("59b92a4f-c1d6-4e21-bd0e-334ab200c968"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("79a3a128-a614-4f48-af49-ed2e2b3cff56"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("952110d8-7156-4f22-82f1-ec04f4bac298"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("afbe216f-4ea0-407c-beb8-10a23b6047d3"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("d0ed2a2b-6e53-4253-80bf-7eddd963f1b3"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("d2ccac48-4af3-4704-a933-176bed04d6d4"));

            migrationBuilder.InsertData(
                table: "SanPhamChiTiets",
                columns: new[] { "Id", "GhiChu", "GiaBan", "GiaNhap", "GiaNiemYet", "IdChatLieu", "IdMau", "IdNSX", "IdSize", "IdSp", "Is_detele", "MaSp", "MoTa", "SoLuong", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("1509d22f-7ff4-43a2-a34f-4557206d9337"), "", 4500000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081137"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081110"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081127"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081150"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081611"), true, "SP05", "oke la", 100, true },
                    { new Guid("17f73722-02ba-4eed-9d08-da38f11dd5ac"), "", 600000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081138"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081131"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081125"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081147"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081311"), true, "SP02", "oke la", 100, true },
                    { new Guid("575137b8-ea1d-44f8-89fc-8dd6ea39b23f"), "", 500000f, 300000f, 450000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081137"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081112"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081146"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081211"), true, "SP01", "oke la", 100, true },
                    { new Guid("6f81ec60-1f39-4d86-89df-42d284725ed8"), "", 700000f, 300000f, 750000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081138"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081116"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081152"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081711"), true, "SP06", "oke la", 100, true },
                    { new Guid("6fe602c8-be33-4e6f-be46-9a553966056d"), "", 600000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081131"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081155"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081122"), true, "SP09", "oke la", 100, true },
                    { new Guid("76a70c1c-ef95-4cbf-8018-cbf2b1eda53f"), "", 600000f, 300000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081110"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081126"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081149"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081511"), true, "SP04", "oke la", 100, true },
                    { new Guid("78ed11b9-b8f0-43de-a46a-0f63bce8604e"), "", 650000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081121"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081154"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081911"), true, "SP08", "oke la", 100, true },
                    { new Guid("7d492627-9ea9-4d19-b898-e863cd0476ef"), "", 700000f, 600000f, 70000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081137"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081112"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081125"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081148"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081411"), true, "SP03", "oke la", 100, true },
                    { new Guid("ee521cd3-3135-4569-8c72-a3e5c6afbf27"), "", 500000f, 400000f, 450000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081138"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081113"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081153"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081811"), true, "SP07", "oke la", 100, true },
                    { new Guid("f604d486-3456-4207-9970-5b0bc86524c9"), "", 600000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081138"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081112"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081156"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081123"), true, "SP10", "oke la", 100, true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("1509d22f-7ff4-43a2-a34f-4557206d9337"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("17f73722-02ba-4eed-9d08-da38f11dd5ac"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("575137b8-ea1d-44f8-89fc-8dd6ea39b23f"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("6f81ec60-1f39-4d86-89df-42d284725ed8"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("6fe602c8-be33-4e6f-be46-9a553966056d"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("76a70c1c-ef95-4cbf-8018-cbf2b1eda53f"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("78ed11b9-b8f0-43de-a46a-0f63bce8604e"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("7d492627-9ea9-4d19-b898-e863cd0476ef"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("ee521cd3-3135-4569-8c72-a3e5c6afbf27"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("f604d486-3456-4207-9970-5b0bc86524c9"));

            migrationBuilder.InsertData(
                table: "SanPhamChiTiets",
                columns: new[] { "Id", "GhiChu", "GiaBan", "GiaNhap", "GiaNiemYet", "IdChatLieu", "IdMau", "IdNSX", "IdSize", "IdSp", "Is_detele", "MaSp", "MoTa", "SoLuong", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("1c03f1ca-365c-4e25-968c-36ff95b16374"), "", 600000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081138"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081112"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081156"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081123"), true, "SP10", "oke la", 100, true },
                    { new Guid("2c0646d5-9341-4c06-8102-8495b423a17e"), "", 4500000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081137"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081110"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081127"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081150"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081611"), true, "SP05", "oke la", 100, true },
                    { new Guid("2d91e0e8-671b-4495-b6d0-7fce091c7cb6"), "", 500000f, 400000f, 450000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081138"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081113"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081153"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081811"), true, "SP07", "oke la", 100, true },
                    { new Guid("31425bcc-f1c4-4c7f-8df2-ea8c91f01eca"), "", 700000f, 300000f, 750000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081138"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081116"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081152"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081711"), true, "SP06", "oke la", 100, true },
                    { new Guid("59b92a4f-c1d6-4e21-bd0e-334ab200c968"), "", 650000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081121"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081154"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081911"), true, "SP08", "oke la", 100, true },
                    { new Guid("79a3a128-a614-4f48-af49-ed2e2b3cff56"), "", 500000f, 300000f, 450000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081137"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081112"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081146"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081211"), true, "SP01", "oke la", 100, true },
                    { new Guid("952110d8-7156-4f22-82f1-ec04f4bac298"), "", 700000f, 600000f, 70000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081137"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081112"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081125"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081148"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081411"), true, "SP03", "oke la", 100, true },
                    { new Guid("afbe216f-4ea0-407c-beb8-10a23b6047d3"), "", 600000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081138"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081131"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081125"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081147"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081311"), true, "SP02", "oke la", 100, true },
                    { new Guid("d0ed2a2b-6e53-4253-80bf-7eddd963f1b3"), "", 600000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081131"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081155"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081122"), true, "SP09", "oke la", 100, true },
                    { new Guid("d2ccac48-4af3-4704-a933-176bed04d6d4"), "", 600000f, 300000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081110"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081126"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081149"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081511"), true, "SP04", "oke la", 100, true }
                });
        }
    }
}
