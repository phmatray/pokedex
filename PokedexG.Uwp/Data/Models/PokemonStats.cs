using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFPokemonStats : IEFModel
    {
        public int PokemonId { get; set; }
        public int StatId { get; set; }
        public int BaseStat { get; set; }
        public int Effort { get; set; }

        public virtual EFPokemon Pokemon { get; set; }
        public virtual EFStats Stat { get; set; }
    }
}
