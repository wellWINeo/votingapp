using FastEndpoints;
using FluentValidation;

namespace VotingApp.Web.Features.Forms.Create;

public class CreateVoteFormValidator : Validator<CreateVoteFormRequest>
{
    public CreateVoteFormValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title cannot be null or empty");

        RuleFor(x => x.Questions)
            .Must(x => x.Count >= 1)
            .WithMessage("At least 1 question must be provided");

        RuleForEach(x => x.Questions)
            .Must(x => !string.IsNullOrWhiteSpace(x.Text))
            .WithMessage("`Text` property cannot be null or empty")
            .Must(x => x.Options.Count >= 2)
            .WithMessage("At least 2 options must be provided for question");
    }
}