namespace PokemonAPI
{
    public class TestingConfig : IDataFetcherConfig
    {
        public string SiteUrl { get; } = "http://localhost:50357";
        public string BaseUrl { get; } = "/api/v1/";
    }
}