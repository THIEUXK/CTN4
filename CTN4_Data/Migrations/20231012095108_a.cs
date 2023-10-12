using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CTN4_Data.Migrations
{
    public partial class a : Migration
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
                    AnhDaiDien = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    IdChucVu = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhanViens_ChucVus_IdChucVu",
                        column: x => x.IdChucVu,
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
                    IdKhachHang = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaiChiNhanHangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DaiChiNhanHangs_KhachHangs_IdKhachHang",
                        column: x => x.IdKhachHang,
                        principalTable: "KhachHangs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GioHangs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    IdKhachHang = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GioHangs_KhachHangs_IdKhachHang",
                        column: x => x.IdKhachHang,
                        principalTable: "KhachHangs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SanPhamYeuThichs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdKhachHang = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhamYeuThichs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPhamYeuThichs_KhachHangs_IdKhachHang",
                        column: x => x.IdKhachHang,
                        principalTable: "KhachHangs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KhuyenMaiPhanLoais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idKhuyenMai = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdPhanLoai = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMaiPhanLoais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhuyenMaiPhanLoais_KhuyenMais_idKhuyenMai",
                        column: x => x.idKhuyenMai,
                        principalTable: "KhuyenMais",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KhuyenMaiPhanLoais_PhanLoais_IdPhanLoai",
                        column: x => x.IdPhanLoai,
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
                    IdSp = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhamChiTiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPhamChiTiets_ChatLieus_IdChatLieu",
                        column: x => x.IdChatLieu,
                        principalTable: "ChatLieus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SanPhamChiTiets_Maus_IdMau",
                        column: x => x.IdMau,
                        principalTable: "Maus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SanPhamChiTiets_NSXs_IdNSX",
                        column: x => x.IdNSX,
                        principalTable: "NSXs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SanPhamChiTiets_SanPhams_IdSp",
                        column: x => x.IdSp,
                        principalTable: "SanPhams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SanPhamChiTiets_Sizes_IdSize",
                        column: x => x.IdSize,
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
                    IdDiaChiNhanHang = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoaDons_DaiChiNhanHangs_IdDiaChiNhanHang",
                        column: x => x.IdDiaChiNhanHang,
                        principalTable: "DaiChiNhanHangs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HoaDons_KhachHangs_IdKhachHang",
                        column: x => x.IdKhachHang,
                        principalTable: "KhachHangs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HoaDons_PhuongThucThanhToans_IdPhuongThuc",
                        column: x => x.IdPhuongThuc,
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
                    IdSanPhamChiTiet = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anhs_SanPhamChiTiets_IdSanPhamChiTiet",
                        column: x => x.IdSanPhamChiTiet,
                        principalTable: "SanPhamChiTiets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietSanPhamYeu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSanPhamChiTiet = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdSanPhamYeuThich = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietSanPhamYeu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietSanPhamYeu_SanPhamChiTiets_IdSanPhamChiTiet",
                        column: x => x.IdSanPhamChiTiet,
                        principalTable: "SanPhamChiTiets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChiTietSanPhamYeu_SanPhamYeuThichs_IdSanPhamYeuThich",
                        column: x => x.IdSanPhamYeuThich,
                        principalTable: "SanPhamYeuThichs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DanhMucChiTiets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSanPhamChiTiet = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdDanhMuc = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucChiTiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhMucChiTiets_DanhMucs_IdDanhMuc",
                        column: x => x.IdDanhMuc,
                        principalTable: "DanhMucs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DanhMucChiTiets_SanPhamChiTiets_IdSanPhamChiTiet",
                        column: x => x.IdSanPhamChiTiet,
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
                    IdSanPhamChiTiet = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangChiTiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GioHangChiTiets_GioHangs_IdGioHang",
                        column: x => x.IdGioHang,
                        principalTable: "GioHangs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GioHangChiTiets_SanPhamChiTiets_IdSanPhamChiTiet",
                        column: x => x.IdSanPhamChiTiet,
                        principalTable: "SanPhamChiTiets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KhuyenMaiSanPhams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSanPhamChiTiet = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdkhuyenMai = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMaiSanPhams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhuyenMaiSanPhams_KhuyenMais_IdkhuyenMai",
                        column: x => x.IdkhuyenMai,
                        principalTable: "KhuyenMais",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KhuyenMaiSanPhams_SanPhamChiTiets_IdSanPhamChiTiet",
                        column: x => x.IdSanPhamChiTiet,
                        principalTable: "SanPhamChiTiets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PhanLoaiChiTiets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSanPhamChiTiet = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdPhanLoai = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanLoaiChiTiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhanLoaiChiTiets_PhanLoais_IdPhanLoai",
                        column: x => x.IdPhanLoai,
                        principalTable: "PhanLoais",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhanLoaiChiTiets_SanPhamChiTiets_IdSanPhamChiTiet",
                        column: x => x.IdSanPhamChiTiet,
                        principalTable: "SanPhamChiTiets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GiamGiaChiTiets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdGiamGia = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdHoaDon = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiamGiaChiTiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiamGiaChiTiets_GiamGias_IdGiamGia",
                        column: x => x.IdGiamGia,
                        principalTable: "GiamGias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GiamGiaChiTiets_HoaDons_IdHoaDon",
                        column: x => x.IdHoaDon,
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
                    IdHoaDon = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonChiTiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiets_HoaDons_IdHoaDon",
                        column: x => x.IdHoaDon,
                        principalTable: "HoaDons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiets_SanPhamChiTiets_IdSanPhamChiTiet",
                        column: x => x.IdSanPhamChiTiet,
                        principalTable: "SanPhamChiTiets",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ChatLieus",
                columns: new[] { "Id", "GhiChu", "Is_detele", "TenChatLieu", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("131ebe68-817e-42b9-9500-a782c551538b"), "", true, "Vải bông (Cotton)", true },
                    { new Guid("7fba3480-8024-44b2-8cf4-5e5975e103a9"), "", true, "Da thuộc (real leather)", true },
                    { new Guid("90a0f439-4ddf-414b-a634-0a25c2a6ee23"), "", true, "Nylon (Polyester)", true },
                    { new Guid("bf5c3467-6814-49e9-82c1-ddfb385319c7"), "", true, "Vải Simili (Giả da)", true },
                    { new Guid("c04aa76a-47ba-42ec-887c-476c4b79fb06"), "", true, "Tricot (Vải dệt kim)", true },
                    { new Guid("c285414a-9dec-427e-8da4-f46bfbb4b9ec"), "", true, "Vải không dệt (Micro Polyester)", true },
                    { new Guid("caf4c25a-a041-4ed7-8613-6fdf00e34f9b"), "", true, "Canvas", true }
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
                    { new Guid("315848fd-720e-4783-8fea-3e9c41c5735b"), true, "Túi Bowling" },
                    { new Guid("3d4caaa0-b1e1-495f-952f-60d21d50dcde"), true, "Túi đeo vai – Shoulder bag" },
                    { new Guid("549b3410-4c0e-4be4-bfbd-cd7d4abee207"), true, "Túi satchel" },
                    { new Guid("566f00b3-2e39-437a-ae3c-b970ab880445"), true, "Túi Bucket" },
                    { new Guid("56bfc699-1b3c-4531-9968-8b96560e8c9f"), true, "Túi đeo chéo Nữ – Cross body" },
                    { new Guid("6a0da401-809f-4f61-9c29-5bda2c1d94d9"), true, "Túi bao tử – Túi bumbag" },
                    { new Guid("6aba43ff-9c48-4828-835c-b08fcaeab1c0"), true, "Túi Ring Bag" },
                    { new Guid("718aeeef-a65c-4a41-8d0a-0d85b4644ed6"), true, "Túi tote" },
                    { new Guid("87a70960-e62b-4163-8e30-64cdc3d3ee8a"), true, "Túi Hobo" },
                    { new Guid("9b58564e-cd07-4581-9842-e665c8c86b70"), true, "Túi cầm tay – Clutch" },
                    { new Guid("af02fc7e-787d-4bc2-8232-54edc63f3120"), true, "Túi dây rút – Pouch" },
                    { new Guid("f07cde9a-3e2f-4f0a-ac46-35a5888b9803"), true, "Túi baguette" }
                });

            migrationBuilder.InsertData(
                table: "KhachHangs",
                columns: new[] { "Id", "AnhDaiDien", "DiaChi", "Email", "GioiTinh", "Ho", "Is_detele", "MatKhau", "SDT", "Ten", "TenDangNhap", "Trangthai" },
                values: new object[] { new Guid("d16ac357-3ced-4c2c-bcdc-d38971214499"), "", "Hà Nội", "thieubvph20221@gmail.com", "Nam", "Bùi Văm", true, "thieuxk", "0912384746", "Thiều", "thieuxk", true });

            migrationBuilder.InsertData(
                table: "Maus",
                columns: new[] { "Id", "Is_detele", "TenMau", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("2651117c-5c4b-4322-a61f-1b7623cf029d"), true, "xám", true },
                    { new Guid("4b8dff92-605b-4286-b60a-2d224019706a"), true, "xanh lục", true },
                    { new Guid("7958fdc4-e712-4bba-b43b-ee8b87d8887f"), true, "xanh lá đậm", true },
                    { new Guid("a61b7286-953a-417f-8313-3c22b34a28f5"), true, "hồng", true },
                    { new Guid("b90217ed-c917-4dd6-876d-5d130e68c73c"), true, "kem", true },
                    { new Guid("dcafec03-493b-4ebf-aa2a-8114042921aa"), true, "cam", true },
                    { new Guid("ec2ece9d-bb4a-4d0d-a2ae-ec635f8f76e6"), true, "đen", true },
                    { new Guid("f3222ef8-5189-4d04-a197-f748337679c4"), true, "tràm", true },
                    { new Guid("f51dcf74-d5a1-46ff-84ad-bda18f9481c7"), true, "xanh đương", true },
                    { new Guid("f70e19c8-a30e-4bdc-959b-d3490db9052a"), true, "vàng", true },
                    { new Guid("f86e0891-a98b-4314-9c56-2f614ca9b1de"), true, "trắng", true },
                    { new Guid("f96e2063-3e8d-4435-9795-683aa57e52b5"), true, "nâu da", true },
                    { new Guid("f9ca60bd-18e7-4aa2-9467-fa8ce198090f"), true, "tím", true }
                });

            migrationBuilder.InsertData(
                table: "NSXs",
                columns: new[] { "Id", "GhiChu", "Is_detele", "TenNSX", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("1bb51547-3274-4c37-8542-d8fc5b19fd63"), "", true, "Juno", true },
                    { new Guid("34390bdb-94f0-467b-87b2-58fd516a6669"), "", true, "Christian Dior", true },
                    { new Guid("6eb43a1f-a5af-4f46-a2b4-103805f82421"), "", true, "Prada", true },
                    { new Guid("79f28d09-1151-436f-9b9d-b7553a5e4b9e"), "", true, "JW Anderson", true },
                    { new Guid("9a1587c0-311b-49f3-bc34-dc8fc2858b2a"), "", true, "MLB Korea", true },
                    { new Guid("9e6e979e-6486-429b-a6c2-a1ce849b9f42"), "", true, "Gucci", true },
                    { new Guid("a0b454b4-d252-446f-b5fb-ab893d7186a7"), "", true, "Coach", true }
                });

            migrationBuilder.InsertData(
                table: "NSXs",
                columns: new[] { "Id", "GhiChu", "Is_detele", "TenNSX", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("b50a5b33-ef8a-4316-bcff-348ca032d023"), "", true, "Chanel", true },
                    { new Guid("dbf3af41-9ef1-4a98-abe7-206349314e1b"), "", true, "Michael Kors", true },
                    { new Guid("f8c38d41-39df-4bfb-96c6-62b5f57d0660"), "", true, "Louis Vuitton", true }
                });

            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "Id", "AnhDaiDien", "Is_detele", "TenSanPham", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("11e1197e-0a57-4d08-9d4f-ad52b2e3a7a8"), "TDV Hobo Đáy Tròn_QuanChau_Trang_Da lộn, da PU cao cấp(1).jpg", true, "TDV Hobo Đáy Tròn_QuanChau_Trang_Da lộn, da PU cao cấp(1)", true },
                    { new Guid("29c7b5e0-e4b7-4780-9a55-d1a0857bb0a7"), "Túi Xách Nhỏ Curve 1_Trung Quốc_Xanhduong_Da tổng hợp(1).webp", true, "Túi Xách Nhỏ Curve 1_Trung Quốc_Xanhduong_Da tổng hợp(1)", true },
                    { new Guid("2c601d72-36df-4025-a5fa-1e7d05173522"), "TXT Phủ Màu Tag Vuông_QuanChau_XanhLuc_Da PU mềm mịn, cao cấp(1).jpg", true, "TXT Phủ Màu Tag Vuông_QuanChau_XanhLuc_Da PU mềm mịn, cao cấp(1)", true },
                    { new Guid("363a5a0c-994f-4716-97fe-bcda34cbdb1c"), "Túi Xách Nhỏ Curve 1_Trung Quốc_XanhLa_Da tổng hợp(1).webp", true, "Túi Xách Nhỏ Curve 1_Trung Quốc_XanhLa_Da tổng hợp(1)", true },
                    { new Guid("708c0668-37eb-4540-8062-03f5be9435c3"), "TOT Classic Phối Màu _QuanChau_Nau_Da PU mềm mịn, cao cấp(1).jpg", true, "TOT Classic Phối Màu _QuanChau_Nau_Da PU mềm mịn, cao cấp(1)", true },
                    { new Guid("84c9d404-4ded-4bb9-acf9-28dfec7dcf2b"), "TDV Hobo Đáy Tròn_QuanChau_Xanh-Duong_Da lộn, da PU cao cấp(1).jpg", true, "TDV Hobo Đáy Tròn_QuanChau_Xanh-Duong_Da lộn, da PU cao cấp(1)", true },
                    { new Guid("a335f6c0-657f-403d-b0e8-d70c12a53fe1"), "TXT Da Rắn Khóa Bạc _QuanChau_Trang_Da PU cao cấp(1).jpg", true, "TXT Da Rắn Khóa Bạc _QuanChau_Trang_Da PU cao cấp(1)", true },
                    { new Guid("c90e2c7f-7546-4388-8d0a-aa4f8edc631e"), "Túi Xách Nhỏ Đeo Vai - Cycling_Trung Quốc_XanhNhat_Da tổng hợp(1).webp", true, "Túi Xách Nhỏ Đeo Vai - Cycling_Trung Quốc_XanhNhat_Da tổng hợp(1)", true },
                    { new Guid("fb70ec79-1e06-4d40-9f04-c2308c650fb4"), "TDV Hobo Quai Ngắn_QuanChau_Trang_Da PU mềm mịn, cao cấp(1).jpg", true, "TDV Hobo Quai Ngắn_QuanChau_Trang_Da PU mềm mịn, cao cấp(1)", true },
                    { new Guid("fdfa182a-72bb-4c02-88b6-1023222f4a67"), "TOT Classic Phối Màu _QuanChau_Ghi_Da PU mềm mịn, cao cấp(1).jpg", true, "TOT Classic Phối Màu _QuanChau_Ghi_Da PU mềm mịn, cao cấp(1)", true }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Is_detele", "TenSize", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("2411a4c6-e46d-4cd1-b5c2-be6a5e61c791"), true, "Large", true },
                    { new Guid("7a4c7ab4-7e83-4d00-bcfe-14294ff24adc"), true, "Standard (Medium)", true },
                    { new Guid("b5382171-fd3f-43d6-8b56-845e5176e3e0"), true, "Extra Large", true },
                    { new Guid("b551ea39-dc8e-4811-be74-fd4e54a4f078"), true, "Extra Small", true },
                    { new Guid("f4684415-27b9-4b21-8297-78171ef11e06"), true, "Small", true }
                });

            migrationBuilder.InsertData(
                table: "NhanViens",
                columns: new[] { "Id", "AnhDaiDien", "DiaChi", "Email", "GioiTinh", "Ho", "IdChucVu", "MatKhau", "SDT", "Ten", "TenDangNhap", "Trangthai" },
                values: new object[] { new Guid("943b6b80-baea-45d5-8e96-a0ea3a55f0d3"), "", "Hà Nội", "nothing@gmail.com", "Nữ", "Nguyễn", new Guid("d16ac357-3ced-4c2c-bcdc-d38971214414"), "12345678", "0912384746", "Trang", "trangnt34", true });

            migrationBuilder.CreateIndex(
                name: "IX_Anhs_IdSanPhamChiTiet",
                table: "Anhs",
                column: "IdSanPhamChiTiet");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPhamYeu_IdSanPhamChiTiet",
                table: "ChiTietSanPhamYeu",
                column: "IdSanPhamChiTiet");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPhamYeu_IdSanPhamYeuThich",
                table: "ChiTietSanPhamYeu",
                column: "IdSanPhamYeuThich");

            migrationBuilder.CreateIndex(
                name: "IX_DaiChiNhanHangs_IdKhachHang",
                table: "DaiChiNhanHangs",
                column: "IdKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucChiTiets_IdDanhMuc",
                table: "DanhMucChiTiets",
                column: "IdDanhMuc");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucChiTiets_IdSanPhamChiTiet",
                table: "DanhMucChiTiets",
                column: "IdSanPhamChiTiet");

            migrationBuilder.CreateIndex(
                name: "IX_GiamGiaChiTiets_IdGiamGia",
                table: "GiamGiaChiTiets",
                column: "IdGiamGia");

            migrationBuilder.CreateIndex(
                name: "IX_GiamGiaChiTiets_IdHoaDon",
                table: "GiamGiaChiTiets",
                column: "IdHoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangChiTiets_IdGioHang",
                table: "GioHangChiTiets",
                column: "IdGioHang");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangChiTiets_IdSanPhamChiTiet",
                table: "GioHangChiTiets",
                column: "IdSanPhamChiTiet");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangs_IdKhachHang",
                table: "GioHangs",
                column: "IdKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiets_IdHoaDon",
                table: "HoaDonChiTiets",
                column: "IdHoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiets_IdSanPhamChiTiet",
                table: "HoaDonChiTiets",
                column: "IdSanPhamChiTiet");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_IdDiaChiNhanHang",
                table: "HoaDons",
                column: "IdDiaChiNhanHang");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_IdKhachHang",
                table: "HoaDons",
                column: "IdKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_IdPhuongThuc",
                table: "HoaDons",
                column: "IdPhuongThuc");

            migrationBuilder.CreateIndex(
                name: "IX_KhuyenMaiPhanLoais_idKhuyenMai",
                table: "KhuyenMaiPhanLoais",
                column: "idKhuyenMai");

            migrationBuilder.CreateIndex(
                name: "IX_KhuyenMaiPhanLoais_IdPhanLoai",
                table: "KhuyenMaiPhanLoais",
                column: "IdPhanLoai");

            migrationBuilder.CreateIndex(
                name: "IX_KhuyenMaiSanPhams_IdkhuyenMai",
                table: "KhuyenMaiSanPhams",
                column: "IdkhuyenMai");

            migrationBuilder.CreateIndex(
                name: "IX_KhuyenMaiSanPhams_IdSanPhamChiTiet",
                table: "KhuyenMaiSanPhams",
                column: "IdSanPhamChiTiet");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_IdChucVu",
                table: "NhanViens",
                column: "IdChucVu");

            migrationBuilder.CreateIndex(
                name: "IX_PhanLoaiChiTiets_IdPhanLoai",
                table: "PhanLoaiChiTiets",
                column: "IdPhanLoai");

            migrationBuilder.CreateIndex(
                name: "IX_PhanLoaiChiTiets_IdSanPhamChiTiet",
                table: "PhanLoaiChiTiets",
                column: "IdSanPhamChiTiet");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamChiTiets_IdChatLieu",
                table: "SanPhamChiTiets",
                column: "IdChatLieu");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamChiTiets_IdMau",
                table: "SanPhamChiTiets",
                column: "IdMau");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamChiTiets_IdNSX",
                table: "SanPhamChiTiets",
                column: "IdNSX");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamChiTiets_IdSize",
                table: "SanPhamChiTiets",
                column: "IdSize");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamChiTiets_IdSp",
                table: "SanPhamChiTiets",
                column: "IdSp");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamYeuThichs_IdKhachHang",
                table: "SanPhamYeuThichs",
                column: "IdKhachHang");
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
