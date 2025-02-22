using Data.DAO;
using Data.Repositories;

namespace Application.Services
{
    public class BuildingPlacementService
    {
        private readonly BuildingRepository buildingRepository;
        private readonly CityMapRepository cityMapRepository;
        public BuildingPlacementService(BuildingRepository buildingRepository, CityMapRepository cityMapRepository)
        {
            this.buildingRepository = buildingRepository;
            this.cityMapRepository = cityMapRepository;
        }
        public async Task<List<Building>?> GetBuildings()
        {
            var buildings = await buildingRepository.GetBuildings();
            return buildings;
        }

        public async Task<bool> PlaceBuilding(BuildingToPlace buildingToPlace)
        {
            var building = await buildingRepository.GetBuildingById(buildingToPlace.buildingId);
            var cityMap = await cityMapRepository.GetCityMap(buildingToPlace.userId);
            if (building == null || cityMap == null) return false;
            var canPlace = CheckPlaceAvailability(cityMap, building, buildingToPlace);
            if (!canPlace) return false;
            await buildingRepository.PlaceBuilding(buildingToPlace);
            return true;
        }

        public async Task<bool> DeleteBuilding(int userId, int buildingId)
        {
            var result = await buildingRepository.DeleteBuilding(userId, buildingId);
            return result;
        }

        private bool CheckPlaceAvailability(CityMap cityMap, Building building, BuildingToPlace buildingToPlace)
        {
            var buildingsInCollision = cityMap.Buildings.Where(b =>
                ((b.YCoordinate + b.building.height - 1 >= buildingToPlace.YCoordinate + building.height - 1
                && b.YCoordinate <= buildingToPlace.YCoordinate + building.height - 1)
                || (Math.Abs(b.YCoordinate - buildingToPlace.YCoordinate) < building.height))
                &&
                ((b.XCoordinate + b.building.width - 1 >= buildingToPlace.XCoordinate + building.width - 1
                && b.XCoordinate <= buildingToPlace.XCoordinate + building.width - 1)
                || (Math.Abs(b.XCoordinate - buildingToPlace.XCoordinate) < building.width))
            );
            if (buildingsInCollision.Count() != 0) return false;

            HashSet<(int, int)> extensionCells = new HashSet<(int, int)>();

            foreach (var extension in cityMap.Extensions)
            {
                for (int x = extension.XCoordinate; x < extension.XCoordinate + extension.width; x++)
                {
                    for (int y = extension.YCoordinate; y < extension.YCoordinate + extension.height; y++)
                    {
                        extensionCells.Add((x, y));
                    }
                }
            }

            for (int x = buildingToPlace.XCoordinate; x < buildingToPlace.XCoordinate + building.width; x++)
            {
                for (int y = buildingToPlace.YCoordinate; y < buildingToPlace.YCoordinate + building.height; y++)
                {
                    if (!extensionCells.Contains((x, y)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}