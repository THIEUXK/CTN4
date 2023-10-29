using CTN4_Data.Models.DB_CTN4;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTN4_Data.Configurations
{
    public class SanPhamConfiguration : IEntityTypeConfiguration<SanPham>
    {
        public void Configure(EntityTypeBuilder<SanPham> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.ChatLieu).WithMany(c => c.SanPhams).HasForeignKey(c => c.IdChatLieu);
            builder.HasOne(c => c.NSX).WithMany(c => c.SanPhams).HasForeignKey(c => c.IdNSX);
        }
    }
}
