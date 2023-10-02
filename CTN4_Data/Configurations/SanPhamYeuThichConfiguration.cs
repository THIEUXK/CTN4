using CTN4_Data.Models.DB_CTN4;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CTN4_Data.Configurations
{
    public class SanPhamYeuThichConfiguration : IEntityTypeConfiguration<SanPhamYeuThich>
    {
        public void Configure(EntityTypeBuilder<SanPhamYeuThich> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.KKhachHang).WithMany(c => c.SanPhamYeuThiches).HasForeignKey(c => c.IdKhachHang);
        }

    }

}
