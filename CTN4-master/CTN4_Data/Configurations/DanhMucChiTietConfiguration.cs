using CTN4_Data.Models.DB_CTN4;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CTN4_Data.Configurations
{
    public class DanhMucChiTietConfiguration : IEntityTypeConfiguration<DanhMucChiTiet>
    {
        public void Configure(EntityTypeBuilder<DanhMucChiTiet> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.DanhMuc).WithMany(c => c.DanhMucChiTiets).HasForeignKey(c => c.IdDanhMuc);
            builder.HasOne(c => c.SanPham).WithMany(c => c.DanhMucChiTiets).HasForeignKey(c => c.IdSanPham);

        }
    }
}
