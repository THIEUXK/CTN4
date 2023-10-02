using CTN4_Data.Models.DB_CTN4;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTN4_Data.Models.Configurations
{
    public class KhuyenMaiChiTietConfiguration : IEntityTypeConfiguration<KhuyenMaiChiTiet>
    {
        public void Configure(EntityTypeBuilder<KhuyenMaiChiTiet> builder)
        {
            builder.HasKey(c => c.Id);
        }
    }
}
