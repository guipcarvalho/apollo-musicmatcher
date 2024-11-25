namespace Odyssey.MusicMatcher.Models;

[GraphQLDescription("An artist who creates music.")]
public record Artist
{
    [ID]
    [GraphQLDescription("The id of the artist.")]
    public Guid Id { get; init; } = Guid.NewGuid();
    
    [GraphQLDescription("The name of the artist.")]
    public string Name { get; init; }
    
    [GraphQLDescription("The number of followers the artist has.")]
    public int Followers { get; set; }
    
    [GraphQLDescription("The popularity of the artist.")]
    public float Popularity { get; set; }
}