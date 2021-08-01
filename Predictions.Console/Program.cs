using Predictions.Library.NetStandard;
using Predictions.Library.NetStandard.SampleData;
using Predictions.TestConsole.Predictors;
using Predictions.TestConsole.UI;
using System.Threading.Tasks;

namespace Predictions.TestConsole
{
    internal static class Program
    {
        static async Task Main(string[] _0)
        {
            string[] dictionary = Dictionary3K.GetSampleData9M();
            while (true)
            {
                ImplementationDetail selectedPredictor = AskForImplementation.Ask();
                using (IStringPredictor predictor = PredictorFactory.Instantiate(dictionary, selectedPredictor.Implementation))
                {
                    await PredictorLoadingScreen.ShowAsync(selectedPredictor, predictor);
                    while (true)
                        if (!await AskForSearchPhrase.RunAsync(predictor))
                            break;
                }
            }

        }
    }
}
