using CTN4_Data.Models.DB_CTN4;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CTN4_Data.Configurations
{
    public class NhanVienConfiguration : IEntityTypeConfiguration<NhanVien>
    {
        public void Configure(EntityTypeBuilder<NhanVien> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.ChucVu).WithMany(c => c.NhanViens).HasForeignKey(c => c.IdChucVu);
        }
    }
}
