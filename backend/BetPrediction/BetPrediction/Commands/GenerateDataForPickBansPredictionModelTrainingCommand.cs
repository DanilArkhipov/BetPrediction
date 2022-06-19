using System.ComponentModel.DataAnnotations;
using Common.Commands;

namespace BetPrediction.Commands;

public class GenerateDataForPickBansPredictionModelTrainingCommand : ICommand
{
    public DateOnly StartPeriodDate { get; set; }
    public DateOnly EndPeriodDate { get; set; }

    [Range(0, 1)] public double TestSize { get; set; }
}