using Domain.Entities.City;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class CityBuildingConfiguration : IEntityTypeConfiguration<CityBuilding>
    {
        public void Configure(EntityTypeBuilder<CityBuilding> builder)
        {
            builder.HasKey(b => new { b.UserCityMapId, b.BuildingId, b.Id });

            builder.HasOne(c => c.Building)
                    .WithMany()
                    .HasForeignKey(c => c.BuildingId);
        }
    }
}