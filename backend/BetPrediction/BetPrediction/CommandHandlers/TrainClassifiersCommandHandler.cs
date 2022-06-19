using BetPrediction.Commands;
using Common.Commands;
using Implementation.Data;
using Repositories.Models.Entities;
using Services;

namespace BetPrediction.CommandHandlers;

public class TrainClassifiersCommandHandler : ICommandHandler<TrainClassifiersCommand>
{
    private readonly DataBaseContext _context;
    private readonly IGameService _gameService;
    private readonly IHeroServices _heroServices;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IPlayerService _playerService;

    public TrainClassifiersCommandHandler(DataBaseContext context, IHttpContextAccessor httpContextAccessor,
        IHeroServices heroServices, IPlayerService playerService, IGameService gameService)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
        _heroServices = heroServices;
        _playerService = playerService;
        _gameService = gameService;
    }

    public async Task ExecuteAsync(TrainClassifiersCommand command)
    {
        var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
        var logEntity = new AdminLogEntity
        {
            ActionName = "Обучение классификаторов",
            EndPeriodDate = command.EndPeriodDate,
            StartPeriodDate = command.StartPeriodDate,
            StartDate = DateTime.Now.ToString(),
            UserName = userName
        };
        _context.AdminLogs.Add(logEntity);
        await _context.SaveChangesAsync();
        await _heroServices.GenerateDataForPickBansPredictionModelTraining(
            DateOnly.FromDateTime(command.StartPeriodDate), DateOnly.FromDateTime(command.EndPeriodDate), 0.3);
        await _playerService.GeneratePlayerDataSetForPeriod(DateOnly.FromDateTime(command.StartPeriodDate),
            DateOnly.FromDateTime(command.EndPeriodDate));
        await _playerService.GeneratePlayerIndicatorsDatasetForPeriod(DateOnly.FromDateTime(command.StartPeriodDate),
            DateOnly.FromDateTime(command.EndPeriodDate));
        await _playerService.GeneratePlayerAvgIndicatorsDatasetForPeriod(DateOnly.FromDateTime(command.StartPeriodDate),
            DateOnly.FromDateTime(command.EndPeriodDate));
        await _gameService.GenerateGamesDataSetForPeriod(DateOnly.FromDateTime(command.StartPeriodDate),
            DateOnly.FromDateTime(command.EndPeriodDate));
    }
}