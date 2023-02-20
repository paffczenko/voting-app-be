namespace VotingApp.Domain.Voter.Repositories;

using VotingApp.Domain.Voter.Models;

public interface IVoterRepository
{
    Task<Voter?> GetById(Guid id);

    Task<List<Voter>> GetAll();

    Task Insert(Voter voter);
}