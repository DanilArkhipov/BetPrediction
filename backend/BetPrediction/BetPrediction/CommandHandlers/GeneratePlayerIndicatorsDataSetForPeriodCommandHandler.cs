using BetPrediction.Commands;
using Common.Commands;
using Services;

namespace BetPrediction.CommandHandlers;

public class
    GeneratePlayerIndicatorsDataSetForPeriodCommandHandler : ICommandHandler<
        GeneratePlayerIndicatorsDataSetForPeriodCommand>
{
    private readonly IPlayerService _playerService;

    public GeneratePlayerIndicatorsDataSetForPeriodCommandHandler(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    public async Task ExecuteAsync(GeneratePlayerIndicatorsDataSetForPeriodCommand command)
    {
        await _playerService.GeneratePlayerIndicatorsDatasetForPeriod(command.StartPeriodDate, command.EndPeriodDate);
    }
}