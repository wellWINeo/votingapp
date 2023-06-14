using FastEndpoints;

namespace VotingApp.Web.Features.AccessModes;

public sealed class AccessModesGroup : Group
{
    public AccessModesGroup()
    {
        Configure("access-modes", ep =>
        {
            ep.AllowAnonymous();
            ep.Summary(
                summary => summary.Summary = "Group to get access modes list"
            );
        });
    }
}