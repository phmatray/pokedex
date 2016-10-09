namespace PokemonAPI.WebService.Models
{
    public partial class ConquestEpisodeNames
    {
        public int EpisodeId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual ConquestEpisodes Episode { get; set; }
        public virtual Languages LocalLanguage { get; set; }
    }
}
