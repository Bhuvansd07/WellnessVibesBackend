﻿namespace WebApplication1.Models.Reviews
{
    public class FeedbackSettings : IFeedbackSettings
    {
        public string MongoDbCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
