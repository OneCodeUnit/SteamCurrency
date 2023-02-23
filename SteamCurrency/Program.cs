using System.Globalization;

namespace SteamCurrency
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }

        internal static string ChangeEnding(string text)
        {
            string textAnalyze;
            if (text.Contains('.'))
            {
                text = text[0..text.IndexOf('.')];
            }

            if (text.Length > 2)
            {
                textAnalyze = text[^2..];
            }
            else if (text.Length == 0)
            {
                textAnalyze = "0";
            }
            else
            {
                textAnalyze = text;
            }

            int number = Convert.ToInt32(textAnalyze, CultureInfo.InvariantCulture);

            if (number is >= 10 and <= 20)
                return "рублей";
            if (number > 20)
                number %= 10;
            return (number) switch
            {
                1 => "рубль",
                >= 2 and <= 4 => "рубля",
                _ => "рублей"
            };
        }
    }
}