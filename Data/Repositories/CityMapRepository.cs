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
                Id = map.Id,
                Extensions = map.Extensions.Select(e =>
                new Extension
                {
                    XCoordinate = e.CityExtension.XCoordinate,
                    YCoordinate = e.CityExtension.YCoordinate,
                    width = e.CityExtension.width,
                    height = e.CityExtension.height
                }).ToList(),
                Buildings = map.Buildings.Select(b =>
                new DAO.CityBuilding
                {
                    Id = b.Id,
                    XCoordinate = b.XCoordinate,
                    YCoordinate = b.YCoordinate,
                    building = new Building
                    {
                        Name = b.Building.Name,
                        width = b.Building.width,
                        height = b.Building.height
                    }
                }
                ).ToHashSet()
            };
        }
    }
}