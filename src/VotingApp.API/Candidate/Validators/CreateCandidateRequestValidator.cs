namespace VotingApp.API.Candidate.Validators;

using FluentValidation;
using VotingApp.API.Candidate.Requests;

public class CreateCandidateRequestValidator : AbstractValidator<CreateCandidateRequest>
{
    public CreateCandidateRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
    }
}