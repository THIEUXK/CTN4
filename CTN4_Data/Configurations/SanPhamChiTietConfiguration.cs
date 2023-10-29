using CTN4_Data.Models.DB_CTN4;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTN4_Data.Configurations
{
    public class SanPhamChiTietConfiguration : IEntityTypeConfiguration<SanPhamChiTiet>
    {
        public void Configure(EntityTypeBuilder<SanPhamChiTiet> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.Size).WithMany(c => c.SanPhamChiTiets).HasForeignKey(c => c.IdSize);
            builder.HasOne(c => c.SanPham).WithMany(c => c.SanPhamChiTiets).HasForeignKey(c => c.IdSp);
            builder.HasOne(c => c.Mau).WithMany(c => c.SanPhamChiTiets).HasForeignKey(c => c.IdMau);
        }
    }
}
