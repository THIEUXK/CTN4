using CTN4_Data.Models.DB_CTN4;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CTN4_Data.Configurations
{
    public class PhanLoaiChiTietConfiguration : IEntityTypeConfiguration<PhanLoaiChiTiet>
    {
        public void Configure(EntityTypeBuilder<PhanLoaiChiTiet> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.PhanLoai).WithMany(c => c.PhanLoaiChiTiets).HasForeignKey(c => c.IdPhanLoai);
            builder.HasOne(c => c.SanPham).WithMany(c => c.PhanLoaiChiTiets).HasForeignKey(c => c.IdSanPham);
        }
    }
}
