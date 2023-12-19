using CTN4_Data.Models;
using CTN4_Data.Models.DB_CTN4;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTN4_Data.Configurations
{
    public class DanhGiaSanPhamConfiguration : IEntityTypeConfiguration<DanhGiaSanPham>
    {
        public void Configure(EntityTypeBuilder<DanhGiaSanPham> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.SanPham).WithMany(c => c.DanhGiaSanPhams).HasForeignKey(c => c.IdSanPham);
            builder.HasOne(c => c.KhachHang).WithMany(c => c.DanhGiaSanPhams).HasForeignKey(c => c.IdKhachHang);
        }
    }
}
