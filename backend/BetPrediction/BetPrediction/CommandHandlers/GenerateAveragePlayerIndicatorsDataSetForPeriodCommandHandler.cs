using BetPrediction.Commands;
using Common.Commands;
using Services;

namespace BetPrediction.CommandHandlers;

public class GenerateAveragePlayerIndicatorsDataSetForPeriodCommandHandler : ICommandHandler<
    GenerateAveragePlayerIndicatorsDataSetForPeriodCommand>
{
    private readonly IPlayerService _playerService;

    public GenerateAveragePlayerIndicatorsDataSetForPeriodCommandHandler(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    public async Task ExecuteAsync(GenerateAveragePlayerIndicatorsDataSetForPeriodCommand command)
    {
        await _playerService.GeneratePlayerAvgIndicatorsDatasetForPeriod(command.StartPeriodDate,
            command.EndPeriodDate);
    }
}