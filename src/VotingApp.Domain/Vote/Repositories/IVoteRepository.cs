namespace VotingApp.Domain.Vote.Repositories;

using VotingApp.Domain.Vote.Models;

public interface IVoteRepository
{
    Task Insert(Vote vote);
}