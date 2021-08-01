using Predictions.Library.NetStandard;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Predictions.TestConsole.UI
{
    internal static class AskForSearchPhrase
    {
        public static async Task<bool> RunAsync(IStringPredictor predictor)
        {
            Console.Clear();
            Stopwatch stopwatch = new();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Type word you want to search: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string searchedWord = Console.ReadLine();
            if (searchedWord == "exit")
                return false;
            stopwatch.Start();
            string bestMatch = await predictor.PredictAsync(searchedWord);
            stopwatch.Stop();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nBest match: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(bestMatch);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nSearch ms: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(stopwatch.ElapsedMilliseconds);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\nPres any key to continue...");
            _ = Console.ReadKey();

            return true;
        }
    }
}
