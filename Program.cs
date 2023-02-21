using System.Globalization;

namespace SteamCurrency
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }

        internal static string[] GetCurrencySteam()
        {
            HttpClient client = new();
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:110.0) Gecko/20100101 Firefox/110.0");

            //37 - тенге
            //5 - рубли
            //1 - доллары
            string jsonUSD = GetJson(client, 1);
            string jsonRUB = GetJson(client, 5);
            char[] separators = { ',', ':' };

            string[] tempUSD = jsonUSD.Split(separators, StringSplitOptions.TrimEntries);
            string USD = tempUSD[3].Substring(2, tempUSD[3].Length - 7);

            string[] tempRUB = jsonRUB.Split(separators, StringSplitOptions.TrimEntries);
            string RUB = string.Concat(tempRUB[3].AsSpan(1), ".", tempRUB[4].AsSpan(0, tempRUB[4].Length - 6));

            string[] result = { USD, RUB };
            return result;
        }

        private static string GetJson(HttpClient client, int CurrencyCode)
        {
            HttpResponseMessage response = client.GetAsync("https://steamcommunity.com/market/priceoverview/?country=RU&currency=" + CurrencyCode + "&appid=730&market_hash_name=M4A1-S | Hyper Beast (Factory New)").Result;

            if (response.IsSuccessStatusCode == false)
            {
                return "0";
            }
            string json = response.Content.ReadAsStringAsync().Result;
            return json;
        }

        internal static double CalculateCurrency(string[] RawCurrency)
        {
            string tempUSD = RawCurrency[0];
            string tempRUB = RawCurrency[1];

            CultureInfo culture = CultureInfo.InvariantCulture;

            double USD = Convert.ToDouble(tempUSD, culture);
            double RUB = Convert.ToDouble(tempRUB, culture);

            double result = 0;
            if (RUB != 0 && USD != 0)
            {
                double USDRate = RUB / USD;
                result = USDRate;
            }

            return result;
        }

        internal static double[] GetCurrencyQiwi()
        {
            HttpClient client = new();
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:110.0) Gecko/20100101 Firefox/110.0");

            string jsonQiwi = GetJsonQiwi(client);

            char[] separators = { ',', ':' };
            string[] tempKZT = jsonQiwi.Split(separators, StringSplitOptions.TrimEntries);

            string result = "0";
            StringComparison comparison = StringComparison.OrdinalIgnoreCase;
            //398 - тенге
            //643 - рубли
            //840 - доллары
            //978 - евро
            //156 - юани
            for (int i = 0; i < tempKZT.Length; i++)
            {
                if (tempKZT[i].Equals("\"from\"", comparison) && tempKZT[i + 1].Equals("\"643\"", comparison))
                {
                    if (tempKZT[i + 2].Equals("\"to\"", comparison) && tempKZT[i + 3].Equals("\"398\"", comparison))
                    {
                        result = tempKZT[i + 5].Substring(0, tempKZT[i + 5].Length - 1);
                        break;
                    }
                }
            }
            CultureInfo culture = CultureInfo.InvariantCulture;
            double[] rates = { 0, 0 };
            rates[0] = Convert.ToDouble(result, culture);
            result = "0";
            for (int i = 0; i < tempKZT.Length; i++)
            {
                if (tempKZT[i].Equals("\"from\"", comparison) && tempKZT[i + 1].Equals("\"398\"", comparison))
                {
                    if (tempKZT[i + 2].Equals("\"to\"", comparison) && tempKZT[i + 3].Equals("\"840\"", comparison))
                    {
                        result = tempKZT[i + 5].Substring(0, tempKZT[i + 5].Length - 1);
                        break;
                    }
                }
            }
            rates[1] = Convert.ToDouble(result, culture);
            return rates;
        }

        private static string GetJsonQiwi(HttpClient client)
        {
            HttpResponseMessage response = client.GetAsync("https://edge.qiwi.com/sinap/crossRates").Result;

            if (response.IsSuccessStatusCode == false)
            {
                return "0";
            }
            string json = response.Content.ReadAsStringAsync().Result;
            return json;
        }

        internal static double CalculateFunds(double RUB, double KZT_Qiwi, double USD_Qiwi, double USD)
        {
            //RUB - введённая сумма
            //KZT_Qiwi - рублей за тенге (Qiwi)
            //KZT_Steam - тенге за доллар (Steam)
            //USD - рублей за доллар (Steam)
            //Полный путь: Рубли -> Тенге -> Доллары -> Рубли
            double funds = RUB / KZT_Qiwi; //Рубли -> Тенге
            funds = funds / (USD_Qiwi + 0.0415 * USD_Qiwi); //Тенге -> Доллары (на этом этапе киви каким-то образом подворовывает)
            funds = funds * USD; //Доллары -> Рубли
            return funds;
        }

        internal static string ChangeEnd(string text)
        {
            string textAnalyze;
            if (text.Contains('.'))
            {
                text = text.Substring(0, text.IndexOf('.'));
            }

            if (text.Length > 2)
            {
                textAnalyze = text.Substring(text.Length - 2);
            }
            else if (text.Length == 0)
            {
                textAnalyze = "0";
            }
            else
            {
                textAnalyze = text;
            }

            CultureInfo culture = CultureInfo.InvariantCulture;
            int number = Convert.ToInt32(textAnalyze, culture);

            if (number >= 5 && number <= 20)
            {
                return "рублей";
            }
            if (number > 10)
            {
                number = number % 10;
            }
            if (number == 1)
            {
                return "рубль";
            }
            if (number == 0)
            {
                return "рублей";
            }
            if (number >= 2 && number <= 4)
            {
                return "рубля";
            }
            return "рублей";
        }
    }
}