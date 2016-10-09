namespace PokemonAPI.WebService.Models
{
    public partial class PokemonFormPokeathlonStats
    {
        public int PokemonFormId { get; set; }
        public int PokeathlonStatId { get; set; }
        public int MinimumStat { get; set; }
        public int BaseStat { get; set; }
        public int MaximumStat { get; set; }

        public virtual PokeathlonStats PokeathlonStat { get; set; }
        public virtual PokemonForms PokemonForm { get; set; }
    }
}
