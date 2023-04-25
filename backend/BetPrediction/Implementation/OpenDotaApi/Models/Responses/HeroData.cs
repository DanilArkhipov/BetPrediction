using System.Text.Json.Serialization;

namespace Implementation.OpenDotaApi.Models.Responses;

public record HeroData
{
    [JsonPropertyName("id")]
    public int OpenDotaId { get; init; }
    
    [JsonPropertyName("name")]
    public string Name { get; init; }
    
    [JsonPropertyName("localized_name")]
    public string LocalizedName { get; init; }

    [JsonPropertyName("img")]
    public string OpenDotaRelativeHeroImageUrl { get; init; }
    
    [JsonPropertyName("icon")]
    public string OpenDotaRelativeHeroIconUrl { get; init; }
}