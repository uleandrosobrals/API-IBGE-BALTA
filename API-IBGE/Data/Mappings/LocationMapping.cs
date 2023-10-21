using API_IBGE.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace API_IBGE.Data.Mappings
{
    public class LocationMapping : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("IBGE");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.City).IsRequired();
            builder.Property(e => e.State).IsRequired();
        }
    }
}
