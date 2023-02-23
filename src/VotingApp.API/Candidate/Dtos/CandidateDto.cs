namespace VotingApp.Application.Candidate.Dtos;

using System.ComponentModel.DataAnnotations;

public record CandidateDto([property: Required] Guid Id, 
    [property: Required] string Name, 
    [property: Required] int VotesCount);