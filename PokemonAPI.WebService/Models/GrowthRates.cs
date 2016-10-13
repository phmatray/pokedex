using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFGrowthRates : IEFModel, IEFIdentifier
    {
        public EFGrowthRates()
        {
            Experience = new HashSet<EFExperience>();
            GrowthRateProse = new HashSet<EFGrowthRateProse>();
            PokemonSpecies = new HashSet<EFPokemonSpecies>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Formula { get; set; }

        public virtual ICollection<EFExperience> Experience { get; set; }
        public virtual ICollection<EFGrowthRateProse> GrowthRateProse { get; set; }
        public virtual ICollection<EFPokemonSpecies> PokemonSpecies { get; set; }
    }
}
