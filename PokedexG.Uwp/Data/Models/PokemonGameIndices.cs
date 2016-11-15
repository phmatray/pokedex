using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFPokemonGameIndices : IEFModel
    {
        public int PokemonId { get; set; }
        public int VersionId { get; set; }
        public int GameIndex { get; set; }

        public virtual EFPokemon Pokemon { get; set; }
        public virtual EFVersions Version { get; set; }
    }
}
