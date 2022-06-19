using BetPrediction.Commands;
using Common.Commands;
using Services;

namespace BetPrediction.CommandHandlers;

public class
    GenerateDataForPickBansPredictionModelTrainingCommandHandler : ICommandHandler<
        GenerateDataForPickBansPredictionModelTrainingCommand>
{
    private readonly IHeroServices _heroServices;

    public GenerateDataForPickBansPredictionModelTrainingCommandHandler(IHeroServices heroServices)
    {
        _heroServices = heroServices;
    }

    public async Task ExecuteAsync(GenerateDataForPickBansPredictionModelTrainingCommand command)
    {
        await _heroServices.GenerateDataForPickBansPredictionModelTraining(command.StartPeriodDate,
            command.EndPeriodDate, command.TestSize);
    }
}