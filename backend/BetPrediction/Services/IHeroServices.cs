namespace Services;

public interface IHeroServices
{
    Task LoadHeroesToSystem();

    Task<string> GenerateHeroMatrixForPeriod(DateOnly startPeriodDate, DateOnly endPeriodDate);

    Task<string> GeneratePickBansDataSetForPeriod(DateOnly startPeriodDate, DateOnly endPeriodDate, string dataSetName);

    Task GenerateDataForPickBansPredictionModelTraining(DateOnly startPeriodDate, DateOnly endPeriodDate,
        double testSize);
}