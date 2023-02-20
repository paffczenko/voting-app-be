namespace VotingApp.API.Candidate;

using FluentValidation;
using VotingApp.API.Candidate.Requests;
using VotingApp.Application.Candidate.Dtos;
using VotingApp.Application.Shared.Dtos;
using VotingApp.Domain.Candidate.Models;
using VotingApp.Domain.Candidate.Repositories;

internal static class RouteGroup
{
    internal static RouteGroupBuilder MapCandidateApi(this RouteGroupBuilder group)
    {
        group.MapGet("/", async (ICandidateRepository candidateRepository) =>
        {
            var candidates = await candidateRepository.GetAll();

            return Results.Ok(candidates.Select(x => new CandidateDto(x.Id, x.Name, x.VotesCount)));
        });

        group.MapPost("/", async (CreateCandidateRequest request, IValidator<CreateCandidateRequest> validator, ICandidateRepository candidateRepository) =>
        {
            var validation = validator.Validate(request);
            if (!validation.IsValid) return Results.BadRequest();
            var candidate = new Candidate(Guid.NewGuid(), request.Name);

            await candidateRepository.Insert(candidate);

            return Results.Ok(new CreatedResultDto(candidate.Id));
        });

        return group;
    }
}