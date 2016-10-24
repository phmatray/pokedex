namespace PokemonAPI
{
    public class CustomConfig : IDataFetcherConfig
    {
        public string SiteUrl { get; }
        public string BaseUrl { get; }

        public CustomConfig(string siteUrl, string baseUrl)
        {
            SiteUrl = siteUrl;
            BaseUrl = baseUrl;
        }
    }
}