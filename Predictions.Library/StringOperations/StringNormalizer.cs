using System.Text;

namespace Predictions.Library.NetStandard.StringOperations
{
    internal static class StringNormalizer
    {
        public static string NormalizeForPredictions(this string text)
        {
            //This method makes simple lowercase strings 'a-z' '0-9' with no diacritics like "   Štěpán Žilka &@{}123 " -> "stepanzilka123"

            string normalizedString = text.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
                if (c >= 'a' && c <= 'z' || c >= '0' && c <= '9')
                    _ = stringBuilder.Append(c);
            return stringBuilder.ToString();
        }
    }
}
