namespace OpenRP.GameMode.Configuration
{
    public class Config
    {
        public string ConnectionString { get; set; }

        public Config()
        {
            ConnectionString = "server=localhost;user=root;password=;database=openrp";
        }
    }
}
