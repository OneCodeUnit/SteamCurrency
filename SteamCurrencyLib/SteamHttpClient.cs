using Newtonsoft.Json;
using System.Net.Http;

namespace SteamCurrencyLib
{
    public class SteamHttpClient
    {
        private static readonly HttpClient Client = new HttpClient();
        static SteamHttpClient()
        {
            Client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:110.0) Gecko/20100101 Firefox/110.0");
        }

        public static SteamJson GetSteamJson(int CurrencyCode, string item = "M4A1-S | Hyper Beast (Factory New)", int gameId = 730)
        {
            HttpResponseMessage response = Client.GetAsync($"https://steamcommunity.com/market/priceoverview/?country=RU&currency={CurrencyCode}&appid={gameId}&market_hash_name={item}").Result;
            string text = response.Content.ReadAsStringAsync().Result;
            SteamJson json = JsonConvert.DeserializeObject<SteamJson>(text);
            return json;
        }

        public static QiwiJsonRoot GetQiwiJson()
        {
            HttpResponseMessage response = Client.GetAsync("https://edge.qiwi.com/sinap/crossRates").Result;
            string text = response.Content.ReadAsStringAsync().Result;
            QiwiJsonRoot json = JsonConvert.DeserializeObject<QiwiJsonRoot>(text);
            return json;
        }
    }
}
