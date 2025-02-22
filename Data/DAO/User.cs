namespace Data.DAO
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string passwordHash { get; set; }

        public User(string name, string passwordHash, int id = 0)
        {
            this.id = id;
            this.name = name;
            this.passwordHash = passwordHash;
        }
    }
}