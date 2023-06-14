using System.Security.Claims;

namespace VotingApp.Web.Extensions;

public static class UserExtensions
{
    private static string USERNAME_CLAIM_TYPE = "preferred_username";
    private static string EMAIL_CLAIM_TYPE = "email";
    private static string GIVEN_NAME_CLAIM_TYPE = "given_name";
    private static string FAMILY_NAME_CLAIM_TYPE = "family_name";

    public static string? GetUserName(this ClaimsPrincipal claims)
#if !ALLOW_ANONYMOUS
        => claims.Claims
            .FirstOrDefault(c => c.Type == USERNAME_CLAIM_TYPE)
            ?.Value;
#else
        => "test";
#endif

    public static string? GetEmail(this ClaimsPrincipal claims)
#if !ALLOW_ANONYMOUS
        => claims.Claims
            .FirstOrDefault(c => c.Type == EMAIL_CLAIM_TYPE)
            ?.Value;
#else
        => "test@example.com";
#endif

    public static string? GetFullName(this ClaimsPrincipal claims)
#if !ALLOW_ANONYMOUS
    {
        var claimValues = claims.Claims
            .Where(c => c.Type == GIVEN_NAME_CLAIM_TYPE
                        || c.Type == FAMILY_NAME_CLAIM_TYPE)
            .OrderBy(c => c.Type)
            .Select(c => c.Value);

        return string.Join(" ", claimValues);
    }
#else
        => "John Doe";
#endif
}