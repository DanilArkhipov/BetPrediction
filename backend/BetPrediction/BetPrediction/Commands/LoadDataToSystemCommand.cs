using Common.Commands;

namespace BetPrediction.Commands;

public class LoadDataToSystemCommand : ICommand
{
    public DateTime StartPeriodDate { get; set; }
    public DateTime EndPeriodDate { get; set; }
}