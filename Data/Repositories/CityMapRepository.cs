using Data.DAO;
using Data.Entities.City;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CityMapRepository
    {
        private TheAgesDBContext dbContext;
        public CityMapRepository(TheAgesDBContext context)
        {
            dbContext = context;
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