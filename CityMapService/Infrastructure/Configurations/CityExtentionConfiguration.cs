using Domain.Entities.City;
using Infrastructure.Presets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class CityExtentionConfiguration : IEntityTypeConfiguration<CityExtension>
    {
        private CityExtentionOptions cityExtentionOptions;

        public CityExtentionConfiguration(CityExtentionOptions options)
        {
            cityExtentionOptions = options;
        }

        public void Configure(EntityTypeBuilder<CityExtension> builder)
        {
            builder.HasData(cityExtentionOptions.cityExtensions.Select((e, index) =>
            new CityExtension
            {
                Id = index + 1,
                XCoordinate = e.XCoordinate,
                YCoordinate = e.YCoordinate,
                Width = e.Width,
                Height = e.Height
            }));
        }
    }
}