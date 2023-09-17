using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTN4.Models.Configurations
{
    public class KhuyenMaiChiTietConfiguration : IEntityTypeConfiguration<KhuyenMaiChiTiet>
    {
        public void Configure(EntityTypeBuilder<KhuyenMaiChiTiet> builder)
        {
            builder.HasKey(c => c.Id);
        }
    }
}
