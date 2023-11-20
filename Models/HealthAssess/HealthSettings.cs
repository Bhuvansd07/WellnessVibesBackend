namespace WebApplication1.Models.HealthAssess
{
    public class HealthSettings : IHealthSettings
    {
        public string MongoDbCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
