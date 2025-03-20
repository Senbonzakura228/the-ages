namespace Infrastructure.DAO
{
    public class CityMap
    {
        public int id { get; set; }
        public List<Extension> extensions { get; set; }

        public HashSet<CityBuilding> buildings { get; set; }
    }
}