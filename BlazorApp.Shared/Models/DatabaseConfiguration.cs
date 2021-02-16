namespace BlazorApp.Shared.Models
{
    public class DatabaseConfiguration : IDatabaseConfiguration
    {
        public string Database { get; set; }
        public string Server { get; set; }
    }
}