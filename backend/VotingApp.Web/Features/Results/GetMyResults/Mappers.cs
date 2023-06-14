using FastEndpoints;
using VotingApp.Web.Core;
using VotingApp.Web.Models.Entities;

namespace VotingApp.Web.Features.Results.GetMyResults;

public sealed class VoteResultResponseMapper
    : ResponseMapper<VoteResultResponse, VoteResult>
{
    public override VoteResultResponse FromEntity(VoteResult e)
    {
        var questionsMapper = new MultipleQuestionResponseMapper();
        
        return new VoteResultResponse()
        {
            FormId = e.Form.Id,
            Title = e.Form.Title,
            CreatedAt = e.CreatedAt,
            Questions = questionsMapper.FromEntity(e.QuestionResults),
        };
    }
}

public sealed class MultipleVoteResultsResponseMapper : MultipleResponseMapper<
    VoteResultResponse,
    VoteResult,
    VoteResultResponseMapper
> { }

file sealed class VoteQuestionResponseMapper
    : ResponseMapper<VoteQuestionResponse, VoteQuestionResult>
{
    public override VoteQuestionResponse FromEntity(VoteQuestionResult e)
    {
        return new VoteQuestionResponse()
        {
            QuestionText = e.Question.Text,
            SelectedValues = e.Values.Select(v => v.Value)
        };
    }
}

file sealed class MultipleQuestionResponseMapper
    : MultipleResponseMapper<
        VoteQuestionResponse,
        VoteQuestionResult,
        VoteQuestionResponseMapper
    > { }