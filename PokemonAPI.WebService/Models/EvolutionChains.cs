using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFEvolutionChains : IEFModel, IEFId
    {
        public EFEvolutionChains()
        {
            PokemonSpecies = new HashSet<EFPokemonSpecies>();
        }

        public int Id { get; set; }
        public int? BabyTriggerItemId { get; set; }

        public virtual ICollection<EFPokemonSpecies> PokemonSpecies { get; set; }
        public virtual EFItems BabyTriggerItem { get; set; }
    }
}
