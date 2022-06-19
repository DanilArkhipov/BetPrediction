using System.ComponentModel.DataAnnotations;
using Common.Commands;

namespace BetPrediction.Commands;

public class GenerateHeroMatrixForPeriodCommand: ICommand
{
    public DateOnly StartPeriodDate { get; set; }
    public DateOnly EndPeriodDate { get; set; }
}