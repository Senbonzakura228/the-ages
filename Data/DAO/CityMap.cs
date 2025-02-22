namespace Data.DAO
{
    public record CityMap
    {
        public int Id { get; set; }
        public List<Extension> Extensions { get; set; }

        public HashSet<CityBuilding> Buildings { get; set; }
    }
}