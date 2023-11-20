namespace WebApplication1.Models.DailyActivities
{
    public interface IActivities
    {
        string MongoDbCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

    }
}
