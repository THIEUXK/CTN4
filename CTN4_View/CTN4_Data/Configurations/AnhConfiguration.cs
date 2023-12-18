using CTN4_Data.Models.DB_CTN4;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTN4_Data.Configurations
{
    public class AnhConfiguration : IEntityTypeConfiguration<Anh>
    {
        public void Configure(EntityTypeBuilder<Anh> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.SanPhamChiTiet).WithMany(c => c.Anhs).HasForeignKey(c => c.IdSanPhamChiTiet);
        }

    }
}
