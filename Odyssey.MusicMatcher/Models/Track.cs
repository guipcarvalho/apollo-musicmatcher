namespace Odyssey.MusicMatcher.Models;


[GraphQLDescription("A single audio file, usually a song.")]
public record Track
{
    [ID]
    [GraphQLDescription("The ID for the track.")]
    public string Id { get; set; }

    [GraphQLDescription("The name of the track.")]
    public string Name { get; set; }

    [GraphQLDescription("The track length in milliseconds.")]
    public double DurationMs { get; set; }

    [GraphQLDescription(
        "Whether or not the track has explicit lyrics (true = yes it does; false = no it does not OR unknown)"
    )]
    public bool Explicit { get; set; }

    [GraphQLDescription("The URI for the track, usually a Spotify link.")]
    public string Uri { get; set; }

}