using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFPokemonItems : IEFModel
    {
        public int PokemonId { get; set; }
        public int VersionId { get; set; }
        public int ItemId { get; set; }
        public int Rarity { get; set; }

        public virtual EFItems Item { get; set; }
        public virtual EFPokemon Pokemon { get; set; }
        public virtual EFVersions Version { get; set; }
    }
}
