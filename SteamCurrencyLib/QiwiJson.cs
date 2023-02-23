using System.Collections.Generic;

namespace SteamCurrencyLib
{
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
            result = new List<QiwiJsonResult>();
        }
    }
}
