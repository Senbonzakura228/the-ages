using Domain.Entities.City;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class UserCityMapConfiguration : IEntityTypeConfiguration<UserCityMap>
    {
        public void Configure(EntityTypeBuilder<UserCityMap> builder)
        {
            builder.HasMany(c => c.Extensions)
                    .WithOne(e => e.UserCityMap)
                    .HasForeignKey(e => e.CityMapId);

            builder.HasMany(c => c.Buildings)
                    .WithOne(b => b.UserCityMap)
                    .HasForeignKey(b => b.UserCityMapId);
        }
    }
}