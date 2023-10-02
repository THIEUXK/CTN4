using CTN4_Data.Models.DB_CTN4;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CTN4_Data.Configurations
{
    public class PhanLoaiConfiguration : IEntityTypeConfiguration<PhanLoai>
    {
        public void Configure(EntityTypeBuilder<PhanLoai> builder)
        {
            builder.HasKey(c => c.Id);
        }
    }
}
