using Predictions.Library.NetStandard;
using Predictions.TestConsole.Predictors;
using System;
using System.Threading.Tasks;

namespace Predictions.TestConsole.UI
{
    internal static class PredictorLoadingScreen
    {
        public static async Task ShowAsync(ImplementationDetail detail, IStringPredictor predictor)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Loading predictor: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{detail.DisplayName}\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{detail.Description}\n\nPlease wait...\n");
            await predictor.InitAsync();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Pres any key to continue");
            _ = Console.ReadKey();
        }

    }
}
