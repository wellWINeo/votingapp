using FastEndpoints;
using VotingApp.Web.Core;
using VotingApp.Web.Models.Entities;

namespace VotingApp.Web.Features.Forms;

public sealed class VoteQuestionMapper : ResponseMapper<VoteQuestionResponse, VoteQuestion>
{
    public override VoteQuestionResponse FromEntity(VoteQuestion e)
    {
        var valuesMapper = new MultipleVoteValueMapper();

        return new VoteQuestionResponse
        {
            Id = e.Id,
            Text = e.Text,
            IsMultipleAllowed = e.IsMultipleAllowed,
            IsCustomAllowed = e.IsCustomAllowed,
            Options = valuesMapper
                .FromEntity(e.Options),
        };
    }
}

public sealed class MultipleVoteQuestionMapper
    : MultipleResponseMapper<
        VoteQuestionResponse,
        VoteQuestion,
        VoteQuestionMapper
    > { }