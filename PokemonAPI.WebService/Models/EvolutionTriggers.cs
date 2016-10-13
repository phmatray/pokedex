using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFEvolutionTriggers : IEFModel, IEFIdentifier
    {
        public EFEvolutionTriggers()
        {
            EvolutionTriggerProse = new HashSet<EFEvolutionTriggerProse>();
            PokemonEvolution = new HashSet<EFPokemonEvolution>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<EFEvolutionTriggerProse> EvolutionTriggerProse { get; set; }
        public virtual ICollection<EFPokemonEvolution> PokemonEvolution { get; set; }
    }
}
