using Odyssey.MusicMatcher.GraphQL.Query;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>();

var app = builder.Build();

app.MapGraphQL();

app.UseGraphQLPlayground();

app.Run();
