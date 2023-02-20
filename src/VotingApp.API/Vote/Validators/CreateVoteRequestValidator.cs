namespace VotingApp.API.Vote.Validators;

using FluentValidation;
using VotingApp.API.Vote.Requests;

internal class CreateVoteRequestValidator : AbstractValidator<CreateVoteRequest>
{
    public CreateVoteRequestValidator()
    {
        RuleFor(x => x.CandidateId)
            .NotEmpty();

        RuleFor(x => x.VoterId)
            .NotEmpty();
    }
}