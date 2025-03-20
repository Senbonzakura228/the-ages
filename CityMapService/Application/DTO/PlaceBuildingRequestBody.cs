namespace Application.DTO
{
    public record PlaceBuildingRequestBody
    {
        public int buildingId { get; set; }

        public int xCoordinate { get; set; }

        public int yCoordinate { get; set; }
    }
}