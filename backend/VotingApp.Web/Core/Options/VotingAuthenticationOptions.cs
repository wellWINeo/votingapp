namespace VotingApp.Web.Core.Configuration;

public class VotingAuthenticationOptions
{
    public static string Section => "Authentication";
    
    public string Authority { get; set; } = default!;
    public string Audience { get; set; } = default!;
    public bool RequireSsl { get; set; } = default!;
    public string RoleClaimType { get; set; } = default!;
    public string NameClaimType { get; set; } = default!;
    public string EmailClaimType { get; set; } = default!;
}