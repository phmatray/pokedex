namespace PokemonAPI.WebService.Models
{
    public partial class ConquestPokemonStats
    {
        public int PokemonSpeciesId { get; set; }
        public int ConquestStatId { get; set; }
        public int BaseStat { get; set; }

        public virtual ConquestStats ConquestStat { get; set; }
        public virtual PokemonSpecies PokemonSpecies { get; set; }
    }
}
