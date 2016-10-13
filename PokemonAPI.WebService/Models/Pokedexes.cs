using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFPokedexes : IEFModel, IEFIdentifier
    {
        public EFPokedexes()
        {
            PokedexProse = new HashSet<EFPokedexProse>();
            PokedexVersionGroups = new HashSet<EFPokedexVersionGroups>();
            PokemonDexNumbers = new HashSet<EFPokemonDexNumbers>();
        }

        public int Id { get; set; }
        public int? RegionId { get; set; }
        public string Identifier { get; set; }
        public bool IsMainSeries { get; set; }

        public virtual ICollection<EFPokedexProse> PokedexProse { get; set; }
        public virtual ICollection<EFPokedexVersionGroups> PokedexVersionGroups { get; set; }
        public virtual ICollection<EFPokemonDexNumbers> PokemonDexNumbers { get; set; }
        public virtual EFRegions Region { get; set; }
    }
}
