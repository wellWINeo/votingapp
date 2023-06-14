using FastEndpoints;
using VotingApp.Web.Core;
using VotingApp.Web.Extensions;
using VotingApp.Web.Models.Entities;

namespace VotingApp.Web.Features.AccessModes.Get;

public class AccessModeMapper : ResponseMapper<AccessMode, VoteResultsAccess>
{
    public override AccessMode FromEntity(VoteResultsAccess e)
    {
        var mode = new AccessMode
        {
            Description = e.GetDescription(),
            Value = (int)e,
        };

        return mode;
    }
}

public class MultipleAccessModeMapper
    : MultipleResponseMapper<
        AccessMode,
        VoteResultsAccess,
        AccessModeMapper
    > { }