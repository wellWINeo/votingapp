# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:8.0-preview AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY VotingApp.Web/*.csproj VotingApp.Web/
RUN dotnet restore VotingApp.Web

# copy everything else and build app
COPY VotingApp.Web/. ./VotingApp.Web/
WORKDIR /source/VotingApp.Web
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview
WORKDIR /app
COPY --from=build /app ./
COPY ./entrypoint.sh .
ENTRYPOINT ["./entrypoint.sh"]