using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using VotingApp.Web.Infrastructure;
using VotingApp.Web.Models.Entities;

namespace VotingApp.Web.Features.Comments.GetComments;

public class Handler : ICommandHandler<GetCommentsCommand, IEnumerable<CommentDto>>
{
    private readonly VotingAppContext _context;

    public Handler(VotingAppContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CommentDto>> ExecuteAsync(
        GetCommentsCommand command, 
        CancellationToken ct = new())
    {
        var comments = await _context.Set<VoteFormComment>()
            .Where(c => c.FormId == command.FormId)
            .Select(c => new CommentDto
            {
                Id = c.Id,
                Comment = c.Comment,
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy,
                FormId = c.FormId,
            }).ToArrayAsync(ct) ?? Array.Empty<CommentDto>();

        return comments;
    }
}