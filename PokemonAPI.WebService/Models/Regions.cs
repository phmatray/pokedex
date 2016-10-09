using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class Regions : INamedModel
    {
        public Regions()
        {
            Generations = new HashSet<Generations>();
            Locations = new HashSet<Locations>();
            Pokedexes = new HashSet<Pokedexes>();
            RegionNames = new HashSet<RegionNames>();
            VersionGroupRegions = new HashSet<VersionGroupRegions>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<Generations> Generations { get; set; }
        public virtual ICollection<Locations> Locations { get; set; }
        public virtual ICollection<Pokedexes> Pokedexes { get; set; }
        public virtual ICollection<RegionNames> RegionNames { get; set; }
        public virtual ICollection<VersionGroupRegions> VersionGroupRegions { get; set; }
    }
}
