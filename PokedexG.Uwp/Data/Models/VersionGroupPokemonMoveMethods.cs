using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFVersionGroupPokemonMoveMethods : IEFModel
    {
        public int VersionGroupId { get; set; }
        public int PokemonMoveMethodId { get; set; }

        public virtual EFPokemonMoveMethods PokemonMoveMethod { get; set; }
        public virtual EFVersionGroups VersionGroup { get; set; }
    }
}
