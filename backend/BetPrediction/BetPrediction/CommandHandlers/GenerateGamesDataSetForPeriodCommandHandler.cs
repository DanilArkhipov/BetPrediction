using BetPrediction.Commands;
using Common.Commands;
using Services;

namespace BetPrediction.CommandHandlers;

public class GenerateGamesDataSetForPeriodCommandHandler : ICommandHandler<GenerateGamesDataSetForPeriodCommand>
{
    private readonly IGameService _gameService;

    public GenerateGamesDataSetForPeriodCommandHandler(IGameService gameService)
    {
        _gameService = gameService;
    }

    public async Task ExecuteAsync(GenerateGamesDataSetForPeriodCommand command)
    {
        await _gameService.GenerateGamesDataSetForPeriod(command.StartPeriodDate, command.EndPeriodDate);
    }
}