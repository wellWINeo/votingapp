using FastEndpoints;
using VotingApp.Web.Core;
using VotingApp.Web.Models.Entities;

namespace VotingApp.Web.Features.Forms.Create;

public class CreateVoteFormRequestMapper : RequestMapper<CreateVoteFormRequest, VoteForm>
{
    public override VoteForm ToEntity(CreateVoteFormRequest r)
    {
        return new VoteForm()
        {
            Title = r.Title,
            Description = r.Description ?? string.Empty,
            CreatedAt = DateTime.UtcNow,
            Access = r.Access,
            Questions = new MultipleCreateVoteFormRequestQuestionMapper()
                .ToEntity(r.Questions)
                .ToList(),
        };
    }
}

public class CreateVoteFormRequestQuestionMapper : RequestMapper<CreateVoteFormRequestQuestion, VoteQuestion>
{
    public override VoteQuestion ToEntity(CreateVoteFormRequestQuestion r)
    {
        return new VoteQuestion
        {
            Text = r.Text,
            IsMultipleAllowed = r.IsMultipleAllowed,
            IsCustomAllowed = r.IsCustomAllowed,
            Options = r.Options.Select(o => new VoteValue()
            {
                Value = o,
            }).ToList(),
        };
    }
}

public class MultipleCreateVoteFormRequestQuestionMapper
    : MultipleRequestMapper<
        CreateVoteFormRequestQuestion, 
        VoteQuestion, 
        CreateVoteFormRequestQuestionMapper
    > { }