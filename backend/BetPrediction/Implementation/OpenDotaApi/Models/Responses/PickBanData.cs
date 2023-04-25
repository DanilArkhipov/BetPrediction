using System.Text.Json.Serialization;

namespace Implementation.OpenDotaApi.Models.Responses;

public record PickBanData
{
    [JsonPropertyName("is_pick")]
    public bool IsPick { get; init; }
    
    [JsonPropertyName("hero_id")]
    public int OpenDotaHeroId { get; init; }
    
    [JsonPropertyName("team")]
    public long Team { get; init; }
    
    [JsonPropertyName("match_id")]
    public long GameId { get; init; }
}