using FastEndpoints.Swagger;
using Keycloak.AuthServices.Authentication;
using VotingApp.Web.Core.Configuration;
using VotingApp.Web.Extensions;
using VotingApp.Web.Features.Comments;

var builder = WebApplication.CreateBuilder(args);

/*
var keycloakOptions = builder.Configuration
    .GetSection("Keycloak")
    .Get<KeycloakAuthenticationOptions>()
    .OrThrow(new Exception("Cannot read Keycloak options"));
*/

builder.Configuration.AddEnvironmentVariables(prefix: "VotingApp__");
builder.Services.AddVotingAuthentication(builder.Configuration, "/ws");

builder.Services
    .AddDatabase(VotingDatabaseOptions
        .Create(builder.Configuration)
        .GetConnectionString())
#if !ALLOW_ANONYMOUS
    //.AddKeycloak(keycloakOptions)
#endif
    .AddVotingAppFastEndpoints()
    .AddVotingAppSwagger()
    .AddCors()
    ;

builder.Services.AddSignalR();

var app = builder.Build();

#if !ALLOW_ANONYMOUS
app
    .UseAuthentication()
    .UseAuthorization();
#endif

app.UseCors(cors =>
{
    cors
        .AllowAnyHeader()
        .AllowCredentials()
        .WithOrigins("http://localhost:5003");
});

app
    .UseVotingAppFastEndpoints()
    .UseSwaggerGen();

app.MapHub<CommentsHub>("/ws/comments");

await app.RunAsync();