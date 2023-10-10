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
                        name: "FK_GioHangChiTiets_SanPhamChiTiets_IdGioHang",
                        column: x => x.IdGioHang,
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
                    { new Guid("094ca951-83de-4c08-833d-8311ceb09761"), "", true, "Nylon (Polyester)", true },
                    { new Guid("1a3ad2d4-fdfc-4725-9e04-1e1329ec0179"), "", true, "Vải không dệt (Micro Polyester)", true },
                    { new Guid("1b6ee31b-d377-4482-b5bf-866b68959e72"), "", true, "Vải bông (Cotton)", true },
                    { new Guid("7b1524c5-a0f4-4676-933a-67ad3d3c6953"), "", true, "Da thuộc (real leather)", true },
                    { new Guid("b9517dde-7237-4d9d-a193-ea27b519655a"), "", true, "Canvas", true },
                    { new Guid("d84de0f3-e1a0-4704-be06-a34edceebda9"), "", true, "Vải Simili (Giả da)", true },
                    { new Guid("e3d5cc85-0bcc-4930-bb56-68c3f8b275f4"), "", true, "Tricot (Vải dệt kim)", true }
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
                    { new Guid("00a2ffcc-e12b-4bd7-ac46-59f21571b68b"), true, "Túi satchel" },
                    { new Guid("1bd36788-c97f-4d29-948a-27e25b17554e"), true, "Túi bao tử – Túi bumbag" },
                    { new Guid("2a7ec1bc-49e4-4df8-a0fd-f232e0d39ab3"), true, "Túi cầm tay – Clutch" },
                    { new Guid("2fd6df78-1def-4b21-8a40-db5ef77211d4"), true, "Túi Bucket" },
                    { new Guid("43f2a9f0-ce38-459f-bd07-1ab54a2560ab"), true, "Túi đeo chéo Nữ – Cross body" },
                    { new Guid("5d5f7e88-1ff7-4575-a61c-771f0483acc6"), true, "Túi dây rút – Pouch" },
                    { new Guid("6ce05de5-e0b7-4b4b-8168-e41a6f2c017a"), true, "Túi đeo vai – Shoulder bag" },
                    { new Guid("8171275b-f4bd-49a0-a0a5-38a1d8b6718b"), true, "Túi Hobo" },
                    { new Guid("b1365862-bb4b-42a7-bcea-af5176cc405a"), true, "Túi baguette" },
                    { new Guid("da809ffc-5b5c-4c10-92af-d3d95b0d8c1d"), true, "Túi Ring Bag" },
                    { new Guid("ddb12c7e-7246-4561-9888-000be2b16216"), true, "Túi Bowling" },
                    { new Guid("fb98b4fb-d941-439a-8ed9-86166f9362f5"), true, "Túi tote" }
                });

            migrationBuilder.InsertData(
                table: "Maus",
                columns: new[] { "Id", "Is_detele", "TenMau", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("04196172-0d23-45e3-82c7-154f7cb79cc1"), true, "nâu da", true },
                    { new Guid("0f0d0801-6300-4c1d-a81d-aee84e07ce6b"), true, "xám", true },
                    { new Guid("1675ec61-957c-46ac-8e08-ea027feec9a0"), true, "xanh lục", true },
                    { new Guid("2c4470d6-26c9-4c7c-8902-9ade81515b1b"), true, "tím", true },
                    { new Guid("3ce6f344-eff7-489d-9f0b-daca40960c92"), true, "cam", true },
                    { new Guid("44254058-4f89-4ecb-8665-a0d2be9d8228"), true, "xanh đương", true },
                    { new Guid("6148cb90-cbd2-4b78-ad5d-9c6315ccca74"), true, "vàng", true },
                    { new Guid("66fee70c-2c00-40a0-b7eb-b29554b453f1"), true, "trắng", true },
                    { new Guid("75673d9f-0387-4b07-8113-79557415676d"), true, "xanh lá đậm", true },
                    { new Guid("a14575d1-23b8-4842-ab93-0d2c0ddd9166"), true, "đen", true },
                    { new Guid("d951c306-6e12-4de7-80cb-68b2c96df928"), true, "hồng", true },
                    { new Guid("ec55cb54-7a31-4163-8c31-8e7456b38bd2"), true, "tràm", true },
                    { new Guid("fa08fe04-02cd-44ad-b709-87828b26290f"), true, "kem", true }
                });

            migrationBuilder.InsertData(
                table: "NSXs",
                columns: new[] { "Id", "GhiChu", "Is_detele", "TenNSX", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("1e3728ce-891e-4027-9956-88b53a299a1f"), "", true, "Juno", true },
                    { new Guid("27d93154-2ba6-4bdb-a969-267a21d60781"), "", true, "Louis Vuitton", true },
                    { new Guid("31bda7a6-064b-4f9b-945a-d19a0c3b8d24"), "", true, "Gucci", true },
                    { new Guid("353f94f4-ff82-43e5-a71a-32aef8bb9bff"), "", true, "Michael Kors", true },
                    { new Guid("3d2ec165-7e42-4008-ac79-5787e3c0e265"), "", true, "Prada", true },
                    { new Guid("419d297f-10d8-46a1-8137-f0fcf0edf6b2"), "", true, "MLB Korea", true },
                    { new Guid("582e24af-d698-4dc0-85ff-8d0c5cae15e8"), "", true, "Christian Dior", true },
                    { new Guid("bfe7baf1-d821-42c6-8ae6-b2ffc8ab1e24"), "", true, "Chanel", true }
                });

            migrationBuilder.InsertData(
                table: "NSXs",
                columns: new[] { "Id", "GhiChu", "Is_detele", "TenNSX", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("d2210412-6f2a-43b7-a92b-08ca4a006861"), "", true, "JW Anderson", true },
                    { new Guid("edad5ce4-cb79-406f-84d6-a094d77a9ae2"), "", true, "Coach", true }
                });

            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "Id", "AnhDaiDiem", "Is_detele", "TenSanPham", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("00634307-c911-47e6-8693-5f8ec9cb02e8"), "", true, "Túi Xách Nhỏ Top Handle Cozy", true },
                    { new Guid("182b5646-e907-44c7-9d12-a784cc625c0b"), "", true, "Túi Xách Nhỏ Hobo Time Travelling", true },
                    { new Guid("93e3a5ef-3dcf-40a0-9f65-5f7f7e7c9b22"), "", true, "Túi Xách Nhỏ Dây Kéo Phối 2 Chất Liệu", true },
                    { new Guid("a36cff49-a02c-40d7-9138-30932c228591"), "", true, "Túi Xách Nhỏ Shoulder Bag Trang Trí Khóa Logo Cách Điệu", true },
                    { new Guid("b3c0600e-92f1-4a6a-918d-c34238707adf"), "", true, "Túi Xách Nhỏ Đeo Vai Time Travelling", true },
                    { new Guid("b408cfc5-3394-4f54-baee-aff744c1d3c1"), "", true, "Túi Xách Nhỏ Top Handle Phối Hoa 3D", true },
                    { new Guid("c2b33031-ac34-485c-b992-a4e1e0f55ba1"), "", true, "Túi Xách Nhỏ Hobo Dập Logo Jn", true },
                    { new Guid("e987e6c0-3506-4b3b-b33e-b04647aa7d70"), "", true, "Túi Xách Nhỏ Đeo Vai Elite Of The Class", true },
                    { new Guid("f0a68696-d90e-43b4-ab6a-c45eb5eff7d5"), "", true, "Túi Xách Nhỏ Nắp Gập Khóa Trang Trí", true },
                    { new Guid("fd7ffec8-9f4d-48b4-962a-a99a56a2c46e"), "", true, "Túi Xách Nhỏ Dáng Boho New Moon", true }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Is_detele", "TenSize", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("0da55823-cb4d-4310-80df-b7d49ddd69c1"), true, "Small", true },
                    { new Guid("29bc9d3e-5492-4277-898e-134fdc752155"), true, "Extra Small", true },
                    { new Guid("7b6baa57-b1ed-49ab-896f-24b2805dfad0"), true, "Standard (Medium)", true },
                    { new Guid("e8e4ddd3-ddad-4eea-95da-2e98d9955144"), true, "Extra Large", true },
                    { new Guid("faefdc0f-963f-4701-8572-d75ed0138b12"), true, "Large", true }
                });

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
