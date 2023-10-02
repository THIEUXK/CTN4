using CTN4_Data.Models.DB_CTN4;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTN4_Data.Models.Configurations
{
    public class AnhConfiguration : IEntityTypeConfiguration<Anh>
    {
        public void Configure(EntityTypeBuilder<Anh> builder)
        {
            builder.HasKey(c => c.Id);
        }
    }
}
