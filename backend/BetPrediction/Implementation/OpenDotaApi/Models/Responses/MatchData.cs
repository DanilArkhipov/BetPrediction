using System.Text.Json.Serialization;

namespace Implementation.OpenDotaApi.Models.Responses;

public record MatchData
{
    /// <summary>
    /// The ID number of the match assigned by Valve
    /// </summary>
    [JsonPropertyName("match_id")]
    public int MatchId { get; init; }
    
    /// <summary>
    /// Bitmask. An integer that represents a binary of which barracks are still standing. 63 would mean all barracks still stand at the end of the game.
    /// </summary>
    [JsonPropertyName("barracks_status_dire")]
    public int? BarracksStatusDire { get; init; }
    
    /// <summary>
    /// Bitmask. An integer that represents a binary of which barracks are still standing. 63 would mean all barracks still stand at the end of the game.
    /// </summary>
    [JsonPropertyName("barracks_status_radiant")]
    public int? BarracksStatusRadiant { get; init; }
    
    /// <summary>
    /// Array containing information on the chat of the game
    /// </summary>
    [JsonPropertyName("chat")]
    public object? Chat { get; init; }
    
    /// <summary>
    /// cluster
    /// </summary>
    [JsonPropertyName("cluster")]
    public int? Cluster { get; init; }
    
    /// <summary>
    /// cosmetics
    /// </summary>
    [JsonPropertyName("cosmetics")]
    public object? Cosmetics { get; init; }
    
    /// <summary>
    /// Final score for Dire (number of kills on Radiant)
    /// </summary>
    [JsonPropertyName("dire_score")]
    public int? DireScore { get; init; }

 
    /// <summary>
    /// draft_timings
    /// </summary>
    [JsonPropertyName("draft_timings")]
    public object? DraftTimings { get; init; }
 

    /// <summary>
    /// Duration of the game in seconds
    /// </summary>
    [JsonPropertyName("duration")]
    public int? GameDuration { get; init; }
    
    /// <summary>
    /// engine
    /// </summary>
    [JsonPropertyName("engine")]
    public int? Engine { get; init; }
    
    /// <summary>
    /// Time in seconds at which first blood occurred
    /// </summary>
    [JsonPropertyName("first_blood_time")]
    public int? FirstBloodTime { get; init; }
    
    /// <summary>
    /// Integer corresponding to game mode played. List of constants can be found here: https://github.com/odota/dotaconstants/blob/master/json/game_mode.json
    /// </summary>
    [JsonPropertyName("game_mode")]
    public int? GameMode { get; init; }
    
    /// <summary>
    /// Number of human players in the game
    /// </summary>
    [JsonPropertyName("human_players")]
    public int? HumanPlayersCount { get; init; }
    
    /// <summary>
    /// leagueid
    /// </summary>
    [JsonPropertyName("leagueid")]
    public int? LeagueId { get; init; }
    
    /// <summary>
    /// Integer corresponding to lobby type of match. List of constants can be found here: https://github.com/odota/dotaconstants/blob/master/json/lobby_type.json
    /// </summary>
    [JsonPropertyName("lobby_type")]
    public int? LobbyType { get; init; }
    	

    /// <summary>
    /// match_seq_num
    /// </summary>
    [JsonPropertyName("match_seq_num")]
    public int? MatchSwqNum { get; init; }
    
    /// <summary>
    /// Number of negative votes the replay received in the in-game client
    /// </summary>
    [JsonPropertyName("negative_votes")]
    public int? NegativeVotes { get; init; }
    
    /// <summary>
    /// objectives
    /// </summary>
    [JsonPropertyName("objectives")]
    public object? Objectives { get; init; }
    
    /// <summary>
    /// Object containing information on the draft. Each pick/ban contains a boolean relating to whether the choice is a pick or a ban, the hero ID, the team the picked or banned it, and the order.
    /// </summary>
    [JsonPropertyName("picks_bans")]
    public object? PicksBans { get; init; }
    
    /// <summary>
    /// Number of positive votes the replay received in the in-game client
    /// </summary>
    [JsonPropertyName("positive_votes")]
    public int? PositiveVotes { get; init; }
    
    /// <summary>
    /// Array of the Radiant gold advantage at each minute in the game. A negative number means that Radiant is behind, and thus it is their gold disadvantage.
    /// </summary>
    [JsonPropertyName("radiant_gold_adv")]
    public object? RadiantGoldAdv { get; init; }
    
    
    /// <summary>
    /// Final score for Radiant (number of kills on Radiant)
    /// </summary>
    [JsonPropertyName("radiant_score")]
    public int? RadiantScore { get; init; }
    

    /// <summary>
    /// Boolean indicating whether Radiant won the match
    /// </summary>
    [JsonPropertyName("radiant_win")]
    public bool? RadiantWin { get; init; }
    
    /// <summary>
    /// Array of the Radiant experience advantage at each minute in the game. A negative number means that Radiant is behind, and thus it is their experience disadvantage.
    /// </summary>
    [JsonPropertyName("radiant_xp_adv")]
    public object? RadiantXpAdv { get; init; }
    
    
    /// <summary>
    /// The Unix timestamp at which the game started
    /// </summary>
    [JsonPropertyName("start_time")]
    public int? StartTime { get; init; }
    
    /// <summary>
    /// teamfights
    /// </summary>
    [JsonPropertyName("teamfights")]
    public object? TeamFights { get; init; }

    /// <summary>
    /// Bitmask. An integer that represents a binary of which Dire towers are still standing.
    /// </summary>
    [JsonPropertyName("tower_status_dire")]
    public int? TowerStatusDire { get; init; }
    
    /// <summary>
    /// Bitmask. An integer that represents a binary of which Radiant towers are still standing.
    /// </summary>
    [JsonPropertyName("tower_status_radiant")]
    public int? TowerStatusRadiant { get; init; }
    
    /// <summary>
    /// Parse version, used internally by OpenDota
    /// </summary>
    [JsonPropertyName("version")]
    public int? Version { get; init; }
    
    /// <summary>
    /// replay_salt
    /// </summary>
    [JsonPropertyName("replay_salt")]
    public int? ReplaySalt { get; init; }
    
    /// <summary>
    /// replay_salt
    /// </summary>
    [JsonPropertyName("series_id")]
    public int? SeriesId { get; init; }
    
    /// <summary>
    /// series_type
    /// </summary>
    [JsonPropertyName("series_type")]
    public int? SeriesType { get; init; }
    
    /// <summary>
    /// radiant_team
    /// </summary>
    [JsonPropertyName("radiant_team")]
    public object? RadiantTeam { get; init; }
    
    /// <summary>
    /// dire_team
    /// </summary>
    [JsonPropertyName("dire_team")]
    public object? DireTeam { get; init; }
    
    /// <summary>
    /// League
    /// </summary>
    [JsonPropertyName("league")]
    public object? League { get; init; }
    
    /// <summary>
    /// Skill
    /// </summary>
    [JsonPropertyName("skill")]
    public int? Skill { get; init; }
    
    /// <summary>
    /// Array of information on individual players
    /// </summary>
    [JsonPropertyName("players")]
    public object? Players { get; init; }
    

    /// <summary>
    /// Patch
    /// </summary>
    [JsonPropertyName("patch")]
    public int? Patch { get; init; }
    
    /// <summary>
    /// Region
    /// </summary>
    [JsonPropertyName("region")]
    public int? Region { get; init; }
    
    /// <summary>
    /// Word counts of the all chat messages in the player's games
    /// </summary>
    [JsonPropertyName("all_word_counts")]
    public object? AllWordCounts { get; init; }
    
    /// <summary>
    /// Word counts of the player's all chat messages
    /// </summary>
    [JsonPropertyName("my_word_counts")]
    public object? MyWordCounts { get; init; }
    
    /// <summary>
    /// Maximum gold advantage of the player's team if they lost the match
    /// </summary>
    [JsonPropertyName("throw")]
    public int? Throw { get; init; }
    

    /// <summary>
    /// Maximum gold disadvantage of the player's team if they won the match
    /// </summary>
    [JsonPropertyName("comeback")]
    public int? Comeback { get; init; }
    
    /// <summary>
    /// Maximum gold disadvantage of the player's team if they lost the match
    /// </summary>
    [JsonPropertyName("loss")]
    public int? Loss { get; init; }
    
    /// <summary>
    /// Maximum gold advantage of the player's team if they won the match
    /// </summary>
    [JsonPropertyName("win")]
    public int? Win { get; init; }

    /// <summary>
    /// replay_url
    /// </summary>
    [JsonPropertyName("replay_url")]
    public string? ReplayUrl { get; init; }
}

public record Chat(
    int time,
    string unit,
    string key,
    int slot,
    int player_slot
);

public record Cosmetics(

);

public record Draft_timings(
    int order,
    bool pick,
    int active_team,
    int hero_id,
    int player_slot,
    int extra_time,
    int total_time_taken
);

public record Objectives(

);

public record Picks_bans(

);

public record Radiant_gold_adv(

);

public record Radiant_xp_adv(

);

public record Teamfights(

);

public record Radiant_team(

);

public record Dire_team(

);

public record League(

);



public record Ability_uses(

);

public record Ability_targets(

);

public record Damage_targets(

);

public record Actions(

);

public record Additional_units(

);

public record Buyback_log(
    int time,
    int slot,
    int player_slot
);

public record Connection_log(
    int time,
    string @event,
    int player_slot
);

public record Damage(

);

public record Damage_inflictor(

);

public record Damage_inflictor_received(

);

public record Damage_taken(

);

public record Gold_reasons(

);

public record Hero_hits(

);

public record Item_uses(

);

public record Kill_streaks(

);

public record Killed(

);

public record Killed_by(

);

public record Kills_log(
    int time,
    string key
);

public record Purchase_log(
    int time,
    string key,
    int charges
);

public record Runes(
    int property1,
    int property2
);

public record Runes_log(
    int time,
    int key
);


public record Sen_left_log(

);

public record Sen_log(

);

public record Xp_reasons(

);

public record Purchase_time(

);

public record First_purchase_time(

);

public record Item_win(

);

public record Item_usage(

);

public record Purchase_tpscroll(

);

public record Benchmarks(

);

public record All_word_counts(

);

public record My_word_counts(

);


