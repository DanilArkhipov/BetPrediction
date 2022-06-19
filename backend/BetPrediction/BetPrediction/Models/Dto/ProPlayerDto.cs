namespace BetPrediction.Models.Dto;

public class ProPlayerDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string AvatarUrl { get; set; }
    public string TeamName { get; set; }
    public string Role { get; set; }
    public string Region { get; set; }
    public double Prizes { get; set; }
    public int MatchesCount { get; set; }
    public int WinsCount { get; set; }
    public int LossesCount { get; set; }
}