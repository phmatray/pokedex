using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class EvolutionTriggers
    {
        public EvolutionTriggers()
        {
            EvolutionTriggerProse = new HashSet<EvolutionTriggerProse>();
            PokemonEvolution = new HashSet<PokemonEvolution>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<EvolutionTriggerProse> EvolutionTriggerProse { get; set; }
        public virtual ICollection<PokemonEvolution> PokemonEvolution { get; set; }
    }
}
