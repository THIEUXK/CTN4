using CTN4_Data.Models.DB_CTN4;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTN4_Data.Configurations
{
    public class HoaDonConfiguration : IEntityTypeConfiguration<HoaDon>
    {
        public void Configure(EntityTypeBuilder<HoaDon> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.KhachHang).WithMany(c => c.HoaDon).HasForeignKey(c => c.IdKhachHang);
            builder.HasOne(c => c.DiaChiNhanHang).WithMany(c => c.HoaDon).HasForeignKey(c => c.IdDiaChiNhanHang);
            builder.HasOne(c => c.PhuongThucThanhToan).WithMany(c => c.HoaDon).HasForeignKey(c => c.IdPhuongThuc);
        }
    }
}

