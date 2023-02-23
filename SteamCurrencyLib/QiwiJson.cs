using System.Collections.Generic;

namespace SteamCurrencyLib
{
    public class QiwiJsonResult
    {
        public string set { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public double rate { get; set; }
    }

    public class QiwiJsonRoot
    {
        public List<QiwiJsonResult> result { get; set; }
    }
}
