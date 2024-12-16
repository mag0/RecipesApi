using MongoDB.Driver;

namespace RecipeApi.Data;

public class MongoDbService
{
    private readonly IConfiguration _configuration;
    private readonly IMongoDatabase? _database;
 
    public MongoDbService(IConfiguration configuration)
    {
        _configuration = configuration;

        var connectingString = _configuration.GetConnectionString("DbConnection");
        var mongoUrl = MongoUrl.Create(connectingString);
        var mongoClient = new MongoClient(mongoUrl);
        _database = mongoClient.GetDatabase(mongoUrl.DatabaseName ?? "RecipesDB");
    }

    public IMongoDatabase? Database => _database;
}
