using BetPrediction.Commands;
using Common.Commands;
using Services;

namespace BetPrediction.CommandHandlers;

public class GenerateHeroMatrixCommandHandler: ICommandHandler<GenerateHeroMatrixForPeriodCommand>
{
    private readonly IHeroServices _heroServices;

    public GenerateHeroMatrixCommandHandler(IHeroServices heroServices)
    {
        _heroServices = heroServices;
    }

    public async Task ExecuteAsync(GenerateHeroMatrixForPeriodCommand command)
    {
        await _heroServices.GenerateHeroMatrixForPeriod(command.StartPeriodDate, command.EndPeriodDate);
    }
}