using Odyssey.MusicMatcher.GraphQL.Mutations.Inputs;
using Odyssey.MusicMatcher.GraphQL.Mutations.Payloads;
using SpotifyWeb;
using Playlist = Odyssey.MusicMatcher.Models.Playlist;

namespace Odyssey.MusicMatcher.GraphQL.Mutations;

public class Mutation
{
    public Mutation()
    {
    }

    [GraphQLDescription("Add one or more items to a user's playlist.")]
    public async Task<AddItemsToPlaylistPayload> AddItemsToPlaylist(AddItemsToPlaylistInput input, SpotifyService spotifyService)
    {
        // Add the items to the playlist
        var snapshot = spotifyService.AddTracksToPlaylistAsync(input.PlaylistId, null, string.Join(",", input.Uris)).Result;

        var servicePlaylist = await spotifyService.GetPlaylistAsync(input.PlaylistId);
            
        var playlist = new Playlist(servicePlaylist);
        
        // Return the payload
        return new AddItemsToPlaylistPayload(
            200,
            true,
            "Successfully added items to playlist.",
            playlist
        );
    }
}