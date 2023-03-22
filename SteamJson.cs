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
    }
#pragma warning restore IDE1006, CA1707
}