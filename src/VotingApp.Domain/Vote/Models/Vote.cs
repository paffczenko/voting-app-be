namespace VotingApp.Domain.Vote.Models;

using VotingApp.Domain.Shared;

public class Vote : IEntity<Guid>
{
    public Guid Id { get; init; }

    public Guid CandidateId { get; init; }

    public Guid VoterId { get; init; }


    private Vote() { }

    internal Vote(Guid id, Guid candidateId, Guid voterId)
    {
        Id = id;
        CandidateId = candidateId;
        VoterId = voterId;
    }

    internal static Vote InvalidVote = new()
    {
        Id = Guid.Empty
    };
}