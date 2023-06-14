using FastEndpoints;

namespace VotingApp.Web.Features.Results;

public class ResultsGroup : Group
{
    public ResultsGroup()
    {
        Configure("results", ep =>
        {
#if ALLOW_ANONYMOUS
            ep.AllowAnonymous();
#endif
            ep.Summary(es =>
            {
                es.Summary = "Interacting with voting results";
            });
        });
    }
}