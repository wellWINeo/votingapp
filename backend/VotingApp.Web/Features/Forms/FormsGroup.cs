using FastEndpoints;

namespace VotingApp.Web.Features.Forms;

public class FormsGroup : Group
{
    public FormsGroup()
    {
        Configure("forms", ep =>
        {
#if ALLOW_ANONYMOUS
            ep.AllowAnonymous();
#endif
            ep.Summary(
                summary => summary.Summary = "Group to interact with voting forms"
            );
        });
    }
}