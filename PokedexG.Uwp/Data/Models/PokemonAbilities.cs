using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFPokemonAbilities : IEFModel
    {
        public int PokemonId { get; set; }
        public int AbilityId { get; set; }
        public bool IsHidden { get; set; }
        public int Slot { get; set; }

        public virtual EFAbilities Ability { get; set; }
        public virtual EFPokemon Pokemon { get; set; }
    }
}
