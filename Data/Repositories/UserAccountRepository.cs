using System.Runtime.ConstrainedExecution;
using Data.DAO;
using Data.Entities.City;
using Data.Entities.User;
using Data.Presets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Data.Repositories
{
    public class UserAccountRepository
    {
        private TheAgesDBContext dbContext;
        private BuildingOptions buildingOptions;
        private CityExtentionOptions extensionOptions;

        public UserAccountRepository(TheAgesDBContext context,
         IOptions<BuildingOptions> buildingOptions,
         IOptions<CityExtentionOptions> extensionOptions)
        {
            dbContext = context;
            this.buildingOptions = buildingOptions.Value;
            this.extensionOptions = extensionOptions.Value;
        }

        public async Task<User?> GetUserByName(string name)
        {
            var users = await dbContext.userAccounts.AsNoTracking().ToListAsync();
            var user = users.Where(user => user.UserName == name).FirstOrDefault();
            if (user == null) return null;
            return new User(user.UserName, user.PasswordHash, user.Id);
        }

        public async Task Add(User user)
        {
            var userEntity = new UserAccount()
            {
                UserName = user.name,
                PasswordHash = user.passwordHash,
                GameData = new UserGameData
                {
                    UserCityMap = new UserCityMap
                    {
                        Extensions = extensionOptions.cityExtensions.Select(
                            e => new UserCityExtension
                            {
                                CityExtensionId = e.Id
                            }
                        ).ToHashSet(),
                        Buildings = new HashSet<Entities.City.CityBuilding>()
                    }
                }
            };

            await dbContext.AddAsync(userEntity);
            await dbContext.SaveChangesAsync();
        }
    }
}