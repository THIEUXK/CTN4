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
                    DieuKienGiam = table.Column<float>(type: "real", nullable: false),
                    LoaiGiamGia = table.Column<bool>(type: "bit", nullable: false),
                    Is_detele = table.Column<bool>(type: "bit", nullable: false)
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
                    Ho = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TenDangNhap = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    DongGia = table.Column<float>(type: "real", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    Ghichu = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: true),
                    TienShip = table.Column<float>(type: "real", nullable: true),
                    IdKhachHang = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    division_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codename = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "SanPhams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdChatLieu = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdNSX = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MaSp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnhDaiDien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaNhap = table.Column<float>(type: "real", nullable: false),
                    GiaBan = table.Column<float>(type: "real", nullable: false),
                    GiaNiemYet = table.Column<float>(type: "real", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_detele = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPhams_ChatLieus_IdChatLieu",
                        column: x => x.IdChatLieu,
                        principalTable: "ChatLieus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SanPhams_NSXs_IdNSX",
                        column: x => x.IdNSX,
                        principalTable: "NSXs",
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
                name: "HoaDons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHoaDon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTaoHoaDon = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TongTien = table.Column<float>(type: "real", nullable: false),
                    TienShip = table.Column<float>(type: "real", nullable: false),
                    NgayDat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayGiao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayNhan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TenKhachHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDTNguoiNhan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Is_detele = table.Column<bool>(type: "bit", nullable: false),
                    TrangThaiThanhToan = table.Column<bool>(type: "bit", nullable: false),
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
                name: "ChiTietSanPhamYeu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSanPham = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdKhachHang = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietSanPhamYeu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietSanPhamYeu_KhachHangs_IdKhachHang",
                        column: x => x.IdKhachHang,
                        principalTable: "KhachHangs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChiTietSanPhamYeu_SanPhams_IdSanPham",
                        column: x => x.IdSanPham,
                        principalTable: "SanPhams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DanhMucChiTiets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSanPham = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                        name: "FK_DanhMucChiTiets_SanPhams_IdSanPham",
                        column: x => x.IdSanPham,
                        principalTable: "SanPhams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KhuyenMaiSanPhams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSanPham = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                        name: "FK_KhuyenMaiSanPhams_SanPhams_IdSanPham",
                        column: x => x.IdSanPham,
                        principalTable: "SanPhams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PhanLoaiChiTiets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSanPham = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                        name: "FK_PhanLoaiChiTiets_SanPhams_IdSanPham",
                        column: x => x.IdSanPham,
                        principalTable: "SanPhams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SanPhamChiTiets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    Is_detele = table.Column<bool>(type: "bit", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    IdMau = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdSize = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdSp = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhamChiTiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPhamChiTiets_Maus_IdMau",
                        column: x => x.IdMau,
                        principalTable: "Maus",
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
                name: "GiamGiaChiTiets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdGiamGia = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdHoaDon = table.Column<int>(type: "int", nullable: true)
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
                name: "LichSuHoaDons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdHoaDon = table.Column<int>(type: "int", nullable: true),
                    TenHanhDong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGiaoThaoTac = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiThucHien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_detele = table.Column<bool>(type: "bit", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    HoaDonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichSuHoaDons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LichSuHoaDons_HoaDons_HoaDonId",
                        column: x => x.HoaDonId,
                        principalTable: "HoaDons",
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
                name: "HoaDonChiTiets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    GiaTien = table.Column<float>(type: "real", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    Is_detele = table.Column<bool>(type: "bit", nullable: false),
                    IdSanPhamChiTiet = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdHoaDon = table.Column<int>(type: "int", nullable: true)
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
                values: new object[] { new Guid("d16ac357-3ced-4c2c-bcdc-d38971214499"), "", "Hà Nội", "thieubvph20221@gmail.com", "Nam", "Bùi Văn", true, "thieuxk2k3hahl", "0912384746", "Thiều", "thieuxk2k3hahl", true });

            migrationBuilder.InsertData(
                table: "KhuyenMais",
                columns: new[] { "Id", "DongGia", "Ghichu", "Is_Detele", "MaKhuyenMai", "NgayBatDau", "NgayKetThuc", "PhanTramGiamGia", "SoTienGiam", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("13effe44-e728-48a8-9baa-967da4ee38cd"), 0f, null, true, "km04", new DateTime(2023, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 22000f, true },
                    { new Guid("23bdd26c-d7a3-4307-8e22-d230b653d611"), 0f, null, true, "km03", new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 0f, true },
                    { new Guid("da810cca-4fca-4291-a52b-875841d49e34"), 0f, null, true, "km02", new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 50000f, true },
                    { new Guid("e3e37e9e-7ea3-4f87-94af-1329363a4322"), 0f, null, true, "km06", new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, 0f, true },
                    { new Guid("f877e80d-2b32-43b0-be70-cf3b15113056"), 0f, null, true, "km01", new DateTime(2023, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, 0f, true },
                    { new Guid("fa1ae994-6ab0-4ee6-b8b1-ff336cf994a8"), 0f, null, true, "km05", new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 0f, true }
                });

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
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081171"), true, "xanh tím", true }
                });

            migrationBuilder.InsertData(
                table: "Maus",
                columns: new[] { "Id", "Is_detele", "TenMau", "TrangThai" },
                values: new object[,]
                {
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
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081127"), "", true, "Chanel", true },
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
                    { new Guid("d16ac357-3ced-4c2c-bcdc-d38971211114"), true, "Thanh toán qua VNpay", true }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "CoSize", "Is_detele", "TenSize", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081146"), "S", true, "15cm x 9.5cm x 7cm", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081147"), "M", true, "20cm x 12cm x 7cm", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081148"), "OM", true, "25cm x 14.5cm x 8cm", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081149"), "L", true, "30cm x 21cm x 10cm", true }
                });

            migrationBuilder.InsertData(
                table: "NhanViens",
                columns: new[] { "Id", "AnhDaiDien", "DiaChi", "Email", "GioiTinh", "Ho", "IdChucVu", "MatKhau", "SDT", "Ten", "TenDangNhap", "Trangthai" },
                values: new object[,]
                {
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081173"), "", "Hà Nội", "nothing@gmail.com", "Nữ", "Nguyễn", new Guid("d16ac357-3ced-4c2c-bcdc-d38971214414"), "12345678", "0912384746", "Trang", "trangnt34", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081174"), "", "Hà Nội", "nothing@gmail.com", "Nam", "Cao", new Guid("d16ac357-3ced-4c2c-bcdc-d38971214414"), "1", "0912384746", "Toan", "1", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081175"), "", "Hà Nội", "thieubvph20221@gmail.com", "Nam", "Bùi Văn", new Guid("56dd3ee2-c4df-4376-b982-e2c0f70877e9"), "Thieuxk2k3hahl2", "0912384746", "Thiều", "Thieuxk2k3hahl2", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081176"), "", "Hà Nội", "thieubvph20221@gmail.com", "Nam", "Bùi Văn", new Guid("d16ac357-3ced-4c2c-bcdc-d38971214414"), "Thieuxk2k3hahl", "0912384746", "Thiều", "Thieuxk2k3hahl", true }
                });

            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "Id", "AnhDaiDien", "GhiChu", "GiaBan", "GiaNhap", "GiaNiemYet", "IdChatLieu", "IdNSX", "Is_detele", "MaSp", "MoTa", "TenSanPham", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("56dd3de2-c4df-4376-b982-e2c0f7081817"), "TOT Lưới_QuanChau_Den_Vai Canvat_Dài 20 x Rộng 13.5 x Cao 7.5 (cm)(1).jpg", "", 600000f, 400000f, 600000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081139"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081126"), true, "SP02", "oke la", "TOT Lưới", true },
                    { new Guid("56dd3de2-c4df-4376-b982-e2c0f7081818"), "TOT Ngang Da Mịn_QuanChau_Kem_Da PU mềm mịn, cao cấp__Dài 37 x Rộng 13 x Cao 28 (cm)(1).jpg", "", 600000f, 400000f, 600000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081139"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081126"), true, "SP03", "oke la", "TOT Ngang Da Mịn", true },
                    { new Guid("56dd3de2-c4df-4376-b982-e2c0f7081819"), "Túi Xách Nhỏ Curve 1_Trung Quốc_XanhLa_Da tổng hợp_20cmx12cmx7cm(1).webp", "", 600000f, 400000f, 600000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081126"), true, "SP03", "oke la", "Túi Xách Nhỏ Curve 1", true },
                    { new Guid("56dd3de2-c4df-4376-b982-e2c0f7081820"), "Túi Xách Nhỏ Đeo Vai - Cycling_Trung Quốc_XanhNhat_Da tổng hợp_23cmx15cmx5cm(1).webp", "", 600000f, 400000f, 600000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081126"), true, "SP03", "oke la", "Túi Xách Nhỏ Đeo Vai", true },
                    { new Guid("56dd3de2-c4df-4376-b982-e2c0f7081821"), "Túi Xách Nhỏ Hobo Dập Logo Jn_Trung Quốc_Nau_Da PU cao cấp_23cmx13cmx6cm(1).webp", "", 600000f, 400000f, 600000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081137"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081126"), true, "SP03", "oke la", "Túi Xách Nhỏ Hobo Dập Logo Jn", true },
                    { new Guid("56dd3de2-c4df-4376-b982-e2c0f7081822"), "Túi Xách Nhỏ Saddle Bag Time Travelling_Trung Quốc_Nau_Da tổng hợp_22cmx15cmx6cm(1).webp", "", 600000f, 400000f, 600000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081126"), true, "SP03", "oke la", "Túi Xách Nhỏ Saddle Bag Time Travelling", true },
                    { new Guid("56dd3de2-c4df-4376-b982-e2c0f7081823"), "Túi Xách Nhỏ Top Handle Cozy _Trung Quốc_Tim_Da tổng hợp_17cmx16cmx7cm(1).webp", "", 600000f, 400000f, 600000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081126"), true, "SP03", "oke la", "Túi Xách Nhỏ Top Handle Cozy", true },
                    { new Guid("56dd3de2-c4df-4376-b982-e2c0f7081824"), "Túi Xách Nhỏ Top Handle Phối Hoa 3D _Trung Quốc_XanhTim_Da tổng hợp_17cmx16cmx7cm(1).webp", "", 600000f, 400000f, 600000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081126"), true, "SP03", "oke la", "Túi Xách Nhỏ Top Handle Phối Hoa 3D", true },
                    { new Guid("56dd3de2-c4df-4376-b982-e2c0f7081825"), "Túi Xách Nhỏ Tote Elite Of The Class_Trung Quốc_Kem_Da tổng hợp_22cmx18cmx8cm(1).webp", "", 600000f, 400000f, 600000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081126"), true, "SP03", "oke la", "Túi Xách Nhỏ Tote Elite Of The Class", true },
                    { new Guid("56dd3de2-c4df-4376-b982-e2c0f7081826"), "Túi Xách Trung Đeo Vai Wholeheartedly_Trung Quốc_Hong_Da tổng hợp_30cmx20cmx10cm(1).webp", "", 600000f, 400000f, 600000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081126"), true, "SP03", "oke la", "Túi Xách Trung Đeo Vai Wholeheartedly", true },
                    { new Guid("56dd3de2-c4df-4376-b982-e2c0f7081827"), "Túi Xách Trung Hobo Cozy_Trung Quốc_Kem_Da tổng hợp_27cmx12cmx8cm(1).webp", "", 600000f, 400000f, 600000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081126"), true, "SP03", "oke la", "Túi Xách Trung Hobo Cozy", true },
                    { new Guid("56dd3de2-c4df-4376-b982-e2c0f7081828"), "Túi Xách Trung Satchel Elite Of The Class_Trung Quốc_Xanh_Da tổng hợp_28cmx22cmx10cm(1).webp", "", 600000f, 400000f, 600000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081126"), true, "SP03", "oke la", "Túi Xách Trung Satchel - Enhanced Confidence", true },
                    { new Guid("56dd3de2-c4df-4376-b982-e2c0f7081829"), "TXT Hộp Quai Xích_QuanChau_XanhLuc_Da PU mềm mịn, cao cấp_Dài 20 x Rộng 6 x Cao 13 (cm)(1).jpg", "", 600000f, 400000f, 600000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081137"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081126"), true, "SP03", "oke la", "TXT Hộp Quai Xích", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081211"), "TXT Da Rắn Khóa Bạc _QuanChau_Trang_Da PU cao cấp(1).jpg", "", 600000f, 400000f, 600000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), true, "SP01", "oke la", "TXT Da Rắn Khóa Bạc", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081311"), "TXT Phủ Màu Tag Vuông_QuanChau_XanhLuc_Da PU mềm mịn, cao cấp(1).jpg", "", 600000f, 400000f, 600000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), true, "SP02", "oke la", "TXT Phủ Màu Tag Vuông", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081411"), "TDV Hobo Đáy Tròn_QuanChau_Xanh-Duong_Da lộn, da PU cao cấp_Dài 22 x Cao 12 x Rộng 6 (cm)(1).jpg", "", 600000f, 400000f, 600000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), true, "SP03", "oke la", "TDV Hobo Đáy Tròn", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081511"), "TDV Hobo Quai Ngắn_QuanChau_Ghi_Da PU mềm mịn, cao cấp_Dài 27 x Rộng 6 x Cao 19 (cm)(1).jpg", "", 600000f, 400000f, 600000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), true, "SP04", "oke la", "TDV Hobo Quai Ngắn", true },
                    { new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081611"), "TOT Classic Phối Màu _QuanChau_Den_Da PU mềm mịn, cao cấp_Dài 20 x Rộng 13.5 x Cao 7.5 (cm)(1).jpg", "", 600000f, 400000f, 600000f, new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081144"), new Guid("56dd3ee2-c4df-4376-b982-e2c0f7081124"), true, "SP05", "oke la", "TOT Classic Phối Màu", true }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Anhs_IdSanPhamChiTiet",
                table: "Anhs",
                column: "IdSanPhamChiTiet");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPhamYeu_IdKhachHang",
                table: "ChiTietSanPhamYeu",
                column: "IdKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPhamYeu_IdSanPham",
                table: "ChiTietSanPhamYeu",
                column: "IdSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_DaiChiNhanHangs_IdKhachHang",
                table: "DaiChiNhanHangs",
                column: "IdKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucChiTiets_IdDanhMuc",
                table: "DanhMucChiTiets",
                column: "IdDanhMuc");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucChiTiets_IdSanPham",
                table: "DanhMucChiTiets",
                column: "IdSanPham");

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
                name: "IX_KhuyenMaiSanPhams_IdSanPham",
                table: "KhuyenMaiSanPhams",
                column: "IdSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuHoaDons_HoaDonId",
                table: "LichSuHoaDons",
                column: "HoaDonId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_IdChucVu",
                table: "NhanViens",
                column: "IdChucVu");

            migrationBuilder.CreateIndex(
                name: "IX_PhanLoaiChiTiets_IdPhanLoai",
                table: "PhanLoaiChiTiets",
                column: "IdPhanLoai");

            migrationBuilder.CreateIndex(
                name: "IX_PhanLoaiChiTiets_IdSanPham",
                table: "PhanLoaiChiTiets",
                column: "IdSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamChiTiets_IdMau",
                table: "SanPhamChiTiets",
                column: "IdMau");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamChiTiets_IdSize",
                table: "SanPhamChiTiets",
                column: "IdSize");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamChiTiets_IdSp",
                table: "SanPhamChiTiets",
                column: "IdSp");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_IdChatLieu",
                table: "SanPhams",
                column: "IdChatLieu");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_IdNSX",
                table: "SanPhams",
                column: "IdNSX");
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
                name: "LichSuHoaDons");

            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.DropTable(
                name: "PhanLoaiChiTiets");

            migrationBuilder.DropTable(
                name: "DanhMucs");

            migrationBuilder.DropTable(
                name: "GiamGias");

            migrationBuilder.DropTable(
                name: "GioHangs");

            migrationBuilder.DropTable(
                name: "SanPhamChiTiets");

            migrationBuilder.DropTable(
                name: "KhuyenMais");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "ChucVus");

            migrationBuilder.DropTable(
                name: "PhanLoais");

            migrationBuilder.DropTable(
                name: "Maus");

            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "DaiChiNhanHangs");

            migrationBuilder.DropTable(
                name: "PhuongThucThanhToans");

            migrationBuilder.DropTable(
                name: "ChatLieus");

            migrationBuilder.DropTable(
                name: "NSXs");

            migrationBuilder.DropTable(
                name: "KhachHangs");
        }
    }
}
