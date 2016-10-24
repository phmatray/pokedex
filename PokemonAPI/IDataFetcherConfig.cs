namespace PokemonAPI
{
    public interface IDataFetcherConfig
    {
        string SiteUrl { get; }
        string BaseUrl { get; }
    }
}