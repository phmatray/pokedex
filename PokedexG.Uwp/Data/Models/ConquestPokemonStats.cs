using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFConquestPokemonStats : IEFModel
    {
        public int PokemonSpeciesId { get; set; }
        public int ConquestStatId { get; set; }
        public int BaseStat { get; set; }

        public virtual EFConquestStats ConquestStat { get; set; }
        public virtual EFPokemonSpecies PokemonSpecies { get; set; }
    }
}
