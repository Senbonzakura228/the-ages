namespace Data.DAO
{
    public record BuildingToPlace
    {
        public int userId { get; set; }

        public int buildingId { get; set; }

        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }
    }
}