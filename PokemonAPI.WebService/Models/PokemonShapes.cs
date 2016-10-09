using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class PokemonShapes : INamedModel
    {
        public PokemonShapes()
        {
            PokemonShapeProse = new HashSet<PokemonShapeProse>();
            PokemonSpecies = new HashSet<PokemonSpecies>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<PokemonShapeProse> PokemonShapeProse { get; set; }
        public virtual ICollection<PokemonSpecies> PokemonSpecies { get; set; }
    }
}
