using Data.DAO;
using Data.Repositories;

namespace Application.Services
{
    public class CityMapService
    {
        private CityMapRepository cityMapRepository;
        public CityMapService(CityMapRepository cityMapRepository)
        {
            this.cityMapRepository = cityMapRepository;
        }
        public async Task<CityMap?> GetCityMap(int userId)
        {
            var cityMap = await cityMapRepository.GetCityMap(userId);
            return cityMap != null ? cityMap : null;
        }
    }
}