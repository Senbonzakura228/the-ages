using Data.DAO;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class BuildingRepository
    {
        private TheAgesDBContext dbContext;
        public BuildingRepository(TheAgesDBContext context)
        {
            this.dbContext = context;
        }

        public async Task<List<Building>?> GetBuildings()
        {
            var dbBuildings = await dbContext.buildings.AsNoTracking().ToListAsync();
            var buildings = dbBuildings.Select(b => new Building
            {
                id = b.Id,
                name = b.Name,
                width = b.Width,
                height = b.Height
            }).ToList();

            return buildings.Any() ? buildings : null;
        }

        public async Task<Building?> GetBuildingById(int id)
        {
            var dbBuilding = await dbContext.buildings.AsNoTracking()
            .Where(b => b.Id == id)
            .FirstOrDefaultAsync();
            if (dbBuilding == null) return null;
            var building = new Building
            {
                id = dbBuilding.Id,
                name = dbBuilding.Name,
                width = dbBuilding.Width,
                height = dbBuilding.Height
            };
            return building;
        }

        public async Task<bool> PlaceBuilding(BuildingToPlace buildingToPlace)
        {
            var cityMap = await dbContext.userCityMaps
            .Include(m => m.Extensions).ThenInclude(e => e.CityExtension)
            .Include(m => m.Buildings).ThenInclude(b => b.Building)
            .FirstOrDefaultAsync(m => m.Id == buildingToPlace.userId);
            if (cityMap == null) return false;
            cityMap.Buildings.Add(new Entities.City.CityBuilding
            {
                Id = cityMap.Buildings.Count + 1,
                UserCityMapId = buildingToPlace.userId,
                BuildingId = buildingToPlace.buildingId,
                XCoordinate = buildingToPlace.xCoordinate,
                YCoordinate = buildingToPlace.yCoordinate
            });

            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PlaceBuildings(List<BuildingToPlace> buildingsToPlace)
        {
            var cityMap = await dbContext.userCityMaps
            .Include(m => m.Extensions).ThenInclude(e => e.CityExtension)
            .Include(m => m.Buildings).ThenInclude(b => b.Building)
            .FirstOrDefaultAsync(m => m.Id == buildingsToPlace.First().userId);
            if (cityMap == null) return false;
            buildingsToPlace.ForEach(b =>
            {
                cityMap.Buildings.Add(new Entities.City.CityBuilding
                {
                    Id = cityMap.Buildings.Count + 1,
                    UserCityMapId = b.userId,
                    BuildingId = b.buildingId,
                    XCoordinate = b.xCoordinate,
                    YCoordinate = b.yCoordinate
                });
            });

            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteBuilding(int userId, int buildingId)
        {
            var cityMap = await dbContext.userCityMaps
            .Include(c => c.Buildings)
            .FirstOrDefaultAsync(c => c.Id == userId);

            var buildingToRemove = cityMap.Buildings.FirstOrDefault(b => b.Id == buildingId);
            if (buildingToRemove == null) return false;
            cityMap.Buildings.Remove(buildingToRemove);
            await dbContext.SaveChangesAsync();
            return true;
        }

    }
}