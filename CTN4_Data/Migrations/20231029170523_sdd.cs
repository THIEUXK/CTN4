using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CTN4_Data.Migrations
{
    public partial class sdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("a9db3db9-c67c-49b2-953d-e35e1a83a085"));

            migrationBuilder.InsertData(
                table: "SanPhamChiTiets",
                columns: new[] { "Id", "IdMau", "IdSize", "IdSp", "Is_detele", "SoLuong", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6010"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081112"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081146"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081211"), true, 100, true },
                    { new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6011"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081111"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081146"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081211"), true, 100, true },
                    { new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6012"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081113"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081146"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081211"), true, 100, true },
                    { new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6013"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081112"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081147"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081211"), true, 100, true },
                    { new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6014"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081111"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081147"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081211"), true, 100, true },
                    { new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6015"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081113"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081147"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081211"), true, 100, true },
                    { new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6016"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081111"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081148"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081211"), true, 100, true },
                    { new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6017"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081113"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081148"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081211"), true, 100, true },
                    { new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6018"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081114"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081148"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081211"), true, 100, true },
                    { new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6019"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081111"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081146"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081311"), true, 100, true },
                    { new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6020"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081151"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081146"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081311"), true, 100, true },
                    { new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6021"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081113"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081146"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081311"), true, 100, true },
                    { new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6022"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081111"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081147"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081311"), true, 100, true },
                    { new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6023"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081151"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081147"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081311"), true, 100, true },
                    { new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6024"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081113"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081147"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081311"), true, 100, true },
                    { new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6025"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081111"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081148"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081311"), true, 100, true },
                    { new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6026"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081113"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081148"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081311"), true, 100, true },
                    { new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6027"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081151"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081148"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081311"), true, 100, true },
                    { new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6028"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081151"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081149"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081311"), true, 100, true },
                    { new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6029"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081113"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081149"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081311"), true, 100, true },
                    { new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6030"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081111"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081149"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081311"), true, 100, true },
                    { new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6031"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081111"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081146"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081511"), true, 100, true },
                    { new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6032"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081112"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081146"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081511"), true, 100, true },
                    { new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6033"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081111"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081147"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081511"), true, 100, true },
                    { new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6034"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081112"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081147"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081511"), true, 100, true },
                    { new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6035"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081111"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081148"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081511"), true, 100, true },
                    { new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6036"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081112"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081148"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081511"), true, 100, true },
                    { new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6037"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081111"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081149"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081511"), true, 100, true },
                    { new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6038"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081112"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081149"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081511"), true, 100, true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6010"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6011"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6012"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6013"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6014"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6015"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6016"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6017"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6018"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6019"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6020"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6021"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6022"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6023"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6024"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6025"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6026"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6027"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6028"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6029"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6030"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6031"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6032"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6033"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6034"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6035"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6036"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6037"));

            migrationBuilder.DeleteData(
                table: "SanPhamChiTiets",
                keyColumn: "Id",
                keyValue: new Guid("42d4f7d5-0499-4df5-926f-ccce5fbb6038"));

            migrationBuilder.InsertData(
                table: "SanPhamChiTiets",
                columns: new[] { "Id", "IdMau", "IdSize", "IdSp", "Is_detele", "SoLuong", "TrangThai" },
                values: new object[] { new Guid("a9db3db9-c67c-49b2-953d-e35e1a83a085"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081112"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081146"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081211"), true, 0, true });
        }
    }
}
