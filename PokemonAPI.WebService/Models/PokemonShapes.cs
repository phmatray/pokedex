using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFPokemonShapes : IEFModel, IEFIdentifier
    {
        public EFPokemonShapes()
        {
            PokemonShapeProse = new HashSet<EFPokemonShapeProse>();
            PokemonSpecies = new HashSet<EFPokemonSpecies>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<EFPokemonShapeProse> PokemonShapeProse { get; set; }
        public virtual ICollection<EFPokemonSpecies> PokemonSpecies { get; set; }
    }
}
