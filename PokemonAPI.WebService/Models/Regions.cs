using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFRegions : IEFModel, IEFIdentifier
    {
        public EFRegions()
        {
            Generations = new HashSet<EFGenerations>();
            Locations = new HashSet<EFLocations>();
            Pokedexes = new HashSet<EFPokedexes>();
            RegionNames = new HashSet<EFRegionNames>();
            VersionGroupRegions = new HashSet<EFVersionGroupRegions>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<EFGenerations> Generations { get; set; }
        public virtual ICollection<EFLocations> Locations { get; set; }
        public virtual ICollection<EFPokedexes> Pokedexes { get; set; }
        public virtual ICollection<EFRegionNames> RegionNames { get; set; }
        public virtual ICollection<EFVersionGroupRegions> VersionGroupRegions { get; set; }
    }
}
