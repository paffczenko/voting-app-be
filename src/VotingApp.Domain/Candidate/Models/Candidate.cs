namespace VotingApp.Domain.Candidate.Models;

using VotingApp.Domain.Shared;

public class Candidate : IEntity<Guid>
{
    public Guid Id { get; init; }

    public string Name { get; init; }

    public int VotesCount { get; init; }


    public Candidate(Guid id, string name)
    {
        Id = id;
        Name = name;
        VotesCount = 0; 
    }
}