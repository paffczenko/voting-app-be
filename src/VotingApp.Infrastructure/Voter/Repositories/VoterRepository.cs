namespace VotingApp.Infrastructure.Voter.Repositories;

using MongoDB.Driver;
using VotingApp.Domain.Voter.Models;
using VotingApp.Domain.Voter.Repositories;
using VotingApp.Infrastructure.Shared.Factories;

public class VoterRepository : IVoterRepository
{
    private readonly IMongoCollection<Voter> _voterCollection;


    public VoterRepository(MongoCollectionFactory factory)
    {
        _voterCollection = factory.GetCollection<Voter>();
    }

    public async Task<Voter?> GetById(Guid id)
    {
        var voter = await _voterCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        return voter;
    }

    public Task<List<Voter>> GetAll() => _voterCollection.Find(x => true).ToListAsync();

    public Task Insert(Voter voter) => _voterCollection.InsertOneAsync(voter);
}