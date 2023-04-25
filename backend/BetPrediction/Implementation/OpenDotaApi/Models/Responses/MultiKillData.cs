using System.Text.Json.Serialization;

namespace Implementation.OpenDotaApi.Models.Responses;

public record MultiKillData
{
    [JsonPropertyName("2")]
    public int? DoubleKillsCount { get; init; }
    
    [JsonPropertyName("3")]
    public int? TripleKillsCount { get; init; }
    
    [JsonPropertyName("4")]
    public int? UltraKillsCount { get; init; }
    
    [JsonPropertyName("5")]
    public int? RampagesCount { get; init; }
}