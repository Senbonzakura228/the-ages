using System.Data.Common;
using Data.Entities.Building;
using Data.Presets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
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
                  width = b.width,
                  height = b.height
              }));
        }
    }
}