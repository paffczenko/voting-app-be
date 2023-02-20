namespace VotingApp.API.Candidate.Requests;

using System.ComponentModel.DataAnnotations;

public record CreateCandidateRequest([property: Required] string Name);