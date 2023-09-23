using System.Text.Json;

namespace SteamCurrency
{
#pragma warning disable IDE1006, CA1707, CS8600, CS8603
    public class WMJson
    {
        public double BankRate { get; set; }
        public string direction { get; set; }
        public int ratetype { get; set; }

        public WMJson()
        {
            BankRate = 0;
            direction = string.Empty;
            ratetype = 0;
        }

        // 118 означает из RUB в WMZ
        public static WMJson GetData(int type = 118)
        {
            HttpResponseMessage response;
            try
            {
                response = SCHttpClient.Client.GetAsync($"https://wmeng.exchanger.ru/asp/JSONWMList.asp?exchtype={type}").Result;
            }
            catch
            {
                return new WMJson();
            }
            string text = response.Content.ReadAsStringAsync().Result;
            WMJson json = JsonSerializer.Deserialize<WMJson>(text);
            return json;
        }

        public float GetRate()
        {
            float rate = (float)BankRate;
            return rate;
        }
    }
#pragma warning restore IDE1006, CA1707, CS8600, CS8603
}
