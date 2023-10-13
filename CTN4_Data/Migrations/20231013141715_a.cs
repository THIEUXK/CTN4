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
                    { new Guid("11a58cf1-2a35-463a-846c-393a8263ae5a"), "", true, "Da PU cao cấp", true },
                    { new Guid("2571a49c-cafd-44b5-b097-ac7d9b0bcd96"), "", true, "Da PU mềm mịn, cao cấp", true },
                    { new Guid("ce521b50-a065-4d1d-8933-28be59d1129a"), "", true, "Da tổng hợp", true },
                    { new Guid("f76c7f09-4deb-4d83-8115-b28d222e52f4"), "", true, "Vai Canvat", true }
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
                    { new Guid("0f7f8edf-ed4b-4f9e-ba8d-1631bb564cb9"), true, "Túi dây rút – Pouch" },
                    { new Guid("202fe108-4dc4-43ef-81df-dc8c27d069be"), true, "Túi baguette" },
                    { new Guid("3add2fec-6a29-437f-b044-9269e6d92831"), true, "Túi bao tử – Túi bumbag" },
                    { new Guid("5035f0b8-4ced-459b-9893-d0fe202c3d23"), true, "Túi đeo vai – Shoulder bag" },
                    { new Guid("87cf4a90-90ca-44c7-8cdb-7648f89a19ae"), true, "Túi Bucket" },
                    { new Guid("8bf6369f-f17a-437d-837e-93a4e2c042f8"), true, "Túi satchel" },
                    { new Guid("be61710b-46b4-4856-be3a-f52a7c181201"), true, "Túi tote" },
                    { new Guid("c9b613dc-87f7-4414-aeb0-5ab459242437"), true, "Túi Ring Bag" },
                    { new Guid("d71949ec-7f01-43cf-9eb9-349aa26215c3"), true, "Túi cầm tay – Clutch" },
                    { new Guid("ec6c3419-3a19-483f-8e1b-4a02c22dfde0"), true, "Túi Hobo" },
                    { new Guid("ede7be32-49b2-4a9b-9b7a-c1a1bccbde66"), true, "Túi Bowling" },
                    { new Guid("f9f1af17-d9c6-4590-8de5-6420c3536413"), true, "Túi đeo chéo Nữ – Cross body" }
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
                    { new Guid("13431a98-cf18-4628-a3de-409c114b3298"), true, "trắng", true },
                    { new Guid("35c5c671-2c81-4cf4-8720-481a60919a2e"), true, "xanh dương đậm", true },
                    { new Guid("363fe4e9-c8b0-47d4-b610-6ec7b78b9ff6"), true, "xanh lục", true },
                    { new Guid("47dbd6c4-b552-41ae-96c9-2898c0e18ebc"), true, "tràm", true },
                    { new Guid("4a63b31f-3e1c-4ccc-968b-e377e3d9bda5"), true, "xanh lá đậm", true },
                    { new Guid("5768d1e6-ecd1-4f6e-978b-c5cbc19c2d4b"), true, "xanh lá", true },
                    { new Guid("5dd16586-6973-426a-a78e-c6901b41d7d1"), true, "kem Đậm", true },
                    { new Guid("5e5be10e-ca75-4ccb-a4df-0932a1b864fc"), true, "vàng", true },
                    { new Guid("612ea65a-7ad0-45aa-ba59-2d0628514286"), true, "cam", true },
                    { new Guid("6cc26505-2331-496d-a4c3-76652b629594"), true, "kem", true },
                    { new Guid("6d17f685-b5a4-40e1-adc6-50a35a866982"), true, "tím", true },
                    { new Guid("83e1a80f-baf5-4337-83a1-10bd0fa3a2a0"), true, "nâu", true },
                    { new Guid("8eff5a22-0fa8-402d-a0f4-3369671d0465"), true, "xanh tím", true },
                    { new Guid("a3f674bc-e5d7-4aad-bc6e-8583b5d34229"), true, "hồng", true },
                    { new Guid("c2f13edf-2390-4201-8a2c-c9d609bb1e46"), true, "ghi", true },
                    { new Guid("d1241870-b01a-4832-b2aa-3ed0f9e7dfd6"), true, "xám", true },
                    { new Guid("d28a8a35-c195-453f-ad51-8b6e208b8bf1"), true, "xanh dương", true },
                    { new Guid("d3e7bb9e-d9d9-4f13-a4e1-88be4387eefc"), true, "xanh nhạt", true },
                    { new Guid("ff4f69d1-1381-473e-8103-13e1471c0ea0"), true, "đen", true }
                });

            migrationBuilder.InsertData(
                table: "NSXs",
                columns: new[] { "Id", "GhiChu", "Is_detele", "TenNSX", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("287442f6-e66e-4383-a82f-620b27c7aaa9"), "", true, "Michael Kors", true },
                    { new Guid("37a4019f-40fb-42a0-ae0a-b412aef3ef13"), "", true, "Louis Vuitton", true },
                    { new Guid("46658551-a636-4852-869e-d9d2106daa29"), "", true, "JW Anderson", true },
                    { new Guid("7160525e-175f-4143-b15c-767281288b2b"), "", true, "MLB Korea", true }
                });

            migrationBuilder.InsertData(
                table: "NSXs",
                columns: new[] { "Id", "GhiChu", "Is_detele", "TenNSX", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("a41d9a2a-b9dd-4214-a6a3-495185bce92e"), "", true, "Coach", true },
                    { new Guid("cdf2ed3d-7a3e-4366-943a-8782953b587e"), "", true, "Chanel", true },
                    { new Guid("da8feee4-e2ba-4b43-a6f7-4a7ffef5cab3"), "", true, "Juno", true },
                    { new Guid("e00cccba-9e13-4a58-be90-78699664f47a"), "", true, "Prada", true },
                    { new Guid("ec6c31ea-ae1c-443b-823f-39a40bcb2c5d"), "", true, "Gucci", true },
                    { new Guid("efd9c330-93b0-4065-bde9-7287c9e26519"), "", true, "Christian Dior", true }
                });

            migrationBuilder.InsertData(
                table: "PhuongThucThanhToans",
                columns: new[] { "Id", "Is_detele", "TenPhuongThuc", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("d16ac357-3ced-4c2c-bcdc-d38971211111"), true, "Thanh toán khi nhận hàng", true },
                    { new Guid("d16ac357-3ced-4c2c-bcdc-d38971211112"), true, "Thanh toán tại cửa hàng", true },
                    { new Guid("d16ac357-3ced-4c2c-bcdc-d38971211113"), true, "Thanh toán qua ngân hàng", true },
                    { new Guid("d16ac357-3ced-4c2c-bcdc-d38971211114"), true, "Thanh toán qua VNpay", true }
                });

            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "Id", "AnhDaiDien", "Is_detele", "TenSanPham", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("0daa94fb-89ef-439b-a084-c6fae66b6db6"), "TXT Da Rắn Khóa Bạc _QuanChau_Trang_Da PU cao cấp(1).jpg", true, "TXT Da Rắn Khóa Bạc _QuanChau_Trang_Da PU cao cấp(1)", true },
                    { new Guid("33b07e93-a0ce-473b-ac37-b24a8bdb4ad3"), "TDV Hobo Đáy Tròn_QuanChau_Trang_Da lộn, da PU cao cấp(1).jpg", true, "TDV Hobo Đáy Tròn_QuanChau_Trang_Da lộn, da PU cao cấp(1)", true },
                    { new Guid("36ffe385-f22b-4381-a766-87b37815a77c"), "Túi Xách Nhỏ Curve 1_Trung Quốc_Xanhduong_Da tổng hợp(1).webp", true, "Túi Xách Nhỏ Curve 1_Trung Quốc_Xanhduong_Da tổng hợp(1)", true },
                    { new Guid("3b4e8333-af58-435a-a3fe-8bf347fd23b1"), "Túi Xách Nhỏ Curve 1_Trung Quốc_XanhLa_Da tổng hợp(1).webp", true, "Túi Xách Nhỏ Curve 1_Trung Quốc_XanhLa_Da tổng hợp(1)", true },
                    { new Guid("4b96ab38-6a17-4b61-9ab2-afdcf8707902"), "Túi Xách Nhỏ Đeo Vai - Cycling_Trung Quốc_XanhNhat_Da tổng hợp(1).webp", true, "Túi Xách Nhỏ Đeo Vai - Cycling_Trung Quốc_XanhNhat_Da tổng hợp(1)", true },
                    { new Guid("55207b59-91b4-4fe7-88da-459268e04b98"), "TDV Hobo Đáy Tròn_QuanChau_Xanh-Duong_Da lộn, da PU cao cấp(1).jpg", true, "TDV Hobo Đáy Tròn_QuanChau_Xanh-Duong_Da lộn, da PU cao cấp(1)", true },
                    { new Guid("81c17f13-7db0-46a6-b83e-d210e4b19d7a"), "TXT Phủ Màu Tag Vuông_QuanChau_XanhLuc_Da PU mềm mịn, cao cấp(1).jpg", true, "TXT Phủ Màu Tag Vuông_QuanChau_XanhLuc_Da PU mềm mịn, cao cấp(1)", true },
                    { new Guid("b2e88dfb-ad3f-4c89-872e-09d1196192ca"), "TOT Classic Phối Màu _QuanChau_Ghi_Da PU mềm mịn, cao cấp(1).jpg", true, "TOT Classic Phối Màu _QuanChau_Ghi_Da PU mềm mịn, cao cấp(1)", true },
                    { new Guid("b7e2517a-4f29-410d-aa14-3adf036c267e"), "TOT Classic Phối Màu _QuanChau_Nau_Da PU mềm mịn, cao cấp(1).jpg", true, "TOT Classic Phối Màu _QuanChau_Nau_Da PU mềm mịn, cao cấp(1)", true },
                    { new Guid("c621dd2f-640e-4d08-8fd1-f2cbcb28758d"), "TDV Hobo Quai Ngắn_QuanChau_Trang_Da PU mềm mịn, cao cấp(1).jpg", true, "TDV Hobo Quai Ngắn_QuanChau_Trang_Da PU mềm mịn, cao cấp(1)", true }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Is_detele", "TenSize", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("09127eff-8783-48bc-8008-1014431cfc47"), true, "23cm x 13cm x 6cm", true },
                    { new Guid("1fb37c42-1c4d-4486-934c-19b83349bd67"), true, "28cm x 22cm x 10cm", true },
                    { new Guid("238231e3-0eae-4355-9447-0ca4b077fe55"), true, "37cm x 13cm x 28cm", true },
                    { new Guid("29064b95-128d-4e8b-9c14-7973a0274260"), true, "23cm x 15cm x 5cm", true },
                    { new Guid("3914e2ec-e0d5-47c2-b35c-e172a7635b3d"), true, "20cm x 12cm x 7cm", true },
                    { new Guid("462c5bad-4ed7-45d7-96fe-3aa08aea2b63"), true, "22cm x 18cm x 8cm", true },
                    { new Guid("5e6b449e-7b79-4a8b-a8f3-f85b89a6c94d"), true, "17cm x 16cm x 7cm", true },
                    { new Guid("68784dfa-b674-44ad-a88b-4a97683ea623"), true, "22cm x 12cm x 6cm", true },
                    { new Guid("6ae17509-d2d1-452f-b9e1-38d62a7c0811"), true, "20cm x 6cm x 13cm", true },
                    { new Guid("7a773b5a-d519-49b9-89aa-3efd440752eb"), true, "22cm x 15cm x 6cm", true },
                    { new Guid("88f47a21-51c2-41e5-a33e-ab80327b455e"), true, "21cm x 8cm x 13cm", true },
                    { new Guid("b7eceefd-df2f-41f5-acb9-4301fb512e79"), true, "27cm x 6cm x 19cm", true },
                    { new Guid("bbd5ee29-93c9-48fb-a70a-48b1c7df05f1"), true, "30cm x 20cm x 10cm", true },
                    { new Guid("dddee698-4ab7-47d5-a537-8128568cfb8a"), true, "27cm x 12cm x 8cm", true },
                    { new Guid("ee0211d5-26fe-4c5c-b1b9-e718f58e2f49"), true, "20cm x 13.5cm x 7.5cm ", true },
                    { new Guid("fb4cb218-ea67-4997-9ea6-ebeeedf7abb4"), true, "19cm x 13cm x 7cm", true }
                });

            migrationBuilder.InsertData(
                table: "NhanViens",
                columns: new[] { "Id", "AnhDaiDien", "DiaChi", "Email", "GioiTinh", "Ho", "IdChucVu", "MatKhau", "SDT", "Ten", "TenDangNhap", "Trangthai" },
                values: new object[] { new Guid("828b17b0-0ae9-488d-bcdc-187794c53797"), "", "Hà Nội", "nothing@gmail.com", "Nữ", "Nguyễn", new Guid("d16ac357-3ced-4c2c-bcdc-d38971214414"), "12345678", "0912384746", "Trang", "trangnt34", true });

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
