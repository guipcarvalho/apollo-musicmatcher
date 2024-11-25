using Odyssey.MusicMatcher.GraphQL.Query;
using Odyssey.MusicMatcher.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<Playlist>()
    .AddType<Artist>();

builder
    .Services
    .AddCors(options =>
    {
        options.AddDefaultPolicy(builder =>
        {
            builder
                .WithOrigins("https://studio.apollographql.com")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    });

var app = builder.Build();

app.MapGraphQL();

app.UseGraphQLPlayground();

app.UseCors();

app.Run();
