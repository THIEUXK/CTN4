using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTN4.Models.Configurations
{
    public class ErrorVielModelConfiguration : IEntityTypeConfiguration<ErrorViewModel>
    {
        public void Configure(EntityTypeBuilder<ErrorViewModel> builder)
        {
            builder.HasKey(c => c.RequestId);
        }
    }
}
