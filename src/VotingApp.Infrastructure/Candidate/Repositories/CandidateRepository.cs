namespace VotingApp.Infrastructure.Candidate.Repositories;

using MongoDB.Driver;
using VotingApp.Domain.Candidate.Models;
using VotingApp.Domain.Candidate.Repositories;
using VotingApp.Infrastructure.Shared.Factories;

public class CandidateRepository : ICandidateRepository
{
    private readonly IMongoCollection<Candidate> _collection;


    public CandidateRepository(MongoCollectionFactory mongoFactory)
    {
        _collection = mongoFactory.GetCollection<Candidate>();
    }


    public Task<bool> Exists(Guid id) => _collection.Find(x => x.Id == id).AnyAsync();

    public Task<List<Candidate>> GetAll() => _collection.Find(x => true).ToListAsync();

    public Task Insert(Candidate candidate) => _collection.InsertOneAsync(candidate);
}