using Newtonsoft.Json;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SteamCurrencyLib
{
#pragma warning disable CS8603, CS8600
    public class SteamHttpClient
    {
        private static readonly HttpClient Client = new();
        static SteamHttpClient()
        {
            Client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:110.0) Gecko/20100101 Firefox/110.0");
        }

        public static SteamJson GetSteamJson(int CurrencyCode, string item = "M4A1-S | Hyper Beast (Factory New)", int gameId = 730)
        {
            HttpResponseMessage response;
            try
            {
                response = Client.GetAsync($"https://steamcommunity.com/market/priceoverview/?country=RU&currency={CurrencyCode}&appid={gameId}&market_hash_name={item}").Result;
            }
            catch
            {
                return new SteamJson();
            }
            string text = response.Content.ReadAsStringAsync().Result;
            SteamJson json = JsonConvert.DeserializeObject<SteamJson>(text);
            return json;
        }

        public static QiwiJson GetQiwiJson()
        {
            HttpResponseMessage response;
            try
            {
                response = Client.GetAsync("https://edge.qiwi.com/sinap/crossRates").Result;
            }
            catch
            {
                return new QiwiJson();
            }
            string text = response.Content.ReadAsStringAsync().Result;
            QiwiJson json = JsonConvert.DeserializeObject<QiwiJson>(text);
            return json;
        }

        public static float GetWebMoneyRate()
        {
            HttpResponseMessage response;
            try
            {
                response = Client.GetAsync("https://exchanger.web.money/asp/wmlist.asp?exchtype=118").Result;
            }
            catch
            {
                return -1;
            }
            string text = response.Content.ReadAsStringAsync().Result;
            Regex regex = new (@"<span>([\d,]+)", RegexOptions.Compiled);
            string match = regex.Match(text).Groups[1].ToString();
            match = match.Replace(',', '.');
            float rate = Convert.ToSingle(match, CultureInfo.InvariantCulture);
            return rate;
        }
    }
#pragma warning restore CS8603, CS8600
}
