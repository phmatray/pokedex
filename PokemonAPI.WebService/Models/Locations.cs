using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFLocations : IEFModel, IEFIdentifier
    {
        public EFLocations()
        {
            LocationAreas = new HashSet<EFLocationAreas>();
            LocationGameIndices = new HashSet<EFLocationGameIndices>();
            LocationNames = new HashSet<EFLocationNames>();
            PokemonEvolution = new HashSet<EFPokemonEvolution>();
        }

        public int Id { get; set; }
        public int? RegionId { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<EFLocationAreas> LocationAreas { get; set; }
        public virtual ICollection<EFLocationGameIndices> LocationGameIndices { get; set; }
        public virtual ICollection<EFLocationNames> LocationNames { get; set; }
        public virtual ICollection<EFPokemonEvolution> PokemonEvolution { get; set; }
        public virtual EFRegions Region { get; set; }
    }
}
