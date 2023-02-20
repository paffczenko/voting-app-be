namespace VotingApp.API.Voter.Validators;

using FluentValidation;
using VotingApp.API.Voter.Requests;

public class CreateVoterRequestValidator : AbstractValidator<CreateVoterRequest>
{
    public CreateVoterRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
    }
}