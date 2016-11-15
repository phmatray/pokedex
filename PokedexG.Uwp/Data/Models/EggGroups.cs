using System.Collections.Generic;
using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public sealed class EFEggGroups : IEFIdentifier
    {
        public EFEggGroups()
        {
            EggGroupProse = new HashSet<EFEggGroupProse>();
            PokemonEggGroups = new HashSet<EFPokemonEggGroups>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public ICollection<EFEggGroupProse> EggGroupProse { get; set; }
        public ICollection<EFPokemonEggGroups> PokemonEggGroups { get; set; }
    }
}
