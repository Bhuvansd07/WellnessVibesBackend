namespace WebApplication1.Models.DailyActivities
{
    public class Activities : IActivities
    {
        public string MongoDbCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
