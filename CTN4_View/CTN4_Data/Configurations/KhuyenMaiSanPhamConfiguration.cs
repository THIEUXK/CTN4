using CTN4_Data.Models.DB_CTN4;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CTN4_Data.Configurations
{
    public class KhuyenMaiSanPhamConfiguration : IEntityTypeConfiguration<KhuyenMaiSanPham>
    {
        public void Configure(EntityTypeBuilder<KhuyenMaiSanPham> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.KhuyenMai).WithMany(c => c.KKhuyenMaiSanPhams).HasForeignKey(c => c.IdkhuyenMai);
            builder.HasOne(c => c.SanPham).WithMany(c => c.KhuyenMaiSanPhams).HasForeignKey(c => c.IdSanPham);
        }
    }
}
