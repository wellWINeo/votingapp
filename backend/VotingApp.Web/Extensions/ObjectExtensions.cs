namespace VotingApp.Web.Extensions;

public static class ObjectExtensions
{
    public static T OrThrow<T>(this T? value, Exception exception)
        => value ?? throw exception;
}