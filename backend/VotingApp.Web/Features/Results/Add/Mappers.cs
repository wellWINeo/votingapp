using FastEndpoints;
using VotingApp.Web.Core;
using VotingApp.Web.Infrastructure;
using VotingApp.Web.Models.Entities;

namespace VotingApp.Web.Features.Results.Add;

public sealed class AddResultRequestMapper
    : RequestMapper<
        AddResultRequest, 
        VoteResult
    >
{
    public override VoteResult ToEntity(AddResultRequest r)
    {
        var questionMapper = new MultipleAddResultsQuestionRequestMapper();

        return new VoteResult()
        {
            CreatedAt = DateTime.UtcNow,
            FormId = r.FormId,
            QuestionResults = questionMapper
                .ToEntity(r.Questions)
                .ToList(),
        };
    }
}

file sealed class AddResultsQuestionRequestMapper
    : RequestMapper<AddResultQuestionRequest, VoteQuestionResult>
{
    public override VoteQuestionResult ToEntity(AddResultQuestionRequest r)
    {
        var context = Resolve<VotingAppContext>();
        
        return new VoteQuestionResult()
        {
            QuestionId = r.QuestionId,
            Values = context.Set<VoteValue>()
                .Where(v => r.Values.Contains(v.Id))
                .ToList(),
        };
    }
}

file sealed class MultipleAddResultsQuestionRequestMapper
    : MultipleRequestMapper<
        AddResultQuestionRequest,
        VoteQuestionResult,
        AddResultsQuestionRequestMapper
    > { }