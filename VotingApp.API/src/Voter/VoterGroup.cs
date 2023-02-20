namespace VotingApp.API.Voter;

using FluentValidation;
using VotingApp.API.Voter.Requests;
using VotingApp.Application.Shared.Dtos;
using VotingApp.Application.Voter.Dtos;
using VotingApp.Domain.Voter.Models;
using VotingApp.Domain.Voter.Repositories;

internal static class RouteGroup
{
    internal static RouteGroupBuilder MapVoterApi(this RouteGroupBuilder group)
    {
        group.MapGet("/", async (IVoterRepository voterRepository) =>
        {
            var voters = await voterRepository.GetAll();

            return Results.Ok(voters.Select(x => new VoterDto(x.Id, x.Name, x.HasVoted)));
        });
        group.MapPost("/",
            async (CreateVoterRequest request, IValidator<CreateVoterRequest> validator, IVoterRepository voterRepository) =>
            {
                var validationResult = validator.Validate(request);
                if (!validationResult.IsValid) return Results.BadRequest();
                var voter = new Voter(Guid.NewGuid(), request.Name, hasVoted: false);
                await voterRepository.Insert(voter);

                return Results.Ok(new CreatedResultDto(voter.Id));
            });

        return group;
    }
}