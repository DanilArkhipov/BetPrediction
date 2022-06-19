using Repositories.Models.Enums;

namespace Repositories.Models.Entities;

public class PlayerEntity: UpdatableEntity<Guid>
{
    public long AccountId { get; init; }

    public string? SteamId { get; init; }

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
    
    public PlayerRole PlayerRole { get; set; }
    
    public DateTime BirthDate { get; set; }
    
    public double TotalPrizesInDollars { get; set; }
    
    public int MatchesCount { get; set; }
    
    public string? ProfessionalAvatarUrl { get; set; }
}