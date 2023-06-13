using System.Net.Http;

namespace SteamCurrencyLib
{
    internal sealed class SCHttpClient
    {
        internal static readonly HttpClient Client = new HttpClient();
        static SCHttpClient()
        {
            Client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:110.0) Gecko/20100101 Firefox/110.0");
        }
    }
}
