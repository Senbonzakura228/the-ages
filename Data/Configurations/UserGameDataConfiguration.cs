using Data.Entities.City;
using Data.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class UserGameDataConfiguration : IEntityTypeConfiguration<UserGameData>
    {
        public void Configure(EntityTypeBuilder<UserGameData> builder)
        {
            builder.HasOne(d => d.UserCityMap)
           .WithOne(c => c.UserGameData)
           .HasForeignKey<UserCityMap>(c => c.Id);
        }
    }
}