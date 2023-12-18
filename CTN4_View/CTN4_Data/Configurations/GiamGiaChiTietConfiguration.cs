using CTN4_Data.Models.DB_CTN4;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CTN4_Data.Configurations
{
    public class GiamGiaChiTietConfiguration : IEntityTypeConfiguration<GiamGiaChiTiet>
    {
        public void Configure(EntityTypeBuilder<GiamGiaChiTiet> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.GiamGia).WithMany(c => c.GiamGiaChiTiets).HasForeignKey(c => c.IdGiamGia);
            builder.HasOne(c => c.HoaDon).WithMany(c => c.GiamGiaChiTiets).HasForeignKey(c => c.IdHoaDon);
        }
    }
}
