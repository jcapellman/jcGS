namespace jcGS.REST.Objects
{
    public class DbConfig
    {
        public string URL { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
        
        public DbConfig()
        {
            URL = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
        }
    }
}