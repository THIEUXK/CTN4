using CTN4_Data.Models.DB_CTN4;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTN4_Data.Configurations
{
    public class GioHangChiTietConfiguration : IEntityTypeConfiguration<GioHangChiTiet>
    {
        public void Configure(EntityTypeBuilder<GioHangChiTiet> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.GioHang).WithMany(c => c.GioHangChiTiets).HasForeignKey(c => c.IdGioHang);
            builder.HasOne(c => c.SanPhamChiTiet).WithMany(c => c.GioHangChiTiets).HasForeignKey(c => c.IdSanPhamChiTiet);

        }
    }
}
