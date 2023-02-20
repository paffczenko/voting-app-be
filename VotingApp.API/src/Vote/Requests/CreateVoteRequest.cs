namespace VotingApp.API.Vote.Requests;

using System.ComponentModel.DataAnnotations;

public record CreateVoteRequest([property: Required] Guid VoterId, [property: Required] Guid CandidateId);