using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class Pokedexes : INamedModel
    {
        public Pokedexes()
        {
            PokedexProse = new HashSet<PokedexProse>();
            PokedexVersionGroups = new HashSet<PokedexVersionGroups>();
            PokemonDexNumbers = new HashSet<PokemonDexNumbers>();
        }

        public int Id { get; set; }
        public int? RegionId { get; set; }
        public string Identifier { get; set; }
        public bool IsMainSeries { get; set; }

        public virtual ICollection<PokedexProse> PokedexProse { get; set; }
        public virtual ICollection<PokedexVersionGroups> PokedexVersionGroups { get; set; }
        public virtual ICollection<PokemonDexNumbers> PokemonDexNumbers { get; set; }
        public virtual Regions Region { get; set; }
    }
}
