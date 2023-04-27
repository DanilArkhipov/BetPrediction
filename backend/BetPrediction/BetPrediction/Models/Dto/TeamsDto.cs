namespace BetPrediction.Models.Dto;

public class TeamsDto
{
    public Guid Id { get; set; }
    public string TeamLogoUrl { get; set; }
    public string TeamName { get; set; }
    public string TeamTag { get; set; }
    public string TotalWins { get; set; }
    public string TotalLosses { get; set; }
}