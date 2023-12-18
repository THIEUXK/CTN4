using CTN4_Data.Models.DB_CTN4;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTN4_Data.Configurations
{
    public class LichSuDonHangConfiguration : IEntityTypeConfiguration<LichSuDonHang>
    {
        public void Configure(EntityTypeBuilder<LichSuDonHang> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.HoaDon).WithMany(c => c.LichSuDonHangs).HasForeignKey(c => c.IdHoaDonn);
        }
    }
}
