using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CTN4_Data.Migrations
{
    public partial class lkl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("128f73e5-7f5d-4e4b-9bf9-3f78abddda3a"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("1ece7721-46f0-4fec-aaad-fb204f0132e7"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("27219762-eb75-4a50-bc33-7c065d26db20"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("2d873a30-1b23-44be-84fd-a4da5dc0eea3"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("4049a7bd-519d-47a5-9741-b07b103f9262"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("52965ae8-4424-44a8-8f1a-ab35087b2473"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("7d04c29a-91d6-478d-8add-bca74229cb77"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("7d082fc1-0394-4496-9a82-2b415b2ea099"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("ef80152e-afa1-441c-921e-fb6475c85415"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("f783fa3c-7f06-4769-aead-5302bb8c655a"));

            migrationBuilder.InsertData(
                table: "SanPhamChiTiets",
                columns: new[] { "Id", "GhiChu", "GiaBan", "GiaNhap", "GiaNiemYet", "IdChatLieu", "IdMau", "IdNSX", "IdSize", "IdSp", "Is_detele", "MaSp", "MoTa", "SoLuong", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("338c0254-b463-4dfa-b2c4-0f829749344d"), "", 700000f, 300000f, 750000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081138"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081116"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081152"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081711"), true, "SP06", "oke la", 100, true },
                    { new Guid("3c7d5983-0cf6-4585-8015-ef6e8724f9c9"), "", 500000f, 400000f, 450000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081138"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081113"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081153"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081811"), true, "SP07", "oke la", 100, true },
                    { new Guid("513e030a-548c-451e-9d79-b2e277e03cc8"), "", 600000f, 300000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081110"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081126"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081149"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081511"), true, "SP04", "oke la", 100, true },
                    { new Guid("67500674-1125-4cf2-82bb-bf8964dc4769"), "", 650000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081121"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081154"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081911"), true, "SP08", "oke la", 100, true },
                    { new Guid("9aad4c17-4c6d-447f-ba5c-ab92f46275b0"), "", 600000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081138"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081131"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081125"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081147"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081311"), true, "SP02", "oke la", 100, true },
                    { new Guid("ad53e6d4-ea8c-4a7c-a677-613c42ecea29"), "", 500000f, 300000f, 450000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081137"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081112"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081146"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081211"), true, "SP01", "oke la", 100, true },
                    { new Guid("cae4f1fb-feac-486b-9fb4-b53c13d563d4"), "", 4500000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081137"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081110"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081127"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081150"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081611"), true, "SP05", "oke la", 100, true },
                    { new Guid("d078316c-2ecc-410d-a7ac-cd168a3f3aac"), "", 600000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081138"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081112"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081156"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081123"), true, "SP10", "oke la", 100, true },
                    { new Guid("f0fc441f-8757-411c-896b-29f4e2136c5f"), "", 700000f, 600000f, 70000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081137"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081112"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081125"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081148"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081411"), true, "SP03", "oke la", 100, true },
                    { new Guid("fa00c292-d2a8-49e1-b7f0-34c6b495c87d"), "", 600000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081131"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081155"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081122"), true, "SP09", "oke la", 100, true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("338c0254-b463-4dfa-b2c4-0f829749344d"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("3c7d5983-0cf6-4585-8015-ef6e8724f9c9"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("513e030a-548c-451e-9d79-b2e277e03cc8"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("67500674-1125-4cf2-82bb-bf8964dc4769"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("9aad4c17-4c6d-447f-ba5c-ab92f46275b0"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("ad53e6d4-ea8c-4a7c-a677-613c42ecea29"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("cae4f1fb-feac-486b-9fb4-b53c13d563d4"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("d078316c-2ecc-410d-a7ac-cd168a3f3aac"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("f0fc441f-8757-411c-896b-29f4e2136c5f"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("fa00c292-d2a8-49e1-b7f0-34c6b495c87d"));

            migrationBuilder.InsertData(
                table: "SanPhamChiTiets",
                columns: new[] { "Id", "GhiChu", "GiaBan", "GiaNhap", "GiaNiemYet", "IdChatLieu", "IdMau", "IdNSX", "IdSize", "IdSp", "Is_detele", "MaSp", "MoTa", "SoLuong", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("128f73e5-7f5d-4e4b-9bf9-3f78abddda3a"), "", 700000f, 600000f, 70000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081137"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081112"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081125"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081148"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081411"), true, "SP03", "oke la", 100, true },
                    { new Guid("1ece7721-46f0-4fec-aaad-fb204f0132e7"), "", 4500000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081137"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081110"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081127"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081150"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081611"), true, "SP05", "oke la", 100, true },
                    { new Guid("27219762-eb75-4a50-bc33-7c065d26db20"), "", 600000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081131"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081155"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081122"), true, "SP09", "oke la", 100, true },
                    { new Guid("2d873a30-1b23-44be-84fd-a4da5dc0eea3"), "", 500000f, 300000f, 450000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081137"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081112"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081146"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081211"), true, "SP01", "oke la", 100, true },
                    { new Guid("4049a7bd-519d-47a5-9741-b07b103f9262"), "", 500000f, 400000f, 450000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081138"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081113"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081153"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081811"), true, "SP07", "oke la", 100, true },
                    { new Guid("52965ae8-4424-44a8-8f1a-ab35087b2473"), "", 650000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081121"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081154"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081911"), true, "SP08", "oke la", 100, true },
                    { new Guid("7d04c29a-91d6-478d-8add-bca74229cb77"), "", 700000f, 300000f, 750000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081138"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081116"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081152"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081711"), true, "SP06", "oke la", 100, true },
                    { new Guid("7d082fc1-0394-4496-9a82-2b415b2ea099"), "", 600000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081138"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081112"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081156"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081123"), true, "SP10", "oke la", 100, true },
                    { new Guid("ef80152e-afa1-441c-921e-fb6475c85415"), "", 600000f, 300000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081110"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081126"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081149"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081511"), true, "SP04", "oke la", 100, true },
                    { new Guid("f783fa3c-7f06-4769-aead-5302bb8c655a"), "", 600000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081138"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081131"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081125"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081147"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081311"), true, "SP02", "oke la", 100, true }
                });
        }
    }
}
