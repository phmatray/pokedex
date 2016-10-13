using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFEggGroups : IEFModel, IEFIdentifier
    {
        public EFEggGroups()
        {
            EggGroupProse = new HashSet<EFEggGroupProse>();
            PokemonEggGroups = new HashSet<EFPokemonEggGroups>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<EFEggGroupProse> EggGroupProse { get; set; }
        public virtual ICollection<EFPokemonEggGroups> PokemonEggGroups { get; set; }
    }
}
