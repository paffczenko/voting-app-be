namespace VotingApp.API.Vote;

using VotingApp.API.Vote.Requests;
using VotingApp.Domain.Candidate.Repositories;
using VotingApp.Domain.Vote.Repositories;
using VotingApp.Domain.Voter.Repositories;

internal static class RouteGroup
{
    internal static RouteGroupBuilder MapVoteApi(this RouteGroupBuilder group)
    {
        group.MapPost("/",
            async (CreateVoteRequest request, IVoterRepository voterRepository,
                IVoteRepository voteRepository,
                ICandidateRepository candidateRepository) =>
            {
                var voter = await voterRepository.GetById(request.VoterId);
                if (voter == null) return Results.BadRequest();

                var vote = await voter.VoteFor(request.CandidateId, candidateRepository);
                if (vote.Id == Guid.Empty) return Results.BadRequest();

                await voteRepository.Insert(vote);

                return Results.Ok();
            });

        return group;
    }
}