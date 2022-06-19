using Common.Commands;

namespace BetPrediction.Commands;

public class GeneratePlayerIndicatorsDataSetForPeriodCommand : ICommand
{
    public DateOnly StartPeriodDate { get; set; }
    public DateOnly EndPeriodDate { get; set; }
}