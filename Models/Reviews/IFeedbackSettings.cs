namespace WebApplication1.Models.Reviews
{
    public interface IFeedbackSettings
    {
        string MongoDbCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
