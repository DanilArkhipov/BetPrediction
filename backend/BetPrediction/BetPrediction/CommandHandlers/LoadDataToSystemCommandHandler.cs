using BetPrediction.Commands;
using Common.Commands;
using Services;

namespace BetPrediction.CommandHandlers;

public class LoadDataToSystemCommandHandler: ICommandHandler<LoadDataToSystem>
{
    private readonly IPlayerService _playerService;

    private readonly ITeamService _teamService;

    private readonly IMatchService _matchService;

    public LoadDataToSystemCommandHandler(IPlayerService playerService, ITeamService teamService, IMatchService matchService)
    {
        _playerService = playerService;
        _teamService = teamService;
        _matchService = matchService;
    }


    public async Task ExecuteAsync(LoadDataToSystem infoCommand)
    {
        await _matchService.LoadMatchesToSystem();
    }
}