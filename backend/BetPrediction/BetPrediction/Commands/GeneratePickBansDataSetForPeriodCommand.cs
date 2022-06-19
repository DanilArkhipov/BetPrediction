using Common.Commands;

namespace BetPrediction.Commands;

public class GeneratePickBansDataSetForPeriodCommand: ICommand
{
    public DateOnly StartPeriodDate { get; set; }
    public DateOnly EndPeriodDate { get; set; }
}