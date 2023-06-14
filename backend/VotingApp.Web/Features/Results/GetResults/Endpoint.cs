using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using VotingApp.Web.Infrastructure;
using VotingApp.Web.Models.Entities;

namespace VotingApp.Web.Features.Results.GetResults;

public class Endpoint : EndpointWithoutRequest<IEnumerable<ResultsStatistic>>
{
    private readonly VotingAppContext _context;

    public Endpoint(VotingAppContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
#if !ALLOW_ANONYMOUS
        AllowAnonymous();
#endif
        Get("/get-results/{FormId}");
        Group<ResultsGroup>();
        Summary(es =>
        {
            es.Summary = "Retrieve results by voting form";
        });
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var formId = Route<VoteFormId>("FormId");

        var accessMode = await GetAccessMode(formId, ct);
        var response = await GetStatisticsQuery(formId, accessMode)
            .ToListAsync(ct);

        await SendOkAsync(response, ct);
    }
    
    private async Task<VoteResultsAccess> GetAccessMode(VoteFormId formId, CancellationToken ct)
    {
        var form = await _context.Set<VoteForm>()
            .FirstAsync(f => f.Id == formId, ct);

        return form.Access;
    }

    private IQueryable<ResultsStatistic> GetStatisticsQuery(VoteFormId formId, VoteResultsAccess accessMode)
    {
        var results = GetQuestionResultsQuery(formId);
        
        var response = results
            .GroupBy(qr => qr.QuestionId)
            .Select(group => new ResultsStatistic
            {
                QuestionId = group.First().QuestionId,
                QuestionText = group.First().Question.Text,
                Statistics = group
                    .SelectMany(qr => qr.Values)
                    .GroupBy(v => v.Id)
                    .Select(vg => new ResultsQuestionAnswerStatistic
                    {
                        DisplayText = vg.First().Value,
                        Count = vg.Count(),
                    }),
                Answers = accessMode != VoteResultsAccess.OnlyStatistic
                    ? group.Select(qr => new ResultsQuestionAnswer
                    {
                        Login = accessMode != VoteResultsAccess.Anonymous
                            ? qr.Result.CreatedBy
                            : null,
                        Values = qr.Values
                            .Select(v => v.Value), 
                    })
                    : null,
            });

        return response;
    }
    
    private IQueryable<VoteQuestionResult> GetQuestionResultsQuery(VoteFormId formId)
    {
        var query = _context.Set<VoteQuestionResult>()
            .Include(qr => qr.Values)
            .Include(qr => qr.Question)
            .Include(qr => qr.Result)
            .Where(qr => qr.Result.FormId == formId);

        return query;
    }
}