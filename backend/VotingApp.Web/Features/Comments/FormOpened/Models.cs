
using FastEndpoints;

namespace VotingApp.Web.Features.Comments.FormOpened;

public class FormOpenedEvent : IEvent
{
    public VoteFormId FormId { get; set; } = default!;
    public string ConnectionId { get; set; } = default!;
}