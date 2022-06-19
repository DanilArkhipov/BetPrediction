using BetPrediction.Commands;
using Common.Commands;
using Services;

namespace BetPrediction.CommandHandlers;

public class GeneratePickBansDataSetForPeriodCommandHandler : ICommandHandler<GeneratePickBansDataSetForPeriodCommand>
{
    private readonly IHeroServices _heroServices;

    public GeneratePickBansDataSetForPeriodCommandHandler(IHeroServices heroServices)
    {
        _heroServices = heroServices;
    }

    public async Task ExecuteAsync(GeneratePickBansDataSetForPeriodCommand command)
    {
        await _heroServices.GeneratePickBansDataSetForPeriod(command.StartPeriodDate, command.EndPeriodDate,
            "PickBansDataSet");
    }
}