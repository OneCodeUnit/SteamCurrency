using System.Globalization;
using System.Text.Json;

namespace SteamCurrency
{
#pragma warning disable IDE1006, CA1707, CS8600, CS8603, CS8604
    public class SteamJson
    {
        public bool success { get; set; }
        public string lowest_price { get; set; }
        public string volume { get; set; }
        public string median_price { get; set; }

        public SteamJson()
        {
            success = false;
            lowest_price = string.Empty;
            volume = string.Empty;
            median_price = string.Empty;
        }

        // 1 - доллары, 5 - рубли, 37 - тенге (https://partner.steamgames.com/doc/store/pricing/currencies)
        public static SteamJson GetData(int CurrencyCode, string item = "M4A1-S | Hyper Beast (Factory New)", int gameId = 730)
        {
            HttpResponseMessage response;
            try
            {
                response = SCHttpClient.Client.GetAsync($"https://steamcommunity.com/market/priceoverview/?country=RU&currency={CurrencyCode}&appid={gameId}&market_hash_name={item}").Result;
            }
            catch
            {
                return new SteamJson();
            }
            string text = response.Content.ReadAsStringAsync().Result;
            SteamJson json = JsonSerializer.Deserialize<SteamJson>(text);
            return json;
        }

        public static float GetRate(int from = 1, int to = 5)
        {
            float rate;
            SteamJson jsonUSD = GetData(from);
            SteamJson jsonRUB = GetData(to);

            if (jsonUSD?.success == false || jsonRUB?.success == false)
            {
                rate = 0;
            }
            else
            {
                rate = TrimData(jsonRUB, to) / TrimData(jsonUSD, from);
                if (rate == 1)
                    rate = 0;
            }
            return rate;
        }

        private static float TrimData(SteamJson rawText, int id)
        {
            string text;
            float rate;
            switch (id)
            {
                case 1:
                    text = rawText.lowest_price[1..^3];
                    rate = Convert.ToSingle(text, new CultureInfo("en-US"));
                    break;
                case 5:
                    text = rawText.lowest_price[..^5];
                    rate = Convert.ToSingle(text, new CultureInfo("ru-RU"));
                    break;
                case 37:
                    text = rawText.lowest_price[..^1];
                    text = text.Replace(" ", "");
                    rate = Convert.ToSingle(text, new CultureInfo("ru-RU"));
                    break;
                default:
                    text = rawText.lowest_price;
                    try
                    {
                        rate = Convert.ToSingle(text, CultureInfo.InvariantCulture);
                    }
                    catch
                    {
                        rate = 1;
                    }
                    break;
            }
            return rate;
        }
    }
#pragma warning restore IDE1006, CA1707, CS8600, CS8603, CS8604
}
