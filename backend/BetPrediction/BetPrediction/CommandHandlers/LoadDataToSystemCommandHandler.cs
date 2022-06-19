using BetPrediction.Commands;
using Common.Commands;
using Implementation.Data;
using Repositories.Models.Entities;
using Services;

namespace BetPrediction.CommandHandlers;

public class LoadDataToSystemCommandHandler : ICommandHandler<LoadDataToSystemCommand>
{
    private readonly DataBaseContext _context;
    private readonly IGameService _gameService;

    private readonly IHeroServices _heroServices;
    private readonly IHttpContextAccessor _httpContextAccessor;

    private readonly IPatchService _patchService;
    private readonly IPlayerService _playerService;

    private readonly ITeamService _teamService;

    public LoadDataToSystemCommandHandler(IPlayerService playerService, ITeamService teamService,
        IGameService gameService, IHeroServices heroServices, IPatchService patchService, DataBaseContext context,
        IHttpContextAccessor httpContextAccessor)
    {
        _playerService = playerService;
        _teamService = teamService;
        _gameService = gameService;
        _heroServices = heroServices;
        _patchService = patchService;
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }


    public async Task ExecuteAsync(LoadDataToSystemCommand infoCommand)
    {
        var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
        var logEntity = new AdminLogEntity
        {
            ActionName = "Загрузка данных",
            EndPeriodDate = infoCommand.EndPeriodDate,
            StartPeriodDate = infoCommand.StartPeriodDate,
            StartDate = DateTime.Now.ToString(),
            UserName = userName
        };
        _context.AdminLogs.Add(logEntity);
        await _context.SaveChangesAsync();
        //await _playerService.LoadPlayersDataToSystem();
        // // await _teamService.LoadTeamsDataToSystem();
        //  await _patchService.LoadPatchesToSystem();
        //  await _heroServices.LoadHeroesToSystem();
        //await _gameService.LoadGamesToSystem(infoCommand.StartPeriodDate);
    }
}