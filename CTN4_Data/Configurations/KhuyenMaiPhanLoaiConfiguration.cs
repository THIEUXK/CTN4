using CTN4_Data.Models.DB_CTN4;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CTN4_Data.Configurations
{
    public class KhuyenMaiPhanLoaiConfiguration : IEntityTypeConfiguration<KhuyenMaiPhanLoai>
    {
        public void Configure(EntityTypeBuilder<KhuyenMaiPhanLoai> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.KhuyenMai).WithMany(c => c.KKhuyenMaiPhanLoais).HasForeignKey(c => c.idKhuyenMai);
            builder.HasOne(c => c.PhanLoai).WithMany(c => c.KKhuyenMaiPhanLoais).HasForeignKey(c => c.IdPhanLoai);
        }
    }
}
