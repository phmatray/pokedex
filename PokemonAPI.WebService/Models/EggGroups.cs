using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EggGroups : INamedModel
    {
        public EggGroups()
        {
            EggGroupProse = new HashSet<EggGroupProse>();
            PokemonEggGroups = new HashSet<PokemonEggGroups>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<EggGroupProse> EggGroupProse { get; set; }
        public virtual ICollection<PokemonEggGroups> PokemonEggGroups { get; set; }
    }
}
