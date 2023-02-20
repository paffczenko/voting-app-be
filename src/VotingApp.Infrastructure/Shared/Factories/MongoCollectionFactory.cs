using MongoDB.Driver;

namespace VotingApp.Infrastructure.Shared.Factories;

using VotingApp.Domain.Shared;

public class MongoCollectionFactory
{
    private readonly MongoClient _mongoClient;
    private readonly string _databaseName;

    public MongoCollectionFactory(MongoClient mongoClient, string databaseName)
    {
        _databaseName = databaseName;
        _mongoClient = mongoClient;
    }


    public IMongoCollection<TEntity> GetCollection<TEntity>() where TEntity : IEntity<Guid> => _mongoClient.GetDatabase(_databaseName).GetCollection<TEntity>(typeof(TEntity).Name);
}