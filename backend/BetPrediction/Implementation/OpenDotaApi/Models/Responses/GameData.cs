using System.Text.Json.Serialization;

namespace Implementation.OpenDotaApi.Models.Responses;

public record GameData
{
    /// <summary>
    /// The ID number of the match assigned by Valve
    /// </summary>
    [JsonPropertyName("match_id")]
    public long MatchId { get; init; }
    
    /// <summary>
    /// cluster
    /// </summary>
    [JsonPropertyName("cluster")]
    public int? Cluster { get; init; }

    /// <summary>
    /// Duration of the game in seconds
    /// </summary>
    [JsonPropertyName("duration")]
    public long? GameDuration { get; init; }
    
    /// <summary>
    /// engine
    /// </summary>
    [JsonPropertyName("engine")]
    public int? Engine { get; init; }

    /// <summary>
    /// Integer corresponding to game mode played. List of constants can be found here: https://github.com/odota/dotaconstants/blob/master/json/game_mode.json
    /// </summary>
    [JsonPropertyName("game_mode")]
    public int? GameMode { get; init; }

    /// <summary>
    /// leagueid
    /// </summary>
    [JsonPropertyName("leagueid")]
    public long? LeagueId { get; init; }
    
    /// <summary>
    /// Integer corresponding to lobby type of match. List of constants can be found here: https://github.com/odota/dotaconstants/blob/master/json/lobby_type.json
    /// </summary>
    [JsonPropertyName("lobby_type")]
    public int? LobbyType { get; init; }
    	

    /// <summary>
    /// match_seq_num
    /// </summary>
    [JsonPropertyName("match_seq_num")]
    public long? MatchSeqNum { get; init; }

    /// <summary>
    /// Object containing information on the draft. Each pick/ban contains a boolean relating to whether the choice is a pick or a ban, the hero ID, the team the picked or banned it, and the order.
    /// </summary>
    [JsonPropertyName("picks_bans")]
    public List<PickBanData>? PicksBans { get; init; }
    


    /// <summary>
    /// Boolean indicating whether Radiant won the match
    /// </summary>
    [JsonPropertyName("radiant_win")]
    public bool? RadiantWin { get; init; }
    
    /// <summary>
    /// The Unix timestamp at which the game started
    /// </summary>
    [JsonPropertyName("start_time")]
    public long? StartTime { get; init; }

    /// <summary>
    /// Parse version, used internally by OpenDota
    /// </summary>
    [JsonPropertyName("version")]
    public int? Version { get; init; }
    
    /// <summary>
    /// replay_salt
    /// </summary>
    [JsonPropertyName("replay_salt")]
    public long? ReplaySalt { get; init; }
    
    /// <summary>
    /// replay_salt
    /// </summary>
    [JsonPropertyName("series_id")]
    public long? SeriesId { get; init; }
    
    /// <summary>
    /// series_type
    /// </summary>
    [JsonPropertyName("series_type")]
    public long? SeriesType { get; init; }

    /// <summary>
    /// League
    /// </summary>
    [JsonPropertyName("league")]
    public LeagueData? League { get; init; }
    
    /// <summary>
    /// Skill
    /// </summary>
    [JsonPropertyName("skill")]
    public int? Skill { get; init; }
    
    /// <summary>
    /// Array of information on individual players
    /// </summary>
    [JsonPropertyName("players")]
    public List<GamePlayerData>? Players { get; init; }
    

    /// <summary>
    /// Patch
    /// </summary>
    [JsonPropertyName("patch")]
    public int? Patch { get; init; }
    
    /// <summary>
    /// Region
    /// </summary>
    [JsonPropertyName("region")]
    public long? Region { get; init; }

    /// <summary>
    /// replay_url
    /// </summary>
    [JsonPropertyName("replay_url")]
    public string? ReplayUrl { get; init; }
    
    /// <summary>
    /// RadiantTeamOpenDotaId
    /// </summary>
    [JsonPropertyName("radiant_team_id")]
    public long? RadiantTeamOpenDotaId { get; init; }
    
    /// <summary>
    /// DireTeamOpenDotaId
    /// </summary>
    [JsonPropertyName("dire_team_id")]
    public long? DireTeamOpenDotaId { get; init; }
    
}

