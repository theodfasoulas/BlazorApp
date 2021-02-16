namespace BlazorApp.Shared.Models
{
    public interface IDatabaseConfiguration
    {
        string Database { get; set; }
        string Server { get; set; }
    }
}