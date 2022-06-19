namespace BetPrediction.Models.Dto;

public class PredictionDataDto
{
    public List<PlayerPredictionDataDto> Players { get; set; }

    public List<HeroPredictionDataDto> Heroes { get; set; }
}