using System.Collections.Generic;
using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public sealed class EFEvolutionChains : IEFId
    {
        public EFEvolutionChains()
        {
            PokemonSpecies = new HashSet<EFPokemonSpecies>();
        }

        public int Id { get; set; }
        public int? BabyTriggerItemId { get; set; }

        public ICollection<EFPokemonSpecies> PokemonSpecies { get; set; }
        public EFItems BabyTriggerItem { get; set; }
    }
}
