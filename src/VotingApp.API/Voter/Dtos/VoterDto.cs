namespace VotingApp.Application.Voter.Dtos;

using System.ComponentModel.DataAnnotations;

public record VoterDto([property: Required] Guid Id,
    [property: Required] string Name,
    [property: Required] bool HasVoted);