using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTN4.Models.Configurations
{
    public class MauConfiguration : IEntityTypeConfiguration<Mau>
    {
        public void Configure(EntityTypeBuilder<Mau> builder)
        {
            builder.HasKey(c => c.Id);
        }
    }
}
