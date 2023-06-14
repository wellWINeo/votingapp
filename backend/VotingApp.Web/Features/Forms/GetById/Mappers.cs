using FastEndpoints;
using VotingApp.Web.Core;
using VotingApp.Web.Models.Entities;

namespace VotingApp.Web.Features.Forms.GetById;

public sealed class VoteFormWithResultsResponseMapper
    : ResponseMapper<VoteFormWithResultResponse, VoteForm>
{
    public override VoteFormWithResultResponse FromEntity(VoteForm e)
    {
        var result = e.Results.SingleOrDefault();

        return new VoteFormWithResultResponse
        {
            FormId = e.Id,
            Title = e.Title,
            Description = e.Description,
            CreatedAt = e.CreatedAt,
            CreatedBy = e.CreatedBy,
            IsCompleted = e.IsCompleted,
            Questions = result is null
                ? new MultipleVoteQuestionWithoutResultMapper()
                    .FromEntity(e.Questions)
                : new VoteQuestionWithResultResponseMapper()
                    .FromEntity(result),
        };
    }
}

sealed class VoteQuestionWithResultResponseMapper
    : ResponseMapper<
        IEnumerable<VoteQuestionWithResultResponse>,
        VoteResult
    >
{
    public override IEnumerable<VoteQuestionWithResultResponse> FromEntity(VoteResult e)
    {
        var valuesMapper = new MultipleVoteValueMapper();
        
        foreach (var qr in e.QuestionResults)
        {
            yield return new VoteQuestionWithResultResponse()
            {
                QuestionId = qr.QuestionId,
                Text = qr.Question.Text,
                IsMultipleAllowed = qr.Question.IsMultipleAllowed,
                IsCustomAllowed = qr.Question.IsCustomAllowed,
                Options = valuesMapper.FromEntity(qr.Question.Options),
                SelectedOptions = valuesMapper.FromEntity(qr.Values),
            };
        }
    }
}

sealed class VoteQuestionWithoutResultMapper
    : ResponseMapper<
        VoteQuestionWithResultResponse,
        VoteQuestion
    >
{
    public override VoteQuestionWithResultResponse FromEntity(VoteQuestion e)
    {
        var valuesMapper = new MultipleVoteValueMapper();

        return new VoteQuestionWithResultResponse()
        {
            QuestionId = e.Id,
            Text = e.Text,
            IsMultipleAllowed = e.IsMultipleAllowed,
            IsCustomAllowed = e.IsCustomAllowed,
            Options = valuesMapper.FromEntity(e.Options),
            SelectedOptions = Enumerable.Empty<VoteValueResponse>()
        };
    }
}

sealed class MultipleVoteQuestionWithoutResultMapper
    : MultipleResponseMapper<
        VoteQuestionWithResultResponse,
        VoteQuestion,
        VoteQuestionWithoutResultMapper
    > { }