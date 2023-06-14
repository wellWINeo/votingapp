using FastEndpoints;
using VotingApp.Web.Core;
using VotingApp.Web.Models.Entities;

namespace VotingApp.Web.Features.Forms;

public sealed class VoteFormMapper : ResponseMapper<VoteFormResponse, VoteForm>
{
    public override VoteFormResponse FromEntity(VoteForm e)
    {
        var questionsMapper = new MultipleVoteQuestionMapper();

        return new VoteFormResponse
        {
            Id = e.Id,
            Title = e.Title,
            Description = e.Description,
            CreatedAt = e.CreatedAt,
            CreatedBy = e.CreatedBy,
            IsCompleted = e.IsCompleted,
            Questions = questionsMapper.FromEntity(e.Questions),
        };
    }
}

public sealed class MultipleVoteFormsMapper 
    : MultipleResponseMapper<
        VoteFormResponse, 
        VoteForm,
        VoteFormMapper
    >  {  }