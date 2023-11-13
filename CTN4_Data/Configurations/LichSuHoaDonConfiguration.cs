using CTN4_Data.Models;
using CTN4_Data.Models.DB_CTN4;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Data.Configurations
{
    public class LichSuHoaDonConfiguration
    {
        public void Configure(EntityTypeBuilder<LichSuHoaDon> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.HoaDon).WithMany(c => c.LichSuHoaDons).HasForeignKey(c => c.IdHoaDon);
           
        }
    }
}
