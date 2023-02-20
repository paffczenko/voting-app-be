namespace VotingApp.Domain.Voter.Models;

using VotingApp.Domain.Candidate.Repositories;
using VotingApp.Domain.Shared;
using VotingApp.Domain.Vote.Models;

public class Voter : IEntity<Guid>
{
    public Guid Id { get; init; }

    public string Name { get; init; }

    public bool HasVoted { get; private set; }


    public Voter(Guid id, string name, bool hasVoted)
    {
        Id = id;
        Name = name;
        HasVoted = hasVoted;
    }

    public async Task<Vote> VoteFor(Guid candidateId, ICandidateRepository candidateRepository)
    {
        var doesCandidateExist = await candidateRepository.Exists(candidateId);

        return !doesCandidateExist
            ? Vote.InvalidVote
            : new Vote(Guid.NewGuid(), candidateId, Id);
    }
}