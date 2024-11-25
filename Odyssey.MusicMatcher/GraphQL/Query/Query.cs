using Odyssey.MusicMatcher.Models;

namespace Odyssey.MusicMatcher.GraphQL.Query;

public class Query
{
    [GraphQLDescription("Playlists hand-picked to be featured to all users.")]
    public List<Playlist> GetFeaturedPlaylists() => new()
    {
        new Playlist
        {
            Name = "Coding",
            Description = "Music to code to"
        },
        new Playlist
        {
            Name = "Running",
            Description = "Music to run to"
        },
        new Playlist
        {
            Name = "Chill",
            Description = "Music to chill to"
        }
    };
}