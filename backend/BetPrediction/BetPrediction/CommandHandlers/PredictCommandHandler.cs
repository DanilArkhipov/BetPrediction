using System.Diagnostics;
using BetPrediction.Commands;
using Common.Commands;

namespace BetPrediction.CommandHandlers;

public class PredictCommandHandler : ICommandHandler<PredictCommand, Tuple<int, int>>
{
    public async Task<Tuple<int, int>> ExecuteAsync(PredictCommand command)
    {
        var start = new ProcessStartInfo();
        start.FileName = "C:\\Python310/python.exe";
        start.Arguments = string.Format("{0}",
            @"C:\Repository\BetPrediction\backend\BetPrediction\BetPrediction\predict.py");
        start.UseShellExecute = false;
        start.RedirectStandardOutput = true;
        using (var process = Process.Start(start))
        {
            using (var reader = process.StandardOutput)
            {
                var result = await reader.ReadToEndAsync();
                Console.WriteLine(result);
                return new Tuple<int, int>(0, 1);
            }
        }
    }
}