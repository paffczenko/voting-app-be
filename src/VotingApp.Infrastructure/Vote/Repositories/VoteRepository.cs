namespace VotingApp.Infrastructure.Vote.Repositories;

using MongoDB.Driver;
using VotingApp.Domain.Candidate.Models;
using VotingApp.Domain.Vote.Models;
using VotingApp.Domain.Vote.Repositories;
using VotingApp.Domain.Voter.Models;
using VotingApp.Infrastructure.Shared.Factories;
using VotingApp.Infrastructure.Shared.Managers;

public class VoteRepository : IVoteRepository
{
    private readonly IMongoCollection<Vote> _votesCollection;
    private readonly IMongoCollection<Candidate> _candidatesCollection;
    private readonly IMongoCollection<Voter> _voterCollection;
    private readonly MongoTransactionManager _mongoTransactionManager;


    public VoteRepository(MongoCollectionFactory mongoFactory, 
        MongoTransactionManager mongoTransactionManager)
    {
        _candidatesCollection = mongoFactory.GetCollection<Candidate>();
        _voterCollection = mongoFactory.GetCollection<Voter>();
        _votesCollection = mongoFactory.GetCollection<Vote>();
        _mongoTransactionManager = mongoTransactionManager;
    }

    public Task Insert(Vote vote) => _mongoTransactionManager.ExecuteAsTransaction(async () =>
    {
        await _votesCollection.InsertOneAsync(vote);
        await _candidatesCollection.UpdateOneAsync(x => x.Id == vote.CandidateId,
            Builders<Candidate>.Update.Inc(x => x.VotesCount, 1));
        await _voterCollection.UpdateOneAsync(x => x.Id == vote.VoterId,
            Builders<Voter>.Update.Set(x => x.HasVoted, true));
    });
}