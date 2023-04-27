using BetPrediction.Commands;
using Common.Commands;
using Services;

namespace BetPrediction.CommandHandlers;

public class LoadDataToSystemCommandHandler : ICommandHandler<LoadDataToSystem>
{
    private readonly IPlayerService _playerService;

    private readonly ITeamService _teamService;

    private readonly IGameService _gameService;

    private readonly IHeroServices _heroServices;

    private readonly IPatchService _patchService;

    public LoadDataToSystemCommandHandler(IPlayerService playerService, ITeamService teamService,
        IGameService gameService, IHeroServices heroServices, IPatchService patchService)
    {
        _playerService = playerService;
        _teamService = teamService;
        _gameService = gameService;
        _heroServices = heroServices;
        _patchService = patchService;
    }


    public async Task ExecuteAsync(LoadDataToSystem infoCommand)
    {
        await _playerService.LoadPlayersDataToSystem();
        await _teamService.LoadTeamsDataToSystem();
        // await _patchService.LoadPatchesToSystem();
        // await _heroServices.LoadHeroesToSystem();
        // await _gameService.LoadGamesToSystem(new DateOnly(2023, 4, 1));
    }
}