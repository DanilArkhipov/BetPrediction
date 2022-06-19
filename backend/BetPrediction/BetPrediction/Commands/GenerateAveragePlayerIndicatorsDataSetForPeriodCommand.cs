using Common.Commands;

namespace BetPrediction.Commands;

public class GenerateAveragePlayerIndicatorsDataSetForPeriodCommand : ICommand
{
    public DateOnly StartPeriodDate { get; set; }
    public DateOnly EndPeriodDate { get; set; }
}