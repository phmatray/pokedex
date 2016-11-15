using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFPokemonTypes : IEFModel
    {
        public int PokemonId { get; set; }
        public int TypeId { get; set; }
        public int Slot { get; set; }

        public virtual EFPokemon Pokemon { get; set; }
        public virtual EFTypes Type { get; set; }
    }
}
