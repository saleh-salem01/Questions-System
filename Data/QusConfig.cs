using jocksWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jocksWebApp.Data
{
    public class QusConfig : IEntityTypeConfiguration<QAnswer>
    {
        public void Configure(EntityTypeBuilder<QAnswer> builder)
        {
            builder.Property(p=>p.Id).IsRequired();

        }
    }
}
