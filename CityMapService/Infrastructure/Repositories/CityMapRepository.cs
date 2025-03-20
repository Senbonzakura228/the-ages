using Infrastructure.DAO;
using Domain.Entities.City;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Presets;
using Microsoft.Extensions.Options;

namespace Infrastructure.Repositories
{
    public class CityMapRepository
    {
        private TheAgesDBContext dbContext;
        private BuildingOptions buildingOptions;
        private CityExtentionOptions extensionOptions;

        public CityMapRepository(TheAgesDBContext context,
         IOptions<BuildingOptions> buildingOptions,
         IOptions<CityExtentionOptions> extensionOptions)
        {
            dbContext = context;
            this.buildingOptions = buildingOptions.Value;
            this.extensionOptions = extensionOptions.Value;
        }

        public async Task<bool> Add(int userId)
        {
            var existedCityMap = dbContext.userCityMaps.AsNoTracking().FirstOrDefault(c => c.Id == userId);
            if (existedCityMap != null) return false;
            var userEntity = new UserCityMap
            {
                Id = userId,
                Extensions = extensionOptions.cityExtensions.Select(
                            e => new UserCityExtension
                            {
                                CityExtensionId = e.Id
                            }
                        ).ToHashSet(),
                Buildings = new HashSet<Domain.Entities.City.CityBuilding>()
            };

            await dbContext.AddAsync(userEntity);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<CityMap?> GetCityMap(int userId)
        {
            var map = await dbContext.userCityMaps.AsNoTracking()
            .Include(m => m.Extensions)
            .ThenInclude(e => e.CityExtension)
            .Include(m => m.Buildings)
            .ThenInclude(b => b.Building)
            .FirstOrDefaultAsync(m => m.Id == userId);

            if (map == null) return null;

            return new CityMap
            {
                id = map.Id,
                extensions = map.Extensions.Select(e =>
                new Extension
                {
                    XCoordinate = e.CityExtension.XCoordinate,
                    YCoordinate = e.CityExtension.YCoordinate,
                    width = e.CityExtension.Width,
                    height = e.CityExtension.Height
                }).ToList(),
                buildings = map.Buildings.Select(b =>
                new DAO.CityBuilding
                {
                    id = b.Id,
                    xCoordinate = b.XCoordinate,
                    yCoordinate = b.YCoordinate,
                    building = new Building
                    {
                        name = b.Building.Name,
                        width = b.Building.Width,
                        height = b.Building.Height
                    }
                }
                ).ToHashSet()
            };
        }
    }
}