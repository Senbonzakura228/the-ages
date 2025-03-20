namespace Infrastructure.DAO
{
    public class CityBuilding
    {
        public int id { get; set; }

        public int xCoordinate { get; set; }

        public int yCoordinate { get; set; }

        public Building building { get; set; }
    }
}