using Common.Commands;

namespace BetPrediction.Commands;

public class TrainClassifiersCommand : ICommand
{
    public DateTime StartPeriodDate { get; set; }
    public DateTime EndPeriodDate { get; set; }
}