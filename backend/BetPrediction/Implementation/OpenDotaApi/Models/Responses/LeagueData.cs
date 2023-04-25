using System.Text.Json.Serialization;

namespace Implementation.OpenDotaApi.Models.Responses;

public record LeagueData
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("leagueid")]
    public long LeagueId { get; set; }
    
    [JsonPropertyName("tier")]
    public string Tier { get; set; }
}