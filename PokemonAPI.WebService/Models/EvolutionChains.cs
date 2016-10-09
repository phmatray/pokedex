using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EvolutionChains : IIdModel
    {
        public EvolutionChains()
        {
            PokemonSpecies = new HashSet<PokemonSpecies>();
        }

        public int Id { get; set; }
        public int? BabyTriggerItemId { get; set; }

        public virtual ICollection<PokemonSpecies> PokemonSpecies { get; set; }
        public virtual Items BabyTriggerItem { get; set; }
    }
}
