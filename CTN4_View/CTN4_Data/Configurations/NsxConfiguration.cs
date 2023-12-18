using CTN4_Data.Models.DB_CTN4;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTN4_Data.Configurations
{
    public class NSXConfiguration : IEntityTypeConfiguration<NSX>
    {
        public void Configure(EntityTypeBuilder<NSX> builder)
        {
            builder.HasKey(c => c.Id);
        }
    }
}
