using FastEndpoints;
using VotingApp.Web.Core;
using VotingApp.Web.Models.Entities;

namespace VotingApp.Web.Features.Forms;

public class VoteValueMapper
    : ResponseMapper<VoteValueResponse, VoteValue>
{
    public override VoteValueResponse FromEntity(VoteValue e)
    {
        return new VoteValueResponse
        {
            Id = e.Id,
            Value = e.Value,
        };
    }
}

public class MultipleVoteValueMapper
    : MultipleResponseMapper<
        VoteValueResponse,
        VoteValue,
        VoteValueMapper
    >
{  }