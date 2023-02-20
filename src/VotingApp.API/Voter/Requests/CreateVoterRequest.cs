namespace VotingApp.API.Voter.Requests;

using System.ComponentModel.DataAnnotations;

public record CreateVoterRequest([property: Required] string Name);