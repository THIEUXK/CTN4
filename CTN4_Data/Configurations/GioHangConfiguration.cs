using CTN4_Data.Models.DB_CTN4;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTN4_Data.Configurations
{
    public class GioHangConfiguration : IEntityTypeConfiguration<GioHang>
    {
        public void Configure(EntityTypeBuilder<GioHang> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.KhachHang).WithMany(c => c.GioHang).HasForeignKey(c => c.IdKhachHang);

        }
    }
}
