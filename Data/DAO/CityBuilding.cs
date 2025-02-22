namespace Data.DAO
{
    public record CityBuilding
    {
        public int Id { get; set; }

        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }

        public Building building { get; set; }
    }
}