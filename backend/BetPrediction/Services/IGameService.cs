namespace Services;

public interface IGameService
{
    Task LoadGamesToSystem(DateOnly dateStart);

    Task<string> GenerateGamesDataSetForPeriod(DateOnly startDate, DateOnly endDate);
}