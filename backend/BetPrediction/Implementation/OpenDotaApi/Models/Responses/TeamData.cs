using System.Text.Json.Serialization;

namespace Implementation.OpenDotaApi.Models.Responses;

public record TeamData
{
    /// <summary>
    /// Team's identifier
    /// </summary>
    [JsonPropertyName("team_id")]
    public int TeamId { get; init; }

    /// <summary>
    /// The Elo rating of the team
    /// </summary>
    [JsonPropertyName("rating")]
    public double? TeamRating { get; init; }

    /// <summary>
    /// The number of games won by this team
    /// </summary>
    [JsonPropertyName("wins")]
    public int? TotalWins { get; init; }

    /// <summary>
    /// The number of losses by this team
    /// </summary>
    [JsonPropertyName("losses")]
    public int? TotalLosses { get; init; }


    /// <summary>
    /// The Unix timestamp of the last match played by this team
    /// </summary>
    [JsonPropertyName("last_match_time")]
    public int? LastMatchTimeStamp { get; init; }

    /// <summary>
    /// Team name, eg. 'Newbee'
    /// </summary>
    [JsonPropertyName("name")]
    public string? TeamName { get; init; }


    /// <summary>
    /// The team tag/abbreviation
    /// </summary>
    [JsonPropertyName("tag")]
    public string? TeamTag { get; init; }
}