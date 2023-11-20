namespace WebApplication1.Models.HealthAssess
{
    public interface IHealthSettings
    {
        string MongoDbCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
