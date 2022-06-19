namespace Models.Entities.Player;

public class PlayerIndicators
{
    public long? AccountId { get; init; }

    public double? AssistsCount { get; init; }

    public double? CampsStackedCount { get; init; }

    public double? CreepsStackedCount { get; init; }

    public double? Deaths { get; init; }

    public double? Denies { get; init; }

    public double? FirstTenMinutesIntervalDenies { get; init; }

    public double? SecondTenMinutesIntervalDenies { get; init; }

    public double? ThirdTenMinutesIntervalDenies { get; init; }

    public double? Gold { get; init; }

    public double? GoldPerMinute { get; init; }

    public double? GoldSpent { get; init; }

    public double? FirstTenMinutesIntervalGold { get; set; }

    public double? SecondTenMinutesIntervalGold { get; set; }

    public double? ThirdTenMinutesIntervalGold { get; set; }

    public double? HeroDamage { get; init; }

    public double? HeroHealing { get; init; }

    public double? KillsCount { get; init; }

    public double? LastHits { get; init; }

    public double? Level { get; init; }

    public double? FirstTenMinutesIntervalLastHit { get; init; }

    public double? SecondTenMinutesIntervalLastHit { get; init; }

    public double? ThirdTenMinutesIntervalLastHit { get; init; }

    public double DoubleKillsCount { get; init; }

    public double TripleKillsCount { get; init; }

    public double UltraKillsCount { get; init; }

    public double RampagesCount { get; init; }

    public double? ObsPlaced { get; init; }

    public double? RunePickUps { get; init; }

    public double? SenPlaced { get; init; }

    public double? Stuns { get; init; }

    public double? TowerDamage { get; init; }

    public double? XpPerMin { get; init; }

    public double? FirstTenMinutesIntervalXp { get; set; }

    public double? SecondTenMinutesIntervalXp { get; set; }

    public double? ThirdTenMinutesIntervalXp { get; set; }

    public double? WinRate { get; init; }

    public double? TotalGold { get; init; }

    public double? TotalXp { get; init; }

    public double? KillsPerMin { get; init; }

    public double? Kda { get; init; }

    public double? NeutralKills { get; init; }

    public double? TowerKills { get; init; }

    public double? LaneKills { get; init; }

    public double? LaneEfficiencyPct { get; init; }

    public double? ActionsPerMinute { get; init; }

    public int? PlayerRole { get; set; }

    public bool Win { get; set; }
}