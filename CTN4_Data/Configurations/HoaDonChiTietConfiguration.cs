using CTN4_Data.Models.DB_CTN4;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTN4_Data.Configurations
{
    public class HoaDonChiTietConfiguration : IEntityTypeConfiguration<HoaDonChiTiet>
    {
        public void Configure(EntityTypeBuilder<HoaDonChiTiet> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.HoaDon).WithMany(c => c.HoaDonChiTiets).HasForeignKey(c => c.IdHoaDon);
            builder.HasOne(c => c.SanPhamChiTiet).WithMany(c => c.HoaDonChiTiets).HasForeignKey(c => c.IdSanPhamChiTiet);
        }
    }
}
