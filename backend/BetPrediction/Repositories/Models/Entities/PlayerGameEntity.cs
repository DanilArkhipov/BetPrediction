namespace Repositories.Models.Entities;

public class PlayerGameEntity: BaseEntity<Guid>
{
    public long? AccountId { get; init; }
    
    public long? GameId { get; set; }
    
    public long? AssistsCount { get; init; }
    
    public int? CampsStackedCount { get; init; }
    
    public int? CreepsStackedCount { get; init; }
    
    public int? Deaths { get; init; }
    
    public int? Denies { get; init; }
    
    public int? FirstTenMinutesIntervalDenies { get; init; }
    
    public int? SecondTenMinutesIntervalDenies { get; init; }
    
    public int? ThirdTenMinutesIntervalDenies { get; init; }

    public int? Gold { get; init; }
    
    public double? GoldPerMinute { get; init; }
    
    public int? GoldSpent { get; init; }
    
    public int? FirstTenMinutesIntervalGold { get; set; }
    
    public int? SecondTenMinutesIntervalGold { get; set; }
    
    public int? ThirdTenMinutesIntervalGold { get; set; }

    public double? HeroDamage { get; init; }
    
    public double? HeroHealing { get; init; }
    
    public int? HeroOpenDotaId { get; init; }

    public int? KillsCount { get; init; }
    
    public int? LastHits { get; init; }
    
    public int? LeaverStatus { get; init; }
    
    public int? Level { get; init; }
    
    public int? FirstTenMinutesIntervalLastHit { get; init; }
    
    public int? SecondTenMinutesIntervalLastHit { get; init; }
    
    public int? ThirdTenMinutesIntervalLastHit { get; init; }

    public int DoubleKillsCount { get; init; }
    
    public int TripleKillsCount { get; init; }
    
    public int UltraKillsCount { get; init; }
    
    public int RampagesCount { get; init; }
    
    public int? ObsPlaced { get; init; }
    
    public int? RunePickUps { get; init; }
    
    // public object? Runes { get; init; } можно считать активные и пассивные руны отдельно
    
    public int? SenPlaced { get; init; }
    
    public double? Stuns { get; init; }

    public double? TowerDamage { get; init; }
    
    public double? XpPerMin { get; init; }
    
    public int? FirstTenMinutesIntervalXp { get; set; }
    
    public int? SecondTenMinutesIntervalXp { get; set; }
    
    public int? ThirdTenMinutesIntervalXp { get; set; }

    public bool? Win { get; init; }
    
    public int? TotalGold { get; init; }
    
    public int? TotalXp { get; init; }
    
    public double? KillsPerMin { get; init; }
    
    public double? Kda { get; init; }
    
    public int? Abandons { get; init; }
    
    public int? NeutralKills { get; init; }
    
    public int? TowerKills { get; init; }
    
    public int? CourierKills { get; init; }
    
    public int? LaneKills { get; init; }
    
    public int? HeroKills { get; init; }
    
    public int? ObserverKills { get; init; }
    
    public int? SentryKills { get; init; }
    
    public int? RoshanKills { get; init; }
    
    public int? NecronomiconKills { get; init; }
    
    public int? AncientKills { get; init; }
    
    public int? BuyBackCount { get; init; }
    
    public int? ObserverUses { get; init; }
    
    public int? SentryUses { get; init; }
    
    public double? LaneEfficiency { get; init; }
    
    public double? LaneEfficiencyPct { get; init; }
    
    public int? Lane { get; init; }
    
    public int? LaneRole { get; init; }
    
    public bool? IsRoaming { get; init; }
    
    public double? ActionsPerMinute { get; init; }
    
    public int? RankTier { get; init; }
    
    public bool? IsRadiant { get; init; }
}