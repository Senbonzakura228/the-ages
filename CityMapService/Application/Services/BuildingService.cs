using Infrastructure.DAO;
using Infrastructure.Repositories;

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
            var buildingsInCollision = cityMap.buildings.Where(b =>
                ((b.yCoordinate + b.building.height - 1 >= buildingToPlace.yCoordinate + building.height - 1
                && b.yCoordinate <= buildingToPlace.yCoordinate + building.height - 1)
                || (Math.Abs(b.yCoordinate - buildingToPlace.yCoordinate) < building.height))
                &&
                ((b.xCoordinate + b.building.width - 1 >= buildingToPlace.xCoordinate + building.width - 1
                && b.xCoordinate <= buildingToPlace.xCoordinate + building.width - 1)
                || (Math.Abs(b.xCoordinate - buildingToPlace.xCoordinate) < building.width))
            );
            if (buildingsInCollision.Count() != 0) return false;

            HashSet<(int, int)> extensionCells = new HashSet<(int, int)>();

            foreach (var extension in cityMap.extensions)
            {
                for (int x = extension.XCoordinate; x < extension.XCoordinate + extension.width; x++)
                {
                    for (int y = extension.YCoordinate; y < extension.YCoordinate + extension.height; y++)
                    {
                        extensionCells.Add((x, y));
                    }
                }
            }

            for (int x = buildingToPlace.xCoordinate; x < buildingToPlace.xCoordinate + building.width; x++)
            {
                for (int y = buildingToPlace.yCoordinate; y < buildingToPlace.yCoordinate + building.height; y++)
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