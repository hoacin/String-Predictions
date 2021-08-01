using Predictions.TestConsole.Predictors;
using System;

namespace Predictions.TestConsole.UI
{
    internal static class AskForImplementation
    {
        public static ImplementationDetail Ask()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            Console.WriteLine("Predictions run on dictionary with 9 milions of double words.");
            Console.WriteLine("Similarity is calculated by simple letter pairing logic.");
            Console.WriteLine("This work is introduction to parallel computing in C#.\n");
            Console.WriteLine("Hardware used in video\n");
            Console.WriteLine("CPU: Intel Core i7-3930K");
            Console.WriteLine("GPU: GeForce RTX 2080 Ti\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Select predictor\n");
            Console.ForegroundColor = ConsoleColor.White;

            ImplementationDetail[] predictors = ListImplementations.GetAll();
            foreach (ImplementationDetail predictor in predictors)
                Console.WriteLine($"{predictor.DisplayName.PadRight(20, '.')} ({predictor.Key})");
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                foreach (ImplementationDetail predictor in predictors)
                    if (predictor.Key == key.KeyChar)
                        return predictor;
            }
        }
    }
}
