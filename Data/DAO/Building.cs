namespace Data.DAO
{
    public record Building
    {
        public int id;

        public string Name { get; set; }

        public int width { get; set; }

        public int height { get; set; }
    }
}