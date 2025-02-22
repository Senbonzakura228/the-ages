using Data.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class UserAcoountConfiguration : IEntityTypeConfiguration<UserAccount>
    {
        public void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            builder
            .HasOne(user => user.GameData)
            .WithOne(gameData => gameData.UserAccount)
            .HasForeignKey<UserGameData>(gameData => gameData.Id);
        }
    }
}