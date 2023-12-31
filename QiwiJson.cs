using System.Text.Json;

namespace SteamCurrency
{
#pragma warning disable IDE1006, CS8618, CS8603, CS8600
    public class QiwiJsonResult
    {
        public string set { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public float rate { get; set; }
    }

    public class QiwiJson
    {
        public List<QiwiJsonResult> result { get; set; }

        public QiwiJson()
        {
            result = [];
        }

        public static QiwiJson GetData()
        {
            HttpResponseMessage response;
            try
            {
                response = SCHttpClient.Client.GetAsync("https://edge.qiwi.com/sinap/crossRates").Result;
            }
            catch
            {
                return new QiwiJson();
            }
            string text = response.Content.ReadAsStringAsync().Result;
            QiwiJson json = JsonSerializer.Deserialize<QiwiJson>(text);
            return json;
        }

        // 398 - тенге, 643 - рубли, 840 - доллары, 978 - евро, 156 - юани, 860 - сум
        public float GetRate((string, string) pair)
        {
            float rate = 0;
            foreach (var rateIter in result)
            {
                if (rateIter.from == pair.Item1 && rateIter.to == pair.Item2)
                {
                    rate = rateIter.rate;
                }
            }
            return rate;
        }
    }
#pragma warning restore IDE1006, CS8618, CS8603, CS8600
}
