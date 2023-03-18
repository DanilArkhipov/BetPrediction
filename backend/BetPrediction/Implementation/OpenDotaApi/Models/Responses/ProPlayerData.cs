using System.Text.Json.Serialization;
using Implementation.OpenDotaApi.Models.Enums;

namespace Implementation.OpenDotaApi.Models.Responses;

public record ProPlayerData
{
    /// <summary>
    /// Player's account identifier
    /// </summary>
    [JsonPropertyName("account_id")]
    public int AccountId { get; init; }

    /// <summary>
    /// Player's steam identifier
    /// </summary>
    [JsonPropertyName("steamid")]
    public string? SteamId { get; init; }

    /// <summary>
    /// Steam picture URL (small picture)
    /// </summary>
    [JsonPropertyName("avatar")]
    public string? AvatarUrl { get; init; }

    /// <summary>
    /// Steam picture URL (medium picture)
    /// </summary>
    [JsonPropertyName("avatarmedium")]
    public string? AvatarMediumUrl { get; init; }

    /// <summary>
    /// Steam picture URL (full picture)
    /// </summary>
    [JsonPropertyName("avatarfull")]
    public string? AvatarFullUrl { get; init; }


    /// <summary>
    ///  Steam profile URL
    /// </summary>
    [JsonPropertyName("profileurl")]
    public string? ProfileUrl { get; init; }


    /// <summary>
    ///  Player's Steam name
    /// </summary>
    [JsonPropertyName("personaname")]
    public string? SteamName { get; init; }

    /// <summary>
    ///  Date and time of last login to OpenDota
    /// </summary>
    [JsonPropertyName("last_login")]
    public DateTime? LastLoginDate { get; init; }

    /// <summary>
    ///  Date and time of last request to refresh player's match history
    /// </summary>
    [JsonPropertyName("full_history_time")]
    public DateTime? PlayersMatchHistoryLastUpdateDate { get; init; }

    /// <summary>
    ///  Amount of dollars the player has donated to OpenDota
    /// </summary>
    [JsonPropertyName("cheese")]
    public int? Cheese { get; init; }


    /// <summary>
    ///   Whether the refresh of player' match history failed
    /// </summary>
    [JsonPropertyName("fh_unavailable")]
    public bool? PlayersMatchHistoryUnavailable { get; init; }


    /// <summary>
    ///   Player's country identifier, e.g. US
    /// </summary>
    [JsonPropertyName("loccountrycode")]
    public string? LocalCountryCode { get; init; }

    /// <summary>
    ///    Verified player name, e.g. 'Miracle-'
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }


    /// <summary>
    ///   Player's country code
    /// </summary>
    [JsonPropertyName("country_code")]
    public string? CountryCode { get; init; }


    /// <summary>
    ///   Player's ingame role (core: 1 or support: 2)
    /// </summary>
    [JsonPropertyName("fantasy_role")]
    public PlayerFantasyRole? FantasyRole { get; init; }

    /// <summary>
    ///   Player's team identifier
    /// </summary>
    [JsonPropertyName("team_id")]
    public int? TeamId { get; init; }

    /// <summary>
    ///   Player's team name, e.g. 'Evil Geniuses'
    /// </summary>
    [JsonPropertyName("team_name")]
    public string? TeamName { get; init; }


    /// <summary>
    ///   Player's team shorthand tag, e.g. 'EG'
    /// </summary>
    [JsonPropertyName("team_tag")]
    public string? TeamTag { get; init; }


    /// <summary>
    ///   Whether the roster lock is active
    /// </summary>
    [JsonPropertyName("is_locked")]
    public bool? IsLocked { get; init; }


    /// <summary>
    ///  Whether the player is professional or not
    /// </summary>
    [JsonPropertyName("is_pro")]
    public bool? IsPro { get; init; }


    /// <summary>
    ///   When the roster lock will end
    /// </summary>
    [JsonPropertyName("locked_until")]
    public int? LockedUntil { get; init; }
}