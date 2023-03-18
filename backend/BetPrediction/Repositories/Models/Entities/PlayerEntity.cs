namespace Repositories.Models.Entities;

public class PlayerEntity: UpdatableEntity<Guid>
{
    /// <summary>
    /// Призовые
    /// </summary>
    //public string TotalPrize { get; set; }

    /// <summary>
    /// Матчи
    /// </summary>
    //public string MatchesCount { get; set; }

    public int AccountId { get; init; }

    public string? SteamId { get; init; }

    public string? AvatarUrl { get; init; }

    public string? AvatarMediumUrl { get; init; }

    public string? AvatarFullUrl { get; init; }

    public string? ProfileUrl { get; init; }

    public string? SteamName { get; init; }

    public DateTime? LastLoginDate { get; init; }

    public DateTime? PlayersMatchHistoryLastUpdateDate { get; init; }

    public int? Cheese { get; init; }

    public bool? PlayersMatchHistoryUnavailable { get; init; }

    public string? LocalCountryCode { get; init; }

    public string? Name { get; init; }

    public string? CountryCode { get; init; }

    public string? FantasyRole { get; init; }

    public int? TeamId { get; init; }

    public string? TeamName { get; init; }

    public string? TeamTag { get; init; }

    public bool? IsLocked { get; init; }

    public bool? IsPro { get; init; }

    public int? LockedUntil { get; init; }
    
    public TeamEntity? Team { get; set; }
}