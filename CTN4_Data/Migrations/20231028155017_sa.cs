using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CTN4_Data.Migrations
{
    public partial class sa : Migration
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
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TongTien = table.Column<float>(type: "real", nullable: false),
                    NgayDat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayGiao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayNhan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TenKhachHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDTNguoiNhan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_detele = table.Column<bool>(type: "bit", nullable: false),
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
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081137"), "", true, "Da PU cao cấp", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081138"), "", true, "Da PU mềm mịn, cao cấp", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081139"), "", true, "Vai Canvat", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), "", true, "Da tổng hợp", true }
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
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f4381111"), true, "Túi tote" },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081163"), true, "Túi đeo chéo Nữ – Cross body" },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081164"), true, "Túi đeo vai – Shoulder bag" },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081165"), true, "Túi satchel" },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081166"), true, "Túi baguette" },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081167"), true, "Túi bao tử – Túi bumbag" },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081168"), true, "Túi cầm tay – Clutch" },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081169"), true, "Túi dây rút – Pouch" },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081170"), true, "Túi Bucket" },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081171"), true, "Túi Bowling" },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081172"), true, "Túi Ring Bag" },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7089111"), true, "Túi Hobo" }
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
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081101"), true, "kem Đậm", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081110"), true, "xanh dương", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081111"), true, "đen", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081112"), true, "trắng", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081113"), true, "nâu", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081114"), true, "xám", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081115"), true, "vàng", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081116"), true, "ghi", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081117"), true, "cam", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081118"), true, "xanh dương đậm", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081119"), true, "xanh lục", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081121"), true, "xanh lá", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081131"), true, "xanh nhạt", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081141"), true, "tràm", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081151"), true, "tím", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081161"), true, "xanh lá đậm", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081171"), true, "xanh tím", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081181"), true, "hồng", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081191"), true, "kem", true }
                });

            migrationBuilder.InsertData(
                table: "NSXs",
                columns: new[] { "Id", "GhiChu", "Is_detele", "TenNSX", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), "", true, "Juno", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081125"), "", true, "Prada", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081126"), "", true, "Gucci", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081127"), "", true, "Chanel", true }
                });

            migrationBuilder.InsertData(
                table: "NSXs",
                columns: new[] { "Id", "GhiChu", "Is_detele", "TenNSX", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081128"), "", true, "Coach", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081129"), "", true, "MLB Korea", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081133"), "", true, "Michael Kors", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081134"), "", true, "JW Anderson", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081135"), "", true, "Christian Dior", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081136"), "", true, "Louis Vuitton", true }
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
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081122"), "Túi Xách Nhỏ Đeo Vai - Cycling_Trung Quốc_XanhNhat_Da tổng hợp(1).webp", true, "Túi Xách Nhỏ Đeo Vai - Cycling_Trung Quốc_XanhNhat_Da tổng hợp(1)", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081123"), "TDV Hobo Quai Ngắn_QuanChau_Trang_Da PU mềm mịn, cao cấp(1).jpg", true, "TDV Hobo Quai Ngắn_QuanChau_Trang_Da PU mềm mịn, cao cấp(1)", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081211"), "TXT Da Rắn Khóa Bạc _QuanChau_Trang_Da PU cao cấp(1).jpg", true, "TXT Da Rắn Khóa Bạc _QuanChau_Trang_Da PU cao cấp(1)", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081311"), "TXT Phủ Màu Tag Vuông_QuanChau_XanhLuc_Da PU mềm mịn, cao cấp(1).jpg", true, "TXT Phủ Màu Tag Vuông_QuanChau_XanhLuc_Da PU mềm mịn, cao cấp(1)", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081411"), "TDV Hobo Đáy Tròn_QuanChau_Trang_Da lộn, da PU cao cấp(1).jpg", true, "TDV Hobo Đáy Tròn_QuanChau_Trang_Da lộn, da PU cao cấp(1)", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081511"), "Túi Xách Nhỏ Curve 1_Trung Quốc_Xanhduong_Da tổng hợp(1).webp", true, "Túi Xách Nhỏ Curve 1_Trung Quốc_Xanhduong_Da tổng hợp(1)", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081611"), "TDV Hobo Đáy Tròn_QuanChau_Xanh-Duong_Da lộn, da PU cao cấp(1).jpg", true, "TDV Hobo Đáy Tròn_QuanChau_Xanh-Duong_Da lộn, da PU cao cấp(1)", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081711"), "TOT Classic Phối Màu _QuanChau_Ghi_Da PU mềm mịn, cao cấp(1).jpg", true, "TOT Classic Phối Màu _QuanChau_Ghi_Da PU mềm mịn, cao cấp(1)", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081811"), "TOT Classic Phối Màu _QuanChau_Nau_Da PU mềm mịn, cao cấp(1).jpg", true, "TOT Classic Phối Màu _QuanChau_Nau_Da PU mềm mịn, cao cấp(1)", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081911"), "Túi Xách Nhỏ Curve 1_Trung Quốc_XanhLa_Da tổng hợp(1).webp", true, "Túi Xách Nhỏ Curve 1_Trung Quốc_XanhLa_Da tổng hợp(1)", true }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Is_detele", "TenSize", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081146"), true, "30cm x 20cm x 10cm", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081147"), true, "28cm x 22cm x 10cm", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081148"), true, "27cm x 12cm x 8cm", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081149"), true, "23cm x 13cm x 6cm", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081150"), true, "23cm x 15cm x 5cm", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081152"), true, "22cm x 18cm x 8cm", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081153"), true, "20cm x 12cm x 7cm", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081154"), true, "22cm x 15cm x 6cm", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081155"), true, "17cm x 16cm x 7cm", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081156"), true, "22cm x 12cm x 6cm", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081157"), true, "21cm x 8cm x 13cm", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081158"), true, "27cm x 6cm x 19cm", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081159"), true, "20cm x 6cm x 13cm", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081160"), true, "37cm x 13cm x 28cm", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081161"), true, "20cm x 13.5cm x 7.5cm ", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081162"), true, "19cm x 13cm x 7cm", true }
                });

            migrationBuilder.InsertData(
                table: "NhanViens",
                columns: new[] { "Id", "AnhDaiDien", "DiaChi", "Email", "GioiTinh", "Ho", "IdChucVu", "MatKhau", "SDT", "Ten", "TenDangNhap", "Trangthai" },
                values: new object[] { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081173"), "", "Hà Nội", "nothing@gmail.com", "Nữ", "Nguyễn", new Guid("d16ac357-3ced-4c2c-bcdc-d38971214414"), "12345678", "0912384746", "Trang", "trangnt34", true });

            migrationBuilder.InsertData(
                table: "SanPhamChiTiets",
                columns: new[] { "Id", "GhiChu", "GiaBan", "GiaNhap", "GiaNiemYet", "IdChatLieu", "IdMau", "IdNSX", "IdSize", "IdSp", "Is_detele", "MaSp", "MoTa", "SoLuong", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("0175588f-0cdb-4e98-b201-449d60867dca"), "", 4500000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081137"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081110"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081127"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081150"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081611"), true, "SP05", "oke la", 100, true },
                    { new Guid("31440f45-3ba3-4f9f-821c-89260193b427"), "", 600000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081138"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081131"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081125"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081147"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081311"), true, "SP02", "oke la", 100, true },
                    { new Guid("3c807aff-ea96-44ac-ba2d-129d93fdd882"), "", 600000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081138"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081112"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081156"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081123"), true, "SP10", "oke la", 100, true },
                    { new Guid("4e68f3ae-a223-4e22-99a5-c6d421151acf"), "", 500000f, 400000f, 450000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081138"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081113"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081153"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081811"), true, "SP07", "oke la", 100, true },
                    { new Guid("9305976b-b393-425b-8ef1-f9d97dea5f8b"), "", 700000f, 600000f, 70000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081137"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081112"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081125"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081148"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081411"), true, "SP03", "oke la", 100, true },
                    { new Guid("9906ba33-794b-4c6f-ae1c-2925443b179d"), "", 700000f, 300000f, 750000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081138"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081116"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081152"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081711"), true, "SP06", "oke la", 100, true },
                    { new Guid("9ffe2323-f84e-4f0b-b1c4-a3698f4eb3ca"), "", 600000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081131"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081155"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081122"), true, "SP09", "oke la", 100, true },
                    { new Guid("ab4a90bd-8067-4e84-b034-3b3c27d23bc2"), "", 600000f, 300000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081110"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081126"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081149"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081511"), true, "SP04", "oke la", 100, true },
                    { new Guid("b76c1fea-d0c0-4cd6-b2b7-457eece327b2"), "", 500000f, 300000f, 450000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081137"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081112"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081146"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081211"), true, "SP01", "oke la", 100, true },
                    { new Guid("df824246-8d0f-40a9-8c32-fb774c12a5eb"), "", 650000f, 400000f, 550000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081121"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081154"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081911"), true, "SP08", "oke la", 100, true }
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
