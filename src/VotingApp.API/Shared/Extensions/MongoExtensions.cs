namespace VotingApp.API.Shared.Extensions;

using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using MongoDB.Driver;
using VotingApp.Infrastructure.Shared.Factories;
using VotingApp.Infrastructure.Shared.Managers;
using VotingApp.Infrastructure.Shared.Options;

internal static class MongoExtensions
{
    internal static IServiceCollection AddMongo(this IServiceCollection services, MongoOptions options)
    {
        var mongoClient = new MongoClient(GetConnectionString(options));

        var mongoRepositoryFactory = new MongoCollectionFactory(mongoClient, options.Database);
        var mongoTransactionManager = new MongoTransactionManager(mongoClient);

        BsonSerializer.RegisterSerializer(typeof(Guid), new GuidSerializer(BsonType.String));

        services
            .AddSingleton(mongoRepositoryFactory)
            .AddSingleton(mongoTransactionManager);

        return services;
    }


    private static string GetConnectionString(MongoOptions options)
        => $"mongodb+srv://{options.Username}:{options.Password}@{options.Url}/{options.Database}";
}