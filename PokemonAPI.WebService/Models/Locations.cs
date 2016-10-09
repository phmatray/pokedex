using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class Locations : INamedModel
    {
        public Locations()
        {
            LocationAreas = new HashSet<LocationAreas>();
            LocationGameIndices = new HashSet<LocationGameIndices>();
            LocationNames = new HashSet<LocationNames>();
            PokemonEvolution = new HashSet<PokemonEvolution>();
        }

        public int Id { get; set; }
        public int? RegionId { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<LocationAreas> LocationAreas { get; set; }
        public virtual ICollection<LocationGameIndices> LocationGameIndices { get; set; }
        public virtual ICollection<LocationNames> LocationNames { get; set; }
        public virtual ICollection<PokemonEvolution> PokemonEvolution { get; set; }
        public virtual Regions Region { get; set; }
    }
}
