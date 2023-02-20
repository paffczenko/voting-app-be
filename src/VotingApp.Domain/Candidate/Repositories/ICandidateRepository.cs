namespace VotingApp.Domain.Candidate.Repositories;

using VotingApp.Domain.Candidate.Models;

public interface ICandidateRepository
{
    Task<bool> Exists(Guid id);

    Task<List<Candidate>> GetAll();

    Task Insert(Candidate candidate);
}