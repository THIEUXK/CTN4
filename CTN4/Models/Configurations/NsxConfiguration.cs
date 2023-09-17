using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTN4.Models.Configurations
{
    public class NSXConfiguration : IEntityTypeConfiguration<NSX>
    {
        public void Configure(EntityTypeBuilder<NSX> builder)
        {
            builder.HasKey(c => c.Id);
        }
    }
}
