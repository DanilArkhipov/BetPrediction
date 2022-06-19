using Common.Commands;

namespace BetPrediction.Commands;

public class GenerateGamesDataSetForPeriodCommand : ICommand
{
    public DateOnly StartPeriodDate { get; set; }
    public DateOnly EndPeriodDate { get; set; }
}