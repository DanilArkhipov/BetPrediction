using System.Text.Json.Serialization;

namespace Implementation.OpenDotaApi.Models.Responses;

public record GamePlayerData
{
    /// <summary>
    /// account_id
    /// </summary>
    [JsonPropertyName("account_id")]
    public long? AccountId { get; init; }
    
    /// <summary>
    /// The ID number of the match assigned by Valve
    /// </summary>
    [JsonPropertyName("match_id")]
    public long MatchId { get; init; }
    
    /// <summary>
    /// assists
    /// </summary>
    [JsonPropertyName("assists")]
    public long? AssistsCount { get; init; }
    
    /// <summary>
    /// CampsStackedCount
    /// </summary>
    [JsonPropertyName("camps_stacked")]
    public long? CampsStackedCount { get; init; }
    
    /// <summary>
    /// CreepsStackedCount
    /// </summary>
    [JsonPropertyName("creeps_stacked")]
    public long? CreepsStackedCount { get; init; }
    
    /// <summary>
    /// Deaths
    /// </summary>
    [JsonPropertyName("deaths")]
    public long? Deaths { get; init; }
    
    /// <summary>
    /// Denies
    /// </summary>
    [JsonPropertyName("denies")]
    public long? Denies { get; init; }
    
    /// <summary>
    /// Array containing number of denies at different times of the match
    /// </summary>
    [JsonPropertyName("dn_t")]
    public List<int>? DeniesByTimes { get; init; }
    
    /// <summary>
    /// Gold at the end of the game
    /// </summary>
    [JsonPropertyName("gold")]
    public int? Gold { get; init; }
    
    /// <summary>
    /// GoldPerMinute
    /// </summary>
    [JsonPropertyName("gold_per_min")]
    public double? GoldPerMinute { get; init; }
    
    /// <summary>
    /// GoldSpent
    /// </summary>
    [JsonPropertyName("gold_spent")]
    public int? GoldSpent { get; init; }
    
    /// <summary>
    /// Array containing total gold at different times of the match
    /// </summary>
    [JsonPropertyName("gold_t")]
    public List<int>? GoldByTimes { get; init; }
    
    /// <summary>
    /// Hero Damage Dealt
    /// </summary>
    [JsonPropertyName("hero_damage")]
    public double? HeroDamage { get; init; }
    
    /// <summary>
    /// Hero Heal Dealt
    /// </summary>
    [JsonPropertyName("hero_healing")]
    public double? HeroHealing { get; init; }
    
    /// <summary>
    /// hero_hits
    /// </summary>
    [JsonPropertyName("hero_hits")]
    public object? HeroHits { get; init; }
    
    /// <summary>
    /// HeroOpenDotaId
    /// </summary>
    [JsonPropertyName("hero_id")]
    public int? HeroOpenDotaId { get; init; }
    
    /// <summary>
    /// KillsCount
    /// </summary>
    [JsonPropertyName("kills")]
    public int? KillsCount { get; init; }
    
    /// <summary>
    /// Object containing information on lane position
    /// </summary>
    [JsonPropertyName("lane_pos")]
    public object? LanePos { get; init; }
    
    /// <summary>
    /// Number of last hits
    /// </summary>
    [JsonPropertyName("last_hits")]
    public int? LastHits { get; init; }
    
    /// <summary>
    /// Integer describing whether or not the player left the game. 0: didn't leave. 1: left safely. 2+: Abandoned
    /// </summary>
    [JsonPropertyName("leaver_status")]
    public int? LeaverStatus { get; init; }
    
    /// <summary>
    /// Level
    /// </summary>
    [JsonPropertyName("level")]
    public int? Level { get; init; }
    
    /// <summary>
    /// Array describing last hits at each minute in the game
    /// </summary>
    [JsonPropertyName("lh_t")]
    public List<int>? LastHitsByTimes { get; init; }
    
    /// <summary>
    /// Array describing last hits at each minute in the game
    /// </summary>
    [JsonPropertyName("life_state")]
    public object? LifeState { get; init; }
    
    /// <summary>
    /// Object with information on the highest damage instance the player inflicted
    /// </summary>
    [JsonPropertyName("max_hero_hit")]
    public object? MaxHeroHit { get; init; }

    /// <summary>
    /// MultiKills
    /// </summary>
    [JsonPropertyName("multi_kills")]
    public MultiKillData MultiKills { get; init; }
    
    /// <summary>
    /// ObsPlaced
    /// </summary>
    [JsonPropertyName("obs_placed")]
    public int? ObsPlaced { get; init; }
    
    /// <summary>
    /// RunePickUps
    /// </summary>
    [JsonPropertyName("rune_pickups")]
    public int? RunePickUps { get; init; }
    
    /// <summary>
    /// Runes
    /// </summary>
    [JsonPropertyName("runes")]
    public object? Runes { get; init; }
    
    /// <summary>
    /// SenPlaced
    /// </summary>
    [JsonPropertyName("sen_placed")]
    public int? SenPlaced { get; init; }
    
    /// <summary>
    /// Total stun duration of all stuns by the player
    /// </summary>
    [JsonPropertyName("stuns")]
    public double? Stuns { get; init; }
    
    /// <summary>
    /// Times
    /// </summary>
    [JsonPropertyName("times")]
    public object? Times { get; init; }
    
    /// <summary>
    /// TowerDamage
    /// </summary>
    [JsonPropertyName("tower_damage")]
    public double? TowerDamage { get; init; }
    
    /// <summary>
    /// XpPerMin
    /// </summary>
    [JsonPropertyName("xp_per_min")]
    public double? XpPerMin { get; init; }
    
    /// <summary>
    /// XpByTimes
    /// </summary>
    [JsonPropertyName("xp_t")]
    public List<int>? XpByTimes { get; init; }
    
    /// <summary>
    /// PersonName
    /// </summary>
    [JsonPropertyName("personaname")]
    public String? PersonName { get; init; }
    
    /// <summary>
    /// Name
    /// </summary>
    [JsonPropertyName("name")]
    public String? Name { get; init; }
    
    /// <summary>
    /// Win
    /// </summary>
    [JsonPropertyName("win")]
    public int? Win { get; init; }
    
    /// <summary>
    /// Lose
    /// </summary>
    [JsonPropertyName("lose")]
    public int? Lose { get; init; }

    /// <summary>
    /// TotalGold
    /// </summary>
    [JsonPropertyName("total_gold")]
    public int? TotalGold { get; init; }
    
    /// <summary>
    /// TotalXp
    /// </summary>
    [JsonPropertyName("total_xp")]
    public int? TotalXp { get; init; }
    
    /// <summary>
    /// KillsPerMin
    /// </summary>
    [JsonPropertyName("kills_per_min")]
    public double? KillsPerMin { get; init; }
    
    /// <summary>
    /// Kda
    /// </summary>
    [JsonPropertyName("kda")]
    public double? Kda { get; init; }
    
    /// <summary>
    /// Abandons
    /// </summary>
    [JsonPropertyName("abandons")]
    public int? Abandons { get; init; }

    
    /// <summary>
    /// NeutralKills
    /// </summary>
    [JsonPropertyName("neutral_kills")]
    public int? NeutralKills { get; init; }
    
    /// <summary>
    /// TowerKills
    /// </summary>
    [JsonPropertyName("tower_kills")]
    public int? TowerKills { get; init; }

    /// <summary>
    /// CourierKills
    /// </summary>
    [JsonPropertyName("courier_kills")]
    public int? CourierKills { get; init; }

    /// <summary>
    /// Total number of lane creeps killed by the player
    /// </summary>
    [JsonPropertyName("lane_kills")]
    public int? LaneKills { get; init; }

    /// <summary>
    /// HeroKills
    /// </summary>
    [JsonPropertyName("hero_kills")]
    public int? HeroKills { get; init; }

    /// <summary>
    /// ObserverKills
    /// </summary>
    [JsonPropertyName("observer_kills")]
    public int? ObserverKills { get; init; }
    
    /// <summary>
    /// SentryKills
    /// </summary>
    [JsonPropertyName("sentry_kills")]
    public int? SentryKills { get; init; }
    
    /// <summary>
    /// RoshanKills
    /// </summary>
    [JsonPropertyName("roshan_kills")]
    public int? RoshanKills { get; init; }
    
    /// <summary>
    /// NecronomiconKills
    /// </summary>
    [JsonPropertyName("necronomicon_kills")]
    public int? NecronomiconKills { get; init; }
    
    /// <summary>
    /// AncientKills
    /// </summary>
    [JsonPropertyName("ancient_kills")]
    public int? AncientKills { get; init; }
    
    /// <summary>
    /// BuyBackCount
    /// </summary>
    [JsonPropertyName("buyback_count")]
    public int? BuyBackCount { get; init; }
    
    /// <summary>
    /// ObserverUses
    /// </summary>
    [JsonPropertyName("observer_uses")]
    public int? ObserverUses { get; init; }
    
    /// <summary>
    /// SentryUses
    /// </summary>
    [JsonPropertyName("sentry_uses")]
    public int? SentryUses { get; init; }
    
    /// <summary>
    /// LaneEfficiency
    /// </summary>
    [JsonPropertyName("lane_efficiency")]
    public double? LaneEfficiency { get; init; }
    
    /// <summary>
    /// LaneEfficiencyPct
    /// </summary>
    [JsonPropertyName("lane_efficiency_pct")]
    public double? LaneEfficiencyPct { get; init; }

    /// <summary>
    /// Integer referring to which lane the hero laned in
    /// </summary>
    [JsonPropertyName("lane")]
    public int? Lane { get; init; }

    /// <summary>
    /// LaneRole
    /// </summary>
    [JsonPropertyName("lane_role")]
    public int? LaneRole { get; init; }

    /// <summary>
    /// Boolean referring to whether or not the player roamed
    /// </summary>
    [JsonPropertyName("is_roaming")]
    public bool? IsRoaming { get; init; }
    
    /// <summary>
    /// ActionsPerMinute
    /// </summary>
    [JsonPropertyName("actions_per_min")]
    public double? ActionsPerMinute { get; init; }

    /// <summary>
    /// The rank tier of the player. Tens place indicates rank, ones place indicates stars.
    /// </summary>
    [JsonPropertyName("rank_tier")]
    public int? RankTier { get; init; }
    
    [JsonPropertyName("isRadiant")]
    public bool? IsRadiant { get; init; }
}