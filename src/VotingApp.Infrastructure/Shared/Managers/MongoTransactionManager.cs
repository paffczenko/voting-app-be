namespace VotingApp.Infrastructure.Shared.Managers;

using MongoDB.Driver;

public class MongoTransactionManager
{
    private readonly IMongoClient _mongoClient;

    
    public MongoTransactionManager(IMongoClient mongoClient)
    {
        _mongoClient = mongoClient;
    }

    
    public async Task ExecuteAsTransaction(Func<Task> action)
    {
        using var session = await _mongoClient.StartSessionAsync();
        session.StartTransaction();

        try
        {
            await action.Invoke();
            await session.CommitTransactionAsync();
        }
        catch
        {
            await session.AbortTransactionAsync();
            throw;
        }
    }
}