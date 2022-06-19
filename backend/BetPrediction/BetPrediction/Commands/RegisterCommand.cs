using Common.Commands;

namespace BetPrediction.Commands;

public class RegisterCommand : ICommand
{
    public string Name { get; set; }

    public string Password { get; set; }
}