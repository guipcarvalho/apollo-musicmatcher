using SpotifyWeb;

namespace Odyssey.MusicMatcher.Models;

[GraphQLDescription("A curated collection of tracks designed for a specific activity or mood.")]
public record Playlist
{
    [GraphQLDescription("The ID for the playlist.")]
    [ID]
    public string? Id { get; init; }
    
    [GraphQLDescription("The name of the playlist.")]
    public string? Name { get; init; }
    
    [GraphQLDescription("Describes the playlist, what to expect and entices the user to listen.")]
    public string? Description { get; init; }
    
    private List<Track>? _tracks;
    
    public Playlist() { }
    
    public Playlist(SpotifyWeb.Playlist obj)
    {
        Id = obj.Id;
        Name = obj.Name;
        Description = obj.Description;
        _tracks = obj.Tracks.Items.Select(item => new Models.Track
        {
            Id = item.Track.Id,
            Name = item.Track.Name,
            DurationMs = item.Track.Duration_ms,
            Explicit = item.Track.Explicit,
            Uri = item.Track.Uri
        }).ToList();
    }
    
    [GraphQLDescription("The tracks in the playlist.")]
    public async Task<List<Track>> Tracks(SpotifyService spotifyService,
        [Parent] Playlist playlist
    )
    {
        if (_tracks != null)
        {
            return _tracks;
        }
        
        var response = await spotifyService.GetPlaylistsTracksAsync(playlist.Id);
        
        return response.Items.Select(item => new Track
        {
            Id = item.Track.Id,
            Name = item.Track.Name,
            DurationMs = item.Track.Duration_ms,
            Explicit = item.Track.Explicit,
            Uri = item.Track.Uri
        }).ToList();
    }
}