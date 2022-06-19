using Common.Commands;

namespace BetPrediction.Commands;

public class PredictCommand : ICommand
{
    public List<string> RadiantPlayers { get; set; }

    public List<string> RadiantHeroes { get; set; }

    public List<string> DirePlayers { get; set; }

    public List<string> DireHeroes { get; set; }
}