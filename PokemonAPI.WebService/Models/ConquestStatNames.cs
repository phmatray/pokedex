namespace PokemonAPI.WebService.Models
{
    public partial class ConquestStatNames
    {
        public int ConquestStatId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual ConquestStats ConquestStat { get; set; }
        public virtual Languages LocalLanguage { get; set; }
    }
}
