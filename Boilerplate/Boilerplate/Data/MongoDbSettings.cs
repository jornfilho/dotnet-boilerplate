namespace Boilerplate.Data
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string Database { get; set; }
        public string ConnectionStrings { get; set; }
    }
    
    public interface IMongoDbSettings
    {
        string Database { get; set; }
        string ConnectionStrings { get; set; }
    }
}