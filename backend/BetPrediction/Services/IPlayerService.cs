namespace Services;

public interface IPlayerService
{
    Task LoadPlayersDataToSystem();

    Task<string> GeneratePlayerDataSetForPeriod(DateOnly startDate, DateOnly endDate);
    
    Task<string> GeneratePlayerIndicatorsDatasetForPeriod(DateOnly startDate, DateOnly endDate);
    
    Task<string> GeneratePlayerAvgIndicatorsDatasetForPeriod(DateOnly startDate, DateOnly endDate);
}