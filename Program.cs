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

        // Анализ последних цифр числа
        internal static string ChangeEnding(string text)
        {
            if (text == "NaN")
                text = "0";
            // Убираем точку и запятую для анализа
            string textAnalyze;
            if (text.Contains(','))
            {
                text = text.Replace(',', '.');
            }
            if (text.Contains(' '))
            {
                text = text.Replace(" ", string.Empty);
            }
            if (text.Contains('.'))
            {
                text = text[0..text.IndexOf('.')];
            }
            if (text.Contains('-'))
            {
                text = text.Replace("-", string.Empty);
            }
            if (text.Contains('+'))
            {
                text = text.Replace("-", string.Empty);
            }

            // Если число длинне двух символов, то обрезаем
            textAnalyze = text.Length switch
            {
                > 2 => text[^2..],
                0 => "0",
                _ => text
            };
            int number;
            try
            {
                number = Convert.ToInt32(textAnalyze, CultureInfo.InvariantCulture);
            }
            catch
            {
                number = 0;
            }

            // Выбор надписи в зависимости от числа
            if (number is >= 5 and <= 20)
                return "рублей";
            return (number % 10) switch
            {
                1 => "рубль",
                >= 2 and <= 4 => "рубля",
                _ => "рублей"
            };
        }
    }
}