using Domain.Entities.Building;
using Infrastructure.Presets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class BuildingConfiguration : IEntityTypeConfiguration<Building>
    {
        private BuildingOptions buildingOptions;

        public BuildingConfiguration(BuildingOptions options)
        {
            buildingOptions = options;
        }
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.HasData(buildingOptions.buildings.Select((b, index) =>
              new Building
              {
                  Id = index + 1,
                  Name = b.Name,
                  Width = b.Width,
                  Height = b.Height
              }));
        }
    }
}