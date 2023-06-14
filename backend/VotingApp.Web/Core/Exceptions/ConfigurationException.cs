namespace VotingApp.Web.Core.Exceptions;

public class ConfigurationException : Exception
{
    public ConfigurationException(string message)
        : base($"Error occurred while processing configurations. Details: {message}") { }
}