namespace Odyssey.MusicMatcher.Models;

[GraphQLDescription("A curated collection of tracks designed for a specific activity or mood.")]
public record Playlist
{
    [GraphQLDescription("The ID for the playlist.")]
    [ID]
    public required string Id { get; init; }
    
    [GraphQLDescription("The name of the playlist.")]
    public required string Name { get; init; }
    
    [GraphQLDescription("Describes the playlist, what to expect and entices the user to listen.")]
    public required string Description { get; init; }
    // public List<Track> Tracks { get; init; } = new();
}

public record Track
{
}