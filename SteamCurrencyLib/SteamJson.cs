using Newtonsoft.Json;
using System.Globalization;
using System;
using System.Net.Http;

namespace SteamCurrencyLib
{
#pragma warning disable IDE1006, CA1707
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

        // 1 - доллары, 5 - рубли (https://partner.steamgames.com/doc/store/pricing/currencies)
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
            SteamJson json = JsonConvert.DeserializeObject<SteamJson>(text);
            return json;
        }

        public float GetRate()
        {
            float rate;
            SteamJson jsonUSD = GetData(1);
            SteamJson jsonRUB = GetData(5);

            string rawUSD = jsonUSD.lowest_price.Substring(1, jsonUSD.lowest_price.Length - 4);
            string rawRUB = jsonRUB.lowest_price.Substring(0, jsonRUB.lowest_price.Length - 5);

            if (jsonUSD.success == false || jsonRUB.success == false)
            {
                rate = 0;
            }
            else
            {
                float steamUSD = Convert.ToSingle(rawUSD, new CultureInfo("en-US"));
                float steamRUB = Convert.ToSingle(rawRUB, new CultureInfo("ru-RU"));
                rate = steamRUB / steamUSD;
            }
            return rate;
        }
    }
#pragma warning restore IDE1006, CA1707
}
