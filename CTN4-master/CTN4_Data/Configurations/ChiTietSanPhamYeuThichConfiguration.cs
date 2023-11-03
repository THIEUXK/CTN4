using CTN4_Data.Models.DB_CTN4;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTN4_Data.Configurations
{
    public class ChiTietSanPhamYeuThichConfiguration : IEntityTypeConfiguration<ChiTietSanPhamYeuThich>
    {
        public void Configure(EntityTypeBuilder<ChiTietSanPhamYeuThich> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.SanPham).WithMany(c => c.CtietSanPhamYeuThiches).HasForeignKey(c => c.IdSanPham);
            builder.HasOne(c => c.KhachHang).WithMany(c => c.ChiTietSanPhamYeuThiches).HasForeignKey(c => c.IdKhachHang);
        }
    }
}
