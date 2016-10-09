using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class GrowthRates : INamedModel
    {
        public GrowthRates()
        {
            Experience = new HashSet<Experience>();
            GrowthRateProse = new HashSet<GrowthRateProse>();
            PokemonSpecies = new HashSet<PokemonSpecies>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Formula { get; set; }

        public virtual ICollection<Experience> Experience { get; set; }
        public virtual ICollection<GrowthRateProse> GrowthRateProse { get; set; }
        public virtual ICollection<PokemonSpecies> PokemonSpecies { get; set; }
    }
}
