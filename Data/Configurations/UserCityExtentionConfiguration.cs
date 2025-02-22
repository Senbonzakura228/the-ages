using Data.Entities.City;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class UserCityExtentionConfiguration : IEntityTypeConfiguration<UserCityExtension>
    {

        public void Configure(EntityTypeBuilder<UserCityExtension> builder)
        {
            builder.HasKey(e => new { e.CityMapId, e.CityExtensionId });

            builder.HasOne(e => e.CityExtension)
                    .WithMany()
                    .HasForeignKey(e => e.CityExtensionId);
        }
    }
}