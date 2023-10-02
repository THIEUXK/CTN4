using CTN4_Data.Models.DB_CTN4;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CTN4_Data.Configurations
{
    public class DiaChiNhanHangConfiguration : IEntityTypeConfiguration<DiaChiNhanHang>
    {
        public void Configure(EntityTypeBuilder<DiaChiNhanHang> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.KhachHang).WithMany(c => c.DiaChiNhanHangs).HasForeignKey(c => c.IdKhachHang);


        }
    }
}
