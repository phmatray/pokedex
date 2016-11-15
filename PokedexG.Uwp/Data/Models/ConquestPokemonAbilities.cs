using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFConquestPokemonAbilities : IEFModel
    {
        public int PokemonSpeciesId { get; set; }
        public int Slot { get; set; }
        public int AbilityId { get; set; }

        public virtual EFAbilities Ability { get; set; }
        public virtual EFPokemonSpecies PokemonSpecies { get; set; }
    }
}
