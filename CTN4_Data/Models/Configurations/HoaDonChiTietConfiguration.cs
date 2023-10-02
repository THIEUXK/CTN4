using CTN4_Data.Models.DB_CTN4;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTN4_Data.Models.Configurations
{
    public class HoaDonChiTietConfiguration : IEntityTypeConfiguration<HoaDonChiTiet>
    {
        public void Configure(EntityTypeBuilder<HoaDonChiTiet> builder)
        {
            builder.HasKey(c => c.Id);
        }
    }
}
