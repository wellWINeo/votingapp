using EnumsNET;
using VotingApp.Web.Models.Entities;

namespace VotingApp.Web.Extensions;

public static class VoteResultsAccessExtension
{
    public static string GetDescription(this VoteResultsAccess access)
        => access.AsString(EnumFormat.Description) ?? string.Empty;
}