namespace PokemonAPI.WebService.Models
{
    public partial class PokeathlonStatNames
    {
        public int PokeathlonStatId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual Languages LocalLanguage { get; set; }
        public virtual PokeathlonStats PokeathlonStat { get; set; }
    }
}
