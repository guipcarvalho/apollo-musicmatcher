using SpotifyWeb;
using System.Net;
using Playlist = Odyssey.MusicMatcher.Models.Playlist;

namespace Odyssey.MusicMatcher.GraphQL.Query;

public class Query
{
    [GraphQLDescription("Playlists hand-picked to be featured to all users.")]
    public async Task<IEnumerable<Playlist>> GetFeaturedPlaylists([Service] SpotifyService spotifyService)
    {
        var response = await spotifyService.GetFeaturedPlaylistsAsync();

        return response.Playlists.Items.Select(playlist => new Playlist
        {
            Id = playlist.Id,
            Name = playlist.Name,
            Description = playlist.Description
        });
    }

    [GraphQLDescription("Get a playlist by its ID.")]
    public async Task<Playlist?> GetPlaylist([ID] string id, [Service] SpotifyService spotifyService)
    {
        try
        {
            var playlist = await spotifyService.GetPlaylistAsync(id);
            
            return new Playlist(playlist);
        }
        catch (ApiException e) when (e.StatusCode == (int)HttpStatusCode.NotFound)
        {
            return null;
        }
    }
}