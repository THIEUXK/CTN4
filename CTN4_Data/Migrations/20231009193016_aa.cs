using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CTN4_Data.Migrations
{
    public partial class aa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatLieus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenChatLieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_detele = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatLieus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChucVus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenChucVu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenDanhMuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_detele = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GiamGias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaGiam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoTienGiam = table.Column<float>(type: "real", nullable: false),
                    PhanTramGiam = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoTienGiamToiDa = table.Column<float>(type: "real", nullable: false),
                    DieuKienGiam = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiamGias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenDangNhap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnhDaiDien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trangthai = table.Column<bool>(type: "bit", nullable: false),
                    Is_detele = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KhuyenMais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaKhuyenMai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhanTramGiamGia = table.Column<int>(type: "int", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoTienGiam = table.Column<float>(type: "real", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    Is_Detele = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Maus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenMau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    Is_detele = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NSXs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenNSX = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_detele = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NSXs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhanLoais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenPhanLoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrạngThai = table.Column<bool>(type: "bit", nullable: false),
                    Is_Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanLoais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhuongThucThanhToans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenPhuongThuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    Is_detele = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhuongThucThanhToans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnhDaiDiem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    Is_detele = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    Is_detele = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenDangNhap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trangthai = table.Column<bool>(type: "bit", nullable: false),
                    AnhDaiDien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdChucVu = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ChucVuId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhanViens_ChucVus_ChucVuId",
                        column: x => x.ChucVuId,
                        principalTable: "ChucVus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DaiChiNhanHangs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenDiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    IdKhachHang = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    KhachHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaiChiNhanHangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DaiChiNhanHangs_KhachHangs_KhachHangId",
                        column: x => x.KhachHangId,
                        principalTable: "KhachHangs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GioHangs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    IdKhachHang = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    KhachHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GioHangs_KhachHangs_KhachHangId",
                        column: x => x.KhachHangId,
                        principalTable: "KhachHangs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SanPhamYeuThichs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdKhachHang = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    KKhachHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhamYeuThichs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPhamYeuThichs_KhachHangs_KKhachHangId",
                        column: x => x.KKhachHangId,
                        principalTable: "KhachHangs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KhuyenMaiPhanLoais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idKhuyenMai = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdPhanLoai = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PhanLoaiId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    KhuyenMaiId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMaiPhanLoais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhuyenMaiPhanLoais_KhuyenMais_KhuyenMaiId",
                        column: x => x.KhuyenMaiId,
                        principalTable: "KhuyenMais",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KhuyenMaiPhanLoais_PhanLoais_PhanLoaiId",
                        column: x => x.PhanLoaiId,
                        principalTable: "PhanLoais",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SanPhamChiTiets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaSp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    GiaNhap = table.Column<float>(type: "real", nullable: false),
                    GiaBan = table.Column<float>(type: "real", nullable: false),
                    GiaNiemYet = table.Column<float>(type: "real", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_detele = table.Column<bool>(type: "bit", nullable: false),
                    IdChatLieu = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdMau = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdNSX = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdSize = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdSp = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ChatLieuId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MauId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SizeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NSXId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SanPhamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhamChiTiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPhamChiTiets_ChatLieus_ChatLieuId",
                        column: x => x.ChatLieuId,
                        principalTable: "ChatLieus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SanPhamChiTiets_Maus_MauId",
                        column: x => x.MauId,
                        principalTable: "Maus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SanPhamChiTiets_NSXs_NSXId",
                        column: x => x.NSXId,
                        principalTable: "NSXs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SanPhamChiTiets_SanPhams_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPhams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SanPhamChiTiets_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayTaoHoaDon = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TongTien = table.Column<float>(type: "real", nullable: false),
                    NgayDat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayGiao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayNhan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdKhachHang = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdPhuongThuc = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdDiaChiNhanHang = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PhuongThucThanhToanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DiaChiNhanHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    KhachHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoaDons_DaiChiNhanHangs_DiaChiNhanHangId",
                        column: x => x.DiaChiNhanHangId,
                        principalTable: "DaiChiNhanHangs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HoaDons_KhachHangs_KhachHangId",
                        column: x => x.KhachHangId,
                        principalTable: "KhachHangs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HoaDons_PhuongThucThanhToans_PhuongThucThanhToanId",
                        column: x => x.PhuongThucThanhToanId,
                        principalTable: "PhuongThucThanhToans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Anhs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DuongDanAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    Is_delete = table.Column<bool>(type: "bit", nullable: false),
                    IdSanPhamChiTiet = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SanPhamChiTietId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anhs_SanPhamChiTiets_SanPhamChiTietId",
                        column: x => x.SanPhamChiTietId,
                        principalTable: "SanPhamChiTiets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietSanPhamYeu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSanPhamChiTiet = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdSanPhamYeuThich = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SanPhamYeuThichId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SanPhamChiTietId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietSanPhamYeu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietSanPhamYeu_SanPhamChiTiets_SanPhamChiTietId",
                        column: x => x.SanPhamChiTietId,
                        principalTable: "SanPhamChiTiets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChiTietSanPhamYeu_SanPhamYeuThichs_SanPhamYeuThichId",
                        column: x => x.SanPhamYeuThichId,
                        principalTable: "SanPhamYeuThichs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DanhMucChiTiets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSanPhamChiTiet = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdDanhMuc = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DanhMucId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SanPhamChiTietId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucChiTiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhMucChiTiets_DanhMucs_DanhMucId",
                        column: x => x.DanhMucId,
                        principalTable: "DanhMucs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DanhMucChiTiets_SanPhamChiTiets_SanPhamChiTietId",
                        column: x => x.SanPhamChiTietId,
                        principalTable: "SanPhamChiTiets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GioHangChiTiets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    IdGioHang = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdSanPhamChiTiet = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GioHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SanPhamChiTietId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangChiTiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GioHangChiTiets_GioHangs_GioHangId",
                        column: x => x.GioHangId,
                        principalTable: "GioHangs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GioHangChiTiets_SanPhamChiTiets_SanPhamChiTietId",
                        column: x => x.SanPhamChiTietId,
                        principalTable: "SanPhamChiTiets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KhuyenMaiSanPhams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSanPhamChiTiet = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdkhuyenMai = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SanPhamChiTietId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    KhuyenMaiId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMaiSanPhams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhuyenMaiSanPhams_KhuyenMais_KhuyenMaiId",
                        column: x => x.KhuyenMaiId,
                        principalTable: "KhuyenMais",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KhuyenMaiSanPhams_SanPhamChiTiets_SanPhamChiTietId",
                        column: x => x.SanPhamChiTietId,
                        principalTable: "SanPhamChiTiets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PhanLoaiChiTiets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSanPhamChiTiet = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdPhanLoai = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PhanLoaiId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SanPhamChiTietId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanLoaiChiTiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhanLoaiChiTiets_PhanLoais_PhanLoaiId",
                        column: x => x.PhanLoaiId,
                        principalTable: "PhanLoais",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhanLoaiChiTiets_SanPhamChiTiets_SanPhamChiTietId",
                        column: x => x.SanPhamChiTietId,
                        principalTable: "SanPhamChiTiets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GiamGiaChiTiets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdGiamGia = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdHoaDon = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GiamGiaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HoaDonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiamGiaChiTiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiamGiaChiTiets_GiamGias_GiamGiaId",
                        column: x => x.GiamGiaId,
                        principalTable: "GiamGias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GiamGiaChiTiets_HoaDons_HoaDonId",
                        column: x => x.HoaDonId,
                        principalTable: "HoaDons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HoaDonChiTiets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    GiaTien = table.Column<float>(type: "real", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    Is_detele = table.Column<bool>(type: "bit", nullable: false),
                    IdSanPhamChiTiet = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdHoaDon = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HoaDonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SanPhamChiTietId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonChiTiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiets_HoaDons_HoaDonId",
                        column: x => x.HoaDonId,
                        principalTable: "HoaDons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiets_SanPhamChiTiets_SanPhamChiTietId",
                        column: x => x.SanPhamChiTietId,
                        principalTable: "SanPhamChiTiets",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ChatLieus",
                columns: new[] { "Id", "GhiChu", "Is_detele", "TenChatLieu", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("68bb7ac2-28f9-480b-9ceb-8325bbb9bea0"), "", true, "Canvas", true },
                    { new Guid("785738cd-33e4-421a-b151-cf89953869c1"), "", true, "Vải bông (Cotton)", true },
                    { new Guid("946fc999-f2b9-4ee3-9a17-612b2c8c81d5"), "", true, "Vải không dệt (Micro Polyester)", true },
                    { new Guid("d51512e7-df56-47da-9143-b8f5c5cab437"), "", true, "Nylon (Polyester)", true },
                    { new Guid("f5e2b5ad-0350-4998-8d67-8dbe2f02eaa7"), "", true, "Da thuộc (real leather)", true },
                    { new Guid("f83142bd-6f84-42a4-8fac-9e0d647808f8"), "", true, "Tricot (Vải dệt kim)", true },
                    { new Guid("f871334f-4192-475d-a3ca-3ce6582cb9ad"), "", true, "Vải Simili (Giả da)", true }
                });

            migrationBuilder.InsertData(
                table: "ChucVus",
                columns: new[] { "Id", "TenChucVu", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f70877e9"), "Nhân viên", true },
                    { new Guid("d16ac357-3ced-4c2c-bcdc-d38971214414"), "Quản lý", true }
                });

            migrationBuilder.InsertData(
                table: "DanhMucs",
                columns: new[] { "Id", "Is_detele", "TenDanhMuc" },
                values: new object[,]
                {
                    { new Guid("09e8503e-fa57-4851-ab9f-2db696a9121f"), true, "Túi dây rút – Pouch" },
                    { new Guid("3233f66e-e8de-481b-abda-fe701c926b86"), true, "Túi Bucket" },
                    { new Guid("338f7e35-d766-4d5c-82be-a34093bbe088"), true, "Túi bao tử – Túi bumbag" },
                    { new Guid("3caf4797-b3b2-4d51-ba8f-7c1b0f8ce63e"), true, "Túi Ring Bag" },
                    { new Guid("58e7e73c-30e2-4bef-93a4-06fa9826be59"), true, "Túi baguette" },
                    { new Guid("5de781dd-b5f7-4d02-82a0-078a1db06aaa"), true, "Túi cầm tay – Clutch" },
                    { new Guid("693e5283-3e7a-4bbe-ba59-358c2b69825a"), true, "Túi đeo chéo Nữ – Cross body" },
                    { new Guid("c254c6a8-7497-48be-a235-f9430158a59c"), true, "Túi tote" },
                    { new Guid("cead1d01-1e9e-4fa3-8e48-384f532b7176"), true, "Túi satchel" },
                    { new Guid("d73491be-c467-4b03-be68-243d115b55e3"), true, "Túi Bowling" },
                    { new Guid("f18d1652-a5a6-4ec6-87a0-106fae8b6750"), true, "Túi đeo vai – Shoulder bag" },
                    { new Guid("fc1dcf1f-aef9-49d0-9630-665385476b8b"), true, "Túi Hobo" }
                });

            migrationBuilder.InsertData(
                table: "Maus",
                columns: new[] { "Id", "Is_detele", "TenMau", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("2e402b94-85bd-4932-afd2-d8a71fbfa057"), true, "xanh lục", true },
                    { new Guid("43fe324d-9a7f-4d7d-9912-522c0ce9bfaf"), true, "xanh đương", true },
                    { new Guid("53ba31dc-3fd5-447b-bea6-bbf00ced013c"), true, "đen", true },
                    { new Guid("6a1a7a98-964e-462e-8af4-b0311184f6d7"), true, "tím", true },
                    { new Guid("80f3fd21-6b28-48fb-96e0-ece1b4e0db3f"), true, "xám", true },
                    { new Guid("824a47d3-6c28-462f-8d3a-c2a9f5f2b9e5"), true, "hồng", true },
                    { new Guid("88dafaa1-a710-4591-b130-42c4cb8a2d14"), true, "xanh lá đậm", true },
                    { new Guid("a17cd584-7e98-4e2b-ad8b-af3f6d241757"), true, "trắng", true },
                    { new Guid("bb4adda4-9ca0-4c00-b826-dac7774ab626"), true, "cam", true },
                    { new Guid("c643076a-2715-4caa-9939-c16ee7178986"), true, "kem", true },
                    { new Guid("e0c6312e-c9b1-40c2-99b8-de06646c0ce7"), true, "nâu da", true },
                    { new Guid("f5695f3a-09dd-414d-b862-65ff3d3cd2dc"), true, "vàng", true },
                    { new Guid("fea43936-aaf0-4d95-8726-6e44ab6131b0"), true, "tràm", true }
                });

            migrationBuilder.InsertData(
                table: "NSXs",
                columns: new[] { "Id", "GhiChu", "Is_detele", "TenNSX", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("0c3795f3-f2b0-4640-b8a3-b559eb5b48ae"), "", true, "Christian Dior", true },
                    { new Guid("40f9ea9e-788c-44c9-a8f0-ba2e3301cf80"), "", true, "Michael Kors", true },
                    { new Guid("5bbda650-264b-4c19-be00-511acd847cee"), "", true, "Gucci", true },
                    { new Guid("60bf07fd-00d2-4904-a9b1-0b069f2ee934"), "", true, "Louis Vuitton", true },
                    { new Guid("6ecda325-c9e2-4f69-98a2-6eec0f851ce1"), "", true, "Coach", true },
                    { new Guid("8aa9c4bc-baa5-4815-9470-bb8e8b4bdd12"), "", true, "Prada", true },
                    { new Guid("97edb8e1-96f1-4878-bc43-5d14d69d5e51"), "", true, "MLB Korea", true },
                    { new Guid("c802e2a4-1659-4365-b7df-16378253bca8"), "", true, "JW Anderson", true }
                });

            migrationBuilder.InsertData(
                table: "NSXs",
                columns: new[] { "Id", "GhiChu", "Is_detele", "TenNSX", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("d1eb69fb-a380-48e1-9a53-f952b9505824"), "", true, "Juno", true },
                    { new Guid("eecaf923-954d-4923-9deb-30fbf6bc9d83"), "", true, "Chanel", true }
                });

            migrationBuilder.InsertData(
                table: "NhanViens",
                columns: new[] { "Id", "AnhDaiDien", "ChucVuId", "DiaChi", "Email", "GioiTinh", "Ho", "IdChucVu", "MatKhau", "SDT", "Ten", "TenDangNhap", "Trangthai" },
                values: new object[,]
                {
                    { new Guid("3a25c764-1773-4420-b7ca-72643c5308e3"), "", null, "Hà Nội", "nothing@gmail.com", "Nữ", "Nguyễn", null, "12345678", "0912384746", "Trang", "trangnt34", true },
                    { new Guid("7778c35e-f401-43e1-9cc0-8942401399a0"), "", null, "Bình Thuận", "nothing3@gmail.com", "Nam", "Lê", null, "12345678", "0817236583", "Minh", "Leminh66", true },
                    { new Guid("8f71794e-b7d0-420c-9d2d-cc0a8af2cbf8"), "", null, "New York", "nothing6@gmail.com", "Nam", "Kenny", null, "12345678", "0576947384", "Nguyen", "kennynguyen145", true },
                    { new Guid("abc2192b-7d48-4557-ad19-81ba1357886f"), "", null, "Quảng Ninh", "nothing5@gmail.com", "Nữ", "Bùi", null, "12345678", "0982647912", "Huyền", "Huyenbt62", true },
                    { new Guid("abe2a5b4-2e10-4377-abd3-e0ab251b57f1"), "", null, "Paris", "nothing7@gmail.com", "Nam", "Trần", null, "12345678", "0292304805", "Boss", "Bosshidden69", true },
                    { new Guid("b3f73aab-cb0d-487b-841f-29a8dba002ae"), "", null, "Hà Nội", "nothing9@gmail.com", "Nam", "Báo thủ", null, "12345678", "0975846374", "Bách", "Bachbaothu13", true },
                    { new Guid("f516df8a-4b7a-4000-bfe4-7ca310f8b454"), "", null, "Ninh Bình", "nothing2@gmail.com", "Nam", "Trần", null, "12345678", "0819265834", "Hà", "Hatl12", true },
                    { new Guid("f76bebe9-8db8-415c-a752-443ffc34e0ed"), "", null, "thành phố Hồ Chí Minh", "nothing4@gmail.com", "Nam", "Phùng", null, "12345678", "0129837582", "Hoàng", "Hoangpv14", true }
                });

            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "Id", "AnhDaiDiem", "Is_detele", "TenSanPham", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("0117d4dc-b8c4-4f61-a654-f458654e8132"), "", true, "Túi Xách Nhỏ Dây Kéo Phối 2 Chất Liệu", true },
                    { new Guid("353b8a7e-6b1c-43ba-afef-fdd9cce75d9c"), "", true, "Túi Xách Nhỏ Đeo Vai Time Travelling", true },
                    { new Guid("3fbdbab5-b6be-4c35-bc23-ffbd1533ff34"), "", true, "Túi Xách Nhỏ Đeo Vai Elite Of The Class", true },
                    { new Guid("512de68c-8201-465e-bec3-d14fe4558c2d"), "", true, "Túi Xách Nhỏ Dáng Boho New Moon", true },
                    { new Guid("6dcdd304-710c-4555-b91f-3e92a0ef145a"), "", true, "Túi Xách Nhỏ Nắp Gập Khóa Trang Trí", true },
                    { new Guid("76f56ad6-0a14-43fa-86b8-fb2cf188da7d"), "", true, "Túi Xách Nhỏ Top Handle Cozy", true },
                    { new Guid("804d6669-a69d-449a-9c7e-9cbe9409db28"), "", true, "Túi Xách Nhỏ Top Handle Phối Hoa 3D", true },
                    { new Guid("84cc1168-45db-4d9f-9043-632ddbd6bfe4"), "", true, "Túi Xách Nhỏ Shoulder Bag Trang Trí Khóa Logo Cách Điệu", true },
                    { new Guid("88371ced-ffbd-46bf-a767-af4c82e33dfc"), "", true, "Túi Xách Nhỏ Hobo Dập Logo Jn", true },
                    { new Guid("c1836e48-8ed8-4d6b-909a-084c71a2dc95"), "", true, "Túi Xách Nhỏ Hobo Time Travelling", true }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Is_detele", "TenSize", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("729bc76d-b37e-4268-a3ea-b89f238142be"), true, "Large", true },
                    { new Guid("7d3df483-af51-46b9-a16d-6d73ae8e4e9f"), true, "Small", true },
                    { new Guid("7db6c216-f841-49ca-9c0b-b4f8495b80b8"), true, "Extra Small", true },
                    { new Guid("8546ca45-d18b-44cb-8a0f-f482b8122838"), true, "Extra Large", true },
                    { new Guid("aaa4a128-260f-4eec-ba1a-dd9019af6f48"), true, "Standard (Medium)", true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anhs_SanPhamChiTietId",
                table: "Anhs",
                column: "SanPhamChiTietId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPhamYeu_SanPhamChiTietId",
                table: "ChiTietSanPhamYeu",
                column: "SanPhamChiTietId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPhamYeu_SanPhamYeuThichId",
                table: "ChiTietSanPhamYeu",
                column: "SanPhamYeuThichId");

            migrationBuilder.CreateIndex(
                name: "IX_DaiChiNhanHangs_KhachHangId",
                table: "DaiChiNhanHangs",
                column: "KhachHangId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucChiTiets_DanhMucId",
                table: "DanhMucChiTiets",
                column: "DanhMucId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucChiTiets_SanPhamChiTietId",
                table: "DanhMucChiTiets",
                column: "SanPhamChiTietId");

            migrationBuilder.CreateIndex(
                name: "IX_GiamGiaChiTiets_GiamGiaId",
                table: "GiamGiaChiTiets",
                column: "GiamGiaId");

            migrationBuilder.CreateIndex(
                name: "IX_GiamGiaChiTiets_HoaDonId",
                table: "GiamGiaChiTiets",
                column: "HoaDonId");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangChiTiets_GioHangId",
                table: "GioHangChiTiets",
                column: "GioHangId");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangChiTiets_SanPhamChiTietId",
                table: "GioHangChiTiets",
                column: "SanPhamChiTietId");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangs_KhachHangId",
                table: "GioHangs",
                column: "KhachHangId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiets_HoaDonId",
                table: "HoaDonChiTiets",
                column: "HoaDonId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiets_SanPhamChiTietId",
                table: "HoaDonChiTiets",
                column: "SanPhamChiTietId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_DiaChiNhanHangId",
                table: "HoaDons",
                column: "DiaChiNhanHangId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_KhachHangId",
                table: "HoaDons",
                column: "KhachHangId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_PhuongThucThanhToanId",
                table: "HoaDons",
                column: "PhuongThucThanhToanId");

            migrationBuilder.CreateIndex(
                name: "IX_KhuyenMaiPhanLoais_KhuyenMaiId",
                table: "KhuyenMaiPhanLoais",
                column: "KhuyenMaiId");

            migrationBuilder.CreateIndex(
                name: "IX_KhuyenMaiPhanLoais_PhanLoaiId",
                table: "KhuyenMaiPhanLoais",
                column: "PhanLoaiId");

            migrationBuilder.CreateIndex(
                name: "IX_KhuyenMaiSanPhams_KhuyenMaiId",
                table: "KhuyenMaiSanPhams",
                column: "KhuyenMaiId");

            migrationBuilder.CreateIndex(
                name: "IX_KhuyenMaiSanPhams_SanPhamChiTietId",
                table: "KhuyenMaiSanPhams",
                column: "SanPhamChiTietId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_ChucVuId",
                table: "NhanViens",
                column: "ChucVuId");

            migrationBuilder.CreateIndex(
                name: "IX_PhanLoaiChiTiets_PhanLoaiId",
                table: "PhanLoaiChiTiets",
                column: "PhanLoaiId");

            migrationBuilder.CreateIndex(
                name: "IX_PhanLoaiChiTiets_SanPhamChiTietId",
                table: "PhanLoaiChiTiets",
                column: "SanPhamChiTietId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamChiTiets_ChatLieuId",
                table: "SanPhamChiTiets",
                column: "ChatLieuId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamChiTiets_MauId",
                table: "SanPhamChiTiets",
                column: "MauId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamChiTiets_NSXId",
                table: "SanPhamChiTiets",
                column: "NSXId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamChiTiets_SanPhamId",
                table: "SanPhamChiTiets",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamChiTiets_SizeId",
                table: "SanPhamChiTiets",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamYeuThichs_KKhachHangId",
                table: "SanPhamYeuThichs",
                column: "KKhachHangId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anhs");

            migrationBuilder.DropTable(
                name: "ChiTietSanPhamYeu");

            migrationBuilder.DropTable(
                name: "DanhMucChiTiets");

            migrationBuilder.DropTable(
                name: "GiamGiaChiTiets");

            migrationBuilder.DropTable(
                name: "GioHangChiTiets");

            migrationBuilder.DropTable(
                name: "HoaDonChiTiets");

            migrationBuilder.DropTable(
                name: "KhuyenMaiPhanLoais");

            migrationBuilder.DropTable(
                name: "KhuyenMaiSanPhams");

            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.DropTable(
                name: "PhanLoaiChiTiets");

            migrationBuilder.DropTable(
                name: "SanPhamYeuThichs");

            migrationBuilder.DropTable(
                name: "DanhMucs");

            migrationBuilder.DropTable(
                name: "GiamGias");

            migrationBuilder.DropTable(
                name: "GioHangs");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "KhuyenMais");

            migrationBuilder.DropTable(
                name: "ChucVus");

            migrationBuilder.DropTable(
                name: "PhanLoais");

            migrationBuilder.DropTable(
                name: "SanPhamChiTiets");

            migrationBuilder.DropTable(
                name: "DaiChiNhanHangs");

            migrationBuilder.DropTable(
                name: "PhuongThucThanhToans");

            migrationBuilder.DropTable(
                name: "ChatLieus");

            migrationBuilder.DropTable(
                name: "Maus");

            migrationBuilder.DropTable(
                name: "NSXs");

            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "KhachHangs");
        }
    }
}
