using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using VotingApp.Web.Core.Configuration;
using VotingApp.Web.Core.Exceptions;

namespace VotingApp.Web.Extensions;

public static class AddVotingAuthorization
{
    public static AuthenticationBuilder AddVotingAuthentication(
        this IServiceCollection services,
        VotingAuthenticationOptions options,
        string hubPrefix)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidAudiences = new [] { options.Audience },
            NameClaimType = options.NameClaimType,
            RoleClaimType = options.RoleClaimType,
        };
        
        return services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(o =>
            {
                o.Authority = options.Authority;
                o.Audience = options.Audience;
                o.TokenValidationParameters = tokenValidationParameters;
                o.RequireHttpsMetadata = options.RequireSsl;
                o.SaveToken = true;

                o.Events = new JwtBearerEvents()
                {
                    OnMessageReceived = context =>
                    {
                        var token = context.Request.Query["access_token"];
                        var path = context.HttpContext.Request.Path;

                        if (!string.IsNullOrEmpty(token) 
                            && path.StartsWithSegments(hubPrefix))
                        {
                            context.Token = token;
                        }

                        return Task.CompletedTask;
                    }
                };
            });
    }

    public static AuthenticationBuilder AddVotingAuthentication(
        this IServiceCollection services,
        IConfiguration configuration,
        string hubPrefix)
    {
        var options = configuration
            .GetSection(VotingAuthenticationOptions.Section)
            .Get<VotingAuthenticationOptions>()
            .OrThrow(new ConfigurationException(
                $"Can't read {VotingAuthenticationOptions.Section} section")
            );

        return services.AddVotingAuthentication(options, hubPrefix);
    }
}